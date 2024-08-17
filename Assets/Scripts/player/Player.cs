using System.Runtime.ConstrainedExecution;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    Vector2 moveInput;


    PlayerInputActions playerInputActions;


    CharacterController characterController;
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Move.started += context => { moveInput = context.ReadValue<Vector2>(); };
        playerInputActions.Player.Move.performed += context => { moveInput = context.ReadValue<Vector2>();};
        playerInputActions.Player.Move.canceled += context => { moveInput = context.ReadValue<Vector2>(); };

    }

    private void Start()
    {
        characterController = GetComponent<CharacterController>(); 
    }
    private void Update()
    {
        Move(moveInput);
    }

    private void Move(Vector2 movePosition) {
        if (moveInput != Vector2.zero) { 
            characterController.Move(new Vector3(movePosition.x, 0f, movePosition.y));
        }
    }
    private void OnEnable()
    {
        playerInputActions.Player.Move.Enable();
    }

    private void OnDisable()
    {
        playerInputActions.Player.Move.Disable();
    }
}
