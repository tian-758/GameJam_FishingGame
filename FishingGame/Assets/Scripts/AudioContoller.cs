using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioContoller : MonoBehaviour
{

    [SerializeField]
    public AudioSource intro;
    [SerializeField]
    public AudioSource loop;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(beginLoop());
    }


    IEnumerator beginLoop() {
        
        if (intro != null) {
            intro.Play();
            yield return new WaitForSeconds(intro.clip.length);
            intro.Stop();
        }

        loop.Play();

    }
}
