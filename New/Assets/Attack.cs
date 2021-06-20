using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name.Equals("Player"))
        {
            Thief.isAttacking = true;
        }
    }

    // Update is called once per frame
    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.name.Equals("Player"))
        {
            Thief.isAttacking = false;
        }
    }

}
