using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverSelection : MonoBehaviour
{
    Renderer renderer;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        GetComponent<TextMesh>().color = Color.red;
    }

    // Update is called once per frame
    void Update()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.color = Color.green;
    }

    private void OnMouseEnter()
    {
        Debug.Log("mouse enter");
        GetComponent<TextMesh>().color = Color.green;
    }

    private void OnMouseOver()
    {
        Debug.Log("mouse over");
        GetComponent<TextMesh>().color = Color.white;
    }

    private void OnMouseExit()
    {
        Debug.Log("mouse exit");
        GetComponent<TextMesh>().color = Color.black;
    }

}
