using UnityEngine;

public class SharkController : MonoBehaviour
{
    [SerializeField] Transform preyPosition = null;
    private PreyPickup prey;
    private Animator animator;
    private bool attacking;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    /// <summary>
    /// Grabs the prey it has referenced.
    /// </summary>
    public void Grab()
    {
        // Move the prey to the eating position
        prey.transform.position = preyPosition.position;
        prey.transform.parent = preyPosition;
        prey.transform.localRotation = Quaternion.Euler(0f, 0f, 0f);
        
        prey.Caught();
    }

    /// <summary>
    /// Kills the prey and collects the bonuses.
    /// </summary>
    public void Kill()
    {
        // Collect the prey and remove from focus
        prey.Collected();       
        attacking = false;
        SetPrey(null);
    }

    /// <summary>
    /// Attack a given prey.
    /// </summary>
    /// <param name="target">The prey to attack.</param>
    public void Attack(PreyPickup target)
    {
        if (attacking)
            return;

        // Set prey and start to eat it
        SetPrey(target);
        animator.SetTrigger("Eat");
        attacking = true;
    }

    /// <summary>
    /// Change the prey that the shark targets.
    /// </summary>
    /// <param name="target">The new prey to target.</param>
    public void SetPrey(PreyPickup target)
    {
        if (attacking)
            return;

        // Update prey and whether nearby prey
        prey = target;
        animator.SetBool("NearPrey", prey != null);
    }
}