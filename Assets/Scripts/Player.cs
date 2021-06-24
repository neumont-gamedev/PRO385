using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Range(1, 10)] public float speed = 2;
    public GameObject shot;

    void Start()
    {
        
    }

    void Update()
    {
        Vector2 input;
        input.x = Input.GetAxis("Horizontal");
        input.y = Input.GetAxis("Vertical");
        //Debug.Log(input);
        transform.Translate(input * speed * Time.deltaTime);

        if (Input.GetButtonDown("Fire1"))
		{
            GameObject go = Instantiate(shot, transform.position, Quaternion.identity);
		}
    }
}
