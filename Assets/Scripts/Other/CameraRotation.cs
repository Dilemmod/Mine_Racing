using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
	[SerializeField] private float rotationSpeed = 10f;
	[SerializeField] private float rotationYEnd	= 90f;
	[SerializeField] private float rotationYBegin = 10f;

	private bool firstTurn = true;
	private float rotationY;

	void CameraRotate(Vector3 direction)
    {
		rotationY = transform.localRotation.eulerAngles.y;
		//Проверка на конец поворота
		if ((rotationY > rotationYEnd && firstTurn) ||
			(rotationY < rotationYBegin && !firstTurn))
		{
			if (direction == Vector3.up)
				firstTurn = false;
			else if (direction == Vector3.down)
				firstTurn = true;
		}
		Camera.main.transform.Rotate(direction * rotationSpeed * Time.deltaTime, Space.World);
	}

	void FixedUpdate()
	{
		if (firstTurn)
		{
			Debug.Log("1");
			CameraRotate(Vector3.up);
		}
		else
		{
			Debug.Log("2");
			CameraRotate(Vector3.down);
		}
	}
	
}
