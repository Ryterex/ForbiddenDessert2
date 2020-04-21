using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{

    public Animator transitionAnim;
    public string sceneName;
    public bool stairCollide = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        StartCoroutine(LoadScene());
    //    }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "StairCollider")
        {
            stairCollide = true;
        }
    }

    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene(sceneName);
    }
}
