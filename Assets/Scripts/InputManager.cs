using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// Sam Robichaud 
// NSCC Truro 2024
// This work is licensed under CC BY-NC-SA 4.0 (https://creativecommons.org/licenses/by-nc-sa/4.0/)

public class InputManager : MonoBehaviour
{
    // Script References
    [SerializeField] private PlayerLocomotionHandler playerLocomotionHandler;
    [SerializeField] private CameraManager cameraManager; // Reference to CameraManager


    [Header("Movement Inputs")]
    public float verticalInput;
    public float horizontalInput;
    public bool jumpInput;
    public Vector2 movementInput;
    public float moveAmount;

    // new !!!
    public PlayerInputActions playerControls;
    public InputAction playerControl;
    private InputAction move;
    private InputAction look;
    private InputAction sprint;
    private InputAction jump;


    [Header("Camera Inputs")]
    public float scrollInput; // Scroll input for camera zoom
    public Vector2 cameraInput; // Mouse input for the camera

    public bool isPauseKeyPressed = false;


    // New input system !!!

    private void OnEnable()
    {
        move = playerControls.Player.Move;
        move.Enable();

        look = playerControls.Player.Look;
        look.Enable();

        sprint = playerControls.Player.Sprint;
        sprint.Enable();

        jump = playerControls.Player.Jump;
        jump.Enable();


    }

    private void OnDisable()
    {
        move.Disable();
        look.Disable();
        sprint.Disable();
        jump.Disable();
    }

    private void Awake()
    {
        playerControls = new PlayerInputActions();
    }


    public void HandleAllInputs()
    {
        HandleMovementInput();
        HandleSprintingInput();
        HandleJumpInput();
        HandleCameraInput();
        HandlePauseKeyInput();
    }

    private void HandleCameraInput()
    {


        cameraManager.zoomInput = scrollInput;
        cameraManager.cameraInput = cameraInput;


        // Get mouse input for the camera
        //cameraInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        cameraInput = look.ReadValue<Vector2>();


        // Get scroll input for camera zoom
        scrollInput = Input.GetAxis("Mouse ScrollWheel");

        // Send inputs to CameraManager
        cameraManager.zoomInput = scrollInput;
        cameraManager.cameraInput = cameraInput;
    }


    private void Fire()
    {
        Debug.Log("Fire");
    }

    private void HandleMovementInput()
    {
        //movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        movementInput = move.ReadValue<Vector2>();

        horizontalInput = movementInput.x;
        verticalInput = movementInput.y;
        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
    }




    private void HandlePauseKeyInput()
    {
        isPauseKeyPressed = Input.GetKeyDown(KeyCode.Escape); // Detect the escape key press
    }

    private void HandleSprintingInput()
    {
        if (sprint.ReadValue<float>() > 0)
        {
            playerLocomotionHandler.isSprinting = true;
        }
        else
        {
            playerLocomotionHandler.isSprinting = false;
        }
    }

    private void HandleJumpInput()
    {
        jumpInput = jump.WasPressedThisFrame(); // Detect jump input (spacebar)
        if (jumpInput)
        {
            playerLocomotionHandler.HandleJump(); // Trigger jump in locomotion handler
        }
    }





}