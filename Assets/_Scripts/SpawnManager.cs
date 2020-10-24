using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstacles;
    private Vector3 spawnPos;
    private float startDelay = 1;
    private int randomObstacle;
    
    private PlayerController _playerController;
    // Start is called before the first frame update
    void Start()
    {
        spawnPos = transform.position;
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", startDelay,Random.Range(2,3));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnObstacle()
    {
        if (!_playerController.gameOver) 
        { 
            randomObstacle=Random.Range(0,obstacles.Length);
            Instantiate(obstacles[randomObstacle], spawnPos, obstacles[randomObstacle].transform.rotation);
        }
    }
}
