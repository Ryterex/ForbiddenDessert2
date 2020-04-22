using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueController : MonoBehaviour
{
   // Start is called before the first frame update
    public GameObject nameText;
    public GameObject dialogueText;

    //public GameObject[] interactables;

    private Queue<string> sentences;
    private Queue<string> names;
    private float textSpeed;
    public Animator animator;

    void Start()
    {
        nameText = GameObject.Find("NameText");
        dialogueText = GameObject.Find("DialogueText");;
        sentences = new Queue<string>();
        names = new Queue<string>();
        textSpeed = 0.01f;

        
            
    }

    public void StartDialogue(Dialogue dialogue){
        animator.SetBool("IsOpen", true);
        
        // interactables = GameObject.FindGameObjectsWithTag("Interactable");
        /*
        foreach (GameObject interactable in interactables)
        {
            interactable.GetComponent<BoxCollider2D>().enabled = false;
        }
        */
        names.Clear();
        sentences.Clear();
        foreach (string sentence in dialogue.sentences){
            sentences.Enqueue(sentence);
        }

        foreach (string Name in dialogue.names)
        {
            names.Enqueue(Name);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence(){
        
        if(sentences.Count == 0){
            EndDialogue();
            return;
        }

        string Name = names.Dequeue();
        nameText.GetComponent<TextMeshProUGUI>().text = Name;
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
	{
		dialogueText.GetComponent<TextMeshProUGUI>().text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.GetComponent<TextMeshProUGUI>().text += letter;
            yield return new WaitForSeconds(textSpeed);
		}
	}

    void EndDialogue(){
        animator.SetBool("IsOpen", false);
        /*
        foreach (GameObject interactable in interactables)
        {
            interactable.GetComponent<BoxCollider2D>().enabled = true;
        }
        */
    }

}
