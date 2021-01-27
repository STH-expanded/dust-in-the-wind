using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationBetweenScene : MonoBehaviour
{
    [SerializeField]
    private string sceneToLoad;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseUp()
    {
        SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
    }
}
