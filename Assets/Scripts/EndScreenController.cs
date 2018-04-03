using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class EndScreenController : MonoBehaviour {

    GameObject gameData;
    GameObject finshText;

    GameObject nextButton;
    GameObject textNextButton;
    GameObject restartButton;
    GameObject textRestartButton;

    // Use this for initialization
    void Start () {
        gameData = GameObject.Find("GameDataController");
        finshText = GameObject.Find("Canvas/Text");

        nextButton = GameObject.Find("NextButton");
        restartButton = GameObject.Find("RestartButton");

        textNextButton = GameObject.Find("NextButton/TextNextButton");
        textRestartButton = GameObject.Find("RestartButton/TextRestartButton");

        if (gameData.GetComponent<GameData>().success == true)
        {
            finshText.GetComponent<Text>().text = "YOU WON!";
            gameData.GetComponent<GameData>().LevelMap[gameData.GetComponent<GameData>().currentLevel-1] = 2;
            gameData.GetComponent<GameData>().LevelMap[gameData.GetComponent<GameData>().currentLevel] = 1;

            nextButton.GetComponent<Image>().enabled = true;
            nextButton.GetComponent<Button>().enabled = true;
            textNextButton.GetComponent<Text>().enabled = true;

        }
        else
        {
            finshText.GetComponent<Text>().text = "YOU LOSE!";

            restartButton.GetComponent<Image>().enabled = true;
            restartButton.GetComponent<Button>().enabled = true;
            textRestartButton.GetComponent<Text>().enabled = true;
        }
    }

    // Update is called once per frame
    void Update () {

    }

    public void GoBack()
    {
        SceneManager.LoadScene("LevelMenu", LoadSceneMode.Single);
        gameData.GetComponent<GameData>().currentLevel = 0;
        gameData.GetComponent<GameData>().success = false;

    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
        Debug.Log("Loading Level: " + gameData.GetComponent<GameData>().currentLevel);
    }

    public void PlayNextLevel()
    {
        gameData.GetComponent<GameData>().currentLevel += 1;
        gameData.GetComponent<GameData>().success = false;
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
        Debug.Log("Loading Level: " + gameData.GetComponent<GameData>().currentLevel);
    }

}
