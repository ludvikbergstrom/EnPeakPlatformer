using UnityEngine;
using UnityEngine.SceneManagement;

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

    private void OnEnable()
    {
        SceneManager.activeSceneChanged += OnSceneChanging;
    }

    private void OnDisable()
    {
        SceneManager.activeSceneChanged -= OnSceneChanging;
    }

    private void OnSceneChanging(Scene current, Scene next)
    {
        ChangingScene = true;
    }



    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }


}
