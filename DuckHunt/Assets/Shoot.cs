using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : Photon.MonoBehaviour {
    private GameObject iBullet;
    public GameObject bullet;
    public Transform bulletSpawn;


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

    void iShoot()
    {
        iBullet = PhotonNetwork.Instantiate(bullet.name, bulletSpawn.transform.position, Quaternion.identity, 0);

        Destroy(iBullet, 5.0f);

    }
}
