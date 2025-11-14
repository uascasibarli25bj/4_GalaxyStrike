using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [Header("Partikulak")]
    public ParticleSystem particleSystem;

    public void OnFire(InputValue value)
    {
        particleSystem.Play();
    }
}
