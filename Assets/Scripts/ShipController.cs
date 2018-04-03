using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ShipController : MonoBehaviour
{

    public GameObject shot1;
    public GameObject explosion;

    public float shipSpeed = 10.0F;
    GameObject playerShip;

    bool shooting = false;
    public float gunCoolDown = 1;

    float gunCoolDownTimer = 0;
    public int lvl = 1;
    public int life = 5;

    bool dead = false;
    float deadCounter = 1;


    GameObject life1;
    GameObject life2;
    GameObject life3;

    // Use this for initialization
    void Start()
    {
        playerShip = GameObject.Find("playerShip");

        life1 = GameObject.Find("Canvas/Life1");
        life2 = GameObject.Find("Canvas/Life2");
        life3 = GameObject.Find("Canvas/Life3");

        if (life1 != null)
        {
            DrawLifes();
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
            playerShip.transform.Translate(translation, 0, 0);

            if (this.gameObject.transform.position.x > 2.5)
            {
                playerShip.transform.position = new Vector3(2.5f, -4, 0);
            }
            if (this.gameObject.transform.position.x < -2.5)
            {
                playerShip.transform.position = new Vector3(-2.5f, -4, 0);
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
                if (shooting == true && lvl == 1)
                {
                    Instantiate(shot1, playerShip.transform.position + new Vector3(0, 0.8f, 0), shot1.transform.rotation);
                    gunCoolDownTimer = gunCoolDown;
                }
                if (shooting == true && lvl == 2)
                {
                    Instantiate(shot1, playerShip.transform.position + new Vector3(-0.2f, 0.8f, 0), shot1.transform.rotation * new Quaternion(-1, 15, 0, 0));
                    Instantiate(shot1, playerShip.transform.position + new Vector3(0.2f, 0.8f, 0), shot1.transform.rotation * new Quaternion(1, 15, 0, 0));
                    gunCoolDownTimer = gunCoolDown;
                }
                if (shooting == true && lvl == 3)
                {
                    Instantiate(shot1, playerShip.transform.position + new Vector3(0, 0.8f, 0), shot1.transform.rotation);
                    Instantiate(shot1, playerShip.transform.position + new Vector3(-0.2f, 0.8f, 0), shot1.transform.rotation * new Quaternion(-1, 15, 0, 0));
                    Instantiate(shot1, playerShip.transform.position + new Vector3(0.2f, 0.8f, 0), shot1.transform.rotation * new Quaternion(1, 15, 0, 0));
                    gunCoolDownTimer = gunCoolDown;
                }
                if (shooting == true && lvl == 4)
                {
                    Instantiate(shot1, playerShip.transform.position + new Vector3(0, 0.8f, 0), shot1.transform.rotation);
                    Instantiate(shot1, playerShip.transform.position + new Vector3(-0.2f, 0.8f, 0), shot1.transform.rotation * new Quaternion(-1, 15, 0, 0));
                    Instantiate(shot1, playerShip.transform.position + new Vector3(0.2f, 0.8f, 0), shot1.transform.rotation * new Quaternion(1, 15, 0, 0));
                    Instantiate(shot1, playerShip.transform.position + new Vector3(-0.3f, 0.8f, 0), shot1.transform.rotation * new Quaternion(-1, 7, 0, 0));
                    Instantiate(shot1, playerShip.transform.position + new Vector3(0.3f, 0.8f, 0), shot1.transform.rotation * new Quaternion(1, 7, 0, 0));
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
                Instantiate(explosion, playerShip.transform.position + new Vector3(0, 0, 0), explosion.transform.rotation);
                dead = true;

                this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
    }
}