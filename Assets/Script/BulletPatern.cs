using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPatern : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public Animator animator;
    public float force;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2 (direction.x, direction.y).normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0 ,0 , rot + 90);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D (Collider2D collider){

        if (collider.gameObject.CompareTag("Wall")){
            Destroy(gameObject);
        }
        
        if (collider.gameObject.CompareTag("Player")){
            //animator.SetBool("hitByBullet",true);
            //Debug.Log("Player is hit!");
            collider.gameObject.GetComponent<PlayerDeath>().Bullet = true;
            collider.gameObject.GetComponent<PlayerDeath>().health -= 1;
            collider.gameObject.GetComponent<playerMovement>().moveSpeed = 0;
            Debug.Log(collider.gameObject.name);
            Destroy(gameObject);
        }
    }
}
