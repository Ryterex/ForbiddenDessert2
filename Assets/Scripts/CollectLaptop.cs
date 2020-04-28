using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectLaptop : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Collect(){
        this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
        player.GetComponent<TextAppear>().isCollectedDummy = true;
    }
}
