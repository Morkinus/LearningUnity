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
	[SerializeField] private GameObject leftArm;
	[SerializeField] private GameObject leftLeg;
	[SerializeField] private GameObject rightArm;
	[SerializeField] private GameObject rightLeg;

	//#####################################################################

	bool isMoving;
	float leftLegSwingAngle;
	float rightLegSwingAngle;
	bool leftSwingingForward = false;
	bool rightSwingingForward = true;
	bool reset = false;

	const int LegSwing = 20;
	const int multiplier = 140;
	Vector3 LeftLegOffset = new Vector3 (0.2f, 0.9f, 0);

	void Start()
	{
		Debug.Log (leftLeg.transform.position + "   " + leftLeg.transform.parent.position);
//		Debug.Log (rightLeg.transform.position + "   " + rightLeg.transform.parent.position);
		Debug.Log (leftLeg.transform.parent.position - leftLeg.transform.position);
//		Debug.Log (rightLeg.transform.parent.position - rightLeg.transform.position);


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

		//TODO: set movement for other body parts
		//?? Create separate class to handle this movement based on passed parameters??
		//set body parts to starting position when humanoid is not moving


		if (isMoving) {

			//Left leg movement
			if (leftLegSwingAngle > -LegSwing && leftSwingingForward == false) {
				leftLeg.transform.RotateAround (leftLeg.transform.parent.position, leftLeg.transform.parent.right, Time.deltaTime * multiplier);
				leftLegSwingAngle -= Time.deltaTime * multiplier;
			} else if (leftLegSwingAngle <= -LegSwing) {
				leftSwingingForward = true;
			}

			if (leftLegSwingAngle < LegSwing && leftSwingingForward) {
				leftLeg.transform.RotateAround (leftLeg.transform.parent.position, leftLeg.transform.parent.right, -Time.deltaTime * multiplier);
				leftLegSwingAngle += Time.deltaTime * multiplier;
			} else if (leftLegSwingAngle >= LegSwing) {
				leftSwingingForward = false;
			}

			//Right leg movement
			if (rightLegSwingAngle > -LegSwing && rightSwingingForward) {
				rightLeg.transform.RotateAround (rightLeg.transform.parent.position, rightLeg.transform.parent.right, -Time.deltaTime * multiplier);
				rightLegSwingAngle -= Time.deltaTime * multiplier;
			} else if (rightLegSwingAngle <= -LegSwing) {
				rightSwingingForward = false;
			}

			if (rightLegSwingAngle < LegSwing && rightSwingingForward == false) {
				rightLeg.transform.RotateAround (rightLeg.transform.parent.position, rightLeg.transform.parent.right, Time.deltaTime * multiplier);
				rightLegSwingAngle += Time.deltaTime * multiplier;
			} else if (rightLegSwingAngle >= LegSwing) {
				rightSwingingForward = true;
			}

			//Left Arm movement

			//While humanoid is moving, reset is set to true; to mimic standing still pose when movement stops
			reset = true;
		
		}
		else if(reset) {

			//Left 		leg gets reset when humanoid stops moving
			leftLeg.transform.localRotation = Quaternion.identity;
			leftLeg.transform.localPosition = new Vector3(-0.2f,-0.9f,0);
			leftLegSwingAngle = 0f;
			leftSwingingForward = false;

			//Right leg gets reset when humanoid stops moving

			rightLeg.transform.localRotation = Quaternion.identity;	
			rightLeg.transform.localPosition = new Vector3(0.2f,-0.9f,0);
			rightLegSwingAngle = 0f;
			rightSwingingForward = true;

			//This line prevent reset to be called each frame. Reset happens only when humanoid stops moving
			reset = false;
		}
	}
}

//[RequireComponent(typeof(CharacterController))]
//
//public class PlayerController : MonoBehaviour {
//
//    public Transform cam;
//    public float speed = 5f;
//    public float turnSpeed = 2f;
//
//    float movementX;
//    float movementZ;
//
//    private CharacterController controller;
//    
//    // Use this for initialization
//	void Start () {
//        controller = GetComponent<CharacterController>();
//	}
//	
//	// Update is called once per frame
//	void Update () {
//        movementX = Input.GetAxis("Horizontal") * speed;
//        movementZ = Input.GetAxis("Vertical") * speed;
//        Vector3 move = new Vector3(movementX, 0, movementZ);
//        
//        move = Vector3.ClampMagnitude(move, speed);
//        move *= Time.deltaTime;
//        controller.Move(move);
//		controller.transform.rotation = cam.localRotation;
//        
//		Debug.Log (cam.localRotation);
//
////        if (Input.GetKey(KeyCode.D))
////        {
////            //transform.Rotate(Vector3.Lerp(Vector3.forward,Vector3.right,turnSpeed));
////            transform.position += (Vector3.right + transform.forward/2) * Time.deltaTime * speed;
////            transform.Rotate(new Vector3(0, turnSpeed, 0));
////            
////        }
////        if (Input.GetKey(KeyCode.A))
////        {
////            //transform.Rotate(Vector3.Lerp(Vector3.forward,Vector3.right,turnSpeed));
////            transform.position -= Vector3.right * Time.deltaTime * speed;
////            transform.Rotate(new Vector3(0, -turnSpeed, 0));
////
////        }
////        if (Input.GetKey(KeyCode.W))
////        {
////            //transform.Rotate(Vector3.Lerp(Vector3.forward,Vector3.right,turnSpeed));
////            transform.position += transform.forward * Time.deltaTime * speed;
////
////        }
////        if (Input.GetKey(KeyCode.S))
////        {
////            //transform.Rotate(Vector3.Lerp(Vector3.forward,Vector3.right,turnSpeed));
////            transform.position -= transform.forward * Time.deltaTime * speed;
////
////        }
//
//   }
//}
