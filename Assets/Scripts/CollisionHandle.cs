using UnityEngine;

public class CollisionHandle : MonoBehaviour
{
    [SerializeField] GameObject suntsituVFX;
    void OnTriggerEnter(Collider other)
    {
        Instantiate(suntsituVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
