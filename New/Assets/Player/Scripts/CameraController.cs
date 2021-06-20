using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float smoothing;
    public Vector2 minPosition, maxPosition;
    public Vector3 targetPosition;

    // Start is called before the first frame update
    void Awake() 
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
/*
    void Start(){
        target = FindObjectOfType<Player>().transform;
    }
*/
    // Update is called once per frame
    void LateUpdate()
    {
      /*  transform.position = new Vector3(target.position.x, target.position.y, transform.position.z); */

        if(transform.position != target.position)
        {
            targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);

            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);

            if(Vector2.Distance(transform.position, target.position) <= 5)
            {
                transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
            }
            else
            {
                transform.position = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
            }
        }


       
    }

   
}
