using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroTilt : MonoBehaviour
{
	private void OnEnable()
	{
		GyroManager.Instance.gyroUpdateEvent += Tilt;
	}

	private void OnDisable()
	{
		if (GyroManager.Instance == null) return;

		GyroManager.Instance.gyroUpdateEvent -= Tilt;
	}

	void Tilt(Quaternion rotation)
	{
		//Quaternion quat = Quaternion.FromToRotation(rotation.for);
		Quaternion quat = rotation;// Quaternion.Euler(0, 0, 90) * GyroManager.InvertGyro(rotation);
		transform.rotation = quat;
	}

	//Quaternion quat = GyroManager.InvertGyro(rotation);
	//Quaternion quat = Quaternion.Euler(0, 0, 90) * rotation;
	// invert the rotation
	//Quaternion quat = Quaternion.Euler(0, 0, 90) * GyroManager.InvertGyro(rotation);

}
