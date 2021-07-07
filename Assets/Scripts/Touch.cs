using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
	public float distance = 10;

	public void Move(Vector2 position, float time)
	{
		Vector3 screen = new Vector3(position.x, position.y, distance);
		Vector3 world = Camera.main.ScreenToWorldPoint(screen);
		world.z = transform.position.z;

		transform.position = world;
	}
}
