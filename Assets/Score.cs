using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update

    private int score;
    public static Score instance;
    public Text scoreText;
    public Text win;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        scoreText = GameObject.Find("Score").GetComponent<Text>();
        win = GameObject.Find("Win").GetComponent<Text>();
        score = 0;
        setText();
    }

    private void Update()
    {
        if(score >= 100)
        {
            win.text = "Ganaste!!";
            Invoke("Inicio", 2f);
        }
    }

    public void AumentarScore(int points)
    {
        score += points;
        setText();
    }

    private void setText()
    {
        scoreText.text = "Score: " + score; 
    }

    public void Inicio()
    {
        SceneManager.LoadScene("Menu");
    }

}
