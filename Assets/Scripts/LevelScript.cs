using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour {

    public GameObject[] enemys;
    public GameObject finalE;

    public float levelDuration;
    public int enemyCount;
    float spawnRate;
    float counterSpawn;

    public bool finalEnemy = false;

    GameObject gameData;


    // Use this for initialization
    void Start () {

        gameData = GameObject.Find("GameDataController");



        spawnRate = levelDuration / enemyCount;

        counterSpawn = spawnRate;
    }
	
	// Update is called once per frame
	void Update () {


        //level zeitmessung
        levelDuration -= Time.deltaTime;

        if (enemys.Length > 0)
        {
            LevelProcedure();
        }



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
            SpawnEnemy();
        }

        counterSpawn -= Time.deltaTime;
    }

    void SpawnEnemy()
    {
        int enemyType = Random.Range(0, enemys.Length);
        Instantiate(enemys[enemyType], enemys[enemyType].transform.position + new Vector3(Random.Range(-2.5f, 2.5f), -1.5f, 0), enemys[1].transform.rotation);

        counterSpawn = spawnRate;
    }
}
