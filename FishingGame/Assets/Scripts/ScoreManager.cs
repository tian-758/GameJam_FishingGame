using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    [SerializeField]
    public Text scoreText;
    [SerializeField]
    public Text highscoreText;
    [SerializeField]
    public Text pointText;
    [SerializeField]
    public HighTide tide;
    [SerializeField]
    public int pointsTillHighTide;
    private int pointsLeft;
    public int sceneID;
    int score; // public static int score to share score across scenes
    int points;
    int highscoreFish;
    int highscorePoints;
    private bool canCountDown;

    private void Awake() {
        score = 0;
        points = 0;
        highscoreFish = 0;
        highscorePoints = 0;
        instance = this;
        pointsLeft = pointsTillHighTide;

    }

    // Start is called before the first frame update
    void Start()
    {
        highscorePoints = PlayerPrefs.GetInt("highscorePoints", 0);
        highscoreFish = PlayerPrefs.GetInt("highscoreFish", 0);
        scoreText.text = "Fish Caught: " + score;
        pointText.text = "Points: " + points;
        highscoreText.text = "Highscore: " + highscoreFish + " fish  " + highscorePoints + " points";
        canCountDown = true;
    }

    public void AddPoint() {
        score += 1;
        scoreText.text = "Fish Caught: " + score;
    }

    private void OnTriggerEnter2D(Collider2D Fish) {
        if(Fish.tag == "Fish"){
            score++;
            points += Fish.gameObject.GetComponent<FishMovement>().pointWorth;

            scoreText.text = "Fish Caught: " + score;
            pointText.text = "Points: " + points;

            int savedScorePoints = PlayerPrefs.GetInt("highscorePoints" + sceneID);
            int savedScoreFish = PlayerPrefs.GetInt("highscoreFish" + sceneID);

            if(savedScorePoints < points) {
                savedScorePoints = points;
                PlayerPrefs.SetInt("highscorePoints" + sceneID, points);
            }

            if(savedScoreFish < score) {
                savedScoreFish = score;
                PlayerPrefs.SetInt("highscoreFish" + sceneID, score);
            }
            highscoreText.text = "Highscore: " + savedScoreFish + " fish  " + savedScorePoints + " points";

            if (canCountDown) {

                pointsLeft -= Fish.gameObject.GetComponent<FishMovement>().pointWorth;

            }

            if (pointsLeft <= 0) {
                pointsLeft = pointsTillHighTide;
                StartCoroutine(startHightide());
            }
            
        }
    }

    IEnumerator startHightide() {

        tide.activateHighTide();

        canCountDown = false;

        yield return new WaitForSeconds(tide.highTideDuration);

        tide.deactivateHighTide();

        canCountDown = true;
    }
}
