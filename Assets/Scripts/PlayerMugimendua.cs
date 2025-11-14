using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMugimendua : MonoBehaviour
{
    [Header("Ontziaren Mugimendua")]
    public float moveSpeed = 10f;
    [SerializeField] float rollMaxRange = 45f;
    [SerializeField] float pitchMaxRange = 45f;

    [Header("Ontziaren Mugak")]
    [SerializeField] float xClampRange = 10f;
    [SerializeField] float yClampRange = 10f;

    Vector2 moveInput;

    void Update()
    {
        ProcessTraslation();
        ProcessRotation();
    }

    public void OnMugitu(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    public void OnFire(InputValue value)
    {
        
    }

    public void ProcessTraslation()
    {
        float xOffset = moveInput.x * moveSpeed * Time.deltaTime;
        float rawXpos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXpos, -xClampRange, xClampRange);

        float yOffset = moveInput.y * moveSpeed * Time.deltaTime;
        float rawYpos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYpos, -yClampRange, yClampRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, 0f);
    }

    void ProcessRotation()
    {
        float pitch = -moveInput.y * pitchMaxRange;
        float roll = -moveInput.x * rollMaxRange;

        Quaternion targetRotation = Quaternion.Euler(pitch, 0, roll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetRotation, Time.deltaTime * rollMaxRange);
    }
}