using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipCreatorController : MonoBehaviour {

    GameObject gameData;

    public GameObject item1;
    public GameObject item2;
    public GameObject item3;
    public GameObject item4;

    public GameObject buyButtonItem1;
    public GameObject buyButtonItem2;
    public GameObject buyButtonItem3;
    public GameObject buyButtonItem4;

    public Sprite item1Sprite1;
    public Sprite item1Sprite2;
    public Sprite item1Sprite3;
    public Sprite item1Sprite4;

    public Sprite item2Sprite1;
    public Sprite item2Sprite2;
    public Sprite item2Sprite3;
    public Sprite item2Sprite4;

    public Sprite item3Sprite1;
    public Sprite item3Sprite2;
    public Sprite item3Sprite3;
    public Sprite item3Sprite4;

    public Sprite item4Sprite1;
    public Sprite item4Sprite2;
    public Sprite item4Sprite3;
    public Sprite item4Sprite4;

    Sprite[] item1Sprites = new Sprite[4];
    Sprite[] item2Sprites = new Sprite[4];
    Sprite[] item3Sprites = new Sprite[4];
    Sprite[] item4Sprites = new Sprite[4];

    int item1Counter = 0;
    int item2Counter = 0;
    int item3Counter = 0;
    int item4Counter = 0;

    // Use this for initialization
    void Start () {
        gameData = GameObject.Find("GameDataController");

        item1Sprites[0] = item1Sprite1;
        item1Sprites[1] = item1Sprite2;
        item1Sprites[2] = item1Sprite3;
        item1Sprites[3] = item1Sprite4;

        item2Sprites[0] = item2Sprite1;
        item2Sprites[1] = item2Sprite2;
        item2Sprites[2] = item2Sprite3;
        item2Sprites[3] = item2Sprite4;

        item3Sprites[0] = item3Sprite1;
        item3Sprites[1] = item3Sprite2;
        item3Sprites[2] = item3Sprite3;
        item3Sprites[3] = item3Sprite4;

        item4Sprites[0] = item4Sprite1;
        item4Sprites[1] = item4Sprite2;
        item4Sprites[2] = item4Sprite3;
        item4Sprites[3] = item4Sprite4;

        for (int i = 0; i < gameData.GetComponent<GameData>().equiptItem1.Length; i++)
        {
            if (gameData.GetComponent<GameData>().equiptItem1[i] == true)
            {
                item1.GetComponent<Image>().sprite = item1Sprites[i];
                item1Counter = i;
            }
        }

        for (int i = 0; i < gameData.GetComponent<GameData>().equiptItem2.Length; i++)
        {
            if (gameData.GetComponent<GameData>().equiptItem2[i] == true)
            {
                item2.GetComponent<Image>().sprite = item2Sprites[i];
                item2Counter = i;
            }
        }

        for (int i = 0; i < gameData.GetComponent<GameData>().equiptItem3.Length; i++)
        {
            if (gameData.GetComponent<GameData>().equiptItem3[i] == true)
            {
                item3.GetComponent<Image>().sprite = item3Sprites[i];
                item3Counter = i;
            }
        }

        for (int i = 0; i < gameData.GetComponent<GameData>().equiptItem4.Length; i++)
        {
            if (gameData.GetComponent<GameData>().equiptItem4[i] == true)
            {
                item4.GetComponent<Image>().sprite = item4Sprites[i];
                item4Counter = i;
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}

    void UIUpdate()
    {
        item1.GetComponent<Image>().sprite = item1Sprites[item1Counter];
        item2.GetComponent<Image>().sprite = item2Sprites[item2Counter];
        item3.GetComponent<Image>().sprite = item3Sprites[item3Counter];
        item4.GetComponent<Image>().sprite = item4Sprites[item4Counter];
    }

    public void SwitchButtonRight(int item)
    {
        if (item == 1)
        {
            item1Counter++;
            if (item1Counter > 3)
            {
                item1Counter = 0;
            }
        }

        if (item == 2)
        {
            item2Counter++;
            if (item2Counter > 3)
            {
                item2Counter = 0;
            }
        }

        if (item == 3)
        {
            item3Counter++;
            if (item3Counter > 3)
            {
                item3Counter = 0;
            }
        }

        if (item == 4)
        {
            item4Counter++;
            if (item4Counter > 3)
            {
                item4Counter = 0;
            }
        }

        UIUpdate();
    }

    public void SwitchButtonLeft(int item)
    {
        if (item == 1)
        {
            item1Counter--;
            if (item1Counter < 0)
            {
                item1Counter = 3;
            }
        }

        if (item == 2)
        {
            item2Counter--;
            if (item2Counter < 0)
            {
                item2Counter = 3;
            }
        }

        if (item == 3)
        {
            item3Counter--;
            if (item3Counter < 0)
            {
                item3Counter = 3;
            }
        }

        if (item == 4)
        {
            item4Counter--;
            if (item4Counter < 0)
            {
                item4Counter = 3;
            }
        }

        UIUpdate();
    }

    public void BuyItem(int item)
    {

    }

    public void EquipItem(int item)
    {

    }

    public void DeselectItem(int item)
    {

    }
}
