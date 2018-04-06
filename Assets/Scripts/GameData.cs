using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameData : MonoBehaviour {

    public static GameData gameData;

    public int[] LevelMap;

    public int money;

    public int currentLevel;
    public bool success = false;

    GameObject moneyText;


    void Awake () {
        if (gameData == null)
        {
            DontDestroyOnLoad(this.gameObject);
            gameData = this;
        }else if (gameData != null)
        {
            Destroy(this);
        }

        //wenn keine Datne auf Handy gefunden werden bzw. kein Spieler eingeloggt ist
        if (true)
        {
            LevelMap = new int[20];
            SetLevelToStart();
        }
        else
        {
            //Load from Handy
        }
	}
	
	void Update () {
        if (moneyText == null)
        {
            moneyText = GameObject.Find("MoneyText");
        }
        else
        {
            moneyText.GetComponent<Text>().text = money + "$";
        }
	}


    void SetLevelToStart()
    {
        for (int i = 0; i < LevelMap.Length; i++)
        {
            LevelMap[i] = 0;
        }
        LevelMap[0] = 1;

    }

    public void AddMoney(int moneyAdd)
    {
        money += moneyAdd;
    }

    public void NegMoney(int moneyNeg)
    {
        money -= moneyNeg;
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void OpenSettings()
    {
        //SceneManager.LoadScene("Settings", LoadSceneMode.Single);
    }

    public void OpenAchievements()
    {
        //SceneManager.LoadScene("Achievements", LoadSceneMode.Single);
    }

}
