using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {

	public int ID;
	public float spacing;

	// Use this for initialization
	void Start () {
		print ("I'm alive");
	}
	
	// Update is called once per frame
	void Update () {
		float wave = Mathf.Sin (Time.fixedTime + ID);
		transform.position = new Vector3(ID*spacing,wave,0);
	}
}
