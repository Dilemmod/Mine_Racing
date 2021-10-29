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

    [Header("Animators")]
    [SerializeField] private Animator levelMenuAnimator;
    [SerializeField] private Animator tuningMenuAnimator;

    private CameraControllerMainMenu cameraControllerMainMenu;
    protected override void Start()
    {
        base.Start();
        cameraControllerMainMenu = CameraControllerMainMenu.Instance;
        play.onClick.AddListener(OnPlayClecked);
        buttonBack.onClick.AddListener(OnBackClecked);
        buttonToLevelMenu.onClick.AddListener(OnLevelMenuClecked);
        buttonToTuningMenu.onClick.AddListener(OnTuningMenuClecked);
        if (PlayerPrefs.HasKey("PlayerCoins"))
        {
            //playerMenu.transform.GetChild(1).GetChild(0).GetChild(0).GetComponent<Text>().text = PlayerPrefs.GetString("PlayerCoins");
        }

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
            if (levelMenu.activeInHierarchy)
                levelMenuAnimator.SetTrigger("Close");
            else if (tuningMenu.activeInHierarchy)
                tuningMenuAnimator.SetTrigger("Close");
            cameraControllerMainMenu.CameraPosition(MenuPosition.playerTarget);
            playerMenuButtons.SetActive(true);
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
