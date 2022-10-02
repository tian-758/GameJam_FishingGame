using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;

    private int score;

    private void Awake() {
        score = 0;
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Fish Caught: " + score;
    }

    public void AddPoint() {
        score += 1;
        scoreText.text = "Fish Caught: " + score;
    }

    private void OnTriggerEnter2D(Collider2D Fish) {
        if(Fish.tag == "Fish"){
            score++;
            scoreText.text = "Fish Caught: " + score;
        }
    }
}
