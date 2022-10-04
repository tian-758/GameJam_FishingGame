using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighTide : MonoBehaviour
{
    [SerializeField]
    public Move character;
    [SerializeField]
    public GameObject normalSpawner;
    [SerializeField]
    public GameObject superSpawner;
    [SerializeField]
    public Camera mainCamera;
    [SerializeField]
    public int highTideDuration;


    // Start is called before the first frame update
    void Start()
    {

    }

    
    public void activateHighTide()
    {
        character.transformToSuper();
        normalSpawner.SetActive(false);
        superSpawner.SetActive(true);
        StartCoroutine(moveCamDown(2f));
        
    }

    public void deactivateHighTide()
    {
        character.transformToNormal();
        normalSpawner.SetActive(true);
        superSpawner.SetActive(false);
        StartCoroutine(moveCamUp(2f));
    }

    private IEnumerator moveCamUp(float distance) {
        
        Vector3 newPosition = mainCamera.transform.position + new Vector3(0f, distance, 0f);

        while (mainCamera.transform.position.y <= newPosition.y) {
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, Vector3.Lerp(mainCamera.transform.position, newPosition, .1f).y, mainCamera.transform.position.z);
            yield return new WaitForSeconds(.01f);
        }

    }
    private IEnumerator moveCamDown(float distance) {
        
        Vector3 newPosition = mainCamera.transform.position - new Vector3(0f, distance, 0f);

        while (mainCamera.transform.position.y >= newPosition.y) {
            mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, Vector3.Lerp(mainCamera.transform.position, newPosition, .1f).y, mainCamera.transform.position.z);
            yield return new WaitForSeconds(.01f);
        }

    }
}
