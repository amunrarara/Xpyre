//
//
// This script holds the logic for node-based movement. The code within can be copied into our Player movement architecture
//
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node_Based_Movement : MonoBehaviour
{
    private bool bool_AtNode = false;

    public Node start_Node;
    public Node current_Node;
    public Node previous_Node;
    public Node next_Node;

    public float move_speed = 2f;

    private Rigidbody rb_ball;
    private PlayerInput m_Input;
    private Vector3 FlatCamDirection;
    private Vector3 ball_movement;



    void Awake()
    {
        rb_ball = GetComponent<Rigidbody>();
        m_Input = GetComponent<PlayerInput>();
    }

    void Start()
    {
        bool_AtNode = true;
        current_Node = start_Node;

        if (current_Node == null)
        {
            Debug.Log("Ball needs a Start Node");
        }

        if (transform.position != current_Node.transform.position)
        {
            transform.position = current_Node.transform.position;
        }

        start_Node.DisplayArrows();

    }

    void FixedUpdate()
    {
        if (!bool_AtNode)
        {
            MoveOnPath();
            return;
        }

        AtNode(current_Node);
    }

    void OnTriggerEnter(Collider other)
    {
        if (bool_AtNode)
        {
            return;
        }

        if (other.CompareTag("Node"))
          {
            bool_AtNode = true;
            AtNode(other.GetComponent<Node>());
         }
            // When a collision with a trigger occurs, check to see if it is a Node, a Control_Node, or something else
            // If it is a Control_Node, trigger triggered_Node.ControlThisNode();

    }

    void OnTriggerExit(Collider other)
    {
        // When Ball leaves a Node's Collider
        previous_Node = current_Node;
        current_Node = null;
        bool_AtNode = false;

        previous_Node.StopDisplayArrows();
    }


    // AtNode()
    // Called when Player collides with a Node
    // . Set current_Node to collided Node
    // . Get List of Connected Nodes,
    // . Lock the Player to the Node until they choose a new direction, 
    // . Displays available directions, 
    // . When Player chooses a new direction, call NextNode(chosen_Node)

    void AtNode(Node node)
    {

        if (current_Node != node)
        {
            current_Node = node;

            current_Node.DisplayArrows();
        }

        // If Ball's transform != to the centerpoint of the Node, move it to the center
        if (transform.position != current_Node.transform.position)
        {
            float distance = Vector3.Distance(current_Node.transform.position, transform.position);
            transform.position = Vector3.MoveTowards(transform.position, current_Node.transform.position, Time.deltaTime * move_speed);
        }


            // This is the actual keypress that chooses a new Path (asssigns next_Node)
            string str_InputKey = Input.inputString;

        switch (str_InputKey)
        {
            // Moving in the direction of a Path
            case "w":
                next_Node = current_Node.connected_Nodes[1];
                bool_AtNode = false;
                break;

            case "s":
                next_Node = current_Node.connected_Nodes[0];
                bool_AtNode = false;
                break;

            default:
                break;
        }

    }


        // NextNode()
        // Called from AtNode() when Player has chosen a new direction to travel
        // 1. Set next_Node
        // 2. Set previous_Node
        // 3. Clear current_Node
        // Get all connected Nodes from Node

        void NextNode(Node chosen_Node)
    {

    }

    void MoveOnPath()
    {
        // Receives Player Input and moves Player on a Path between Nodes
        // While on a Path, press forward to move along it in the direction you are facing, and backward to move in the opposite direction

        float vertical = 1f;

        if (vertical > 0f)
        {
            if (next_Node != null)
            {
                float distance = Vector3.Distance(next_Node.transform.position, transform.position);
                transform.position = Vector3.MoveTowards(transform.position, next_Node.transform.position, Time.deltaTime * move_speed);
            }
        }
        else if (vertical < 0f)
        {
            if (previous_Node != null)
            {
                float distance = Vector3.Distance(previous_Node.transform.position, transform.position);
                transform.position = Vector3.MoveTowards(transform.position, previous_Node.transform.position, Time.deltaTime * move_speed);
            }
        }



        //        FlatCamDirection = new Vector3(Camera.main.transform.forward.x, 0f, Camera.main.transform.forward.z);

        //        ball_movement = ((vertical * FlatCamDirection) + (horizontal * Camera.main.transform.right)) * Time.deltaTime;

        //        ball_movement = ball_movement.normalized * move_speed * Time.deltaTime;

        //       rb_ball.MovePosition(transform.position + ball_movement);

    }
}
