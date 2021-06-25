using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Range(1, 10)] public float speed = 2;
    public GameObject shot;

    Vector2 input;

    void Update()
    {
        Gamepad gamepad = Gamepad.current;
        if (gamepad == null) return;

        // movement
        //input = gamepad.leftStick.ReadValue();

        //input.x = Input.GetAxis("Horizontal");
        //input.y = Input.GetAxis("Vertical");

        transform.Translate(input * speed * Time.deltaTime);

        // fire
        //if (Input.GetButtonDown("Fire1"))
        if (gamepad.buttonSouth.wasPressedThisFrame)
		{
            //GameObject go = Instantiate(shot, transform.position, Quaternion.identity);
		}
    }

    public void OnFire()
	{
        GameObject go = Instantiate(shot, transform.position, Quaternion.identity);
    }

	public void OnMove(InputValue inputValue)
	{
        input = inputValue.Get<Vector2>();
    }
}
