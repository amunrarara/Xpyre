//
//
// A Node is a place where the Player can choose between multiple branching paths. It is a rest point. It is a stop. 
//
// This script contains a List that holds all the Nodes this one is connected to. It also holds the necessary logic for defining which Node is going to be 
//

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node : MonoBehaviour
{

    public List<Node> connected_Nodes;
    public List<GameObject> glist_arrows;

    public bool isControlNode = false;


    public void DisplayArrows()
    {
        foreach (GameObject arrow in glist_arrows)
        {
            arrow.SetActive(true);
        }
    }

    public void StopDisplayArrows()
    {
        foreach (GameObject arrow in glist_arrows)
        {
            arrow.SetActive(false);
        }
    }
}