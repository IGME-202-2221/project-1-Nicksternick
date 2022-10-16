using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{
    public GameObject vehicle;
    public GameObject text;
    public GameObject highScore;

    public bool inGame;
    public float score;

    public string format;

    private GameObject[] game;

    private void Awake()
    {
        game = GameObject.FindGameObjectsWithTag("GameController");

        if (game.Length == 1)
        {
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        inGame = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("SHMUP") &&
            vehicle == null || text == null)
        {
            vehicle = GameObject.FindWithTag("Player");
            text = GameObject.FindWithTag("Text");
        }

        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu") &&
            highScore == null)
        {
            highScore = GameObject.FindWithTag("Highscore");
        }

        if (inGame && vehicle != null)
        {
            text.GetComponent<Stats>().MaxScore = score;
            score = text.GetComponent<Stats>().Score;

            if (vehicle.GetComponent<Vehicle>().Health < 0)
            {
                score = text.GetComponent<Stats>().Score;
                SceneManager.LoadScene("MainMenu");
                inGame = false;
            }
        }

        if (!inGame && highScore != null)
        {
            score = Mathf.Floor(score);
            format = string.Format($"Highscore: {score}");
            highScore.GetComponent<Text>().text = format;
        }
    }

    public void OnButton()
    {
        SceneManager.LoadScene("SHMUP");
        
        inGame = true;

    }
}
