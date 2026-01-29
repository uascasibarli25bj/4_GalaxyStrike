using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    int score = 0;
    [SerializeField] private TextMeshPro puntuazioTextua;
    [SerializeField] private TextMeshPro endScoreboard;
    public void ScoreHit(int scorePerHit)
    {
        score += scorePerHit;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        puntuazioTextua.text = score.ToString();
        endScoreboard.text = 
            "YOUR  SCORE: \n" +
            "____________\n\n" +
            score.ToString();
    }
}
