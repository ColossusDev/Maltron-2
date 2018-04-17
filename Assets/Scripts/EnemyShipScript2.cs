using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShipScript2 : MonoBehaviour
{

    public GameObject shot1;

    public bool shooting = false;

    public float gunCoolDownTimer = 1;
    public float gunCoolDown = 1;

    public int life = 5;

    public float speed = 1;
    public float sideSpeed = 1;

    Vector3 direction;

    int baseLife;

    GameData gameData;
    public int moneyMultiplier = 2;

    // Use this for initialization
    void Start()
    {

        gameData = GameObject.Find("GameDataController").GetComponent<GameData>();

        shooting = true;


        if (Random.Range(0, 2) == 0)
        {
            direction = new Vector3(sideSpeed, -speed, 0);
        }
        else
        {
            direction = new Vector3(-sideSpeed, -speed, 0);
        }

        // für Money Berechnung
        baseLife = life;
    }

    // Update is called once per frame
    void Update()
    {

        if (this.gameObject.transform.position.x > 2.5f)
        {
            direction = new Vector3(-sideSpeed, -speed, 0);
        }
        if (this.gameObject.transform.position.x < -2.5f)
        {
            direction = new Vector3(sideSpeed, -speed, 0);
        }

        //movement
        this.gameObject.transform.position = this.gameObject.transform.position + (Time.deltaTime * direction);


        if (shooting == true && gunCoolDownTimer <= 0)
        {
            Instantiate(shot1, this.gameObject.transform.position + new Vector3(0f, -0.5f, 0), shot1.transform.rotation * new Quaternion(0, 0, 2, 0));

            gunCoolDownTimer = gunCoolDown;


        }

        gunCoolDownTimer -= Time.deltaTime;


        if (this.gameObject.transform.position.y <= -8)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Shot")
        {
            life = life - (gameData.GetComponent<GameData>().skillLaserDamage + 1);
            Destroy(collision.gameObject);
        }

        if (life <= 0)
        {
            gameData.AddMoney(baseLife * moneyMultiplier);
            gameData.pointScore += (baseLife * moneyMultiplier);
            Destroy(this.gameObject);
        }
    }
}
