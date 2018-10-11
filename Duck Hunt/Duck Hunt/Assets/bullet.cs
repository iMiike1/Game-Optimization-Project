using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : Photon.MonoBehaviour {

    public GameObject Bullet;
    public GameObject BulletSpawn;
    public float speed = 50.0f;
	
	
	// Update is called once per frame
	void Update () {

        if (photonView.isMine)
        {
            if (Input.GetMouseButtonDown(0))
                SpawnBullet();
        }
    }

    void SpawnBullet()
    {
       
     var  m_bullet = Instantiate(Bullet, BulletSpawn.transform.position, Quaternion.identity) ;
        //Bullet.GetComponent<Rigidbody>().velocity = Bullet.transform.forward * speed * Time.deltaTime;
        m_bullet.GetComponent<Rigidbody>().AddForce(BulletSpawn.transform.forward * 400);
            
            //AddForce(BulletSpawn.transform.forward * 4000);
       
        
    }
}
