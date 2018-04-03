using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipFlyMenu : MonoBehaviour {

    public float speed = 1;
    public GameObject clone;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        float realSpeed = speed * Time.deltaTime;
        this.gameObject.transform.Translate(0, realSpeed, 0);

        if (this.gameObject.transform.position.x > 6 || this.gameObject.transform.position.x < -6)
        {
            Instantiate(clone, new Vector3(-6,9,0), clone.transform.rotation);

            Destroy(this.gameObject);
        }

    }
}
