using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuController : MonoBehaviour {

    public GameObject shot;
    public GameObject shot1;

    public float gunCoolDown = 0.5f;

    float gunCoolDownTimer = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (gunCoolDownTimer > 0)
        {
            gunCoolDownTimer -= Time.deltaTime;
        }
        else
        {
            Instantiate(shot, shot.transform.position, shot.transform.rotation);
            Instantiate(shot1, shot1.transform.position, shot1.transform.rotation);
            gunCoolDownTimer = gunCoolDown;
        }
    }

    public void StartGameButton()
    {
        SceneManager.LoadScene("LevelMenu", LoadSceneMode.Single);
    }

    public void OpenShipCreator()
    {
        //SceneManager.LoadScene("ShipCreator", LoadSceneMode.Single);
    }
}
