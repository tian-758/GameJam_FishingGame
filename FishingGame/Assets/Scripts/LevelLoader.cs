using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public GameObject bgm;
    public float transitionAnimationDuration = 1f;

    public void LoadNextScene() {

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

    }

    IEnumerator LoadLevel(int levelIndex) {
        transition.SetTrigger("Start");

        StartCoroutine(bgm.GetComponent<AudioContoller>().StartFade(transitionAnimationDuration, 0f));
        yield return new WaitForSeconds(transitionAnimationDuration);

        SceneManager.LoadScene(levelIndex);
    }
}
