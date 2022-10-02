using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField]
    public float timeValue = 300;
    public Text timeText;

    [SerializeField]
    public LevelLoader loadNextScene;

    // Update is called once per frame
    void Update()
    {
        if(timeValue > 0) {
            timeValue -= Time.deltaTime;
        }
        else {
            timeValue = 0;
        }

        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay) {
        if(timeToDisplay < 0) {
            timeToDisplay = 0;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            loadNextScene.LoadNextScene();
        }
        else if(timeToDisplay > 0){
            timeToDisplay += 1;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
