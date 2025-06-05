using UnityEngine;

public class ScoreController:MonoBehaviour
{
    int Score;

    void Start()
    {
        Score = 0;
    }
    public void Add(int score)
    {
        this.Score += score;
    }
    public int GetScore()
    {
        return this.Score;
    }
}
