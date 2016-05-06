using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public GameObject target;
	public float rotationSpeed = 5f;
	public float rotationXMin = -5f;
	public float rotationXMax = 60f;

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
//
			transform.LookAt (target.transform);
		}
	}

//    public Transform player;                //camera's target transform
//    public Transform camTransform;          //camera's transform
//    public float rotationSpeed = 4;         //camera rotation speed
//    public float rotationLimitMin = 10f;    //minimum rotation angle
//    public float rotationLimitMax = 70f;    //maximum rotation angle
//	public float zoomSpeed = 2;
//    Vector3 distance;                       //camera distance from target
//    
//    float mouseWheel;                       //mouswheel value
//    float rotationX, rotationY;             //camera rotation values
//
//   
//    
//	void Start () {
//        distance = new Vector3(0, 0, -10);  //starting distance
//        camTransform = transform;           //getting camera transform
//        camera = Camera.main;               //getting camera object
//       
//    }
//	
//	void Update () {
//
//        //processing input from mouseWheel. Used to zoom camera in and out
//        mouseWheel = Input.GetAxis("Mouse ScrollWheel"); 
//        
//        if ((distance.magnitude > 5) && (distance.magnitude < 20))
//        {
//			distance += new Vector3(0, 0, mouseWheel*zoomSpeed);
//        }
//        //distance clamping
//        else if (distance.magnitude < 5)
//        {
//            distance = new Vector3(0, 0, -5.01f);
//        }
//        else if (distance.magnitude > 20)
//        {
//            distance = new Vector3(0, 0, -19.99f);
//        }
//        //values for rotation processing when the right mouse button is pressed
//        if (Input.GetButton("Fire2"))
//        {
//            rotationX -= Input.GetAxis("Mouse Y") * rotationSpeed;
//            rotationY += Input.GetAxis("Mouse X") * rotationSpeed;
//            rotationX = Mathf.Clamp(rotationX, rotationLimitMin, rotationLimitMax);
//        }
//    }
//
//    void LateUpdate()
//    {
//        //setting camera rotation 
//        Quaternion cameraRotation = Quaternion.Euler(rotationX, rotationY, 0);
//        transform.position = player.position + cameraRotation * distance;
//        transform.LookAt(player);
//    }
//}
