using UnityEngine;
using System.Collections;

public class OrbitCamera : MonoBehaviour {

	[SerializeField] private Transform target;

	public float rotationSpeed = 1.5f;

	private float _rotY;
	private Vector3 _offset;
	// Use this for initialization
	void Start () {
		_rotY = transform.eulerAngles.y;
		_offset = target.position - transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		_rotY -= Input.GetAxis ("Horizontal") * rotationSpeed;
		Quaternion rotation = Quaternion.Euler (0, _rotY, 0);
		transform.position = target.position - (rotation * _offset);
		transform.LookAt (target);
	}
}
