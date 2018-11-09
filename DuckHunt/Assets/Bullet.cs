using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    void Awake()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * 100;
    }

}


