using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private InputSystem_Actions inputActions;

    private Vector2 moveInput;

    [Header("PlayerVariables")]
    [SerializeField] private float speed = 5f;

    private void Awake()
    {
        inputActions = new InputSystem_Actions();
    }

    private void Update()
    {
        Vector3 movePosition = new Vector3(moveInput.x, moveInput.y, 0f);
        
        transform.position += movePosition * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            FindAnyObjectByType<GameManager>().SetGameStatus(true);
        }
    }

    private void OnEnable()
    {
        inputActions.Enable();

        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;
    }

    private void OnDisable()
    {
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Move.canceled -= OnMove;

        inputActions.Disable();
    }

    private void OnMove(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }
}