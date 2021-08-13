using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{

    public Camera MainCamera;
    public GameObject levelMenuPosition;
    public GameObject tuningMenuPosition;
    public GameObject playerMenuPosition;
    public GameObject mainMenuPosition;
    //public GameObject TargetPosition;
    public int speed = 1;
    #region Singleton
    public static CameraMoving Instance;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else Destroy(gameObject);
    }
    #endregion
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MoveCameraTo(playerMenuPosition);
        }
        if (Input.GetKey(KeyCode.A))
        {
            MoveCameraTo(levelMenuPosition);
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveCameraTo(tuningMenuPosition);
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveCameraTo(mainMenuPosition);
        }

    }
    void MoveCameraTo(GameObject target)
    {
        MainCamera.transform.position = Vector3.Lerp(transform.position, target.transform.position, speed * Time.deltaTime);
        MainCamera.transform.rotation = Quaternion.Lerp(transform.rotation, target.transform.rotation, speed * Time.deltaTime);
    }
}
