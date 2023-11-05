using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
  
public class Player : MonoBehaviour  
{  
    // Variable that defines the radius of the detection area  
    public float detectionRadius = 10f; 
  
    void Update()  
    {  
        // Debug.Log("---------Update");
        // We keep checking if there are bullets in the detection area every frame  
        DetectBullet();  
    }  
  
    private void DetectBullet()  
    {  
        
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, detectionRadius);  
  
        foreach (var hit in hits)   
        {  
            if(hit.gameObject.tag == "Bullet")   
            {   
                ApplyRandomEffect();  
                break;
            }  
        } 
    }  
  
    private void ApplyRandomEffect()  
    {  
        // Randomly pick a number  
        int effect = Random.Range(0, 2);  
  
        switch(effect)  
        {  
            case 0:  
                SlowDown();
                break;  
            case 1:  
                MoveRandomly();
                break;  
        }  
    }  
  
    private void SlowDown()  
    {  
        // Logic for slowing down the player  
        Debug.Log("----------------------               SlowDown");
    }  
  
    private void MoveRandomly()  
    {  
        // Logic for making the player move randomly  
        Debug.Log("**********************                  MoveRandomly");
    }  

}  
