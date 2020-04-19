using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject MenuUI;
    public GameObject InstructionUI;

    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return))
        {
            Instructions();
        }
    }

    public void Instructions()
    {
        MenuUI.SetActive(false);
        InstructionUI.SetActive(true);
        StartCoroutine(PlayGame());
        
    }

    IEnumerator PlayGame()
    {
        yield return new WaitForSeconds(5);
        LevelEntry.NextLevel = true;
    }

}
