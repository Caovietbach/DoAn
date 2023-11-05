using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detonate : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update() {
    
    } 

    void OnTriggerEnter2D (Collider2D collider){
        
        if (collider.gameObject.CompareTag("Player")){
            collider.gameObject.GetComponent<PlayerDeath>().Bomb = true;
        }
    }
}
