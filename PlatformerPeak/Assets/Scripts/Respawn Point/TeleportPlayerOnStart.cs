using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayerOnStart : MonoBehaviour
{
    private GameObject[] players;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject p in players)
        {
            p.transform.position = transform.position;
        }
    }
}
