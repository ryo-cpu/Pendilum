using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreController:MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    int Score;

    void Start()
    {
        UpdateScoreText();
        Score = 0;
    }
    public void Add(int score)
    {
        Debug.LogWarning(Score);
        this.Score += score;
        Debug.LogWarning(Score);

    }
    public int GetScore()
    {
        return this.Score;
    }
    void UpdateScoreText()
    {
        ScoreText.text = "Score: " + Score;
    }

    void Update()
    {
        UpdateScoreText();
    }
}
