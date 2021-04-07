using UnityEngine;

public class HoverSelection : MonoBehaviour
{
    Renderer renderer;
    private float scale = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseEnter()
    {
        GetComponent<SpriteRenderer>().transform.localScale = (Vector2) GetComponent<SpriteRenderer>().transform.localScale + (new Vector2(scale, scale));
    }
    
    private void OnMouseExit()
    {
        GetComponent<SpriteRenderer>().transform.localScale = (Vector2) GetComponent<SpriteRenderer>().transform.localScale - (new Vector2(scale, scale));
    }
}
