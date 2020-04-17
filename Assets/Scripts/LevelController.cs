using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 5, Color.yellow);

        if(Input.GetMouseButtonDown(1)){
            Debug.Log("hello");
        }

        if(Input.GetMouseButtonDown(0)){
            Debug.Log("Mouse being clicked");
            /*
            if(Physics.Raycast(ray,out hit,3.0f)){
                if(hit.transform != null){
                    if(hit.transform.tag == "InvItem"){
                        Debug.Log(hit.transform.name);
                    }
                }
            }
            */
        }
    }
}
