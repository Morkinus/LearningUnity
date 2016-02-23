using UnityEngine;
using System.Collections;

public class Walking : MonoBehaviour {

	public float speed = 7.0f;
	public float gravity = -9.8f;
	// Use this for initialization

	private CharacterController ctrl;
	void Start () {
		ctrl = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {
		float deltaX = Input.GetAxis ("Horizontal") * speed ;
		float deltaZ = Input.GetAxis ("Vertical") * speed ;
		Vector3 move = new Vector3 (deltaX, 0, deltaZ);
		move = Vector3.ClampMagnitude (move, speed);

		move.y = gravity;

		move *= Time.deltaTime;
		move = transform.TransformDirection (move);
		ctrl.Move (move);
	}
}
