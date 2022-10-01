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
    public GameObject floor;

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
        
        
    }

    public void deactivateHighTide()
    {
        character.transformToNormal();
        normalSpawner.SetActive(true);
        superSpawner.SetActive(false);
    }

}
