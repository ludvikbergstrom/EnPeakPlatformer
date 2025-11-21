using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }



    public bool ChangingScene;


    public void LoadScene(string sceneName) 
    { 
        SceneManager.LoadSceneAsync(sceneName);
        Invoke("NotChangingScene", 0.5f);
    }

    private void NotChangingScene()
    {
        ChangingScene = false;
    }
}
