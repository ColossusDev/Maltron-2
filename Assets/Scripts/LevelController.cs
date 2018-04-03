using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelController : MonoBehaviour {

    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject enemy4;
    public GameObject enemy5;
    public GameObject enemy6;
    public GameObject enemy7;
    public GameObject enemy8;
    public GameObject enemy9;
    public GameObject enemy10;
    public GameObject enemy11;
    public GameObject enemy12;
    public GameObject enemy13;

    public float levelDuration;
    public float hardness;
    public int enemyCount;
    float spawnRate;
    float counterSpawn;

    GameObject[] enemys = new GameObject[13];

    GameObject gameData;

    int level;

	// Use this for initialization
	void Start () {

        gameData = GameObject.Find("GameDataController");

        level = gameData.GetComponent<GameData>().currentLevel;

        enemys[0] = enemy1;
        enemys[1] = enemy2;
        enemys[2] = enemy3;
        enemys[3] = enemy4;
        enemys[4] = enemy5;
        enemys[5] = enemy6;
        enemys[6] = enemy7;
        enemys[7] = enemy8;
        enemys[8] = enemy9;
        enemys[9] = enemy10;
        enemys[10] = enemy11;
        enemys[11] = enemy12;
        enemys[12] = enemy13;

        //Nur im Developmet zu erreichen
        if (level == 0)
        {
            levelDuration = 10000;
            enemyCount = 0;

            spawnRate = levelDuration / enemyCount;
        }
        //Richtige Level
        if (level == 1)
        {
            levelDuration = 30;
            enemyCount = 12;

            spawnRate = levelDuration / enemyCount;
        }
        if (level == 2)
        {
            levelDuration = 40;
            enemyCount = 18;

            spawnRate = levelDuration / enemyCount;
        }
        if (level == 3)
        {
            levelDuration = 40;
            enemyCount = 40;

            spawnRate = levelDuration / enemyCount;
        }



        counterSpawn = spawnRate;
    }

    // Update is called once per frame
    void Update () {

        //level zeitmessung
        levelDuration -= Time.deltaTime;

        LevelProcedure();



        //Beendungs Szenario
        GameObject leftEnemy = GameObject.FindGameObjectWithTag("Enemy");

        if (leftEnemy == null && levelDuration <= 0)
        {
            gameData.GetComponent<GameData>().success = true;
            SceneManager.LoadScene("EndScreen", LoadSceneMode.Single);
        }

    }

    void LevelProcedure()
    {
        if (levelDuration >= 0 && counterSpawn <= 0)
        {
            counterSpawn = spawnRate;

            int enemyRandom = Random.Range(level-1,level+4);
            
                SpawnEnemy(enemyRandom);
        }

        counterSpawn -= Time.deltaTime;
    }

    void SpawnEnemy(int a)
    {

            if (a == 0)
            {
                Instantiate(enemy1, enemy1.transform.position + new Vector3(Random.Range(-2.5f, 2.5f), 0, 0), enemy1.transform.rotation);
            }
            if (a == 1)
            {
                Instantiate(enemy2, enemy2.transform.position + new Vector3(Random.Range(-2.5f, 2.5f), 0, 0), enemy2.transform.rotation);
            }
            if (a == 2)
            {
                Instantiate(enemy3, enemy3.transform.position + new Vector3(Random.Range(-2.5f, 2.5f), 0, 0), enemy3.transform.rotation);
            }
            if (a == 3)
            {
                Instantiate(enemy4, enemy4.transform.position + new Vector3(Random.Range(-2.5f, 2.5f), 0, 0), enemy4.transform.rotation);
            }
            if (a == 4)
            {
                Instantiate(enemy5, enemy5.transform.position + new Vector3(Random.Range(-2.5f, 2.5f), 0, 0), enemy5.transform.rotation);
            }
            if (a == 5)
            {
                Instantiate(enemy6, enemy6.transform.position + new Vector3(Random.Range(-2.5f, 2.5f), 0, 0), enemy6.transform.rotation);
            }
            if (a == 6)
            {
                Instantiate(enemy7, enemy7.transform.position + new Vector3(Random.Range(-2.5f, 2.5f), 0, 0), enemy7.transform.rotation);
            }
            if (a == 7)
            {
                Instantiate(enemy8, enemy8.transform.position + new Vector3(Random.Range(-2.5f, 2.5f), 0, 0), enemy8.transform.rotation);
            }
            if (a == 8)
            {
                Instantiate(enemy9, enemy9.transform.position + new Vector3(Random.Range(-2.5f, 2.5f), 0, 0), enemy9.transform.rotation);
            }
            if (a == 9)
            {
                Instantiate(enemy10, enemy10.transform.position + new Vector3(Random.Range(-2.5f, 2.5f), 0, 0), enemy10.transform.rotation);
            }
            if (a == 10)
            {
                Instantiate(enemy11, enemy11.transform.position + new Vector3(Random.Range(-2.5f, 2.5f), 0, 0), enemy11.transform.rotation);
            }
            if (a == 11)
            {
                Instantiate(enemy12, enemy12.transform.position + new Vector3(Random.Range(-2.5f, 2.5f), 0, 0), enemy12.transform.rotation);
            }
            if (a == 12)
            {
                Instantiate(enemy13, enemy13.transform.position + new Vector3(Random.Range(-2.5f, 2.5f), 0, 0), enemy13.transform.rotation);
            }

    }



}
