using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class gameover : MonoBehaviour
{

    public GameObject gameOverScreen;
    bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Player>().OnPlayerDeath += OnGameOver;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
                Player.hp = 3;
            }
        }
    }

    void OnGameOver()
    {
        gameOverScreen.SetActive(true);
        gameOver = true;
    }
}
