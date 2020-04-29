using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitions : MonoBehaviour
{

    public Animator transitionAnim;
    public string sceneName;
    //public bool stairCollide = false;

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

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.name == "StairCollider")
        {
            StartCoroutine(LoadScene());
        }

        if (other.name == "TextTriggerParent")
        {
            StartCoroutine(LoadStart());
        }
    }*/

    public IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene(sceneName);
    }

    public IEnumerator LoadMainMenu()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene("StartMenu");
    }

    public IEnumerator LoadStart()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(8.0f);
        SceneManager.LoadScene("MainMap");
    }

    public IEnumerator StairFail()
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(8.0f);
        SceneManager.LoadScene("MainMap");
    }
}
