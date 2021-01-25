using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    [Header("Movement Attributes")]
    [Description("How fast the character changes direction. (units/s/s)")]
    public float acceleration;

    [Description("The max speed of the character. (units/s)")]
    public float maxSpeed;

    [Header("Position Limits")]
    [Description("The default position the character goes to if action key is not held.")]
    public Transform defaultPosition;

    [Description("The default position the character goes to if action key is held down.")]
    public Transform actionPosition;

    [Description("The max rotation (degrees) the body can turn.")]
    public float maxBodyRotation = 90;

    [Description("The max amount (degrees) the tail can turn.")]
    public float maxTailRotation = 15;

    [Header("References")]
    public Transform Tail1;
    public Transform Tail2;

    private float tailTurn;
    private float lastSpeed;
    private Vector3 target;
    private Rigidbody rb;

    void Awake()
    {
        target = defaultPosition.position;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!GameController.IsPlaying)
            // Wait until the game has started
            return;

        Vector3 movement = Vector3.zero;
        lastSpeed = rb.velocity.y;

        // Set speed based on game speed
        maxSpeed = GameController.Speed;
        acceleration = GameController.Speed * 2.5f;

        #region Vertical Movement

        if (Mathf.Abs(target.y - transform.position.y) < acceleration * 0.0004)
            rb.velocity = new Vector3(rb.velocity.x, 0f);

        else if (Mathf.Abs(target.y - transform.position.y) <= (rb.velocity.y * rb.velocity.y) / (2 * acceleration))
        {
            // Getting close to the target, start decelerating
            if (rb.velocity.y < 0)
                // Target is below
                // Accelerate upwards
                rb.AddForce(Vector3.up * acceleration, ForceMode.Acceleration);  

            else
                // Target is above
                // Accelerate downwards
                rb.AddForce(Vector3.down * acceleration, ForceMode.Acceleration);                        
        }

        else if (transform.position.y < target.y)
            // Target is above
            // Accelerate upwards
            rb.AddForce(Vector3.up * acceleration, ForceMode.Acceleration);
        
        else if (transform.position.y > target.y)
            // Target is below
            // Accelerate downwards
            rb.AddForce(Vector3.down * acceleration, ForceMode.Acceleration);

        #endregion

        // Set the velocity
        rb.velocity = new Vector3(Mathf.Clamp(target.x - transform.position.x, -maxSpeed * 0.5f, maxSpeed * 0.5f), Mathf.Clamp(rb.velocity.y, -maxSpeed, maxSpeed), 0f);
    }

    // Late Update changes rotation values AFTER the animator
    private void LateUpdate()
    {
        #region Animation

        // If velocity has changed, character is changing speed, tail should move
        if (rb.velocity.y > lastSpeed + GameController.Acceleration)
            // Flip tail up
            tailTurn -= Time.deltaTime * 60f;

        else if (rb.velocity.y < lastSpeed - GameController.Acceleration)
            // Flip tail down
            tailTurn += Time.deltaTime * 60f;

        // Velocity is constant, return tail to straight
        else if (tailTurn < 0)
            // Return tail to 0 from up
            tailTurn += Mathf.Clamp(Time.deltaTime * 60f, 0f, Mathf.Abs(tailTurn));
        else
            // Return tail to 0 from down
            tailTurn -= Mathf.Clamp(Time.deltaTime * 60f, 0f, Mathf.Abs(tailTurn));

        // Clamp rotation between the max values
        tailTurn = Mathf.Clamp(tailTurn, -maxTailRotation, maxTailRotation);
        float bodyTurn = Mathf.Clamp(9f * rb.velocity.y, -maxBodyRotation, maxBodyRotation);

        // Rotate the objects changing only the z euler value
        transform.localRotation = Quaternion.AngleAxis(bodyTurn, Vector3.forward);
        Tail1.Rotate(Vector3.forward, tailTurn);
        Tail2.Rotate(Vector3.forward, tailTurn);

        #endregion
    }

    public void OnDiveToggle(InputAction.CallbackContext context)
    {
        target = context.canceled ? defaultPosition.position : actionPosition.position;
    }
}
