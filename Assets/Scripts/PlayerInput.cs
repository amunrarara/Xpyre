using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    protected Vector2 m_Movement;
    protected Vector2 m_Camera;



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



    void Update()
    {
        m_Movement.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        m_Camera.Set(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }
}
