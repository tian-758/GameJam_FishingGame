using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public LevelLoader next;

    public void NextScene()
    {
        //SceneManager.LoadScene("VisualNovel_Act1");
        next.LoadNextScene();
        Debug.Log("Moved to next scene.");
    }
}
