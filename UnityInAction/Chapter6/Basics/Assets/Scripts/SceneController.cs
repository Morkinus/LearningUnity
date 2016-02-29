using UnityEngine;
using System.Collections;

public class SceneController : MonoBehaviour {

	[SerializeField]private GameObject enemyPrefab;
	private GameObject _enemy;

	void Awake()
	{
		Messenger<float>.AddListener (GameEvent.SPEED_CHANGED, speedChanged);
	}

	void OnDestroy()
	{
		Messenger<float>.RemoveListener (GameEvent.SPEED_CHANGED, speedChanged);
	}



	// Update is called once per frame
	void Update () {
		if (_enemy == null) {
			_enemy = Instantiate (enemyPrefab) as GameObject;
			_enemy.transform.position = new Vector3 (-4, 1, 4);
			float angle = Random.Range (0, 360);
			_enemy.transform.Rotate (0, angle, 0);

		}
	}

	private void speedChanged(float value)
	{
		PlayerPrefs.SetFloat ("enemySpeed", value);
	}
}
