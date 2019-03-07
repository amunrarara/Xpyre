using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    protected Vector2 m_Movement;
    protected Vector2 m_Camera;
    protected float m_Jump;


    public Vector2 MoveInput
    {
        get
        {
            return m_Movement;
        }
    }

    public Vector2 CameraInput
    {
        get
        {
            return m_Camera;
        }
    }

    public float JumpInput
    {
        get
        {
            return m_Jump;
        }
    }



    void Update()
    {
        m_Movement.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        m_Camera.Set(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        m_Jump = Input.GetAxisRaw("Jump");
    }
}
