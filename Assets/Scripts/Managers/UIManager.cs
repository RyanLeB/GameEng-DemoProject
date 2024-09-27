﻿using System.Collections;
using UnityEngine.UI;
using UnityEngine;

// Sam Robichaud 
// NSCC Truro 2024
// This work is licensed under CC BY-NC-SA 4.0 (https://creativecommons.org/licenses/by-nc-sa/4.0/)

public class UIManager : MonoBehaviour
{
    public LevelManager levelManager;

    // References to UI Panels
    public GameObject mainMenuUI;
    public GameObject gamePlayUI;
    public GameObject gameOverUI;
    public GameObject pauseMenuUI;
    public GameObject optionsMenuUI;
    public GameObject creditsMenuUI;
    public GameObject loadingScreen;


    // Gameplay Specific UI Elements
    public Text LevelCount;

    [Header("Loading Screen")]
    public Slider loadingBar;

    public void UpdateLevelCount(int count)
    {
        if (LevelCount != null)
        { LevelCount.text = count.ToString(); }

        if (LevelCount = null)
        { Debug.LogError("LevelCount is not assigned to UIManager in the inspector!"); }
    }


    public void UIMainMenu()
    {
        DisableAllUIPanels();
        mainMenuUI.SetActive(true);
    }

    public void UIGamePlay()
    {
        DisableAllUIPanels();
        gamePlayUI.SetActive(true);
    }

    public void UIGameOver()
    {
        DisableAllUIPanels();
        gameOverUI.SetActive(true);
    }

    public void UIPaused()
    {
        DisableAllUIPanels();
        pauseMenuUI.SetActive(true);
    }

    public void UIOptions()
    {
        DisableAllUIPanels();
        optionsMenuUI.SetActive(true);
    }


    public void UICredits()
    {
        DisableAllUIPanels();
        creditsMenuUI.SetActive(true);
    }

    public void LoadingUI()
    {
        DisableAllUIPanels();
     
    }


    public void DisableAllUIPanels()
    {
        mainMenuUI.SetActive(false);
        gamePlayUI.SetActive(false);
        gameOverUI.SetActive(false);
        pauseMenuUI.SetActive(false);
        optionsMenuUI.SetActive(false);
        creditsMenuUI.SetActive(false);
    }

    public void EnableAllUIPanels()
    {
        mainMenuUI.SetActive(true);
        gamePlayUI.SetActive(true);
        gameOverUI.SetActive(true);
        pauseMenuUI.SetActive(true);
        optionsMenuUI.SetActive(true);
        creditsMenuUI.SetActive(false);
    }

    public void DisableLoadScreen(GameObject targetUI)
    {
        DisableAllUIPanels();

        if (targetUI == gamePlayUI)
        {
            gamePlayUI.SetActive(true);
        }
        else if (targetUI == mainMenuUI)
        {
            mainMenuUI.SetActive(true);
        }
    }

    public void UILoadingScreen()
    {
        DisableAllUIPanels();
        loadingScreen.SetActive(true);
    }

    private IEnumerator LoadingBarProgress()
    {
        while (!levelManager.sceneLoad.isDone)
        {
            loadingBar.value = levelManager.GetLoadingProgress();
            yield return null;
        }
    }
}
