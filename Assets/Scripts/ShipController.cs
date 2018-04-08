using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ShipController : MonoBehaviour
{

    GameObject gameData;

    public GameObject shot0;
    public GameObject shot1;
    public GameObject shot2;
    public GameObject shot3;
    public GameObject shot4;
    public GameObject shot5;
    public GameObject shot6;

    public GameObject explosion;

    public GameObject usedShot;


    float shipSpeed = 5;

    bool shooting = false;
    float gunCoolDown = 0;


    float gunCoolDownTimer = 0;
    int lasergun = 0;
    int laserDamage = 0;
    int life = 0;

    bool dead = false;
    float deadCounter = 1;


    GameObject life1;
    GameObject life2;
    GameObject life3;

    // Use this for initialization
    void Start()
    {
        gameData = GameObject.Find("GameDataController");

        life1 = GameObject.Find("Canvas/MainPanel/LifePanel/Life1");
        life2 = GameObject.Find("Canvas/MainPanel/LifePanel/Life2");
        life3 = GameObject.Find("Canvas/MainPanel/LifePanel/Life3");


        usedShot = shot0;

        StartUpShip();

        if (life1 != null)
        {
            DrawLifes();
        }


    }

    void StartUpShip()
    {
        life = 2;
        if (gameData.GetComponent<GameData>().skillHullStability > 0)
        {
            life = gameData.GetComponent<GameData>().skillHullStability+2;
        }

        if (gameData.GetComponent<GameData>().skillLaserDamage == 1)
        {
            usedShot = shot1;
        }
        if (gameData.GetComponent<GameData>().skillLaserDamage == 2)
        {
            usedShot = shot2;
        }
        if (gameData.GetComponent<GameData>().skillLaserDamage == 3)
        {
            usedShot = shot3;
        }
        if (gameData.GetComponent<GameData>().skillLaserDamage == 4)
        {
            usedShot = shot4;
        }
        if (gameData.GetComponent<GameData>().skillLaserDamage == 5)
        {
            usedShot = shot5;
        }
        if (gameData.GetComponent<GameData>().skillLaserDamage == 6)
        {
            usedShot = shot6;
        }

        if (gameData.GetComponent<GameData>().skillLaserSpeed > 0)
        {
            gunCoolDown = (100 / (2 * gameData.GetComponent<GameData>().skillLaserSpeed) / 100);
        }

        if (gameData.GetComponent<GameData>().skillTurbineSpeed > 0)
        {
            shipSpeed = 5 + gameData.GetComponent<GameData>().skillTurbineSpeed * 2;
        }
    }


    void Update()
    {

        if (dead == true)
        {
            deadCounter -= Time.deltaTime;
        }
        if (dead == true && deadCounter <= 0)
        {
            SceneManager.LoadScene("EndScreen", LoadSceneMode.Single);
            Destroy(this.gameObject);
        }


            if (dead != true)
            {
            float translation = Input.GetAxis("Horizontal") * shipSpeed;
            translation *= Time.deltaTime;
            this.gameObject.transform.Translate(translation, 0, 0);

            if (this.gameObject.transform.position.x > 2.4)
            {
                this.gameObject.transform.position = new Vector3(2.4f, -4, 0);
            }
            if (this.gameObject.transform.position.x < -2.4)
            {
                this.gameObject.transform.position = new Vector3(-2.4f, -4, 0);
            }

            if (Input.GetButtonDown("Jump") == true)
            {
                shooting = true;
            }
            if (Input.GetButtonUp("Jump") == true)
            {
                shooting = false;
            }

            if (gunCoolDownTimer > 0)
            {
                gunCoolDownTimer -= Time.deltaTime;
            }
            else
            {
                if (shooting == true && lasergun == 0)
                {
                    Instantiate(shot1, this.gameObject.transform.position + new Vector3(0, 0.8f, 0), shot1.transform.rotation);
                    gunCoolDownTimer = gunCoolDown;
                }
                if (shooting == true && lasergun == 2)
                {
                    Instantiate(shot1, this.gameObject.transform.position + new Vector3(-0.2f, 0.8f, 0), shot1.transform.rotation * new Quaternion(-1, 15, 0, 0));
                    Instantiate(shot1, this.gameObject.transform.position + new Vector3(0.2f, 0.8f, 0), shot1.transform.rotation * new Quaternion(1, 15, 0, 0));
                    gunCoolDownTimer = gunCoolDown;
                }
                if (shooting == true && lasergun == 3)
                {
                    Instantiate(shot1, this.gameObject.transform.position + new Vector3(0, 0.8f, 0), shot1.transform.rotation);
                    Instantiate(shot1, this.gameObject.transform.position + new Vector3(-0.2f, 0.8f, 0), shot1.transform.rotation * new Quaternion(-1, 15, 0, 0));
                    Instantiate(shot1, this.gameObject.transform.position + new Vector3(0.2f, 0.8f, 0), shot1.transform.rotation * new Quaternion(1, 15, 0, 0));
                    gunCoolDownTimer = gunCoolDown;
                }
                if (shooting == true && lasergun == 4)
                {
                    Instantiate(shot1, this.gameObject.transform.position + new Vector3(0, 0.8f, 0), shot1.transform.rotation);
                    Instantiate(shot1, this.gameObject.transform.position + new Vector3(-0.2f, 0.8f, 0), shot1.transform.rotation * new Quaternion(-1, 15, 0, 0));
                    Instantiate(shot1, this.gameObject.transform.position + new Vector3(0.2f, 0.8f, 0), shot1.transform.rotation * new Quaternion(1, 15, 0, 0));
                    Instantiate(shot1, this.gameObject.transform.position + new Vector3(-0.3f, 0.8f, 0), shot1.transform.rotation * new Quaternion(-1, 7, 0, 0));
                    Instantiate(shot1, this.gameObject.transform.position + new Vector3(0.3f, 0.8f, 0), shot1.transform.rotation * new Quaternion(1, 7, 0, 0));
                    gunCoolDownTimer = gunCoolDown;
                }
            }
        }


        

    }

    void DrawLifes()
    {
        if (life == 3)
        {
            life1.GetComponent<Image>().enabled = true;
            life2.GetComponent<Image>().enabled = true;
            life3.GetComponent<Image>().enabled = true;
        }
        if (life == 2)
        {
            life1.GetComponent<Image>().enabled = true;
            life2.GetComponent<Image>().enabled = true;
            life3.GetComponent<Image>().enabled = false;
        }
        if (life == 1)
        {
            life1.GetComponent<Image>().enabled = true;
            life2.GetComponent<Image>().enabled = false;
            life3.GetComponent<Image>().enabled = false;
        }
        if (life == 0)
        {
            life1.GetComponent<Image>().enabled = false;
            life2.GetComponent<Image>().enabled = false;
            life3.GetComponent<Image>().enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (dead != true)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                life--;
                Destroy(collision.gameObject);

                if (life1 != null)
                {
                    DrawLifes();
                }
            }

            if (life <= 0)
            {
                Instantiate(explosion, this.gameObject.transform.position + new Vector3(0, 0, 0), explosion.transform.rotation);
                dead = true;

                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}