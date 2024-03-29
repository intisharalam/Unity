﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEntry : MonoBehaviour
{
    public static bool NextLevel = false;
    public Animator transition;
    public float transitionTime = 1f;
    GameOver game;

    void Start()
    {
        GameOver game = GetComponent<GameOver>();
    }

    void Update()
    {
        if (NextLevel)
        {
            LoadNextLevel();
            game.GameOverUI.SetActive(false);
        }
    }
    
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
