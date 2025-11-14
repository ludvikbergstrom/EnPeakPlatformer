using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public GameObject[] levels;
    public Transform player;

    private int currentLevel = 0;
    private bool transitioning = false;

    public float cameraMoveTime = 1f;

    void Start()
    {
        for (int i = 0; i < levels.Length; i++)
            levels[i].SetActive(false);

        ActivateLevel(0);
    }

    public void CompleteLevel()
    {
        if (transitioning) return;

        StartCoroutine(TransitionToNextLevel());
    }

    IEnumerator TransitionToNextLevel()
    {
        transitioning = true;

        // Hide current level
        levels[currentLevel].SetActive(false);
        currentLevel++;

        if (currentLevel >= levels.Length)
        {
            Debug.Log("GAME COMPLETE!");
            yield break;
        }

        // Show next level
        levels[currentLevel].SetActive(true);

        // Move player instantly to new level's StartPoint
        Transform startPoint = levels[currentLevel].transform.Find("StartPoint");
        player.position = startPoint.position;

        // Smoothly move camera to new level
        Vector3 targetPos = new Vector3(
            startPoint.position.x,
            startPoint.position.y,
            Camera.main.transform.position.z
        );

        yield return StartCoroutine(MoveCamera(targetPos, cameraMoveTime));

        transitioning = false;
    }

    IEnumerator MoveCamera(Vector3 target, float duration)
    {
        Vector3 start = Camera.main.transform.position;
        float t = 0;

        while (t < duration)
        {
            t += Time.deltaTime;
            Camera.main.transform.position = Vector3.Lerp(start, target, t / duration);
            yield return null;
        }

        Camera.main.transform.position = target;
    }

    void ActivateLevel(int index)
    {
        levels[index].SetActive(true);
        player.position = levels[index].transform.Find("StartPoint").position;
    }
}
