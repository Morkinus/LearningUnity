using UnityEngine;
using System.Collections;

public class DeviceTrigger : MonoBehaviour {

	[SerializeField]private GameObject[] targets;

	public bool RequireKey;

	void OnTriggerEnter(Collider other)
	{
		//This was meant to be key item, but the collectible was named Stamina already, so i went with that
		if (RequireKey && Managers.Inventory.equippedItem != "Stamina") {
			return;
		}

		foreach (GameObject target in targets) {
			target.SendMessage("Activate");
		}
	}

	void OnTriggerExit(Collider other)
	{
		foreach (GameObject target in targets) {
			target.SendMessage("Deactivate");
		}
	}
}
