using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [Description("The intial speed of the game when it starts (u/s).")]
    [SerializeField] float initialSpeed = 5;

    [Description("The max speed that the game can progress at (u/s).")]
    [SerializeField] float maxSpeed = 10;

    [Description("How fast the game speeds up (u/s/s).")]
    [SerializeField] float acceleration = 0.025f;

    [Description("Should the game start on load?")]
    [SerializeField] bool startOnLoad = false;

    [Header("Events")]
    [Description("Called when the game begins.")]
    public UnityEvent GameBeginEvent;

    [Description("Called when the player loses.")]
    public UnityEvent GameOverEvent;

    public static float Speed { get; private set; }
    public static float Acceleration { get => instance.acceleration; }
    public static int Score { get; set; }
    public static float Distance { get; set; }
    public static bool IsPlaying { get; private set; }

    private static GameController instance;

    private void Awake()
    {
        // Set the instance
        instance = this;  
    }

    private void Start()
    {
        // Begin the game is restarting or startOnPlay is enabled
        if (startOnLoad || IsPlaying)
            Begin();
    }

    private void Update()
    {
        // Increase the speed gradually while playing until it reaches max speed
        if (IsPlaying && Speed < maxSpeed)
            Speed += acceleration * Time.deltaTime;
    }

    /// <summary>
    /// Stops the game.
    /// </summary>
    public static void Stop()
    {
        Time.timeScale = 0;
        IsPlaying = false;
    }

    /// <summary>
    /// Begins the game.
    /// </summary>
    public static void Begin()
    {
        // Reset stats
        Score = 0;
        Speed = instance.initialSpeed;
        Distance = 0f;

        // Start the game
        IsPlaying = true;
        instance.GameBeginEvent.Invoke();
    }

    /// <summary>
    /// Signifies that the player has lost.
    /// </summary>
    public static void GameOver()
    {
        Stop();
        instance.GameOverEvent.Invoke();
    }

    /// <summary>
    /// Restarts the game bypassing the Main Menu.
    /// </summary>
    public static void Restart()
    {
        IsPlaying = true;       
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }

    /// <summary>
    /// Returns the game to the main menu.
    /// </summary>
    public static void MainMenu()
    {
        Stop();
        SceneManager.LoadScene("Game");
        Time.timeScale = 1;
    }
}
