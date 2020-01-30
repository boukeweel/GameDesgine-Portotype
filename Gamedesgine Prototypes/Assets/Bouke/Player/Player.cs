using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    CharacterController cc;
    bool curserlockt = true;
    [SerializeField] float speed = 3;
    [Header("how fast the player wil jump")]
    [SerializeField] float JumpHeight;
    float yspeed = 0;

    [Header("the gravity")]
    [SerializeField]float gravity = -15f;

    [Header("Camera")]
    public Transform fpsCamera;
    float pitch = 0f;

    [Header("Range")]
    //[Range(1, 15)]
    public float mousesensetifity = 2f;

    [Range(45, 85)]
    public float pitchrange = 45;


    //floats for speed
    float xInput = 0f;
    float zInput = 0f;
    float xMouse = 0f;
    float yMouse = 0f;
    private void Awake()
    {
        LockCurser();
    }
    private void Start()
    {
        cc = GetComponent<CharacterController>();
    }
    private void unlockcurser()
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

        if (cc.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                yspeed = JumpHeight;
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
        cc.Move((move + new Vector3(0, yspeed, 0)) * Time.deltaTime);



        transform.Rotate(0, xMouse, 0);


        pitch -= yMouse;
        pitch = Mathf.Clamp(pitch, -pitchrange, pitchrange);
        Quaternion camRotation = Quaternion.Euler(pitch, 0, 0);
        fpsCamera.localRotation = camRotation;
    }


}
