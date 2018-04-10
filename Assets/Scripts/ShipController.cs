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


    float shipSpeed = 1;

    bool shooting = false;
    public float gunCoolDown = 0;


    float gunCoolDownTimer = 0;
    int lasergun = 0;
    int laserDamage = 0;
    int life = 0;

    bool dead = false;
    float deadCounter = 1;


    GameObject life1;

    GameObject ship0;
    GameObject ship1;
    GameObject ship2;
    GameObject ship3;
    GameObject ship4;

    GameObject turbine1L;
    GameObject turbine2L;
    GameObject turbine3L;
    GameObject turbine4L;

    GameObject turbine1R;
    GameObject turbine2R;
    GameObject turbine3R;
    GameObject turbine4R;

    GameObject laser1L;
    GameObject laser2L;
    GameObject laser3L;
    GameObject laser4L;

    GameObject laser1R;
    GameObject laser2R;
    GameObject laser3R;
    GameObject laser4R;

    GameObject controll1L;
    GameObject controll2L;
    GameObject controll3L;
    GameObject controll4L;

    GameObject controll1R;
    GameObject controll2R;
    GameObject controll3R;
    GameObject controll4R;


    // Use this for initialization
    void Start()
    {
        gameData = GameObject.Find("GameDataController");

        life1 = GameObject.Find("Canvas/MainPanel/LifePanel/Text");


        ship0 = GameObject.Find("Player/Ships/ship0");
        ship1 = GameObject.Find("Player/Ships/ship1");
        ship2 = GameObject.Find("Player/Ships/ship2");
        ship3 = GameObject.Find("Player/Ships/ship3");
        ship4 = GameObject.Find("Player/Ships/ship4");

        turbine1L = GameObject.Find("Player/TurbineLeft/turb1");
        turbine2L = GameObject.Find("Player/TurbineLeft/turb2");
        turbine3L = GameObject.Find("Player/TurbineLeft/turb3");
        turbine4L = GameObject.Find("Player/TurbineLeft/turb4");

        turbine1R = GameObject.Find("Player/TurbineRight/turb1");
        turbine2R = GameObject.Find("Player/TurbineRight/turb2");
        turbine3R = GameObject.Find("Player/TurbineRight/turb3");
        turbine4R = GameObject.Find("Player/TurbineRight/turb4");

        laser1L = GameObject.Find("Player/FrontGunLeft/gun1");
        laser2L = GameObject.Find("Player/FrontGunLeft/gun2");
        laser3L = GameObject.Find("Player/FrontGunLeft/gun3");
        laser4L = GameObject.Find("Player/FrontGunLeft/gun4");

        laser1R = GameObject.Find("Player/FrontGunRight/gun1");
        laser2R = GameObject.Find("Player/FrontGunRight/gun2");
        laser3R = GameObject.Find("Player/FrontGunRight/gun3");
        laser4R = GameObject.Find("Player/FrontGunRight/gun4");

        controll1L = GameObject.Find("Player/Controlls/controll1L");
        controll2L = GameObject.Find("Player/Controlls/controll2L");
        controll3L = GameObject.Find("Player/Controlls/controll3L");
        controll4L = GameObject.Find("Player/Controlls/controll4L");

        controll1R = GameObject.Find("Player/Controlls/controll1");
        controll2R = GameObject.Find("Player/Controlls/controll2");
        controll3R = GameObject.Find("Player/Controlls/controll3");
        controll4R = GameObject.Find("Player/Controlls/controll4");


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

        usedShot = shot0;
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

        gunCoolDown = 1;
        if (gameData.GetComponent<GameData>().skillLaserSpeed > 0)
        {
            float divider = 2 * (float)gameData.GetComponent<GameData>().skillLaserSpeed;
            gunCoolDown = ((100 / divider) / 100);
        }

        shipSpeed = 2.5f;
        if (gameData.GetComponent<GameData>().skillTurbineSpeed > 0)
        {
            shipSpeed = 2.5f + gameData.GetComponent<GameData>().skillTurbineSpeed * 1.5f;
        }


        ship0.GetComponent<SpriteRenderer>().enabled = false;
        ship1.GetComponent<SpriteRenderer>().enabled = false;
        ship2.GetComponent<SpriteRenderer>().enabled = false;
        ship3.GetComponent<SpriteRenderer>().enabled = false;
        ship4.GetComponent<SpriteRenderer>().enabled = false;

        ship0.GetComponent<PolygonCollider2D>().enabled = false;
        ship1.GetComponent<PolygonCollider2D>().enabled = false;
        ship2.GetComponent<PolygonCollider2D>().enabled = false;
        ship3.GetComponent<PolygonCollider2D>().enabled = false;
        ship4.GetComponent<PolygonCollider2D>().enabled = false;

        bool set = false;
        for (int i = 0; i < 4; i++)
        {
            if (gameData.GetComponent<GameData>().equiptItem1[i])
            {
                if (i == 0)
                {
                    set = true;
                    ship1.GetComponent<SpriteRenderer>().enabled = true;
                    ship1.GetComponent<PolygonCollider2D>().enabled = true;
                }
                if (i == 1)
                {
                    set = true;
                    ship2.GetComponent<SpriteRenderer>().enabled = true;
                    ship2.GetComponent<PolygonCollider2D>().enabled = true;
                }
                if (i == 2)
                {
                    set = true;
                    ship3.GetComponent<SpriteRenderer>().enabled = true;
                    ship3.GetComponent<PolygonCollider2D>().enabled = true;
                }
                if (i == 3)
                {
                    set = true;
                    ship4.GetComponent<SpriteRenderer>().enabled = true;
                    ship4.GetComponent<PolygonCollider2D>().enabled = true;
                }
            }
        }
        if (set == false)
        {
            ship0.GetComponent<SpriteRenderer>().enabled = true;
            ship0.GetComponent<PolygonCollider2D>().enabled = true;
        }


        laser1L.GetComponent<SpriteRenderer>().enabled = false;
        laser1R.GetComponent<SpriteRenderer>().enabled = false;
        laser2L.GetComponent<SpriteRenderer>().enabled = false;
        laser2R.GetComponent<SpriteRenderer>().enabled = false;
        laser3L.GetComponent<SpriteRenderer>().enabled = false;
        laser3R.GetComponent<SpriteRenderer>().enabled = false;
        laser4L.GetComponent<SpriteRenderer>().enabled = false;
        laser4R.GetComponent<SpriteRenderer>().enabled = false;


        lasergun = 0;

        for (int i = 0; i < 4; i++)
        {
            if (gameData.GetComponent<GameData>().equiptItem2[i])
            {
                if (i == 0)
                {
                    laser1L.GetComponent<SpriteRenderer>().enabled = true;
                    laser1R.GetComponent<SpriteRenderer>().enabled = true;
                    lasergun = 1;
                }
                if (i == 1)
                {
                    laser2L.GetComponent<SpriteRenderer>().enabled = true;
                    laser2R.GetComponent<SpriteRenderer>().enabled = true;
                    lasergun = 2;
                }
                if (i == 2)
                {
                    laser3L.GetComponent<SpriteRenderer>().enabled = true;
                    laser3R.GetComponent<SpriteRenderer>().enabled = true;
                    lasergun = 3;
                }
                if (i == 3)
                {
                    laser4L.GetComponent<SpriteRenderer>().enabled = true;
                    laser4R.GetComponent<SpriteRenderer>().enabled = true;
                    lasergun = 4;
                }
            }
        }

        turbine1L.GetComponent<SpriteRenderer>().enabled = false;
        turbine2L.GetComponent<SpriteRenderer>().enabled = false;
        turbine3L.GetComponent<SpriteRenderer>().enabled = false;
        turbine4L.GetComponent<SpriteRenderer>().enabled = false;

        turbine1R.GetComponent<SpriteRenderer>().enabled = false;
        turbine2R.GetComponent<SpriteRenderer>().enabled = false;
        turbine3R.GetComponent<SpriteRenderer>().enabled = false;
        turbine4R.GetComponent<SpriteRenderer>().enabled = false;

        for (int i = 0; i < 4; i++)
        {
            if (gameData.GetComponent<GameData>().equiptItem3[i])
            {
                if (i == 0)
                {
                    turbine1L.GetComponent<SpriteRenderer>().enabled = true;
                    turbine1R.GetComponent<SpriteRenderer>().enabled = true;
                    shipSpeed *= 1.1f;
                }
                if (i == 1)
                {
                    turbine2L.GetComponent<SpriteRenderer>().enabled = true;
                    turbine2R.GetComponent<SpriteRenderer>().enabled = true;
                    shipSpeed *= 1.2f;

                }
                if (i == 2)
                {
                    turbine3L.GetComponent<SpriteRenderer>().enabled = true;
                    turbine3R.GetComponent<SpriteRenderer>().enabled = true;
                    shipSpeed *= 1.3f;
                }
                if (i == 3)
                {
                    turbine4L.GetComponent<SpriteRenderer>().enabled = true;
                    turbine4R.GetComponent<SpriteRenderer>().enabled = true;
                    shipSpeed *= 1.4f;
                }
            }
        }


        controll1L.GetComponent<SpriteRenderer>().enabled = false;
        controll2L.GetComponent<SpriteRenderer>().enabled = false;
        controll3L.GetComponent<SpriteRenderer>().enabled = false;
        controll4L.GetComponent<SpriteRenderer>().enabled = false;

        controll1R.GetComponent<SpriteRenderer>().enabled = false;
        controll2R.GetComponent<SpriteRenderer>().enabled = false;
        controll3R.GetComponent<SpriteRenderer>().enabled = false;
        controll4R.GetComponent<SpriteRenderer>().enabled = false;


        for (int i = 0; i < 4; i++)
        {
            if (gameData.GetComponent<GameData>().equiptItem4[i])
            {
                if (i == 0)
                {
                    controll1L.GetComponent<SpriteRenderer>().enabled = true;
                    controll1R.GetComponent<SpriteRenderer>().enabled = true;
                    shipSpeed *= 1.1f;
                }
                if (i == 1)
                {
                    controll2L.GetComponent<SpriteRenderer>().enabled = true;
                    controll2R.GetComponent<SpriteRenderer>().enabled = true;
                    shipSpeed *= 1.2f;
                }
                if (i == 2)
                {
                    controll3L.GetComponent<SpriteRenderer>().enabled = true;
                    controll3R.GetComponent<SpriteRenderer>().enabled = true;
                    shipSpeed *= 1.3f;
                }
                if (i == 3)
                {
                    controll4L.GetComponent<SpriteRenderer>().enabled = true;
                    controll4R.GetComponent<SpriteRenderer>().enabled = true;
                    shipSpeed *= 1.4f;
                }
            }
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

            for (int i = 0; i < Input.touchCount; ++i)
            {
                if (Input.touchCount <= 0)
                {
                    shooting = false;
                }
                else
                {
                    if (Input.GetTouch(i).phase == TouchPhase.Began)
                    {
                        shooting = true;
                    }
                    if (Input.GetTouch(i).phase == TouchPhase.Ended)
                    {
                        shooting = false;
                    }
                }
                
            }

            if (gunCoolDownTimer > 0)
            {
                gunCoolDownTimer -= Time.deltaTime;
            }
            else
            {
                if (shooting == true && lasergun == 0)
                {
                    Instantiate(usedShot, this.gameObject.transform.position + new Vector3(0, 0.8f, 0), usedShot.transform.rotation);
                    gunCoolDownTimer = gunCoolDown;
                }
                if (shooting == true && lasergun == 1)
                {
                    Instantiate(usedShot, this.gameObject.transform.position + new Vector3(-0.3f, 0.6f, 0), usedShot.transform.rotation);
                    Instantiate(usedShot, this.gameObject.transform.position + new Vector3(0.3f, 0.6f, 0), usedShot.transform.rotation);
                    gunCoolDownTimer = gunCoolDown;
                }
                if (shooting == true && lasergun == 2)
                {
                    Instantiate(usedShot, this.gameObject.transform.position + new Vector3(-0.25f, 0.6f, 0), usedShot.transform.rotation);
                    Instantiate(usedShot, this.gameObject.transform.position + new Vector3(0.25f, 0.6f, 0), usedShot.transform.rotation);
                    Instantiate(usedShot, this.gameObject.transform.position + new Vector3(-0.35f, 0.6f, 0), usedShot.transform.rotation);
                    Instantiate(usedShot, this.gameObject.transform.position + new Vector3(0.35f, 0.6f, 0), usedShot.transform.rotation);
                    gunCoolDownTimer = gunCoolDown;
                }
                if (shooting == true && lasergun == 3)
                {
                    Instantiate(usedShot, this.gameObject.transform.position + new Vector3(-0.25f, 0.6f, 0), usedShot.transform.rotation);
                    Instantiate(usedShot, this.gameObject.transform.position + new Vector3(0.25f, 0.6f, 0), usedShot.transform.rotation);
                    Instantiate(usedShot, this.gameObject.transform.position + new Vector3(-0.35f, 0.6f, 0), usedShot.transform.rotation * new Quaternion(1, 7, 0, 0));
                    Instantiate(usedShot, this.gameObject.transform.position + new Vector3(0.35f, 0.6f, 0), usedShot.transform.rotation * new Quaternion(-1, 7, 0, 0));
                    gunCoolDownTimer = gunCoolDown;
                }
                if (shooting == true && lasergun == 4)
                {
                    Instantiate(usedShot, this.gameObject.transform.position + new Vector3(0.05f, 0.8f, 0), usedShot.transform.rotation);
                    Instantiate(usedShot, this.gameObject.transform.position + new Vector3(-0.05f, 0.8f, 0), usedShot.transform.rotation);
                    Instantiate(usedShot, this.gameObject.transform.position + new Vector3(-0.35f, 0.6f, 0), usedShot.transform.rotation * new Quaternion(1, 7, 0, 0));
                    Instantiate(usedShot, this.gameObject.transform.position + new Vector3(0.35f, 0.6f, 0), usedShot.transform.rotation * new Quaternion(-1, 7, 0, 0));
                    Instantiate(usedShot, this.gameObject.transform.position + new Vector3(-0.35f, 0.6f, 0), usedShot.transform.rotation * new Quaternion(-1, 7, 0, 0));
                    Instantiate(usedShot, this.gameObject.transform.position + new Vector3(0.35f, 0.6f, 0), usedShot.transform.rotation * new Quaternion(1, 7, 0, 0));
                    gunCoolDownTimer = gunCoolDown;
                }
            }
        }


        

    }

    void DrawLifes()
    {
        life1.GetComponent<Text>().text = life + "";
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

                ship0.GetComponent<SpriteRenderer>().enabled = false;
                ship1.GetComponent<SpriteRenderer>().enabled = false;
                ship2.GetComponent<SpriteRenderer>().enabled = false;
                ship3.GetComponent<SpriteRenderer>().enabled = false;
                ship4.GetComponent<SpriteRenderer>().enabled = false;

                ship0.GetComponent<PolygonCollider2D>().enabled = false;
                ship1.GetComponent<PolygonCollider2D>().enabled = false;
                ship2.GetComponent<PolygonCollider2D>().enabled = false;
                ship3.GetComponent<PolygonCollider2D>().enabled = false;
                ship4.GetComponent<PolygonCollider2D>().enabled = false;

                laser1L.GetComponent<SpriteRenderer>().enabled = false;
                laser1R.GetComponent<SpriteRenderer>().enabled = false;
                laser2L.GetComponent<SpriteRenderer>().enabled = false;
                laser2R.GetComponent<SpriteRenderer>().enabled = false;
                laser3L.GetComponent<SpriteRenderer>().enabled = false;
                laser3R.GetComponent<SpriteRenderer>().enabled = false;
                laser4L.GetComponent<SpriteRenderer>().enabled = false;
                laser4R.GetComponent<SpriteRenderer>().enabled = false;

                turbine1L.GetComponent<SpriteRenderer>().enabled = false;
                turbine2L.GetComponent<SpriteRenderer>().enabled = false;
                turbine3L.GetComponent<SpriteRenderer>().enabled = false;
                turbine4L.GetComponent<SpriteRenderer>().enabled = false;

                turbine1R.GetComponent<SpriteRenderer>().enabled = false;
                turbine2R.GetComponent<SpriteRenderer>().enabled = false;
                turbine3R.GetComponent<SpriteRenderer>().enabled = false;
                turbine4R.GetComponent<SpriteRenderer>().enabled = false;

                controll1L.GetComponent<SpriteRenderer>().enabled = false;
                controll2L.GetComponent<SpriteRenderer>().enabled = false;
                controll3L.GetComponent<SpriteRenderer>().enabled = false;
                controll4L.GetComponent<SpriteRenderer>().enabled = false;

                controll1R.GetComponent<SpriteRenderer>().enabled = false;
                controll2R.GetComponent<SpriteRenderer>().enabled = false;
                controll3R.GetComponent<SpriteRenderer>().enabled = false;
                controll4R.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}