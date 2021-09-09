using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static CameraMoving;

public class MainMenuController : BaseGameMenuController
{
    [Header("Player menu")]
    [SerializeField] private GameObject levelMenu;
    [SerializeField] private GameObject tuningMenu;
    [SerializeField] private GameObject playerMenu;
    [SerializeField] protected Button buttonToLevelMenu;
    [SerializeField] protected Button buttonToTuningMenu;
    [SerializeField] protected Button buttonToMainMenu;
    [SerializeField] protected Button buttonToPlayerMenu;

    [Header("Main menu")]
    [SerializeField] protected Button more;

    private CameraRotation cameraRotation;
    private CameraMoving cameraMoving;
    //[SerializeField] protected Button closeLevelMenu;
    protected override void Start()
    {
        base.Start();
        cameraRotation = CameraRotation.Instance;
        cameraMoving = CameraMoving.Instance;
        //buttonToLevelMenu.onClick.AddListener(OnLvlMenuClecked);
        //closeLevelMenu.onClick.AddListener(OnLvlMenuClecked);
        buttonToPlayerMenu.onClick.AddListener(OnPlayClecked);
        buttonToMainMenu.onClick.AddListener(OnBackClecked);
        //reset.onClick.AddListener(OnResetClicked);
        /*
        if (PlayerPrefs.HasKey(GamePrefs.LastPlayedLvl.ToString()))
        {
            play.GetComponentInChildren<Text>().text = "CONTINUE";
            lvl = PlayerPrefs.GetInt(GamePrefs.LastPlayedLvl.ToString());
        }*/

        audioManager.Play(UIClipName.BackgroundMusic);
    }
    protected override void OnDestroy()
    {
        base.OnDestroy();
        //reset.onClick.RemoveListener(levelManager.ResetProgres);
       // buttonToLevelMenu.onClick.RemoveListener(OnLvlMenuClecked);
        //closeLevelMenu.onClick.RemoveListener(OnLvlMenuClecked);
    }
    private void OnBackClecked()
    {
        //камера главного меню 
        cameraMoving.moveTo = MenuPosition.mainTarget;
        ///стоп поворот
        cameraRotation.RotationSwitch();

        playerMenu.SetActive(!playerMenu.activeInHierarchy);
        audioManager.Play(UIClipName.Play);
        //menu.SetActive(!menu.activeInHierarchy);
        OnChangeMenuStatusClicked();
    }
    private void OnPlayClecked()
    {
        //камера главного игрока
        cameraMoving.moveTo = MenuPosition.playerTarget;
        ///стоп поворот
        cameraRotation.RotationSwitch();

        playerMenu.SetActive(!playerMenu.activeInHierarchy);
        audioManager.Play(UIClipName.Play);
        //menu.SetActive(!menu.activeInHierarchy);
        OnChangeMenuStatusClicked();
    }
    private void OnLvlMenuClecked()
    {
        audioManager.Play(UIClipName.LvlMenu);
        levelMenu.SetActive(!levelMenu.activeInHierarchy);
        OnChangeMenuStatusClicked();
    }
    private void OnResetClicked()
    {
        audioManager.Play(UIClipName.Reset);
       // play.GetComponentInChildren<Text>().text = "NEW GAME";
        levelManager.ResetProgres();
    }
}
