using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    public Animator anim;
    public float speed;
   
    Vector3 movement;
    private float attackTime = .25f;
    private float attackCounter = .25f;
    private bool isAttacking;

    BoxCollider2D contactCollider;

    void Start () {

        contactCollider = transform.GetChild(4).GetComponent<BoxCollider2D>();
        contactCollider.enabled = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        if(PauseMenu.isPaused == false)
        {
        //  Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.magnitude);
        
        if (movement != Vector3.zero)
        {
            anim.SetFloat("Horizontalidle", movement.x);
            anim.SetFloat("Verticalidle", movement.y);
        }

        if(isAttacking)
        {
            
            if(movement != Vector3.zero) contactCollider.offset = new Vector2(movement.x/2, movement.y/2);

            //float playbackTime = stateInfo.normalizedTime;
            //if (playbackTime > 0.33 && playbackTime < 0.66) contactCollider.enabled = true;

            movement = Vector3.zero;
            attackCounter -= Time.deltaTime;
            if (attackCounter <= 0)
            {
                anim.SetBool("isAttacking", false);
                isAttacking = false;
            }
        
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
           


            attackCounter = attackTime;
            anim.SetBool("isAttacking", true);
            isAttacking = true;
        
        }
        }
        
    }

    private void FixedUpdate()
    {
        transform.position = transform.position + movement.normalized * speed * Time.deltaTime;

    }

    
}
