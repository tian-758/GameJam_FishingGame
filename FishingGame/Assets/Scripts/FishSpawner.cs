using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    [SerializeField]private GameObject fishLowWorth;
    [SerializeField]private GameObject fishMediumWorth;
    [SerializeField]private GameObject fishHighWorth;

    [SerializeField]private float spawnIntervalLow = 7f;
    [SerializeField]private float spawnIntervalMed = 18f;
    [SerializeField]private float spawnIntervalHigh = 30f;
  

    // Start is called before the first frame update
    void OnEnable()
    {

        StartCoroutine(spawnFish(spawnIntervalLow, fishLowWorth));
        StartCoroutine(spawnFish(spawnIntervalMed, fishMediumWorth));
        StartCoroutine(spawnFish(spawnIntervalHigh, fishHighWorth));

    }

    void Update() {
        
    }

    private IEnumerator spawnFish(float interval, GameObject fish) {
           
        yield return new WaitForSeconds(interval);
        GameObject newFish = Instantiate(fish, new Vector2(Random.Range(-30, 30), Random.Range(-6, -1)), Quaternion.identity);
        StartCoroutine(spawnFish(interval, fish));

    }
}
