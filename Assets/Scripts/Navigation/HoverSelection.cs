using UnityEngine;

public class HoverSelection : MonoBehaviour
{
    Renderer renderer;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    
    private void OnMouseOver()
    {
        GetComponent<TextMesh>().color = Color.green;
    }

    private void OnMouseExit()
    {
        GetComponent<TextMesh>().color = Color.black;
    }
}
