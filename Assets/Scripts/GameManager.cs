using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject[] players;
    private PlayerManager playerM;
    private int deathCounter = 0;

    // Use this for initialization
    void Start()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        EventManager eventM = playerM.eventManager;

        for (int i = 0; i < players.Length; i++)
        {
            if (players[i] == null)
            {
                eventM.GetEvent("PlayerDeath").AddListener(DeathCount);
            }
        }
    }

    void DeathCount()
    {
        deathCounter += 1;

        if (deathCounter >= 3)
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}
