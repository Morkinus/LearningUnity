using UnityEngine;
using System.Collections;

public class MonsterSpawner : MonoBehaviour {

	public int numBoxes =10;
	public float spacing = 2;
	public GameObject[] boxes;
	// Use this for initialization
	void Start () 
	{
		boxes = new GameObject[numBoxes];
		for (int i =0; i < numBoxes; i++) {
			GameObject box = GameObject.CreatePrimitive(PrimitiveType.Cube);
			//box.AddComponent<Monster>();
			Monster m = box.AddComponent<Monster>() as Monster;
			m.ID = i;
			m.spacing = spacing;
			boxes[i]=box;
		}
	}
	
	// Update is called once per frame
	void Update () 
	{

	}
}
