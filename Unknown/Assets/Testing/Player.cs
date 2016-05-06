using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float movementSpeed = 10f;
	public float turningSpeed = 60f;


	
	// Update is called once per frame
	void Update () {
		float horizontal = Input.GetAxisRaw ("Horizontal") * turningSpeed * Time.deltaTime;
		transform.Rotate (0, horizontal, 0);
		float vertical = Input.GetAxisRaw ("Vertical") * movementSpeed * Time.deltaTime;
		transform.Translate (0, 0, vertical);
	}
}
