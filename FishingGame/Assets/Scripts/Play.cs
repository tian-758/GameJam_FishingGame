using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("VisualNovel_Act1");
        Debug.Log("Moved to next scene.");
    }
}
