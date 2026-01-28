using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMugimendua : MonoBehaviour
{
    [Header("Ontziaren Mugimendua")]
    public float moveSpeed = 10f;
    [SerializeField] float rollMaxRange = 45f;
    [SerializeField] float pitchMaxRange = 45f;

    [Header("Ontziaren Mugak")]
    [SerializeField] float xClampRange = 10f;
    [SerializeField] float yClampRange = 10f;

    [Header("Reset Sistema")]
    [SerializeField] GameObject playerShip;
    [SerializeField] AnimationController animationController;

    Vector2 moveInput;
    public bool canMove = true;
    public bool canReset = false;

    void Awake()
    {
        gameObject.SetActive(true);
        playerShip.SetActive(true);
        canMove = true;
        canReset = false;
    }

    public void DisableControlls()
    {
        canMove = false;
    }
    
    public void DisableShip()
    {
        playerShip.SetActive(false);
    }

    public void EnableReset()
    {
        Debug.Log("Reset Enabled");
        canReset = true;
    }

    void Update()
    {
        ProcessTraslation();
        ProcessRotation();
    }

    public void OnReset()
    {
        if (!canReset) return;

        Debug.Log("Reset Input Received");

        SceneManager.LoadScene(0);
    }

    public void OnMugitu(InputValue value)
    {
        if (!canMove) return;

        moveInput = value.Get<Vector2>();
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