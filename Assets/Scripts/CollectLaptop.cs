using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectLaptop : MonoBehaviour
{
    // Start is called before the first frame update
    public Vector3 newPos;
    public Vector3 newRot;
    public GameObject player;
    public GameObject laptop;

    public void Collect(){
        this.gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
        this.gameObject.transform.position = newPos;
        this.gameObject.transform.eulerAngles = newRot;
        laptop.GetComponent<MeshCollider>().enabled = false;
        player.GetComponent<TextAppear>().isCollectedDummy = true;
    }
}
