//
//
// A Control_Node is a type of Node that allows the Player to take control of the parent Object
//
//


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control_Node : Node
{


    void Awake()
    {
        isControlNode = true;
    }

    public void ControlThisNode ()
    {
        // This function tells the GameController to pass Player control from Ball to This Node's Object
        //
        // Called when:
        // 1) Player is making collision with this Node,
        // 2) then presses the "Control This Object button"
    }

    public void StopControllingThisNode ()
    {
        // This function tells the GameController to pass Player control from this Node's Object to the Ball
        //
        // Called when:
        // 1) The Player is controlling this Node's Object,
        // 2) The Player presses the "Stop Controlling Object button"
    }
}
