using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManagerBehavior : MonoBehaviour
{

    private bool gameOver = false;

    public GameObject road;
    private SpawnEnemy spawn;

    public Text turretLabel;
    public int maxTurret;
    private int turret;
    public int Turret
    {
        get
        {
            return turret;
        }
        set
        {
            turret = value;
            turretLabel.text = turret.ToString();
        }
    }


    public Text healthLabel;

    public float maxHealth;

    private float health;

    public float Health
    {
        get
        {
            return health;
        }
        set
        {
            // 1
            if (value < health)
            {
                Camera.main.GetComponent<CameraShake>().Shake();
            }
            // 2
            health = value;
            healthLabel.text = health.ToString();
            // 3
            if (health <= 2.0 && !gameOver)
            {
                gameOver = true;
                GameObject gameOverText = GameObject.FindGameObjectWithTag("GameOver");
                gameOverText.GetComponent<Animator>().SetBool("gameOver", true);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        healthLabel.text = health.ToString();

        turret = maxTurret;
        turretLabel.text = turret.ToString();

        spawn = road.GetComponent<SpawnEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (spawn.waveSize <= 0 && GameObject.FindGameObjectWithTag("Enemy") == null)
        {
            gameOver = true;
            GameObject gameOverText = GameObject.FindGameObjectWithTag("GameWon");
            gameOverText.GetComponent<Animator>().SetBool("gameOver", true);
        }
    }

}
