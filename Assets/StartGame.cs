using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Text startText;

    private bool gameStarted = false;

    void Awake()
    {
        Time.timeScale = 0f; // Set time scale to 0 initially
        startText.text = "Press Spacebar to Start";
        StartCoroutine(BlinkText());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameStarted)
        {
            Time.timeScale = 1f; // Set time scale to 1 when spacebar is pressed
            gameStarted = true;
        }
    }

    private IEnumerator BlinkText()
    {
        while (!gameStarted)
        {
            startText.color = new Color(startText.color.r, startText.color.g, startText.color.b, Mathf.Sin(Time.time * 10f) * 0.5f + 0.5f);
            yield return null;
        }
    }
}