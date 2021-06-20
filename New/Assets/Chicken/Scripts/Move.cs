using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
   public Transform homePos;
    [SerializeField]
    private float speed = 3f;
    


    public float tempoEspera;
    float tempo;
    public Vector3 maxiPosition;
    public Vector3 miniPosition;

    

    // Start is called before the first frame update
    void Start()
    {

        tempo = tempoEspera;
    }

    // Update is called once per frame
    void Update()
    {
        GoHome();
    }

    void GoHome()
    {
       
        
        transform.position = Vector3.MoveTowards(transform.position, homePos.transform.position, Time.deltaTime);
            
        if(Vector2.Distance(transform.position, homePos.position) == 0)
        {   
            if(tempo <= 0)
            {
                homePos.position = new Vector2(Random.Range(maxiPosition.x, miniPosition.x), Random.Range(maxiPosition.y, miniPosition.y)); 
                tempo = tempoEspera;
            }
            else
            { 
                tempo -= Time.deltaTime;
            }
        }       
        
    }
}


