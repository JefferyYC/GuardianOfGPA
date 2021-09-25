using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    int timeCounter = 0;
    public int spawnRate = 5;

    public GameObject[] waypoints;
    public GameObject enemy1Prefab;
    public GameObject enemy2Prefab;
    public GameObject enemy3Prefab;

    public int waveSize = 20;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timeCounter && waveSize > 0)
        {
            timeCounter += spawnRate;

            int rng = Random.Range(0, 10);
            if (rng < 4)
            {
                Instantiate(enemy1Prefab).GetComponent<MoveEnemy>().waypoints = waypoints;
            }
            else if (rng <= 7)
            {
                Instantiate(enemy2Prefab).GetComponent<MoveEnemy>().waypoints = waypoints;

            }
            else
            {
                Instantiate(enemy3Prefab).GetComponent<MoveEnemy>().waypoints = waypoints;

            }
            waveSize -= 1;
        }
    }
}
