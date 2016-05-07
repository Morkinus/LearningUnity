using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject target;
	public float rotationSpeed = 5f;
	public float rotationXMin = -20f;
	public float rotationXMax = 40f;

	//TODO: ?? Ability to zoom camera in and out

	// Distance from camera to player
	Vector3 offset;
	float rotationY;
	float rotationX;

	// Use this for initialization
	void Start () {
		rotationY = transform.eulerAngles.y;
		rotationX = transform.eulerAngles.x;
		offset = target.transform.position - transform.position;
	}

	void Update()
	{
		if (Input.GetButton ("Fire2")) {
			rotationY += Input.GetAxis ("Mouse X") * rotationSpeed;
			rotationX -= Input.GetAxis ("Mouse Y") * rotationSpeed;
			rotationX = Mathf.Clamp (rotationX, rotationXMin, rotationXMax);
		}
	}

	// Update is called once per frame
	void LateUpdate () {
			Quaternion rotate = Quaternion.Euler (rotationX, rotationY, 0);
			transform.position = target.transform.position - (rotate * offset);
			transform.LookAt (target.transform);
		}
	}

