using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HurtPlayer : MonoBehaviour
{

    private HealthManager healthMan;
    public float waitToHurt = 2f;
    public static bool isAttacking = false;
    [SerializeField]
    private int damageToGive = 10;

    // Start is called before the first frame update
    void Start()
    {
        healthMan = FindObjectOfType<HealthManager>();


    }

    // Update is called once per frame
    void Update()
    {
        /*
        if(reloading)
        {
            waitToLoad -= Time.deltaTime;
            if (waitToLoad <= 0)
            {
             SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        */

        if(isAttacking)
        {
            waitToHurt -= Time.deltaTime;
            if(waitToHurt <= 0)
            {
                healthMan.HurtPlayer(damageToGive);
                waitToHurt = 5f;
            }
        }
        
        
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
           // Destroy(other.gameObject);
           //other.gameObject.SetActive(false);
           col.gameObject.GetComponent<HealthManager>().HurtPlayer(damageToGive);
       //reloading = true;
        }

    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            isAttacking = true;
        }
    }
    
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name.Equals("Player"))
        {
            isAttacking = false;
            waitToHurt = 5f;
        }

    }
    
    
}
