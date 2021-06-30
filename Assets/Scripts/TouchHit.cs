using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHit : MonoBehaviour
{
	public float distance = 10;

	private void OnEnable()
	{
		TouchManager.Instance.touchStartEvent += Touch;
	}

	private void OnDisable()
	{
		TouchManager.Instance.touchStartEvent -= Touch;
	}

	private void Touch(Vector2 position)
	{
		Ray ray = Camera.main.ScreenPointToRay(position);
		if (Physics.Raycast(ray, out RaycastHit raycastHit))
		{
			if (raycastHit.collider.gameObject == gameObject)
			{
				Destroy(gameObject);
			}
		}
	}
}
