using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

//[System.Serializable]
//public class StartTouchEvent : UnityEvent<Vector2>
//{
//}

//[System.Serializable]
//public class StopTouchEvent : UnityEvent<Vector2>
//{
//}

//[System.Serializable]
//public class UpdateTouchEvent : UnityEvent<Vector2>
//{
//}

public class TouchManager : MonoBehaviour
{
	//public StartTouchEvent OnStartTouch;
	//public StopTouchEvent OnStopTouch;
	//public UpdateTouchEvent OnUpdateTouch;

	public delegate void touchStartDelegate(Vector2 positon);
	public delegate void touchStopDelegate(Vector2 positon);
	public delegate void touchUpdateDelegate(Vector2 positon);

	public event touchStartDelegate touchStartEvent;
	public event touchStopDelegate touchStopEvent;
	public event touchUpdateDelegate touchUpdateEvent;

	TouchControls touchControls;
	bool touched = false;	

	static TouchManager instance;
	static public TouchManager Instance 
	{ 
		get
		{
			if (instance == null)
			{
				instance = FindObjectOfType<TouchManager>();
			}

			return instance;
		}
	}

	public Vector2 position { get => touchControls.Touch.TouchPosition.ReadValue<Vector2>(); }

	private void Awake()
	{
		touchControls = new TouchControls();
	}

	private void OnEnable()
	{
		touchControls.Enable();
	}

	private void OnDisable()
	{
		touchControls.Disable();
	}

	private void Start()
	{
		touchControls.Touch.TouchPress.started += context => TouchPressStart(context);
		touchControls.Touch.TouchPress.canceled += context => TouchPressStop(context);
	}

	private void Update()
	{
		if (touched)
		{
			//OnUpdateTouch.Invoke(position);
			touchUpdateEvent?.Invoke(position);
		}
	}

	private void TouchPressStart(InputAction.CallbackContext context)
	{
		//OnStartTouch.Invoke(position);
		touchStartEvent?.Invoke(position);
		touched = true;
		//Debug.Log("start: " + position);
	}

	private void TouchPressStop(InputAction.CallbackContext context)
	{
		//OnStopTouch.Invoke(position);
		touchStopEvent?.Invoke(position);
		touched = false;
		//Debug.Log("stop: " + position);
	}
}


