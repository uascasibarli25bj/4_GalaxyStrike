using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ComponentController : MonoBehaviour
{
    [SerializeField] GameObject playerShip;
    [SerializeField] GameObject targetPoint;
    [SerializeField] TextMeshPro scoreboard;
    [SerializeField] TextMeshPro endScore;
    [SerializeField] TextMeshPro resterText;

    void Start()
    {
        playerShip.SetActive(true);
        targetPoint.SetActive(true);
        scoreboard.gameObject.SetActive(true);
        endScore.gameObject.SetActive(false);
        resterText.enabled = false;
    }

    public void ShowEndScore()
    {
        scoreboard.gameObject.SetActive(false);
        endScore.gameObject.SetActive(true);
    }

    public void EnableResterText()
    {
        resterText.enabled = true;
    }
}