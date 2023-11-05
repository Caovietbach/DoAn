using System.Collections;  
using UnityEngine;  
  
public class playerMovement : MonoBehaviour  
{  
    public GameObject slowSign;
    public Transform Sign;
    public float moveSpeed = 5f;
    
    
    public Rigidbody2D rb;  
    public Animator animator;  
    Vector2 movement;  
    Vector3 lastPos;
    private bool isSlowingDown = false;  
    private bool isMovingRandomly = false;  
    public float slowDownFactor = 0.5f; // Factor to slow the player speed  
    public float slowDownDuration = 2f; // Duration to keep the player slowed  
    public float randomMoveDuration = 10f; // Duration between changing random move direction  
    public float detectionRadius = 10f; 
    private float speed;
    private float baseMoveSpeed; 
    int chosenLevel; 
    public GameObject Slow;  
    public GameObject Fear;


    void Awake()  // deactive the "Debuffs" sign at the start of the game
    {  
        Slow.SetActive(false);
        Fear.SetActive(false);  
        chosenLevel = PlayerPrefs.GetInt("chosenLevel");
        Debug.Log("moveSpeed = " + moveSpeed);

        if(chosenLevel == 1){
            baseMoveSpeed = 10f;
        }
        if(chosenLevel == 2){
            baseMoveSpeed = 3f;
        }
        if(chosenLevel == 3){
            baseMoveSpeed = 1f;
        }
    }


    // Update is called once per frame  
    void Update()  
    {  
        movement.x = Input.GetAxisRaw("Horizontal");  
        movement.y = Input.GetAxisRaw("Vertical");  
        animator.SetFloat("Speed",movement.sqrMagnitude);  
        if (movement.sqrMagnitude > 0){  
            speed = baseMoveSpeed + moveSpeed;
            animator.SetBool("Crawl",false); 
            animator.SetFloat("Horizontal",movement.x);  
            animator.SetFloat("Vertical",movement.y);  
            if (Input.GetKey(KeyCode.LeftShift)){
                speed = 1f;
                animator.SetBool("Crawl", true);
                animator.SetFloat("Horizontal",movement.x);  
                animator.SetFloat("Vertical",movement.y); 
            }
        }
        DetectBullet();
    }  
  
    void FixedUpdate(){  
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);  
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
        if(!isSlowingDown)  
        {  
            StartCoroutine(SlowDownCoroutine());  
        }  
    }  

    private void MoveRandomly()  
    {  
        if(!isMovingRandomly)  
        {  
            StartCoroutine(MoveRandomlyCoroutine());  
        }  
    }

    IEnumerator SlowDownCoroutine()  
    {  
        Debug.Log("----------------------               SlowDownCoroutine");
        isSlowingDown = true;  // setting up the debuff
        Slow.SetActive(isSlowingDown); // active the icon of slowing down 
        var originalMoveSpeed = moveSpeed;  
        moveSpeed *= slowDownFactor;  
        yield return new WaitForSeconds(slowDownDuration);  
        moveSpeed = originalMoveSpeed;  
        isSlowingDown = false;  // the slow debuff is wear off
        Slow.SetActive(isSlowingDown);  // deactive the icon of slowing down
    }  
  
  
  
    IEnumerator MoveRandomlyCoroutine()  
    {  
        Debug.Log("----------------------               MoveRandomlyCoroutine");
        isMovingRandomly = true;  
        
        while (isMovingRandomly)  
        {  
            Fear.SetActive(isMovingRandomly); // active the icon of moving random
            movement = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));  
            yield return new WaitForSeconds(randomMoveDuration);  
        }  
        
        //Fear.SetActive(isMovingRandomly); // deactive the icon of moving random
        
    }  
  
    public void StopMovingRandomly()  
    {  
        isMovingRandomly = false;  
    }  

}  