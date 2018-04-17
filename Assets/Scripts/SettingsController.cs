using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsController : MonoBehaviour {


    GameObject gameData;

    public GameObject soundButton;
    public GameObject controllButton;

    public Sprite controllButtonRed;
    public Sprite controllButtonGreen;

    public Sprite soundButtonGreen;
    public Sprite soundButtonRed;


    // Use this for initialization
    void Start () {
        gameData = GameObject.Find("GameDataController");

        if (gameData.GetComponent<GameData>().gyroControlls == true)
        {
            controllButton.GetComponent<Image>().sprite = controllButtonGreen;
        }
        else
        {
            controllButton.GetComponent<Image>().sprite = controllButtonRed;
        }

        if (gameData.GetComponent<GameData>().sound == true)
        {
            soundButton.GetComponent<Image>().sprite = soundButtonGreen;
        }
        else
        {
            soundButton.GetComponent<Image>().sprite = soundButtonRed;
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void SwitchControllSetting()
    {
        if (gameData.GetComponent<GameData>().gyroControlls == true)
        {
            gameData.GetComponent<GameData>().gyroControlls = false;
            controllButton.GetComponent<Image>().sprite = controllButtonRed;
        }
        else
        {
            gameData.GetComponent<GameData>().gyroControlls = true;
            controllButton.GetComponent<Image>().sprite = controllButtonGreen;
        }
    }

    public void SwitchSoundSetting()
    {
        if (gameData.GetComponent<GameData>().sound == true)
        {
            gameData.GetComponent<GameData>().sound = false;
            soundButton.GetComponent<Image>().sprite = soundButtonRed;
        }
        else
        {
            gameData.GetComponent<GameData>().sound = true;
            soundButton.GetComponent<Image>().sprite = soundButtonGreen;
        }
    }
}
