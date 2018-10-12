using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : Photon.MonoBehaviour {

    public int gunDamage = 1;

    public float fireRate = .25f;

    public float weaponRange = 50f;

    public float hitForce = 100f;

    public Transform gunEnd;

    public GameObject bulletspawn;

    private Camera fpsCam;

    private WaitForSeconds shotDuration = new WaitForSeconds(.07f);

    private AudioSource gunAudio;

    private LineRenderer laserLine;

    private float nextFire;



    void Start()
    {
        laserLine = GetComponent<LineRenderer>();
        fpsCam = GetComponentInParent<Camera>();
    }

    // Update is called once per frame
    void Update () {



        if (photonView.isMine)
        {
            if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
            {
                
                nextFire = Time.time + fireRate;
                StartCoroutine(Effect());
                Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(.5f, .5f, 0));

                RaycastHit hit;

                if (Physics.Raycast(bulletspawn.transform.position, fpsCam.transform.forward, out hit, weaponRange))
                {
                    laserLine.SetPosition(0, gunEnd.position);
                    Debug.Log("outhit");

                }
                else
                {
                    laserLine.SetPosition(1, bulletspawn.transform.position + (fpsCam.transform.forward * weaponRange));
                    Debug.Log("NotHit");
                }


            }

        }
        else
        {

        }


	}

    private IEnumerator Effect()
    {
        
        laserLine.enabled = true;

        yield return shotDuration;

        laserLine.enabled = false;
    }

}
