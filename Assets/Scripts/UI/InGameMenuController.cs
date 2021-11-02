using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameMenuController : BaseGameMenuController
{
    [Header("Buttons")]
    [SerializeField] private Button restart;
    [SerializeField] private Button restart1;
    [SerializeField] private Button restart2;
    [SerializeField] private Button nextLvl;
    [SerializeField] private Button backToMenu;
    [SerializeField] private Button backToMenu1;

    [Header("GameOver")]
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] public Text gameOverHeader;
    [SerializeField] public Text DistanceValue;
    [SerializeField] public Text CoinsValue;
    [SerializeField] public Text RecordValue;


    [Header("GameWin")]
    [SerializeField] private GameObject lvlComplete;
    //[SerializeField] private Camera playerCamera;
    protected override void Start()
    {
        base.Start();
        play.onClick.AddListener(OnChangeMenuStatusClicked);
        restart.onClick.AddListener(OnRestartClicked);
        restart1.onClick.AddListener(OnRestartClicked);
        restart2.onClick.AddListener(OnRestartClicked);
        //nextLvl.onClick.AddListener(levelManager.EndLevel);
        backToMenu.onClick.AddListener(OnGoToMainMenuClicked);
        backToMenu1.onClick.AddListener(OnGoToMainMenuClicked);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        play.onClick.RemoveListener(OnChangeMenuStatusClicked);
        restart.onClick.RemoveListener(OnRestartClicked);
        restart1.onClick.RemoveListener(OnRestartClicked);
        restart2.onClick.RemoveListener(OnRestartClicked);
       // nextLvl.onClick.RemoveListener(levelManager.EndLevel);
        backToMenu.onClick.RemoveListener(OnGoToMainMenuClicked);
        backToMenu1.onClick.RemoveListener(OnGoToMainMenuClicked);
    }
    private void OnRestartClicked()
    {
        OnChangeMenuStatusClicked();
        SceneTransition.Restart();
    }
    protected override void OnChangeMenuStatusClicked()
    {
        base.OnChangeMenuStatusClicked();
        Time.timeScale =(menu.activeInHierarchy ? 0 : 1);
    }

    public void OnGoToMainMenuClicked()
    {
        OnChangeMenuStatusClicked();
        SceneTransition.SwitchToScene(0);
    }
    public void OnPlayerDeath()
    {
        //-3.4 2.8 -14
        //-2.4 2 -8
        //PlayerPrefs.SetInt(SceneManager.GetActiveScene().buildIndex+"PlayerRecord", );
        RecordValue.text = PlayerPrefs.GetInt(SceneManager.GetActiveScene().buildIndex + "PlayerRecord").ToString();
        int record = Convert.ToInt32(RecordValue.text);
        int distanse = Convert.ToInt32(DistanceValue.text);
        if (record <= distanse) 
        {
            gameOverHeader.text = "NEW RECORD!";
            gameOverHeader.color = new Color(135,148, 37);
            RecordValue.text = distanse.ToString();
            audioManager.Play(UIClipName.Сongratulations);
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().buildIndex + "PlayerRecord", distanse);
        }
        RecordValue.text += "m";
        DistanceValue.text += "m";
        gameOverMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void OnPlayerWin(){
        //lvlComplete.SetActive(true);
        //Time.timeScale = 0;
    }
}
