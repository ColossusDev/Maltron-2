using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelController : MonoBehaviour {

    GameObject gameData;

    int level;

    public GameObject[] levelList;

	// Use this for initialization
	void Start () {

        gameData = GameObject.Find("GameDataController");

        level = gameData.GetComponent<GameData>().currentLevel;

        Instantiate(levelList[level], levelList[level].transform.position, Quaternion.identity);


    }

    // Update is called once per frame
    void Update () {



    }

    





}
