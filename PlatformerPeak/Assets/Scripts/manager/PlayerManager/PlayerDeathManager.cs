using UnityEngine;

public class PlayerDeathManager : MonoBehaviour
{
    public GameObject playerOnePrefab;
    public GameObject playerTwoPrefab;

    // Update is called once per frame
    void Update()
    {
        if (playerOnePrefab == null)
        {
            SpawnPlayer(playerOnePrefab);
        }
        if (playerTwoPrefab == null)
        {
            SpawnPlayer(playerTwoPrefab);
        }
    }
    void SpawnPlayer(GameObject player)
    {
        Instantiate(player,transform.position, Quaternion.identity);
    }
}
