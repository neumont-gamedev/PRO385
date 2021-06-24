using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    [Range(1, 10)] public float speed = 2;
    [Range(1, 5)] public float lifetime = 2;

	private void Start()
	{
		Destroy(gameObject, lifetime);
	}

	void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
