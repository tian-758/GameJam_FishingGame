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

    
    public IEnumerator StartFade(float duration, float targetVolume)
    {
        float currentTime = 0;
        float start = loop.volume;
        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            loop.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }

}
