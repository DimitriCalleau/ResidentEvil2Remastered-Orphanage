using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class victoire : MonoBehaviour
{
    public bool triggerVictoire;

    public void OnTriggerEnter(Collider win)
    {
        if (triggerVictoire)
        {
            Debug.Log("Win");
            //Display.main("you win");
        }
    }
}
