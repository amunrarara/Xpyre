using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear_Controller : MonoBehaviour
{ 
    
    public float turnSpeed = 50f;
    public float ToothCount;
    private bool isControlled;

    public List<Node> nodes = new List<Node>();
    public List<Control_Node> control_nodes = new List<Control_Node>();


    private void Update()
    {
        if (!isControlled)
        {
            return;
        }


        float rotation = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotation = turnSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rotation = -turnSpeed * Time.deltaTime;
        }

        transform.Rotate(transform.up, rotation, Space.World);
    
    }
 
            

    public void Rotate(float rotation)
    {
        rotation /= ToothCount;
        transform.Rotate(transform.up * rotation);
    }

    public void SetIsControlled(bool b)
    {
        isControlled = b;
    }

}

