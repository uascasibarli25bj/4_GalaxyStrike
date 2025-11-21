using TMPro;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    int score = 0;
    [SerializeField] private TextMeshProUGUI puntuazioTextua;
    public void ScoreHit(int scorePerHit)
    {
        score += scorePerHit;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        puntuazioTextua.text = score.ToString();
    }
}
