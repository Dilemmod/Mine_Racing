using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{

    [SerializeField] private Camera MainCamera;
    [SerializeField] private GameObject mainMenuPosition;
    [SerializeField] private GameObject playerMenuPosition;
    [SerializeField] private GameObject levelMenuPosition;
    [SerializeField] private GameObject tuningMenuPosition;
    private GameObject target;
    //public GameObject TargetPosition;
    public int speed = 1;
    //private bool cameraMove=false;
    public enum MenuPosition
    {
        mainTarget,
        playerTarget,
        levelTarget,
        tuningTarget
    }
    public MenuPosition moveTo= MenuPosition.mainTarget;
    bool stop = true;
    #region Singleton
    public static CameraMoving Instance;
    private void Awake()
    {
        target = new GameObject();
        if (Instance == null)
            Instance = this;
        else Destroy(gameObject);
    }
    #endregion
    void Update()
    {
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
        if (TimeToStop(mainMenuPosition)   ||
            TimeToStop(playerMenuPosition) ||
            TimeToStop(tuningMenuPosition) ||
            TimeToStop(levelMenuPosition)
            )
        {
            Debug.Log("Stop");
            stop = true;
        }
    }
    bool TimeToStop(GameObject obj)
    {
        return Vector3.Distance(MainCamera.transform.position, obj.transform.position) < 0.01f;
    }
    void ToPreviousMenu()
    {
        //if(moveTo==MenuPosition.tuningTarget|| moveTo == MenuPosition)
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
        stop = false;
        MainCamera.transform.position = Vector3.Lerp(transform.position, target.transform.position, speed * Time.deltaTime);
        MainCamera.transform.rotation = Quaternion.Lerp(transform.rotation, target.transform.rotation, speed * Time.deltaTime);
    }
}
