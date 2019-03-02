using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessionObject : MonoBehaviour
{
    // True if player is controlling the object
    private bool isControlled; 

    //True if player can currently possess the object
    private bool isPossessable;

    //True if object is turnable
    private bool isTurnable;

    //True if object is slideable
    private bool isSlideable;
}
