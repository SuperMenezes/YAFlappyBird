using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Manager : MonoBehaviour
{
    
    public static Manager Instance { get; private set; }

    public List<GameObject> obstaclePrefabs;

    public float fObjectInterval = 1;

    public float fObstacleSpeed = 10f;

    public Vector2 yOffset = Vector2.zero;
    public float xOffset = 0;

    [HideInInspector]
    public int score = 0;

    private bool isGameOver = false;


    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }


    public void EndGame()
    {
        isGameOver = true;
        Debug.Log("Score: " + score);
    }

    public bool IsGameOver()
    {
        return isGameOver;
    }

    public bool IsGameActive()
    {
        return !isGameOver;
    }

}
