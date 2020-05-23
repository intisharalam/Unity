using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    bool gameHasEnded = false;
    public float restartDelay = 1f;
    public GameObject complteLevelUI;



    public void CompleteLevel()
        {
            complteLevelUI.SetActive(true);
        }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            
        gameHasEnded = true;
        Debug.Log("Game Over");
        Invoke("Restart", restartDelay);

        }
    }

    void Restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
