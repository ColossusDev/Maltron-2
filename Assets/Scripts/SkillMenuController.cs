using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillMenuController : MonoBehaviour {

    public GameObject skill1Level1;
    public GameObject skill1Level2;
    public GameObject skill1Level3;
    public GameObject skill1Level4;
    public GameObject skill1Level5;
    public GameObject skill1Level6;

    public GameObject skill2Level1;
    public GameObject skill2Level2;
    public GameObject skill2Level3;
    public GameObject skill2Level4;
    public GameObject skill2Level5;
    public GameObject skill2Level6;

    public GameObject skill3Level1;
    public GameObject skill3Level2;
    public GameObject skill3Level3;
    public GameObject skill3Level4;
    public GameObject skill3Level5;
    public GameObject skill3Level6;

    public GameObject skill4Level1;
    public GameObject skill4Level2;
    public GameObject skill4Level3;
    public GameObject skill4Level4;
    public GameObject skill4Level5;
    public GameObject skill4Level6;

    GameObject gameData;

    int skill1Price;
    int skill2Price;
    int skill3Price;
    int skill4Price;

    public GameObject skill1PriceText;
    public GameObject skill2PriceText;
    public GameObject skill3PriceText;
    public GameObject skill4PriceText;

    public Sprite finishButton;

    public GameObject buyButton1;
    public GameObject buyButton2;
    public GameObject buyButton3;
    public GameObject buyButton4;

    // Use this for initialization
    void Start () {
        gameData = GameObject.Find("GameDataController");

        skill1Price = 250;
        skill2Price = 150;
        skill3Price = 500;
        skill4Price = 300;


        UIUpdate();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void UIUpdate()
    {
        skill1PriceText.GetComponent<Text>().text = skill1Price * (2 * gameData.GetComponent<GameData>().skillLaserDamage + 1) + "$";
        skill2PriceText.GetComponent<Text>().text = skill2Price * (2 * gameData.GetComponent<GameData>().skillLaserSpeed + 1) + "$";
        skill3PriceText.GetComponent<Text>().text = skill3Price * (2 * gameData.GetComponent<GameData>().skillTurbineSpeed + 1) + "$";
        skill4PriceText.GetComponent<Text>().text = skill4Price * (2 * gameData.GetComponent<GameData>().skillHullStability + 1) + "$";

        if (gameData.GetComponent<GameData>().skillLaserDamage == 6)
        {
            skill1PriceText.GetComponent<Text>().enabled = false;
            buyButton1.GetComponent<Image>().sprite = finishButton;
        }
        if (gameData.GetComponent<GameData>().skillLaserSpeed == 6)
        {
            skill2PriceText.GetComponent<Text>().enabled = false;
            buyButton2.GetComponent<Image>().sprite = finishButton;
        }
        if (gameData.GetComponent<GameData>().skillTurbineSpeed == 6)
        {
            skill3PriceText.GetComponent<Text>().enabled = false;
            buyButton3.GetComponent<Image>().sprite = finishButton;
        }
        if (gameData.GetComponent<GameData>().skillHullStability == 6)
        {
            skill4PriceText.GetComponent<Text>().enabled = false;
            buyButton4.GetComponent<Image>().sprite = finishButton;
        }

        if (gameData.GetComponent<GameData>().skillLaserDamage >= 1)
        {
            skill1Level1.GetComponent<Image>().enabled = true;
        }
        if (gameData.GetComponent<GameData>().skillLaserDamage >= 2)
        {
            skill1Level2.GetComponent<Image>().enabled = true;
        }
        if (gameData.GetComponent<GameData>().skillLaserDamage >= 3)
        {
            skill1Level3.GetComponent<Image>().enabled = true;
        }
        if (gameData.GetComponent<GameData>().skillLaserDamage >= 4)
        {
            skill1Level4.GetComponent<Image>().enabled = true;
        }
        if (gameData.GetComponent<GameData>().skillLaserDamage >= 5)
        {
            skill1Level5.GetComponent<Image>().enabled = true;
        }
        if (gameData.GetComponent<GameData>().skillLaserDamage == 6)
        {
            skill1Level6.GetComponent<Image>().enabled = true;
        }

        if (gameData.GetComponent<GameData>().skillLaserSpeed >= 1)
        {
            skill2Level1.GetComponent<Image>().enabled = true;
        }
        if (gameData.GetComponent<GameData>().skillLaserSpeed >= 2)
        {
            skill2Level2.GetComponent<Image>().enabled = true;
        }
        if (gameData.GetComponent<GameData>().skillLaserSpeed >= 3)
        {
            skill2Level3.GetComponent<Image>().enabled = true;
        }
        if (gameData.GetComponent<GameData>().skillLaserSpeed >= 4)
        {
            skill2Level4.GetComponent<Image>().enabled = true;
        }
        if (gameData.GetComponent<GameData>().skillLaserSpeed >= 5)
        {
            skill2Level5.GetComponent<Image>().enabled = true;
        }
        if (gameData.GetComponent<GameData>().skillLaserSpeed == 6)
        {
            skill2Level6.GetComponent<Image>().enabled = true;
        }

        if (gameData.GetComponent<GameData>().skillTurbineSpeed >= 1)
        {
            skill3Level1.GetComponent<Image>().enabled = true;
        }
        if (gameData.GetComponent<GameData>().skillTurbineSpeed >= 2)
        {
            skill3Level2.GetComponent<Image>().enabled = true;
        }
        if (gameData.GetComponent<GameData>().skillTurbineSpeed >= 3)
        {
            skill3Level3.GetComponent<Image>().enabled = true;
        }
        if (gameData.GetComponent<GameData>().skillTurbineSpeed >= 4)
        {
            skill3Level4.GetComponent<Image>().enabled = true;
        }
        if (gameData.GetComponent<GameData>().skillTurbineSpeed >= 5)
        {
            skill3Level5.GetComponent<Image>().enabled = true;
        }
        if (gameData.GetComponent<GameData>().skillTurbineSpeed == 6)
        {
            skill3Level6.GetComponent<Image>().enabled = true;
        }

        if (gameData.GetComponent<GameData>().skillHullStability >= 1)
        {
            skill4Level1.GetComponent<Image>().enabled = true;
        }
        if (gameData.GetComponent<GameData>().skillHullStability >= 2)
        {
            skill4Level2.GetComponent<Image>().enabled = true;
        }
        if (gameData.GetComponent<GameData>().skillHullStability >= 3)
        {
            skill4Level3.GetComponent<Image>().enabled = true;
        }
        if (gameData.GetComponent<GameData>().skillHullStability >= 4)
        {
            skill4Level4.GetComponent<Image>().enabled = true;
        }
        if (gameData.GetComponent<GameData>().skillHullStability >= 5)
        {
            skill4Level5.GetComponent<Image>().enabled = true;
        }
        if (gameData.GetComponent<GameData>().skillHullStability == 6)
        {
            skill4Level6.GetComponent<Image>().enabled = true;
        }
    } 

    public void BuySkill(int skill)
    {
        if (skill == 1 && gameData.GetComponent<GameData>().money >= skill1Price * (2 * gameData.GetComponent<GameData>().skillLaserDamage+1) && gameData.GetComponent<GameData>().skillLaserDamage < 6)
        {
            gameData.GetComponent<GameData>().money -= skill1Price * (2 * gameData.GetComponent<GameData>().skillLaserDamage + 1);
            gameData.GetComponent<GameData>().skillLaserDamage++;
        }
        if (skill == 2 && gameData.GetComponent<GameData>().money >= skill2Price * (2 * gameData.GetComponent<GameData>().skillLaserSpeed + 1) && gameData.GetComponent<GameData>().skillLaserSpeed < 6)
        {
            gameData.GetComponent<GameData>().money -= skill2Price * (2 * gameData.GetComponent<GameData>().skillLaserSpeed + 1);
            gameData.GetComponent<GameData>().skillLaserSpeed++;
        }
        if (skill == 3 && gameData.GetComponent<GameData>().money >= skill3Price * (2 * gameData.GetComponent<GameData>().skillTurbineSpeed + 1) && gameData.GetComponent<GameData>().skillTurbineSpeed < 6)
        {
            gameData.GetComponent<GameData>().money -= skill3Price * (2 * gameData.GetComponent<GameData>().skillTurbineSpeed + 1);
            gameData.GetComponent<GameData>().skillTurbineSpeed++;
        }
        if (skill == 4 && gameData.GetComponent<GameData>().money >= skill4Price * (2 * gameData.GetComponent<GameData>().skillHullStability + 1) && gameData.GetComponent<GameData>().skillHullStability < 6)
        {
            gameData.GetComponent<GameData>().money -= skill4Price * (2 * gameData.GetComponent<GameData>().skillHullStability + 1);
            gameData.GetComponent<GameData>().skillHullStability++;
        }

        UIUpdate();
    }



}
