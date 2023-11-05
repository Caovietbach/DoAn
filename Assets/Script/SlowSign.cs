using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fearSign : MonoBehaviour
{
    public bool isSlow = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isSlow == true){
            Destroy(gameObject);
        }
    }
}
