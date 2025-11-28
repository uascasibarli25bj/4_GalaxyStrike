using Unity.VisualScripting;
using UnityEngine;

public class Etsaia : MonoBehaviour
{
    [SerializeField] float lifes = 1;
    [SerializeField] GameObject suntsituVFX;
    [SerializeField] AudioClip suntsituSound;

    [SerializeField] int scorePoints = 20;
    Scoreboard scoreboard;

    void Start()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        lifes--;

        if (lifes <= 0)
        {
            Instantiate(suntsituVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);

            AudioSource.PlayClipAtPoint(suntsituSound, Camera.main.transform.position, 2f);

            scoreboard.ScoreHit(scorePoints);
        }
    }
}
