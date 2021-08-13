using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    //[SerializeField] protected Button closeLevelMenu;
    protected override void Start()
    {
        base.Start();
        //buttonToLevelMenu.onClick.AddListener(OnLvlMenuClecked);
        //closeLevelMenu.onClick.AddListener(OnLvlMenuClecked);
        buttonToPlayerMenu.onClick.AddListener(OnPlayerMenuClecked);
        buttonToMainMenu.onClick.AddListener(OnPlayerMenuClecked);
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
        play.onClick.RemoveListener(OnPlayClicked);
    }
    private void OnPlayerMenuClecked()
    {
        audioManager.Play(UIClipName.LvlMenu);
        playerMenu.SetActive(!playerMenu.activeInHierarchy);
        OnChangeMenuStatusClicked();
    }
    private void OnLvlMenuClecked()
    {
        audioManager.Play(UIClipName.LvlMenu);
        levelMenu.SetActive(!levelMenu.activeInHierarchy);
        OnChangeMenuStatusClicked();
    }
    private void OnPlayClicked()
    {
        audioManager.Play(UIClipName.Play);
        menu.SetActive(!menu.activeInHierarchy);
        OnChangeMenuStatusClicked();
    }
    private void OnResetClicked()
    {
        audioManager.Play(UIClipName.Reset);
       // play.GetComponentInChildren<Text>().text = "NEW GAME";
        levelManager.ResetProgres();
    }
}
