using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Range(1, 10)] public float speed = 2;
    public GameObject shot;

    Vector2 input;

    private void Start()
    {
        GetComponent<PlayerInput>().onActionTriggered += HandleAction;
    }

    void Update()
    {
        Gamepad gamepad = Gamepad.current;
        if (gamepad == null) return;

        // movement
        // (input manager)
        //input.x = Input.GetAxis("Horizontal");
        //input.y = Input.GetAxis("Vertical");
        //// (input system)
        //input = gamepad.leftStick.ReadValue();

        transform.Translate(input * speed * Time.deltaTime);

        // fire
        // (input manager)
        //if (Input.GetButtonDown("Fire1"))
        //{
        //    GameObject go = Instantiate(shot, transform.position, Quaternion.identity);
        //}
        //// (input system)
        //if (gamepad.buttonSouth.wasPressedThisFrame)
        //{
        //    GameObject go = Instantiate(shot, transform.position, Quaternion.identity);
        //}
    }

    private void OnFire()
    {
        GameObject go = Instantiate(shot, transform.position, Quaternion.identity);
    }

    private void OnMove(InputValue inputValue)
    {
        input = inputValue.Get<Vector2>();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        input = context.ReadValue<Vector2>();
    }

    private void HandleAction(InputAction.CallbackContext context)
    {
        if (context.action.name == "Fire")
        {
            OnFire();
        }
        if (context.action.name == "Move")
		{
            OnMove(context);
        }
    }
}
