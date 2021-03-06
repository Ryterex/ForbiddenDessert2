﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] inventory;
    public InventoryItem flashlight;
    public InventoryItem batteries;

    public GameObject flashText;

    public bool flash;

    public Animator animator;

    public GameObject Map;

    public GameObject SceneManager;
    void Start()
    {
        flash = false;
        flashlight.collected = false;
        batteries.collected = false;
        Map = GameObject.FindGameObjectWithTag("Map");
        flashText = GameObject.Find("FlashText");
        SceneManager = GameObject.Find("SceneManager");
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

        if(Input.GetKeyUp(KeyCode.M) && !animator.GetBool("IsOpen")){
            if(!Map.activeSelf){
                Map.SetActive(true);
            } else{
                Map.SetActive(false);
            }
        }

        if(flashlight.collected && !flash){
            flash = true;
            flashText.SetActive(true);
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        

        //this is for when interacting with an object 
        if(Input.GetKeyUp(KeyCode.E) && !animator.GetBool("IsOpen")){
            if(Physics.Raycast(ray,out hit,3.0f)){
                if(hit.transform != null){
                    Debug.Log(hit.transform.name);
                    //for collecting an object
                    if(hit.transform.parent.transform.tag == "InvItem"){
                        hit.transform.parent.transform.GetComponent<CollectedItem>().triggered = true;
                        hit.transform.parent.transform.GetComponent<DialogueTrigger>().TriggerDialogue();
                    }
                    else if(hit.transform.name == "door"){
                        hit.transform.GetComponent<OpenDoor>().Open();
                    }
                    else if(hit.transform.name == "doorLeft" || hit.transform.name == "doorRight"){
                        hit.transform.GetComponent<OpenCloset>().StayOpen();
                    }
                    else if(hit.transform.name == "laptop"){
                        hit.transform.parent.transform.GetComponent<CollectLaptop>().Collect();
                    }
                    if(hit.transform.tag == "Food"){
                        hit.transform.GetComponent<DialogueTrigger>().TriggerDialogue();
                        hit.transform.GetComponent<FoodCollected>().startOver = true;
                    }   
                }
            }
            
        }
    }
    public void startOver(){
        StartCoroutine(SceneManager.GetComponent<SceneTransitions>().LoadMainMenu());
        return;
    }
}