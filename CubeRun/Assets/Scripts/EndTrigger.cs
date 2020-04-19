using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public Game_Manager gameManager;

    void OnTriggerEnter()
    {
        gameManager.CompleteLevel();
    }

}
