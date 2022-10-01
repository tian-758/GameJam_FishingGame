using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public bool activateNextScene = false;
    public float transitionAnimationDuration = 1f;

    // Update is called once per frame
    void Update()
    {
        if (activateNextScene) {
            LoadNextScene();
        }
    }

    public void LoadNextScene() {

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

    }

    IEnumerator LoadLevel(int levelIndex) {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionAnimationDuration);

        SceneManager.LoadScene(levelIndex);
    }
}
