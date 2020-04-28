using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedItem : MonoBehaviour
{
    // Start is called before the first frame update

    public InventoryItem item;

    public GameObject boxColliderObject;

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
            if(!animator.GetBool("IsOpen")){
                boxColliderObject.GetComponent<BoxCollider>().enabled = false;
                foreach(Transform child in this.gameObject.transform){
                        child.gameObject.GetComponent<MeshRenderer>().enabled = false;
                }
                    
                item.collected = true;
                triggered = false;
            }
        }
    }
}
