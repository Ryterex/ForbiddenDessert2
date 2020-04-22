using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] inventory;
    public bool flashlight;
    public bool batteries;

    public GameObject flashText;

    public Animator animator;

    public GameObject Map;
    void Start()
    {
        Map = GameObject.FindGameObjectWithTag("Map");
        flashText = GameObject.Find("FlashText");
        flashText.SetActive(false);
        Map.SetActive(false);
        inventory = GameObject.FindGameObjectsWithTag("Inventory");

        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 5, Color.yellow);

        if(Input.GetMouseButtonDown(0) && animator.GetBool("IsOpen")){
            FindObjectOfType<DialogueController>().DisplayNextSentence();
        }

        if(Input.GetKeyUp(KeyCode.M)){
            if(!Map.activeSelf){
                Map.SetActive(true);
            } else{
                Map.SetActive(false);
            }
        }

        

        //this is for when interacting with an object 
        if(Input.GetKeyUp(KeyCode.E)){
            if(Physics.Raycast(ray,out hit,3.0f)){
                if(hit.transform != null){
                    Debug.Log(hit.transform.name);
                    //for collecting an object
                    if(hit.transform.tag == "InvItem"){
                        hit.transform.GetComponent<DialogueTrigger>().TriggerDialogue();
                    }
                    
                }
            }
            
        }
    }
}
