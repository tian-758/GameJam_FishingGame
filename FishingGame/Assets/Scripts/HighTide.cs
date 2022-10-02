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
    public Camera camera;

    


    public bool activated;

    // Start is called before the first frame update
    void Start()
    {
        
        activated = true;

    }

    void Update() {

        if (Input.GetKey("q") && activated) {
            activateHighTide();
            activated = false;
        }
        
        if (Input.GetKey("w") && activated) {
            deactivateHighTide();
            activated = false;
        }

        if (Input.GetKey("e")) {
            activated = true;
        }

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
        
        Vector3 newPosition = camera.transform.position + new Vector3(0f, distance, 0f);

        while (camera.transform.position.y <= newPosition.y) {
            camera.transform.position = new Vector3(camera.transform.position.x, Vector3.Lerp(camera.transform.position, newPosition, .1f).y, camera.transform.position.z);
            yield return new WaitForSeconds(.01f);
        }

    }
    private IEnumerator moveCamDown(float distance) {
        
        Vector3 newPosition = camera.transform.position - new Vector3(0f, distance, 0f);

        while (camera.transform.position.y >= newPosition.y) {
            camera.transform.position = new Vector3(camera.transform.position.x, Vector3.Lerp(camera.transform.position, newPosition, .1f).y, camera.transform.position.z);
            yield return new WaitForSeconds(.01f);
        }

    }
}
