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
    public GameObject button;

    public bool addedEvent;
    public bool inGame;
    public float score;
    public float highscore;

    public string format;

    private GameObject[] game;

    private void Awake()
    {
        // Sees if a GameManger is already initalized, and if so delete this one
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
            highScore == null || button == null)
        {
            button = GameObject.FindWithTag("Button");
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
                addedEvent = false;
                if (score < highscore)
                {
                    score = highscore;
                }
            }
        }

        if (!inGame && highScore != null && button != null)
        {
            if (!addedEvent)
            {
                button.GetComponent<Button>().onClick.AddListener(OnButton);               
                addedEvent = true;
            }
            score = Mathf.Floor(score);
            format = string.Format($"Highscore: {score}");
            highScore.GetComponent<Text>().text = format;
        }
    }

    public void AddButton()
    {

    }

    public void OnButton()
    {
        highscore = score;
        SceneManager.LoadScene("SHMUP");
        inGame = true;
    }
}
