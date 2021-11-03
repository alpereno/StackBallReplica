using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;
    [SerializeField] private Text ScoreUI;
    Player player;
    bool gameOver;

    private void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        player.onPlayerDeath += onGameOver; // I used to event system because when UI screen doesn't exist player object must be executable.
                                            // and there is no sense of in the Player script has to reference UI script.
    }

    private void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }
    }
    void onGameOver() {
        gameOverScreen.SetActive(true);
        ScoreUI.text = player.Score.ToString();
        gameOver = true;
    }
}
