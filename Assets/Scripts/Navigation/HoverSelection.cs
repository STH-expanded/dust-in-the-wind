using System;
using UnityEngine;

public class HoverSelection : MonoBehaviour
{
    Renderer renderer;
    private float scale = 0.2f;
    private AudioSource audio;

    private void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().transform.localScale = (Vector2) GetComponent<SpriteRenderer>().transform.localScale + (new Vector2(scale, scale));
    }
    
    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().transform.localScale = (Vector2) GetComponent<SpriteRenderer>().transform.localScale - (new Vector2(scale, scale));
    }

    private void OnMouseUp()
    {
        audio = GetComponent<AudioSource>();
        audio.Play();
    }
}
