using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleSphere : MonoBehaviour
{
    public GameObject LavaGate;
    public GameObject UnlockTorus;
    public GameObject Sphere;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Unlock Ending"))   //unlock the ending
        {
            LavaGate.SetActive(false);
            Sphere.SetActive(false);
            UnlockTorus.SetActive(false);
            
        }
    }
}
