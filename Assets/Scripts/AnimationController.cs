using TMPro;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [SerializeField] PlayerMugimendua movingScript;
    [SerializeField] Animator playerShipAnimator;
    [SerializeField] TextMeshPro tittleText;
    [SerializeField] TextMeshPro restetText;

    void Awake()
    {
        tittleText.enabled = true;
        movingScript.enabled = false;
        playerShipAnimator.enabled = false;
        restetText.enabled = false;
    }

    public void EnableControlls()
    {
        tittleText.enabled = false;
        movingScript.enabled = true;
    }

    public void ActivateAnimation()
    {
        playerShipAnimator.enabled = true;
    }
}
