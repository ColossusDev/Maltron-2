using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.UI;

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

    public Sprite buyButton;
    public Sprite equipButton;
    public Sprite deselectButton;

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

    public GameObject priceTextItem1;
    public GameObject priceTextItem2;
    public GameObject priceTextItem3;
    public GameObject priceTextItem4;

    int item1Counter = 0;
    int item2Counter = 0;
    int item3Counter = 0;
    int item4Counter = 0;

    int[] item1Prices = new int[4];
    int[] item2Prices = new int[4];
    int[] item3Prices = new int[4];
    int[] item4Prices = new int[4];


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

        item1Prices[0] = 2500;
        item2Prices[0] = 1000;
        item3Prices[0] = 1000;
        item4Prices[0] = 1200;

        item1Prices[1] = 3500;
        item2Prices[1] = 8000;
        item3Prices[1] = 2000;
        item4Prices[1] = 2500;

        item1Prices[2] = 5000;
        item2Prices[2] = 25000;
        item3Prices[2] = 6000;
        item4Prices[2] = 7000;

        item1Prices[3] = 14000;
        item2Prices[3] = 80000;
        item3Prices[3] = 12000;
        item4Prices[3] = 15000;

        UIUpdate();
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

        priceTextItem1.GetComponent<Text>().text = item1Prices[item1Counter] + "$";
        priceTextItem2.GetComponent<Text>().text = item2Prices[item2Counter] + "$";
        priceTextItem3.GetComponent<Text>().text = item3Prices[item3Counter] + "$";
        priceTextItem4.GetComponent<Text>().text = item4Prices[item4Counter] + "$";

        //1
        if (gameData.GetComponent<GameData>().ownItem1[item1Counter] == false)
        {
            buyButtonItem1.GetComponent<Image>().sprite = buyButton;
            priceTextItem1.GetComponent<Text>().enabled = true;
        }
        else if (gameData.GetComponent<GameData>().equiptItem1[item1Counter] == false)
        {
            buyButtonItem1.GetComponent<Image>().sprite = equipButton;
            priceTextItem1.GetComponent<Text>().text = "owned";
        }
        else
        {
            buyButtonItem1.GetComponent<Image>().sprite = deselectButton;
            priceTextItem1.GetComponent<Text>().enabled = true;
            priceTextItem1.GetComponent<Text>().text = "equiped";
        }
        //2
        if (gameData.GetComponent<GameData>().ownItem2[item2Counter] == false)
        {
            buyButtonItem2.GetComponent<Image>().sprite = buyButton;
            priceTextItem2.GetComponent<Text>().enabled = true;
        }
        else if (gameData.GetComponent<GameData>().equiptItem2[item2Counter] == false)
        {
            buyButtonItem2.GetComponent<Image>().sprite = equipButton;
            priceTextItem2.GetComponent<Text>().text = "owned";
        }
        else
        {
            buyButtonItem2.GetComponent<Image>().sprite = deselectButton;
            priceTextItem2.GetComponent<Text>().enabled = true;
            priceTextItem2.GetComponent<Text>().text = "equiped";
        }
        //3
        if (gameData.GetComponent<GameData>().ownItem3[item3Counter] == false)
        {
            buyButtonItem3.GetComponent<Image>().sprite = buyButton;
            priceTextItem3.GetComponent<Text>().enabled = true;
        }
        else if (gameData.GetComponent<GameData>().equiptItem3[item3Counter] == false)
        {
            buyButtonItem3.GetComponent<Image>().sprite = equipButton;
            priceTextItem3.GetComponent<Text>().text = "owned";
        }
        else
        {
            buyButtonItem3.GetComponent<Image>().sprite = deselectButton;
            priceTextItem3.GetComponent<Text>().enabled = true;
            priceTextItem3.GetComponent<Text>().text = "equiped";
        }
        //4
        if (gameData.GetComponent<GameData>().ownItem4[item4Counter] == false)
        {
            buyButtonItem4.GetComponent<Image>().sprite = buyButton;
            priceTextItem4.GetComponent<Text>().enabled = true;
        }
        else if (gameData.GetComponent<GameData>().equiptItem4[item4Counter] == false)
        {
            buyButtonItem4.GetComponent<Image>().sprite = equipButton;
            priceTextItem4.GetComponent<Text>().text = "owned";
        }
        else
        {
            buyButtonItem4.GetComponent<Image>().sprite = deselectButton;
            priceTextItem4.GetComponent<Text>().enabled = true;
            priceTextItem4.GetComponent<Text>().text = "equiped";
        }
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
        if (item == 1)
        {
            if (item1Prices[item1Counter] <= gameData.GetComponent<GameData>().money && gameData.GetComponent<GameData>().ownItem1[item1Counter] == false)
            {
                gameData.GetComponent<GameData>().money -= item1Prices[item1Counter];
                gameData.GetComponent<GameData>().ownItem1[item1Counter] = true;
                for (int i = 0; i < gameData.GetComponent<GameData>().ownItem1.Length; i++)
                {
                    gameData.GetComponent<GameData>().equiptItem1[i] = false;
                }
                gameData.GetComponent<GameData>().equiptItem1[item1Counter] = true;
            }
            else if(gameData.GetComponent<GameData>().ownItem1[item1Counter] == true && gameData.GetComponent<GameData>().equiptItem1[item1Counter] == false)
            {
                for (int i = 0; i < gameData.GetComponent<GameData>().ownItem1.Length; i++)
                {
                    gameData.GetComponent<GameData>().equiptItem1[i] = false;
                }
                gameData.GetComponent<GameData>().equiptItem1[item1Counter] = true;
            }
            else if (gameData.GetComponent<GameData>().equiptItem1[item1Counter] == true)
            {
                for (int i = 0; i < gameData.GetComponent<GameData>().ownItem1.Length; i++)
                {
                    gameData.GetComponent<GameData>().equiptItem1[i] = false;
                }
            }
        }
        if (item == 2)
        {
            if (item2Prices[item2Counter] <= gameData.GetComponent<GameData>().money && gameData.GetComponent<GameData>().ownItem2[item2Counter] == false)
            {
                gameData.GetComponent<GameData>().money -= item2Prices[item2Counter];
                gameData.GetComponent<GameData>().ownItem2[item2Counter] = true;
                for (int i = 0; i < gameData.GetComponent<GameData>().ownItem2.Length; i++)
                {
                    gameData.GetComponent<GameData>().equiptItem2[i] = false;
                }
                gameData.GetComponent<GameData>().equiptItem2[item2Counter] = true;
            }
            else if (gameData.GetComponent<GameData>().ownItem2[item2Counter] == true && gameData.GetComponent<GameData>().equiptItem2[item2Counter] == false)
            {
                for (int i = 0; i < gameData.GetComponent<GameData>().ownItem2.Length; i++)
                {
                    gameData.GetComponent<GameData>().equiptItem2[i] = false;
                }
                gameData.GetComponent<GameData>().equiptItem2[item2Counter] = true;
            }
            else if (gameData.GetComponent<GameData>().equiptItem2[item2Counter] == true)
            {
                for (int i = 0; i < gameData.GetComponent<GameData>().ownItem2.Length; i++)
                {
                    gameData.GetComponent<GameData>().equiptItem2[i] = false;
                }
            }
        }
        if (item == 3)
        {
            if (item3Prices[item3Counter] <= gameData.GetComponent<GameData>().money && gameData.GetComponent<GameData>().ownItem3[item3Counter] == false)
            {
                gameData.GetComponent<GameData>().money -= item3Prices[item3Counter];
                gameData.GetComponent<GameData>().ownItem3[item3Counter] = true;
                for (int i = 0; i < gameData.GetComponent<GameData>().ownItem3.Length; i++)
                {
                    gameData.GetComponent<GameData>().equiptItem3[i] = false;
                }
                gameData.GetComponent<GameData>().equiptItem3[item3Counter] = true;
            }
            else if (gameData.GetComponent<GameData>().ownItem3[item3Counter] == true && gameData.GetComponent<GameData>().equiptItem3[item3Counter] == false)
            {
                for (int i = 0; i < gameData.GetComponent<GameData>().ownItem3.Length; i++)
                {
                    gameData.GetComponent<GameData>().equiptItem3[i] = false;
                }
                gameData.GetComponent<GameData>().equiptItem3[item3Counter] = true;
            }
            else if (gameData.GetComponent<GameData>().equiptItem3[item3Counter] == true)
            {
                for (int i = 0; i < gameData.GetComponent<GameData>().ownItem3.Length; i++)
                {
                    gameData.GetComponent<GameData>().equiptItem3[i] = false;
                }
            }
        }
        if (item == 4)
        {
            if (item4Prices[item4Counter] <= gameData.GetComponent<GameData>().money && gameData.GetComponent<GameData>().ownItem4[item4Counter] == false)
            {
                gameData.GetComponent<GameData>().money -= item4Prices[item4Counter];
                gameData.GetComponent<GameData>().ownItem4[item4Counter] = true;
                for (int i = 0; i < gameData.GetComponent<GameData>().ownItem4.Length; i++)
                {
                    gameData.GetComponent<GameData>().equiptItem4[i] = false;
                }
                gameData.GetComponent<GameData>().equiptItem4[item4Counter] = true;
            }
            else if (gameData.GetComponent<GameData>().ownItem4[item4Counter] == true && gameData.GetComponent<GameData>().equiptItem4[item4Counter] == false)
            {
                for (int i = 0; i < gameData.GetComponent<GameData>().ownItem4.Length; i++)
                {
                    gameData.GetComponent<GameData>().equiptItem4[i] = false;
                }
                gameData.GetComponent<GameData>().equiptItem4[item4Counter] = true;
            }
            else if (gameData.GetComponent<GameData>().equiptItem4[item4Counter] == true)
            {
                for (int i = 0; i < gameData.GetComponent<GameData>().ownItem4.Length; i++)
                {
                    gameData.GetComponent<GameData>().equiptItem4[i] = false;
                }
            }
        }

        UIUpdate();
    }

}
