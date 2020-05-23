using UnityEngine;
using TMPro;

public class ScoreManagerGem : MonoBehaviour
{
    public static ScoreManagerGem ScManagerGem;
    public TextMeshProUGUI text;
    int Score;

    // Start is called before the first frame update
    void Start()
    {
        if (ScManagerGem == null)
        {
            ScManagerGem = this;
        }
    }

    public void ChangeScore(int GemValue)
    {
        Score = Score + GemValue;
        text.text = "x" + Score.ToString();
    }
}
