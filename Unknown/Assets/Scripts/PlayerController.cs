using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public GameObject cam;
	public float movementSpeed = 5f;
	public float turningSpeed = 60f;


	//#####################################################################
	//##################### HUMANOID BODY PARTS ###########################
	//#####################################################################

	[SerializeField] private GameObject head;
	[SerializeField] private GameObject torso;

	//Left arm object and variables belonging to this object
	[SerializeField] private GameObject leftArm;
	float leftArmSwingAngle;
	bool leftArmSwingForward = true;

	//Left leg object and variables belonging to this object
	[SerializeField] private GameObject leftLeg;
	float leftLegSwingAngle;
	bool leftLegSwingForward = false;

	//Right arm object and variabled belonging to this object
	[SerializeField] private GameObject rightArm;
	float rightArmSwingAngle;
	bool rightArmSwingForward = false;

	//Right leg object and variables belonging to this object
	[SerializeField] private GameObject rightLeg;
	float rightLegSwingAngle;
	bool rightSwingForward = true;


	//#####################################################################

	//Keeps a track of whether the humanoid is moving or not
	bool isMoving;

	//Flag for resseting body parts
	bool reset = false;

	Vector3 armSwingPointOffset;
	Vector3 legSwingPointOffset;

	const int LegSwing = 20;
	const int Multiplier = 120;

	void Start()
	{
		armSwingPointOffset = new Vector3 (0f, 0.4f, 0f);
		legSwingPointOffset = new Vector3 (0f, -0.5f, 0f);
	}
	// Update is called once per frame
	void Update () {
		float horizontal = Input.GetAxisRaw ("Horizontal") * movementSpeed * Time.deltaTime;
		float vertical = Input.GetAxisRaw ("Vertical") * movementSpeed * Time.deltaTime;
		transform.Translate (horizontal, 0, vertical);
		float camRotation = cam.transform.rotation.eulerAngles.y;
		transform.Rotate (Vector3.up, camRotation - transform.rotation.eulerAngles.y);

		if (horizontal != 0 || vertical != 0) {
			isMoving = true;		
		} else {
			isMoving = false;
		}

	
		//TODO: Create separate class to handle this movement based on passed parameters??
		//TODO: Set head turning ability. ?? Make camera follow mouse cursor ?? Rotate character to camera rotation only when RMB is pressed ??


		if (isMoving) {

			//Left leg movement
			if (leftLegSwingAngle > -LegSwing && leftLegSwingForward == false) {
				leftLeg.transform.RotateAround (leftLeg.transform.parent.position + legSwingPointOffset, leftLeg.transform.parent.right, Time.deltaTime * Multiplier);
				leftLegSwingAngle -= Time.deltaTime * Multiplier;
			} else if (leftLegSwingAngle <= -LegSwing) {
				leftLegSwingForward = true;
			}

			if (leftLegSwingAngle < LegSwing && leftLegSwingForward) {
				leftLeg.transform.RotateAround (leftLeg.transform.parent.position + legSwingPointOffset, leftLeg.transform.parent.right, -Time.deltaTime * Multiplier);
				leftLegSwingAngle += Time.deltaTime * Multiplier;
			} else if (leftLegSwingAngle >= LegSwing) {
				leftLegSwingForward = false;
			}

			//Right leg movement
			if (rightLegSwingAngle > -LegSwing && rightSwingForward) {
				rightLeg.transform.RotateAround (rightLeg.transform.parent.position + legSwingPointOffset, rightLeg.transform.parent.right, -Time.deltaTime * Multiplier);
				rightLegSwingAngle -= Time.deltaTime * Multiplier;
			} else if (rightLegSwingAngle <= -LegSwing) {
				rightSwingForward = false;
			}

			if (rightLegSwingAngle < LegSwing && rightSwingForward == false) {
				rightLeg.transform.RotateAround (rightLeg.transform.parent.position + legSwingPointOffset, rightLeg.transform.parent.right, Time.deltaTime * Multiplier);
				rightLegSwingAngle += Time.deltaTime * Multiplier;
			} else if (rightLegSwingAngle >= LegSwing) {
				rightSwingForward = true;
			}

			//Left Arm movement
			if (leftArmSwingAngle < LegSwing && leftArmSwingForward) {
				leftArm.transform.RotateAround (leftArm.transform.parent.position + armSwingPointOffset, leftArm.transform.parent.right, -Time.deltaTime * Multiplier);
				leftArmSwingAngle += Time.deltaTime * Multiplier;
			} else if (leftArmSwingAngle >= LegSwing) {
				leftArmSwingForward = false;
			}

			if (leftArmSwingAngle > -LegSwing && leftArmSwingForward == false) {
				leftArm.transform.RotateAround (leftArm.transform.parent.position + armSwingPointOffset, leftArm.transform.parent.right, Time.deltaTime * Multiplier);
				leftArmSwingAngle -= Time.deltaTime * Multiplier;
			} else if (leftArmSwingAngle <= LegSwing) {
				leftArmSwingForward = true;
			}

			//Right Arm movement
			if (rightArmSwingAngle > -LegSwing && rightArmSwingForward == false) {
				rightArm.transform.RotateAround (rightArm.transform.parent.position + armSwingPointOffset, rightArm.transform.parent.right, Time.deltaTime * Multiplier);
				rightArmSwingAngle -= Time.deltaTime * Multiplier;
			} else if (rightArmSwingAngle <= LegSwing) {
				rightArmSwingForward = true;
			}

			if (rightArmSwingAngle < LegSwing && rightArmSwingForward) {
				rightArm.transform.RotateAround (rightArm.transform.parent.position + armSwingPointOffset, rightArm.transform.parent.right, -Time.deltaTime * Multiplier);
				rightArmSwingAngle += Time.deltaTime * Multiplier;
			} else if (rightArmSwingAngle >= LegSwing) {
				rightArmSwingForward = false;
			}


			//While humanoid is moving, reset is set to true; to mimic standing still pose when movement stops
			reset = true;
		
		}
		else if(reset) {
			Reset ();
		}
	}

	void Reset()
	{
	
		//Left leg gets reset when humanoid stops moving
		leftLeg.transform.localRotation = Quaternion.identity;
		leftLeg.transform.localPosition = new Vector3(-0.225f,-0.9f,0);
		leftLegSwingAngle = 0f;
		leftLegSwingForward = false;

		//Right leg gets reset when humanoid stops moving

		rightLeg.transform.localRotation = Quaternion.identity;	
		rightLeg.transform.localPosition = new Vector3(0.225f,-0.9f,0);
		rightLegSwingAngle = 0f;
		rightSwingForward = true;

		//Left arm get reset when humanoid stops moving

		leftArm.transform.localRotation = Quaternion.identity;
		leftArm.transform.localPosition = new Vector3 (-0.55f, 0.1f, 0);
		leftArmSwingAngle = 0f;
		leftArmSwingForward = true;

		//Right arm get reset when humanoid stops moving

		rightArm.transform.localRotation = Quaternion.identity;
		rightArm.transform.localPosition = new Vector3 (0.55f, 0.1f, 0);
		rightArmSwingAngle = 0f;
		rightArmSwingForward = false;

		//This line prevents reset to be called each frame. Reset happens only when humanoid stops moving
		reset = false;

	}
}

