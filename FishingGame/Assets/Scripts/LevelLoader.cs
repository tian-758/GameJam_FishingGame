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
    public string nextSceneName;

    private void Start()  {
        //data = GameObject.FindGameObjectsWithTag("Data")[0].GetComponent<MainManager>(); 
    }

    public void LoadNextScene() {

        if (score != null) {
            //data.fishCaught = ScoreManager.score;
            //data.points = ScoreManager.points;

        }

        
        StartCoroutine(LoadLevel(nextSceneName));

    }

    IEnumerator LoadLevel(string nextScene) {
        transition.SetTrigger("Start");

        StartCoroutine(bgm.GetComponent<AudioContoller>().StartFade(transitionAnimationDuration, 0f));
        yield return new WaitForSeconds(transitionAnimationDuration);

        SceneManager.LoadScene(nextScene);
    }
}
