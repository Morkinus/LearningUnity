using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public enum RotationAxes
	{
		MouseX = 0,
		MouseY = 1
	}

	public RotationAxes axes = RotationAxes.MouseX;
	public float rotationSensitivity = 5.0f;

	public float vertMin = -50.0f;
	public float vertMax = 50.0f;

	private float vertRotation = 0;

	// Update is called once per frame
	void Update () {
		if (axes == RotationAxes.MouseX) {
			transform.Rotate(0, Input.GetAxis ("Mouse X") * rotationSensitivity,0);
		}
		else if(axes == RotationAxes.MouseY)
		{
			vertRotation -= Input.GetAxis("Mouse Y")*rotationSensitivity;
			vertRotation = Mathf.Clamp(vertRotation,vertMin,vertMax);

			float horRotation = transform.localEulerAngles.y;

			transform.localEulerAngles = new Vector3(vertRotation,horRotation,0);
		}
	}
}
