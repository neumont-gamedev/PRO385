using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchHit : MonoBehaviour
{
	private void OnEnable()
	{
		TouchManager.Instance.touchStartEvent += Touch;
	}

	private void OnDisable()
	{
		if (TouchManager.Instance == null) return;

		TouchManager.Instance.touchStartEvent -= Touch;
	}

	private void Touch(Vector2 position)
	{
		Ray ray = Camera.main.ScreenPointToRay(position);
		if (Physics.Raycast(ray, out RaycastHit raycastHit))
		{
			if (raycastHit.collider.gameObject == gameObject)
			{
				RandomColor();
			}
		}
	}

	public void RandomColor()
	{
		GetComponent<SpriteRenderer>().material.color = new Color(Random.value, Random.value, Random.value);
	}
}
