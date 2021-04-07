using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NavigationBetweenScene : MonoBehaviour
{
    [SerializeField]
    private string sceneToLoad;
    
    private float timeBeforeLoadingScene = 2;
    private bool buttonClicked = false;

    
    void Update()
    {
        if (buttonClicked) {
            StartCoroutine(WaitBeforeLoadingScene(2));
            if (timeBeforeLoadingScene < 1)
            {
                SceneManager.LoadScene(sceneToLoad, LoadSceneMode.Single);
            }
            else
            {
                timeBeforeLoadingScene -= Time.deltaTime;
            }
        }
        
    }
    
    void OnMouseUp()
    {
        buttonClicked = true;
    }

    IEnumerator WaitBeforeLoadingScene(int waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }
}
