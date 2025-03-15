using System.Collections;
using UnityEngine;
using TMPro;  // Import TextMeshPro for UI text

public class Timer : MonoBehaviour
{
    public float timeRemaining = 180f; // 3 minutes = 180 seconds
    public TextMeshProUGUI timerText; // Reference to the UI text
    private bool timerRunning = true;

    void Start()
    {
        UpdateTimerDisplay(); // Show initial time
        StartCoroutine(StartCountdown()); // Start the coroutine
    }

    IEnumerator StartCountdown()
    {
        while (timeRemaining > 0 && timerRunning)
        {
            yield return new WaitForSeconds(1f); // Wait for 1 second
            timeRemaining--;
            UpdateTimerDisplay();
        }

        if (timeRemaining <= 0)
        {
            OnTimerEnd();
        }
    }

    void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60);
        int seconds = Mathf.FloorToInt(timeRemaining % 60);
        timerText.text = $"{minutes:00}:{seconds:00}"; // Format as MM:SS
    }

    void OnTimerEnd()
    {
        Debug.Log("Time's Up! Game Over!");
        // Add logic for game over (e.g., show a game over screen)
    }

    // Optional: Call this to stop the timer
    public void StopTimer()
    {
        timerRunning = false;
    }

    // Optional: Call this to restart the timer
    public void RestartTimer()
    {
        timeRemaining = 180f;
        timerRunning = true;
        UpdateTimerDisplay();
        StartCoroutine(StartCountdown()); // Restart the coroutine
    }
}

void OnTimerEnd()
{
    timerRunning = false;
    Debug.Log("Time's Up! Game Over!");
    Time.timeScale = 0; // Pause the game
    ShowGameOverMessage(); // Display a UI message
}
