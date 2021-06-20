using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Thief : MonoBehaviour
{
    private Animator myAnim;
    private Transform target;
    public Transform homePos;
    [SerializeField]
    private float speed = 3f;
    [SerializeField]
    private float maxRange = 0;
    [SerializeField]
    private float minRange = 0;

    NavMeshAgent agent;


    public float tempoEspera;
    float tempo;
    public Vector3 maxiPosition;
    public Vector3 miniPosition;

    public GameObject shot;
    public float timeBtwShots;
    public float startTimeBtwShots;

    public static bool isAttacking = false;


    void Start()
    {
    

        myAnim = GetComponent<Animator>();
        target = FindObjectOfType<Player>().transform;

        tempo = tempoEspera;
        timeBtwShots = startTimeBtwShots;

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

    }

    // Update is called once per frame
    void Update()
    {
      

        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position)>= minRange)
        {
         FollowPlayer();
        }
        else if(Vector3.Distance(target.position, transform.position) >= maxRange)
        {
            GoHome();
        }

        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position)>= minRange && timeBtwShots <= 0)
        {
            Instantiate(shot, transform.position, Quaternion.identity);
            timeBtwShots = startTimeBtwShots;
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        if(isAttacking)
        {
            myAnim.SetBool("isAttacking", true);
        }
        else
        {
            myAnim.SetBool("isAttacking", false);
        }

    }


    public void FollowPlayer()
    {
        myAnim.SetFloat("Horizontal", (target.position.x - transform.position.x));
        myAnim.SetFloat("Vertical", (target.position.y - transform.position.y));
        myAnim.SetBool("isMoving", true);
        agent.isStopped = false;

      //  transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
        agent.SetDestination(target.position);
    }

    void GoHome()
    {
        myAnim.SetFloat("Horizontal", (homePos.position.x - transform.position.x));
        myAnim.SetFloat("Vertical", (homePos.position.y - transform.position.y));   
        agent.SetDestination(homePos.position);

        if (Vector3.Distance(transform.position, homePos.position) <=1)
        {
            agent.isStopped = true;
            transform.position = Vector3.MoveTowards(transform.position, homePos.transform.position, Time.deltaTime);
            
            if(Vector3.Distance(transform.position, homePos.position) == 0)
            {   
                if(tempo <= 0)
                {
                    myAnim.SetBool("isMoving", true);
                    homePos.position = new Vector3(Random.Range(maxiPosition.x, miniPosition.x), Random.Range(maxiPosition.y, miniPosition.y));
                    tempo = tempoEspera;
                    agent.isStopped = false;
                }
                else
                { 
                    myAnim.SetBool("isMoving", false);
                    tempo -= Time.deltaTime;
                }
            }
        }        
        
    }

   private void OnTriggerEnter2D(Collider2D other)
   {
       if (other.tag == "MyWeapon")
       {
           Vector3 difference = transform.position - other.transform.position;
           transform.position = new Vector3(transform.position.x + difference.x, transform.position.y + difference.y);

       }
   }
}
