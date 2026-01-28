using TMPro;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] PlayerMugimendua movingScript;
    [SerializeField] Animator playerShipAnimator;
    [SerializeField] TextMeshPro restetText;

    void Awake()
    {
        movingScript.enabled = false;
        playerShipAnimator.enabled = false;
        restetText.enabled = false;
    }

    public void EnableControlls()
    {
        movingScript.enabled = true;
    }

    public void ActivateAnimation()
    {
        playerShipAnimator.enabled = true;
    }
}
