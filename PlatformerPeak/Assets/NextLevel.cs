using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public string nextSceneName;
    private TextMeshProUGUI playerDoorText;
    private int playersInDoor = 0;

    private void Start()
    {
        playerDoorText = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Update()
    {
        if (playersInDoor > 0) {
        playerDoorText.text = playersInDoor + "/2";
        }
        else
        {
            playerDoorText.text = "";
        }

        if (playersInDoor == 2)
        {
            SceneController.instance.ChangingScene = true;
            SceneController.instance.LoadScene(nextSceneName);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playersInDoor += 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playersInDoor -= 1;
        }
    }
}
