using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public GameObject bgm;
    public MainManager data;
    public ScoreManager score;
    public float transitionAnimationDuration = 1f;

    private void Start()  {
        data = GameObject.FindGameObjectsWithTag("Data")[0].GetComponent<MainManager>(); 
    }

    public void LoadNextScene() {

        if (score != null && data != null) {
            data.fishCaught = score.score;
            data.points = score.points;

        }

        
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

    }

    IEnumerator LoadLevel(int levelIndex) {
        transition.SetTrigger("Start");

        StartCoroutine(bgm.GetComponent<AudioContoller>().StartFade(transitionAnimationDuration, 0f));
        yield return new WaitForSeconds(transitionAnimationDuration);

        SceneManager.LoadScene(levelIndex);
    }
}
