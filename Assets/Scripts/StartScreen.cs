using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StartScreen : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Sprite off;
    public Sprite hover;
    public GameObject panel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        panel.GetComponent<Image>().sprite = hover;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        panel.GetComponent<Image>().sprite = off;
    }
}
