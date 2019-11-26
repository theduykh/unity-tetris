using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnClickLeft : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public static bool pressing = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log(this.gameObject.name + " Was Clicked.");
        pressing = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("The mouse click was released");
        pressing = false;
    }
}
