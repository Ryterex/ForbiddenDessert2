using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloset : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject otherDoor;

    public Vector3 newPos;
    public Vector3 newRot;

    public bool doorOpen;
    void Start()
    {
        doorOpen = false;
        //Debug.Log(this.gameObject.transform.position); 
        //Debug.Log(this.gameObject.transform.eulerAngles); 
    }

    // Update is called once per frame

    public void StayOpen(){
        if(!doorOpen){
            //Debug.Log("Door isnt open");
            otherDoor.transform.position += otherDoor.GetComponent<OpenCloset>().newPos;
            otherDoor.transform.eulerAngles += otherDoor.GetComponent<OpenCloset>().newRot;
            this.gameObject.transform.position += newPos;
            this.gameObject.transform.eulerAngles += newRot;
            otherDoor.GetComponent<OpenCloset>().doorOpen = true;
            doorOpen = true;
        }
        else{
            //Debug.Log("Door is open");
            otherDoor.transform.position -= otherDoor.GetComponent<OpenCloset>().newPos;
            otherDoor.transform.eulerAngles -= otherDoor.GetComponent<OpenCloset>().newRot;
            this.gameObject.transform.position -= newPos;
            this.gameObject.transform.eulerAngles -= newRot;
            otherDoor.GetComponent<OpenCloset>().doorOpen = false;
            doorOpen = false;
        }
        
    }
}
