using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreyPickup : Pickup
{
    /// <summary>
    /// Called when the prey is initial caught by the shark.
    /// </summary>
    public void Caught()
    {
        // Prey is caught, stop any animation that could cause issues
        // TODO: Stop prey animation when caught
    }
}
