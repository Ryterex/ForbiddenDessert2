using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    // Start is called before the first frame update
    //public Animator animator;

    public Vector3 originalPos;
    public Vector3 originalRot;

    public Vector3 newPos;
    public Vector3 newRot;

    public bool doorOpen;
    public bool delay;
    void Start()
    {
        doorOpen = false;
        Debug.Log(this.gameObject.transform.position); 
        Debug.Log(this.gameObject.transform.eulerAngles); 
    }

    // Update is called once per frame

    public void Open(){
           
        if(!delay){
            StayOpen();
        } else if(!doorOpen){
            doorOpen = true;
            StartCoroutine(Close());
        }   
    }

    IEnumerator Close(){
        this.gameObject.transform.position += newPos;
        this.gameObject.transform.eulerAngles += newRot; 
        yield return new WaitForSeconds(5.0f);
        this.gameObject.transform.position -= newPos;
        this.gameObject.transform.eulerAngles -= newRot;
        doorOpen = false;
        
    }

    void StayOpen(){
        if(!doorOpen){
            //Debug.Log("Door isnt open");
            this.gameObject.transform.position += newPos;
            this.gameObject.transform.eulerAngles += newRot;
            doorOpen = true;
        }
        else{
            //Debug.Log("Door is open");
            this.gameObject.transform.position -= newPos;
            this.gameObject.transform.eulerAngles -= newRot;
            doorOpen = false;
        }
        
    }
}
