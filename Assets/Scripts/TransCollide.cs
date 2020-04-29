using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransCollide : MonoBehaviour
{

    public GameObject SceneManager;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "StairCollider")
        {
            StartCoroutine(SceneManager.GetComponent<SceneTransitions>().LoadScene());
        }

        if (other.name == "TextTriggerParent")
        {
            //Debug.Log("ParentsRoomText");
            other.GetComponent<DialogueTrigger>().TriggerDialogue();
            
            
        }

        if (other.name == "StairFailTrigger")
        {
            //Debug.Log("StairFallText");
            other.GetComponent<DialogueTrigger>().TriggerDialogue();
            
        }
    }

    private void OnTriggerStay(Collider other){
        if (other.name == "TextTriggerParent")
        {
            if(!animator.GetBool("IsOpen")){
                StartCoroutine(SceneManager.GetComponent<SceneTransitions>().LoadStart());
            }
            
        }

        if (other.name == "StairFailTrigger")
        {
            //Debug.Log("StairFallText");
            if(!animator.GetBool("IsOpen")){
                StartCoroutine(SceneManager.GetComponent<SceneTransitions>().LoadStart());
            }
        }
    }
}
