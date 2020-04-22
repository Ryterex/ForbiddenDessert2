using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedItem : MonoBehaviour
{
    // Start is called before the first frame update

    public InventoryItem item;

    public Animator animator;

    public bool triggered;

    void Start()
    {
        animator = GameObject.Find("DialogueBox").GetComponent<Animator>();
        triggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(triggered){
            Debug.Log("Made it to the trigger");
            if(!animator.GetBool("IsOpen")){
                this.gameObject.GetComponent<MeshCollider>().enabled = false;
                this.gameObject.GetComponent<MeshRenderer>().enabled = false;
                triggered = false;
            }
        }
    }
}
