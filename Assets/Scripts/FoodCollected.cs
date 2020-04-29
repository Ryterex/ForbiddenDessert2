using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollected : MonoBehaviour
{
    // Start is called before the first frame update
    public bool startOver = false;

    private GameObject SceneManager;
    public Animator animator;

    public GameObject[] foods;

    void Start() {
        SceneManager = GameObject.Find("SceneManager");
        foods = GameObject.FindGameObjectsWithTag("Food");
        animator = GameObject.Find("DialogueBox").GetComponent<Animator>();
    }

    void Update() {
        if(startOver && !animator.GetBool("IsOpen") ){
            foreach(GameObject food in foods){
                food.GetComponent<BoxCollider>().enabled = false;
            }
            StartCoroutine(SceneManager.GetComponent<SceneTransitions>().LoadMainMenu());
            startOver = false;
        }
    }
}
