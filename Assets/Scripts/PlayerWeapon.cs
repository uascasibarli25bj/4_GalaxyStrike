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
        AimLasers();
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
        Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, targetDistance))
        {
            targetPoint.position = hit.point;
        }
        else
        {
            targetPoint.position = ray.GetPoint(targetDistance);
        }
    }


    // void MugituTargetPoint()
    // {
    //     Vector3 targetPointPosition = new Vector3(Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y, targetDistance);
    //     targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    // }

    void AimLasers()
    {
        foreach (GameObject laser in lasers)
        {
            Vector3 fireDirection = targetPoint.position - laser.transform.position;
            Quaternion rotationTarget = Quaternion.LookRotation(fireDirection);

            laser.transform.rotation = rotationTarget;
        }
    }
}
