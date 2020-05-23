using UnityEngine;
using TMPro;

public class ScoreManagerCherry : MonoBehaviour
{
    public static ScoreManagerCherry ScManagerCherry;
    public TextMeshProUGUI text;
    int Score;

    // Start is called before the first frame update
    void Start()
    {
        if (ScManagerCherry == null)
        {
            ScManagerCherry = this;
        }   
    }

    public void ChangeScore(int CherryValue)
    {
        Score = Score + CherryValue;
        text.text = "x" + Score.ToString();
    }
}
