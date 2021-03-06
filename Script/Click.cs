using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{

    public Material glowMaterial, glassMaterial;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseDown()
    {
        if (PlayerController.interactable.name == "Sphere 1(Clone)")
        {
            PlayerController.interactable.GetComponent<MeshRenderer>().material = glowMaterial;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
