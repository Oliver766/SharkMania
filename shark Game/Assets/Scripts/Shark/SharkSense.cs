using System.Collections.Generic;
using UnityEngine;

public class SharkSense : MonoBehaviour
{
    [SerializeField] SharkController controller = null;
    
    private List<PreyPickup> nearbyPrey;

    private void Awake()
    {
        nearbyPrey = new List<PreyPickup>();
    }

    private void OnTriggerEnter(Collider other)
    {       
        if (other.CompareTag("Prey"))
        {
            // Prey has entered the sense area
            // Add it to the list of nearby prey
            nearbyPrey.Add(other.GetComponent<PreyPickup>());
        }

        UpdatePrey();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Prey"))
        {
            // Prey has exited the sense area
            // Remove it from the list of nearby prey
            nearbyPrey.Remove(other.GetComponent<PreyPickup>());
        }

        UpdatePrey();
    }

    public void UpdatePrey()
    {
        nearbyPrey.RemoveAll(item => item == null);

        if (nearbyPrey.Count == 0)
            // No nearby prey
            controller.SetPrey(null);

        else
            // Select any nearby prey
            controller.SetPrey(nearbyPrey[0]);
    }
}
