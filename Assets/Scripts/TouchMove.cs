using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMove : MonoBehaviour
{
	public float distance = 10;

	private void OnEnable()
	{
		TouchManager.Instance.touchStartEvent += Move;
		TouchManager.Instance.touchStopEvent += Move;
		TouchManager.Instance.touchUpdateEvent += Move;
	}

	private void OnDisable()
	{
		TouchManager.Instance.touchStartEvent -= Move;
		TouchManager.Instance.touchStopEvent -= Move;
		TouchManager.Instance.touchUpdateEvent -= Move;
	}

	private void Move(Vector2 position)
	{
		Vector3 screen = new Vector3(position.x, position.y, distance);
		Vector3 world = Camera.main.ScreenToWorldPoint(screen);
		world.z = transform.position.z;

		transform.position = world;
	}
}
