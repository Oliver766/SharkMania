using UnityEngine;

public class SharkAttack : MonoBehaviour
{
    [SerializeField] SharkController controller = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Prey"))
        {
            controller.Attack(other.GetComponent<PreyPickup>());
        }
    }
}
