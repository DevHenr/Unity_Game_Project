using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DialogueManager : MonoBehaviour
{   
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;

    public GameObject dialogBox;

    //Posso remover
    private Queue<string> name;

    private Queue<string> sentences;

    void Start() {
        sentences = new Queue<string>();

        //Posso remover
        name = new Queue<string>();

        
    }

    public void StartDialogue (Dialogue dialogue)
    {
       // POsso ter que colocar novamente: nameText.text = dialogue.name;

        sentences.Clear();

       //Posso remover name.Clear();


        foreach (string sentence in dialogue.sentences)
        {
          sentences.Enqueue(sentence);  
        }

        //Posso remover
        foreach (string nan in dialogue.name)
        {
          name.Enqueue(nan);  
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0 || name.Count == 0 )
        {
            EndDialogue();
            return;
        }

        string nan = name.Dequeue();
        string sentence = sentences.Dequeue();
        nameText.text = nan;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue()
    {
       // Debug.Log("End");
        dialogBox.SetActive(false);

    }
}
