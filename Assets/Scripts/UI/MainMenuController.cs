using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static CameraControllerMainMenu;
using System;

public class MainMenuController : BaseGameMenuController
{
    [Header("Player menu")]
    [SerializeField] private GameObject playerMenuButtons;
    [SerializeField] private GameObject levelMenu;
    [SerializeField] private GameObject tuningMenu;
    [SerializeField] private GameObject playerMenu;
    [SerializeField] protected Button buttonBack;
    [SerializeField] protected Button buttonToLevelMenu;
    [SerializeField] protected Button buttonToTuningMenu;

    
    private CameraControllerMainMenu cameraControllerMainMenu;
    protected override void Start()
    {
        base.Start();
        cameraControllerMainMenu = CameraControllerMainMenu.Instance;
        play.onClick.AddListener(OnPlayClecked);
        buttonBack.onClick.AddListener(OnBackClecked);
        buttonToLevelMenu.onClick.AddListener(OnLevelMenuClecked);
        buttonToTuningMenu.onClick.AddListener(OnTuningMenuClecked);
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
        buttonBack.onClick.RemoveListener(OnBackClecked);
        play.onClick.RemoveListener(OnPlayClecked);
        buttonToLevelMenu.onClick.RemoveListener(OnLevelMenuClecked);
        buttonToTuningMenu.onClick.RemoveListener(OnTuningMenuClecked);
    }
    private void OnPlayClecked()
    {
        cameraControllerMainMenu.CameraPosition(MenuPosition.playerTarget);
        playerMenu.SetActive(!playerMenu.activeInHierarchy);
        audioManager.Play(UIClipName.Play);
        OnChangeMenuStatusClicked();
    }
    private void OnBackClecked()
    {
        if (playerMenuButtons.activeInHierarchy)
        {
            cameraControllerMainMenu.CameraPosition(MenuPosition.mainTarget);
            playerMenu.SetActive(!playerMenu.activeInHierarchy);
            OnChangeMenuStatusClicked();
            audioManager.Play(UIClipName.Quit);
        }
        else
        {
            cameraControllerMainMenu.CameraPosition(MenuPosition.playerTarget);
            ActiveMenu(playerMenuButtons);
            audioManager.Play(UIClipName.Quit);
        }
    }
    private void OnLevelMenuClecked()
    {
        cameraControllerMainMenu.CameraPosition(MenuPosition.levelTarget);
        audioManager.Play(UIClipName.LvlMenu);
        ActiveMenu(levelMenu);
    }
    private void OnTuningMenuClecked()
    {
        cameraControllerMainMenu.CameraPosition(MenuPosition.tuningTarget);
        audioManager.Play(UIClipName.LvlMenu);
        ActiveMenu(tuningMenu);
    }
    private void ActiveMenu(GameObject menu)
    {
        tuningMenu.SetActive(false);
        levelMenu.SetActive(false);
        playerMenuButtons.SetActive(false);
        menu.SetActive(true);
    }
}
