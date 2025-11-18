using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{
    [Header("Partikulak")]
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform joPuntua;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 100f;

    bool isFiring = false;

    void Start()
    {
        Cursor.visible = false;
    }

    private void Update()
    {
        ProcessFiring();
        MugituJoPuntua();
        MugituTargetPoint();
    }

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }

    void ProcessFiring()
    {
        foreach (GameObject laser in lasers)
        {
            var emmisionModule = laser.GetComponent<ParticleSystem>().emission;
            emmisionModule.enabled = isFiring;
        }
    }

    void MugituJoPuntua()
    {
        joPuntua.position = Mouse.current.position.ReadValue();
    }

    void MugituTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }
    
    // public ParticleSystem laser1;
    // public ParticleSystem laser2;

    // void Start()
    // {
    //     laser1.Stop();
    //     laser2.Stop();
    // }

    // public void OnFire(InputValue value)
    // {
    //     if (value.isPressed)
    //     {
    //         laser1.Play();
    //         laser2.Play();
    //     }
    //     else
    //     {
    //         laser1.Stop();
    //         laser2.Stop();
    //     }
    // }
}
