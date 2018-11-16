using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shoot : Photon.MonoBehaviour {
    private GameObject iBullet;
    public GameObject bullet;
    public Transform bulletSpawn;
   

    public float damage = 10f;
    public float range = 100f;


    // Use this for initialization
    void Start () {

    

    }
	
	// Update is called once per frame
	void Update () {
        if (photonView.isMine)
        {
            if (Input.GetMouseButtonDown(0))
            {
                iShoot();
            }
        }
	}

    

    /*  void iShoot()
      {
         );

      }

      */

    void iShoot()
    {
        /*
        iBullet = PhotonNetwork.Instantiate(bullet.name, bulletSpawn.transform.position, Quaternion.identity, 0);
        iBullet.GetComponent<Rigidbody>().velocity = GameObject.FindWithTag("Camera").transform.forward * 150;
        Destroy(iBullet, 5.0f);*/

        RaycastHit hit;
        if (Physics.Raycast(GameObject.FindWithTag("Camera").transform.position, GameObject.FindWithTag("Camera").transform.forward, out hit, range))

        {

            Debug.Log(hit.transform.name);
            Target target = hit.transform.GetComponent<Target>();
            if(target != null)
            {
                target.TakeDamage(damage);
            }

        }

    }
}

