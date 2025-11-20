
using UnityEngine;

public class Etsaia : MonoBehaviour
{
    [SerializeField] float lifes = 1;
    [SerializeField] GameObject suntsituVFX;
    void OnParticleCollision(GameObject other)
    {
        lifes--;

        if (lifes <= 0)
        {
            Instantiate(suntsituVFX, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
