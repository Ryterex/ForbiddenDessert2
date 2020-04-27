using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenLightOn : MonoBehaviour
{

    public GameObject kitchenLights;
    //public bool isOn = false;

    // Start is called before the first frame update
    void Start()
    {
        //kitchenLights.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (isOn == false) {
            
            StartCoroutine(LightOn());
            isOn = true;
        }*/

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "LightTrigger")
        {
            kitchenLights.SetActive(true);
        }
    }

    /*public IEnumerator LightOn()
    {
        yield return new WaitForSeconds(2.0f);
        kitchenLights.SetActive(true);
    }*/
}
