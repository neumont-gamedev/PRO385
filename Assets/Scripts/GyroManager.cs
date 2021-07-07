using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class GyroManager : MonoBehaviour
{
    public Text debug;

    public delegate void gyroDelegate(Quaternion rotation);
    public event gyroDelegate gyroUpdateEvent;

    GyroControls gyroControls;

    static GyroManager instance;
    static public GyroManager Instance
	{
        get
		{
            if (instance == null)
			{
                instance = FindObjectOfType<GyroManager>();
			}
            return instance;
		}
	}

    public Quaternion rotation { get => gyroControls.Gyro.Attitude.ReadValue<Quaternion>(); }

	private void Awake()
	{
        gyroControls = new GyroControls();
	}

	private void OnEnable()
	{
        gyroControls.Enable();
	}

	private void OnDisable()
	{
        gyroControls.Disable();
	}

    void Update()
    {
        if (AttitudeSensor.current != null && !AttitudeSensor.current.enabled)
		{
            InputSystem.EnableDevice(AttitudeSensor.current);
		}
        Quaternion q = InvertGyro(rotation);
        gyroUpdateEvent?.Invoke(q);
        debug.text = "pitch: " + q.eulerAngles.x.ToString("F1") + " yaw: " + q.eulerAngles.y.ToString("F1") + " roll: " + q.eulerAngles.z.ToString("F1");
    }

    public static Quaternion InvertGyro(Quaternion q)
	{
        return new Quaternion(q.x, q.y, -q.z, -q.w);
	}
}
