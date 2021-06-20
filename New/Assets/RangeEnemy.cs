/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class visaovilao : MonoBehaviour
{
[SerializeField]
    public float raioVisao,raioAtaque,vel;
    public LayerMask oqePlayer;
 
    [SerializeField]
     private GameObject player;
 
    [SerializeField]
    private Rigidbody2D rb2D;
 
    [SerializeField]
    private Vector3 posInicial;
    [SerializeField]
    private Vector3 alvo;
    [SerializeField]
    public float fov;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private Vector3 dir;
	public Rigidbody2D bala;
	private WaitForSeconds tempo = new WaitForSeconds(1.5f);
	private bool atk;

    public float life = 100;


    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        rb2D = GetComponent<Rigidbody2D>();
        posInicial = transform.position;
        alvo = posInicial;
    }
    public Vector3 DirFAngle(float angDeg){


        return new Vector3(Mathf.Sin(angDeg * Mathf.Deg2Rad), Mathf.Cos(angDeg * Mathf.Deg2Rad),0);
    }
	IEnumerator Tiro(){
		atk = true;
		Instantiate (bala, transform.position, Quaternion.identity);
		print ("Tiro");
		yield return tempo;
		atk = false;

	
	}
 /*
    private void Update()
    {
       /* if((Vector2.Angle(player.transform.position - transform.position, -transform.up)) <= fov * 0.5f){
            RaioJogador();
        }
        */

        /*
        if(dir.x != 0 || dir.y != 0)
        {
        anim.SetFloat("x", dir.x);
        anim.SetFloat("y", dir.y);
        }
        if(life <= 0){
            Destroy(gameObject);
        }
        RaioJogador();
        if(life <= 0){
            Sangue.instance.experience += 35;
            
        }
    }
 
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, raioVisao);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, raioAtaque);
    }
 
    void RaioJogador()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, player.transform.position - transform.position, raioVisao, oqePlayer);
        Vector3 temp = transform.TransformDirection(player.transform.position - transform.position);
        Debug.DrawRay(transform.position, temp, Color.cyan);
 
        if (hit.collider != null)
        {
            if (hit.collider.tag == "Player")
            {
                alvo = player.transform.position;
				if (!atk) {
					StartCoroutine ("Tiro");
				}
            }
           
        }else
        {
            alvo = posInicial;
        }
        
        float distanciaTemp = Vector3.Distance(alvo, transform.position);
        dir = (alvo - transform.position).normalized;
 
        if (alvo != posInicial && distanciaTemp < raioAtaque)
        {
            
        }
 
        else
        {
            rb2D.MovePosition(transform.position + dir * vel * Time.deltaTime);
        }
 
        if (alvo == posInicial && distanciaTemp <= 0.02f)
        {
            transform.position = posInicial;
        }
 
        Debug.DrawLine(transform.position, alvo, Color.green);
    }
    private void OnTriggerStay2D(Collider2D other) {
            if(other.CompareTag("SkillPlayer"))
            {
                life += -5;
            } 
            if(other.CompareTag("SkillSword"))
            {
                life += -2;
            }
             if(other.CompareTag("SkillSwordIce"))
            {
                life += -1;
            }      
    }
     
}   
*/ 