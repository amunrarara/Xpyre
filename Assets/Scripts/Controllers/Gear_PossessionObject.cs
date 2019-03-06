using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear_PossessionObject : PossessionObject
{

    public float turnSpeed = 50f;
    public float ToothCount;
    public bool isPossessed;

    public List<GameObject> children = new List<GameObject>();

    private bool parented = false;

    public Material m_red;
    public Material m_blue;
    public Material m_green;
    public Material m_grey;


    private void Awake()
    {
        children.Clear();
    }

    private void Start()
    {
        foreach (GameObject child in children)
        {
            child.GetComponent<Gear_PossessionObject>().parented = true;
        }
    }

    private void Update()
    {
        if (parented)
        {
            return;
        }

        if (!isPossessed)
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

        if (children.Count >= 1)
        {
            foreach (GameObject child in children)
            {
                child.GetComponent<Gear_PossessionObject>().Rotate(-rotation * ToothCount);
            }
        }
    
    }
 
            

    public void Rotate(float rotation)
    {
        rotation /= ToothCount;
        transform.Rotate(transform.up * rotation);

        foreach (GameObject child in children)
        {
            child.GetComponent<Gear_PossessionObject>().Rotate(-rotation * ToothCount);

        }
    }

    public void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Gear") && !other.gameObject.GetComponent<Gear_PossessionObject>().isPossessed)
            {

            // Add touching gear as a child in the list
            children.Add(other.gameObject);
                other.gameObject.GetComponent<Gear_PossessionObject>().parented = true;
                // Set color to red             
                other.GetComponentInChildren<MeshRenderer>().material = m_red;
            }
    }

    private void OnTriggerStay (Collider other)
    {

    }

    private void OnTriggerExit (Collider other)
    {
        if (other.CompareTag("Gear") && !other.gameObject.GetComponent<Gear_PossessionObject>().isPossessed)
        {
            other.gameObject.GetComponent<Gear_PossessionObject>().parented = false;
            // Set color to red             
            other.GetComponentInChildren<MeshRenderer>().material = m_grey;

            children.Remove(other.gameObject);

        }
    }
  
}

