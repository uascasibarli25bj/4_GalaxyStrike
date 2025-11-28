using UnityEngine;

public class CollisionHandle : MonoBehaviour
{
    [SerializeField] GameObject suntsituVFX;
    GameSceneManager gameSceneManager;

    private void Start()
    {
        gameSceneManager = FindFirstObjectByType<GameSceneManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        gameSceneManager.ReloadLevel();
        Instantiate(suntsituVFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
