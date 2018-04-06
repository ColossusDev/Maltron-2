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

    public bool[] equiptItem1 = new bool[4];
    public bool[] equiptItem2 = new bool[4];
    public bool[] equiptItem3 = new bool[4];
    public bool[] equiptItem4 = new bool[4];

    public bool[] ownItem1 = new bool[4];
    public bool[] ownItem2 = new bool[4];
    public bool[] ownItem3 = new bool[4];
    public bool[] ownItem4 = new bool[4];

    public int skillLaserDamage;
    public int skillLaserSpeed;
    public int skillTurbineSpeed;
    public int skillHullStability;

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

            equiptItem1 = new bool[4];
            equiptItem2 = new bool[4];
            equiptItem3 = new bool[4];
            equiptItem4 = new bool[4];

            ownItem1 = new bool[4];
            ownItem2 = new bool[4];
            ownItem3 = new bool[4];
            ownItem4 = new bool[4];

            for (int i = 0; i < equiptItem1.Length; i++)
            {
                equiptItem1[i] = false;
                equiptItem2[i] = false;
                equiptItem3[i] = false;
                equiptItem4[i] = false;

                ownItem1[i] = false;
                ownItem2[i] = false;
                ownItem3[i] = false;
                ownItem4[i] = false;
            }

            money = 100000;

            skillLaserDamage = 0;
            skillLaserSpeed = 0;
            skillTurbineSpeed = 0;
            skillHullStability = 0;
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
        SceneManager.LoadScene("Settings", LoadSceneMode.Single);
    }

    public void OpenAchievements()
    {
        SceneManager.LoadScene("Achievements", LoadSceneMode.Single);
    }

}
