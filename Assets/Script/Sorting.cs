using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "Foreground";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
