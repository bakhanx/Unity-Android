using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float mouseSensitivity = 100f;

    public float xRotation = 0f;
    public Camera cam;


    public CharacterController controller;
    public float gravity = -9.8f;

    Vector3 velocity;

    public Transform groundCheck;
    public float groundDistance;
    public LayerMask groundMask;

    private bool isGrounded;

    public Text text;
    
    private RaycastHit hitInfo;
    public static RaycastHit hit;
    [SerializeField] private float range;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        PlayerMove();
        MouseRotate();
        TextEnable();
        hit = hitInfo;
    }

    private void PlayerMove()
    {
        float moveDirX = Input.GetAxis("Horizontal");
        float moveDirZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveDirX + transform.forward * moveDirZ;

        controller.Move(move * moveSpeed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }

    private void MouseRotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        this.transform.Rotate(Vector3.up * mouseX);
    }

    private void TextEnable()
    {
        if (Physics.Raycast(cam.transform.position, cam.transform.TransformDirection(Vector3.forward), out hitInfo, range))
        {
            if (hitInfo.transform.tag == "Interactive" || hitInfo.transform.tag == "Item")
            {
                Debug.Log(hitInfo.transform.tag);
                text.enabled = true;
            }
            else
            {
                text.enabled = false;
            }
           
        }
    }
}
