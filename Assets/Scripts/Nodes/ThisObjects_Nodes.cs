//
//
// This Script does the following: 
// 1) Collect all Nodes attached to this Object into a single Array,
// 2) Use a constantly-updating list to keep track of which Paths to draw (why?) <<<<<
// 3) If bool_DrawLines is true, draw lines in the Editor for Paths and Nodes
//
//


using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ThisObjects_Nodes : MonoBehaviour
{
    // Draw lines in the Editor?
    public bool bool_DrawLines;

    // Draw color of the paths and nodes
    private Color rayColor = Color.green;

    // Array collects all Transforms attached to this Object
    private Transform[] children_array;

    // List collects all NODE Transforms attached to this Object
    private List<Transform> node_objs = new List<Transform>();


    void Start()
    {
        children_array = GetComponentsInChildren<Transform>();
        foreach (Transform child in children_array)
        {
            if (child.gameObject.CompareTag("Node"))
            {
                node_objs.Add(child.gameObject.transform);
            }

        }

        Debug.Log(children_array.Length);
        Debug.Log(node_objs.Count);

    }

// Try this script without the List logic and see what happens <<<<<
    void OnDrawGizmos()
    {
        if (!bool_DrawLines)
        {
            return;
        }

        Gizmos.color = rayColor;
        children_array = GetComponentsInChildren<Transform>();
        node_objs.Clear();

        foreach (Transform child in children_array)
        {
            if (child.gameObject.CompareTag("Node"))
            {
                node_objs.Add(child.gameObject.transform);
            }

        }

        for (int i = 0; i < node_objs.Count; i++)
        {
            Vector3 position = node_objs[i].position;
            if (i > 0)
            {
                Vector3 previous = node_objs[i - 1].position;
                Gizmos.DrawLine(previous, position);
                Gizmos.DrawWireSphere(previous, 0.3f);
                Gizmos.DrawWireSphere(position, 0.3f);
            }

        }

    }

}