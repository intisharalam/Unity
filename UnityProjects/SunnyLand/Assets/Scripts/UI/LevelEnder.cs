using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnder : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public static bool LevelComplete = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            LoadNextLevel();
        }
    }
    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel());
        EndOfGame();
    }

    public void EndOfGame()
    {
        Application.Quit();
    }

    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);
    }
}
