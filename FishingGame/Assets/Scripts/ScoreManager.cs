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
    public Text pointText;
    [SerializeField]
    public HighTide tide;
    [SerializeField]
    public int pointsTillHighTide;
    private int pointsLeft;
    public static int score;
    public static int points;
    private bool canCountDown;

    private void Awake() {
        score = 0;
        points = 0;
        instance = this;
        pointsLeft = pointsTillHighTide;

    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "Fish Caught: " + score;
        pointText.text = "Money Earned: $" + points;
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
            pointText.text = "Money Earned: $" + points;

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
