using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerDeath : MonoBehaviour
{
    public float health;
    public Animator animator;
    public int condition;
    public bool Bullet = false;
    public bool Bomb = false;
    public GameObject player;

    void Start(){
        health = 1;
    }   

    void Update() {
        if (Bullet == true){
            Debug.Log("Player is hit!");
            player.GetComponent<playerMovement>().moveSpeed = 0;
            player.GetComponent<PlayerDeath>().health -= 1;
            animator.SetTrigger("hitByBullet");
        }
        if (Bomb == true){
            Debug.Log("Bomb is true");
            animator.SetTrigger("stepInBomb");
        }
    }

    void Reset() {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
    
        
        
}
