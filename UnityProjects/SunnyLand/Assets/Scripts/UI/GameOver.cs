using UnityEngine;

public class GameOver : MonoBehaviour
{
    public static bool GameIsOver = false;
    public GameObject GameOverUI;

    void FixedUpdate()
    {
        if (GameIsOver)
        {
            GamesOver();
        }
    }

    public void GamesOver()
    {
        GameOverUI.SetActive(true);
    }

}
