using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerMainMenu : MonoBehaviour
{
	[Header("CameraRotation")]
	[SerializeField] private float rotationSpeed = 10f;
	[SerializeField] private float rotationYEnd = 90f;
	[SerializeField] private float rotationYBegin = 10f;
	private bool firstTurn = true;
	private float rotationY;
	private bool rotateOn = true;

	[Header("CameraMoving")]
	[SerializeField] private Camera MainCamera;
	[SerializeField] private GameObject mainMenuPosition;
	[SerializeField] private GameObject playerMenuPosition;
	[SerializeField] private GameObject levelMenuPosition;
	[SerializeField] private GameObject tuningMenuPosition;
	private GameObject target;
	public int speed = 1;
    public enum MenuPosition
    {
        mainTarget,
        playerTarget,
        levelTarget,
        tuningTarget
    }
    public MenuPosition moveTo = MenuPosition.mainTarget;
    bool stop = true;
    //private bool cameraMove=false;
    #region Singleton
    public static CameraControllerMainMenu Instance;
	private void Awake()
	{
		if (Instance == null)
			Instance = this;
		else Destroy(gameObject);
	}
	#endregion
	#region CameraRotation
	public void RotationSwitch()
	{
		if (rotateOn)
			rotateOn = false;
		else
			rotateOn = true;
	}
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
    void UpdateRotetion()
    {
        if (!rotateOn)
            return;
        if (firstTurn)
        {
            CameraRotate(Vector3.up);
        }
        else
        {
            CameraRotate(Vector3.down);
        }
    }
    #endregion
    #region CameraMoving
    bool TimeToStop(GameObject obj)
    {
        return Vector3.Distance(MainCamera.transform.position, obj.transform.position) < 0.01f;
    }
    void MoveCameraTo(MenuPosition index)
    {
        switch (index)
        {
            case (MenuPosition)0:
                target = mainMenuPosition;
                break;
            case (MenuPosition)1:
                target = playerMenuPosition;
                break;
            case (MenuPosition)2:
                target = levelMenuPosition;
                break;
            case (MenuPosition)3:
                target = tuningMenuPosition;
                break;
        }
        MainCamera.transform.position = Vector3.Lerp(transform.position, target.transform.position, speed * Time.deltaTime);
        MainCamera.transform.rotation = Quaternion.Lerp(transform.rotation, target.transform.rotation, speed * Time.deltaTime);
    }
    #endregion
    void FixedUpdate()
    {
        UpdateRotetion();
        if (Input.GetKey(KeyCode.W))
            moveTo = MenuPosition.playerTarget;
        if (Input.GetKey(KeyCode.A))
            moveTo = MenuPosition.levelTarget;
        if (Input.GetKey(KeyCode.D))
            moveTo = MenuPosition.tuningTarget;
        if (Input.GetKey(KeyCode.S))
            moveTo = MenuPosition.mainTarget;
        MoveCameraTo(moveTo);
        if (stop == true)
            return;
        if (TimeToStop(mainMenuPosition) ||
            TimeToStop(playerMenuPosition) ||
            TimeToStop(tuningMenuPosition) ||
            TimeToStop(levelMenuPosition)
            )
        {
            Debug.Log("Stop");
            stop = true;
        }
        else stop = false;
    }
}
