using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(1, 15)]
    public float mousesensetifity = 5f;

    [Range(45, 85)]
    public float visualrange = 45;

    [SerializeField] float speed = 3;
    [SerializeField] float Jump;
    [SerializeField] float gravity = -15f;

    public Transform fpsCamera;

    CharacterController characterController;

    bool curserlockt = true;
    float yspeed = 0;
    float visualspeed = 0f;

    //float for speed
    float xInput = 0f;
    float zInput = 0f;
    float xMouse = 0f;
    float yMouse = 0f;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        LockCurser();
    }
    private void UnlockCurser()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    private void Update()
    {
        GetInputs();
        Updatemovement();
    }
    private void LockCurser()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    void GetInputs()
    {
        xInput = Input.GetAxis("Horizontal") * speed;
        zInput = Input.GetAxis("Vertical") * speed;
        xMouse = Input.GetAxis("Mouse X") * mousesensetifity;
        yMouse = Input.GetAxis("Mouse Y") * mousesensetifity;
    }
    void Updatemovement()
    {
        Vector3 move = new Vector3(xInput * speed, 0, zInput * speed);
        move = Vector3.ClampMagnitude(move, speed);
        move = transform.TransformVector(move);

        if (characterController.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                yspeed = Jump;
            }
            else
            {
                yspeed = gravity * Time.deltaTime;
            }
        }
        else
        {
            yspeed += gravity * Time.deltaTime;
        }

        characterController.Move((move + new Vector3(0, yspeed, 0)) * Time.deltaTime);
        transform.Rotate(0, xMouse, 0);

        visualspeed-= yMouse;
        visualspeed = Mathf.Clamp(visualspeed, -visualrange, visualrange);

        Quaternion camRotation = Quaternion.Euler(visualspeed, 0, 0);
        fpsCamera.localRotation = camRotation;
    }
}
