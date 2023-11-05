using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patern : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPosition;
    public float speed = 5f;
    public Transform[] points;
    //public Animator animator;

    private float count;
    private GameObject Player;
    private float distance;
    private int pointIndex = 0;
    private Transform position ;
    

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        //animator = GetComponent<Animator>();
        transform.position = points[pointIndex].transform.position;
        //animator.SetBool("changePosition", false);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, Player.transform.position);
        //Debug.Log("Distance: " + distance);
        if (distance < 80){
            count += Time.deltaTime;
            if ( count >= 2){
                count = 0;
                shoot();
            }
        }
        
        if (distance <50){
            if (pointIndex <= points.Length - 1){
                Debug.Log("THe enemy is moved");
                transform.position = Vector2.MoveTowards(transform.position, points[pointIndex].transform.position, speed * Time.deltaTime);
                if (transform.position == points[pointIndex].transform.position)
                {
                    pointIndex += 1;
                }
            }
        }
        
        
    }
    

    void shoot(){
        Instantiate(bullet, bulletPosition.position, Quaternion.identity );
    }
}
