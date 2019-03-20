using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Ball_Controller ball_Controller;

    private Control_Node control_node = null;

    protected PlayerInput player_Input;

    void Start()
    {
        player_Input = GetComponent<PlayerInput>();
    }

    public void SetControlNode(Control_Node node)
    {
        control_node = node;
    }

    public void PassControlToGear(Node node)
    {
        ball_Controller.SetIsControlled(false);
        node.GetComponentInParent<Gear_Controller>().SetIsControlled(true);
    }
}
