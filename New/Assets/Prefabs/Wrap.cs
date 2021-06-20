using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrap : MonoBehaviour
{
  public GameObject target;
  private CameraController cam;

  public Vector2 newMinPos, newMaxPos;
  
  bool start = false;
  bool isFadeIn = false;
  float alpha = 0;
  float fadeTime = 1f;


  GameObject area;

  

  void Start()
    {
      cam = Camera.main.GetComponent<CameraController>();

    }

  void Awake() 
    {   
      GetComponent<SpriteRenderer>().enabled = false;
      transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;   

      area = GameObject.FindGameObjectWithTag("Area");  
    }
  

  IEnumerator OnTriggerEnter2D(Collider2D other)
    {

      if(other.tag == "Player")
      {
        
        other.GetComponent<Player>().enabled = false;
        other.GetComponent<Animator>().enabled = false;

        FadeIn();

        yield return new WaitForSeconds(fadeTime);

        other.transform.position = target.transform.GetChild(0).transform.position;
        cam.minPosition = newMinPos;
        cam.maxPosition = newMaxPos;


        FadeOut();

        
        other.GetComponent<Player>().enabled = true;
        other.GetComponent<Animator>().enabled = true;

        StartCoroutine(area.GetComponent<Area>().ShowArea(name));
      }
    }

    void OnGUI()
    {
        if(!start)
        {
            return;
        }
        
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);

        Texture2D tex;
        tex = new Texture2D(1, 1);
        tex.SetPixel(0, 0, Color.black);
        tex.Apply();

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), tex);

        if(isFadeIn)
        {
            alpha = Mathf.Lerp(alpha, 1.1f, fadeTime * Time.deltaTime);
        }
        else
        {
            alpha = Mathf.Lerp(alpha, -0.1f, fadeTime * Time.deltaTime);

            if(alpha < 0)
            {
              start = false;
            }
        }
        
  }

    void FadeIn()
    {
       start = true;
       isFadeIn = true;
    }

    void FadeOut()
    {
      isFadeIn = false;
    }
}
