using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Player_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    protected PlayerInput m_Input;


    public float speed = 6f;
    public float jumpMagnitude = 10f;

    Vector3 movement;
    Vector3 JumpForce;
    Vector3 FlatCamDirection;
    Rigidbody playerRigidbody;


    // Update is called once per frame
    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        m_Input = GetComponent<PlayerInput>();
    }
    void FixedUpdate()
    {
        Movement();
        Jump();
    }

    void Movement()
    {
        float horizontal = m_Input.MoveInput.x;
        float vertical = m_Input.MoveInput.y;

        FlatCamDirection = new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z);
        movement = ((vertical * FlatCamDirection) + (horizontal * Camera.main.transform.right)) * Time.deltaTime;

        movement = movement.normalized * speed * Time.deltaTime;

        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Jump()
    {
        float up = m_Input.JumpInput;
        JumpForce.Set(0f, up, 0f);
        GetComponent<Rigidbody>().AddForce(JumpForce * jumpMagnitude, ForceMode.Impulse);
    }
}