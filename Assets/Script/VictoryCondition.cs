using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryCondition : MonoBehaviour
{
    private GameObject player;
    void OnTriggerEnter2D (Collider2D collider){
        if (collider.gameObject.CompareTag("Player")){
            Debug.Log("You Win");
            SceneManager.LoadScene("Map 2");
        }
    }
}
