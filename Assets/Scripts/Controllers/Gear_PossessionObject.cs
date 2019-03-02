using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear_PossessionObject : PossessionObject
{

    public float turnSpeed = 50f;
    public float ToothCount;

    public Gear_PossessionObject[] children;

    private bool parented = false;


    private void Start()
    {
        for (int i = 0; i < children.Length; i++)
        {
            children[i].parented = true;
        }
    }

    private void Update()
    {
        if (parented)
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

        for (int i = 0; i < children.Length; i++)
        {
            children[i].Rotate(-rotation * ToothCount);
        }
    }
 
            

    public void Rotate(float rotation)
    {
        rotation /= ToothCount;
        transform.Rotate(transform.up * rotation);

        for (int i = 0; i < children.Length; i++)
        {
            children[i].Rotate(-rotation * ToothCount);

        }
    }
  
}

