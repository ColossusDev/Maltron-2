using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelMenuController : MonoBehaviour {

    int[] levelMap;

    GameObject gameData;

    public Sprite buttonGreen;
    public Sprite buttonBlue;
    public Sprite buttonRed;

	// Use this for initialization
	void Start () {

        gameData = GameObject.Find("GameDataController");

        levelMap = gameData.gameObject.GetComponent<GameData>().LevelMap;

        SetButtonColor();
    }
	
	// Update is called once per frame
	void Update () {

	}


    public void StartLevel(int level)
    {

        if (levelMap[level-1] == 1 || levelMap[level-1] == 2)
        {
            gameData.GetComponent<GameData>().currentLevel = level;
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
            Debug.Log("Loading Level: " + level);
        }

        SetButtonColor();
    }

    public void NextLevel()
    {
        for (int i = 0; i < levelMap.Length; i++)
        {
            if (levelMap[i] == 1)
            {

                StartLevel(i+1);
            }
        }
    }

    void SetButtonColor()
    {

        for (int i = 0; i < levelMap.Length; i++)
        {
            int a = i + 1;

            string nameX = "Canvas/LevelButton" + a;

            GameObject buttonX = GameObject.Find(nameX);

            if (buttonX != null)
            {
                if (levelMap[i] == 2)
                {
                    buttonX.GetComponent<Image>().sprite = buttonGreen;
                }
                if (levelMap[i] == 1)
                {
                    buttonX.GetComponent<Image>().sprite = buttonBlue;
                }
                if (levelMap[i] == 0)
                {
                    buttonX.GetComponent<Image>().sprite = buttonRed;
                }
            }

        }
    }
}
