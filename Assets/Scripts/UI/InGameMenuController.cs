﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    [Header("GameWin")]
    [SerializeField] private GameObject lvlComplete;
    //[SerializeField] private Camera playerCamera;
    protected override void Start()
    {
        base.Start();
        play.onClick.AddListener(OnChangeMenuStatusClicked);
        restart.onClick.AddListener(levelManager.Restart);
        restart1.onClick.AddListener(levelManager.Restart);
        restart2.onClick.AddListener(levelManager.Restart);
        nextLvl.onClick.AddListener(levelManager.EndLevel);
        backToMenu.onClick.AddListener(OnGoToMainMenuClicked);
        backToMenu1.onClick.AddListener(OnGoToMainMenuClicked);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        play.onClick.RemoveListener(OnChangeMenuStatusClicked);
        restart.onClick.RemoveListener(levelManager.Restart);
        restart1.onClick.RemoveListener(levelManager.Restart);
        restart2.onClick.RemoveListener(levelManager.Restart);
        nextLvl.onClick.RemoveListener(levelManager.EndLevel);
        backToMenu.onClick.RemoveListener(OnGoToMainMenuClicked);
        backToMenu1.onClick.RemoveListener(OnGoToMainMenuClicked);
    }
    protected override void OnChangeMenuStatusClicked()
    {
        base.OnChangeMenuStatusClicked();
        Time.timeScale =(menu.activeInHierarchy ? 0 : 1);
    }

    public void OnGoToMainMenuClicked()
    {
        LevelManager.Instance.ChangeLvl((int)Scenes.MainMenu);
    }
    public void OnPlayerDeath()
    {
        //-3.4 2.8 -14
        //-2.4 2 -8
        gameOverMenu.SetActive(true);
        Time.timeScale = 0;
    }
    public void OnPlayerWin(){
        lvlComplete.SetActive(true);
        Time.timeScale = 0;
    }
}
