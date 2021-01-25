using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] protected int worth = 0;

    /// <summary>
    /// Called when the pickup is collected.
    /// </summary>
    public virtual void Collected()
    {
        GameController.Score += worth;
        Debug.Log(name + " was collected.");
        Destroy();
    }

    /// <summary>
    /// Called when the pickup should be destroyed.
    /// </summary>
    public virtual void Destroy()
    {
        // Destroy the game object
        Destroy(gameObject);
    }
}
