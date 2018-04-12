using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour {


    GameObject gameData;

    // Use this for initialization
    void Start () {
        gameData = GameObject.Find("GameDataController");

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void SwitchControllSetting()
    {
        if (gameData.GetComponent<GameData>().gyroControlls == true)
        {
            gameData.GetComponent<GameData>().gyroControlls = false;
        }
        else
        {
            gameData.GetComponent<GameData>().gyroControlls = true;
        }
    }
}
