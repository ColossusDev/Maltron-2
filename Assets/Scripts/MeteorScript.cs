using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorScript : MonoBehaviour {


    public GameObject split1;
    public GameObject split2;
    public GameObject split3;

    public float speed = 1;

    public int life = 3;
    int baseLife;
    public int moneyMultiplier = 1;

    float rotationD;

    public float randomSideSpeedMax = 1.1f;

    Vector3 direction;

    GameData gameData;

    public float rotationMax = 0.7f;

	// Use this for initialization
	void Start () {

        gameData = GameObject.Find("GameDataController").GetComponent<GameData>();

        rotationD = Random.Range(-rotationMax, rotationMax);

        direction = new Vector3(0, -speed, 0);


        if (split1 == null)
        {
            life = 1;
            direction = new Vector3(Random.Range(-randomSideSpeedMax,randomSideSpeedMax),-speed,0);
        }


        //Für Money Berechnung 
        baseLife = life;
    }

    // Update is called once per frame
    void Update () {

        //movement
        this.gameObject.transform.position = this.gameObject.transform.position + (Time.deltaTime * direction);
        
        //alternativ movement
        //this.gameObject.transform.Translate(0, realSpeed, 0);

        //rotation
        this.gameObject.transform.RotateAround(this.gameObject.transform.position, Vector3.forward, rotationD);


        if (this.gameObject.transform.position.y <= -6)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shot")
        {
            life --;
            Destroy(collision.gameObject);
        }

        if (life <= 0)
        {
            if (split1 != null)
            {
                Instantiate(split1, this.gameObject.transform.position + new Vector3(0.5f, 0.5f, 0), split1.transform.rotation);
                Instantiate(split2, this.gameObject.transform.position + new Vector3(0, -0.5f, 0), split2.transform.rotation);
                Instantiate(split3, this.gameObject.transform.position + new Vector3(-0.5f, 0.5f, 0), split3.transform.rotation);
            }
            gameData.AddMoney(baseLife * moneyMultiplier);
            Destroy(this.gameObject);
        }
    }

}
