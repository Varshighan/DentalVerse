using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class XRMovementNewInput : MonoBehaviour
{
    public InputActionProperty moveAction;
    public float speed = 2.0f;
    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        if (characterController == null)
        {
            Debug.LogError("CharacterController not found! Please add one to your XR Rig.");
        }
    }

    void Update()
    {
        if (characterController != null)
        {
            Vector2 input = moveAction.action.ReadValue<Vector2>();
            Vector3 move = transform.right * input.x + transform.forward * input.y;
            characterController.Move(move * speed * Time.deltaTime);
        }
    }
}
