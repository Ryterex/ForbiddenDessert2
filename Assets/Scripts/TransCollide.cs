using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransCollide : MonoBehaviour
{

    public GameObject SceneManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "StairCollider")
        {
            StartCoroutine(SceneManager.GetComponent<SceneTransitions>().LoadScene());
        }

        if (other.name == "TextTriggerParent")
        {
            //Debug.Log("ParentsRoomText");
            StartCoroutine(SceneManager.GetComponent<SceneTransitions>().LoadStart());
        }

        if (other.name == "StairFailTrigger")
        {
            Debug.Log("StairFallText");
            StartCoroutine(SceneManager.GetComponent<SceneTransitions>().StairFail());
        }
    }
}
