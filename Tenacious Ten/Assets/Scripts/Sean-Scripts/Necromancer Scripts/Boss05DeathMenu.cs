﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss05DeathMenu : MonoBehaviour
{
    private LevelManager levelManager;
    //public static bool GameIsPaused = false;

    public GameObject deathMenuUI;

    Boss05Camera cameraB;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        deathMenuUI.SetActive(false);
        cameraB = FindObjectOfType<Boss05Camera>();

    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerHealthManager.playerHealth <= 0)
        {
            deathMenuUI.SetActive(true);
            Time.timeScale = 0f;
        }
        
    }

    public void Respawn()
    {
        cameraB.transform.localPosition = cameraB.StartingPos;
        levelManager.RespawnPlayer();
        Debug.Log("Spawned after death.");
        deathMenuUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        Debug.Log("Quitting game");
        SceneManager.LoadScene("MainMenu");
    }
}
