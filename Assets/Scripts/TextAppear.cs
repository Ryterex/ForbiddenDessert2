using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;

public class TextAppear : MonoBehaviour
{

    public GameObject textTriggerHallway1;
    public GameObject boredText;
    public GameObject textTriggerStart1;
    public GameObject textTriggerSis1;
    public GameObject textTriggerBath1;
    public GameObject textTriggerSisHall;
    public GameObject stopColliderBath1;
    public GameObject stopColliderHallway;
    public GameObject stopColliderSis;
    public GameObject stairCollider;
    public GameObject stairFailCollider;
    public GameObject flashFlickerTrigger;
    public GameObject stopColliderSis2;

    public InventoryItem fLight;
    public GameObject flashSpotLight; //the light above the flashlight collectible
    public GameObject playerLight;  //the spotlight attached to the player
    public InventoryItem battery;
    public GameObject batteryModel; //the actual battery
    public GameObject batteryLight; //the light above the battery collectible
    public GameObject inventory;
    public Sprite flashlightInv;
    public Sprite flashlightInvNoBat;
    public bool flashflicker = false;

    public Animator animator;
    public GameObject SceneManager;

    //this bool is just here for testing the structure of the game after the laptop is found
    //doesnt actually mean the laptop has been found
    public bool isCollectedDummy = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(animator.GetBool("IsOpen")){
            this.gameObject.GetComponent<FirstPersonController>().m_WalkSpeed = 0;
            this.gameObject.GetComponent<FirstPersonController>().m_RunSpeed = 0;
        } else{
            this.gameObject.GetComponent<FirstPersonController>().m_WalkSpeed = 1;
            this.gameObject.GetComponent<FirstPersonController>().m_RunSpeed = 2;
        }

        if (fLight.collected)
        {
            stopColliderHallway.SetActive(false);
            stopColliderSis.SetActive(false);
            flashSpotLight.SetActive(false);
            textTriggerHallway1.SetActive(false);
            textTriggerSisHall.SetActive(false);

            if (flashflicker == false)
            {
                inventory.GetComponent<Image>().sprite = flashlightInv;
            } else
            {
                inventory.GetComponent<Image>().sprite = flashlightInvNoBat;
            }

        }

        if (isCollectedDummy == true)
        {
            stopColliderBath1.SetActive(false);
            textTriggerBath1.SetActive(false);
        }

        if (battery.collected)
        {
            stairCollider.SetActive(true);
            stairFailCollider.SetActive(false);
            flashFlickerTrigger.SetActive(false);
            playerLight.SetActive(true);
            batteryLight.SetActive(false);
            flashflicker = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if laptop is collected dummy script
        
        if (other.name == "LaptopCollectDUMMY")
        {
            //Debug.Log("LaptopFoundText");
            other.GetComponent<DialogueTrigger>().TriggerDialogue();
            isCollectedDummy = true;
        }

        if (other.tag == "HallCollider")
        {
            //Debug.Log("HallText");
            other.GetComponent<DialogueTrigger>().TriggerDialogue();
        }

        if (other.name == "TextTriggerBath1")
        {
            //Debug.Log("BathroomText");
            other.GetComponent<DialogueTrigger>().TriggerDialogue();
        }

        if (other.name == "TextTriggerSis1")
        {
            //Debug.Log("SisRoomText");
            other.GetComponent<DialogueTrigger>().TriggerDialogue();
            textTriggerSis1.SetActive(false);
            textTriggerStart1.SetActive(true);
        }

        if (other.name == "TextTriggerStart1")
        {
            //Debug.Log("StartReturnText");
            other.GetComponent<DialogueTrigger>().TriggerDialogue();
            flashSpotLight.SetActive(true);
            textTriggerStart1.SetActive(false);
            stopColliderSis2.SetActive(false);
        }

        if (other.name == "TextTriggerGrand")
        {
            //Debug.Log("GrandRoomText");
            other.GetComponent<DialogueTrigger>().TriggerDialogue();
        }

        /*if (other.name == "FlashlightFlickerTrigger")
        {
            //Debug.Log("FlashFlickerText");
            other.GetComponent<DialogueTrigger>().TriggerDialogue();
            playerLight.SetActive(false);
            inventory.GetComponent<Image>().sprite = flashlightInvNoBat;
        }*/

        if (other.name == "FlashlightFlickerTrigger")
        {
            //Debug.Log("FlashFlickerText");
            other.GetComponent<DialogueTrigger>().TriggerDialogue();
            batteryModel.SetActive(true);
            batteryLight.SetActive(true);
            playerLight.SetActive(false);
            flashflicker = true;
        }

        if(other.name == "StartingText"){
            StartCoroutine(waitForLoad());
        }

    }
    
    IEnumerator waitForLoad(){
        yield return new WaitForSeconds(1.5f);
        boredText.GetComponent<DialogueTrigger>().TriggerDialogue();
        boredText.GetComponent<BoxCollider>().enabled = false;
    }
}
