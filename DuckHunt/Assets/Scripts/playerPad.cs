using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPad : Photon.MonoBehaviour {

    public float speed = 5f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (photonView.isMine)
        {
            InputMovement();
        }
		
	}

    void InputMovement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + Vector3.up * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.DownArrow))
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position - Vector3.up * speed * Time.deltaTime);
    }
}
