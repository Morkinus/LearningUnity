using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed = 0.1f;

	void Update () {
		gameObject.transform.position += Movement (speed);
	}

	Vector3 Movement(float dist)
	{
		Vector3 vec = Vector3.zero;
		if (Input.GetKey (KeyCode.A)) {
			vec.x -= dist;
		}
		if (Input.GetKey (KeyCode.D)) {
			vec.x += dist;
		}
		if (Input.GetKey (KeyCode.S)) {
			vec.z -= dist;
		}
		if (Input.GetKey (KeyCode.W)) {
			vec.z += dist;
		}
		return vec;
	}
}

