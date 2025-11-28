using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    public void ReloadLevel()
    {
        StartCoroutine(ReloadCurrentLevel());
    }

    IEnumerator ReloadCurrentLevel()
    {
        yield return new WaitForSeconds(0);
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
