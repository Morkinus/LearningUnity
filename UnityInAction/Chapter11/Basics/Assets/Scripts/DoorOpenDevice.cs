using UnityEngine;
using System.Collections;

public class DoorOpenDevice : MonoBehaviour {

	[SerializeField] private Vector3 dpos;

	private bool _open;

	void Operate()
	{
		if (_open) {
			Vector3 pos = transform.position - dpos;
			transform.position = pos;
		} else {
			Vector3 pos = transform.position + dpos;
			transform.position = pos;
		}
		_open = !_open;
	}

	public void Activate()
	{
		if (!_open) {
			Vector3 pos = transform.position + dpos;
			transform.position = pos;
			_open = true;
		}
	}

	public void Deactivate()
	{
		if (_open) {
			Vector3 pos = transform.position - dpos;
			transform.position = pos;
			_open = false;
		}
	}
}
