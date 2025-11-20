using Unity.VisualScripting;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public string nextSceneName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
           SceneController.instance.LoadScene(nextSceneName);
        }
    }
}
