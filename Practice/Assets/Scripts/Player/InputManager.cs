using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerInput playerInput;
    public PlayerInput.OnFootActions onFoot;

    private PlayerMovement playerMovement;

    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;

        playerMovement = GetComponent<PlayerMovement>();

        onFoot.Interact.performed += ctx => playerMovement.Interact();
    }

    void FixedUpdate()
    {
        playerMovement.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
        playerMovement.ProcessLook(onFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }

    private void OnDisable()
    {
        onFoot.Disable();
    }
}
