using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : Photon.MonoBehaviour {

    // the ball starting speed
    public float StartSpeed = 5f;
    // the maximum speed of the ball
    public float MaxSpeed = 20f;
    // how much faster the ball gets with each bounce
    public float SpeedIncrease = 0.25f;
    // the current speed of the ball
    private float currentSpeed;
    // the current direction of travel
    private Vector2 currentDir;

	// Use this for initialization
	void Start () {

        //initialise starting speed
        currentSpeed = StartSpeed;
        //initialize direction
        currentDir = Random.insideUnitCircle.normalized;
		
	}
	
	// Update is called once per frame
	void Update () {

        if (PhotonNetwork.playerList.Length == 0)
            return;
        Vector2 moveDir = currentDir * currentSpeed * Time.deltaTime;
        transform.Translate(new Vector3(moveDir.x, moveDir.y, 0f));
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Boundary")
        {
            // vertical boundary, reverse Y direction
            currentDir.y *= -1;
        }
        else if (other.tag == "Player")
        {
            //player paddle, reverse x direction
            currentDir.x *= -1;
        }
        //if we hit a goal, and we are the server, give the appropriate player a point
        else if (other.tag == "Goal")
        {
            ChangeColorTo(new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
            ChangePositionTo(new Vector3(0f, 1.5f, -2f));
            ChangeDirTo(Random.insideUnitCircle.normalized);


        }
    }

    [PunRPC]
    void ChangePositionTo (Vector3 myposition)
    {
        GetComponent<Transform>().position = myposition;
        if (photonView.isMine)
            photonView.RPC("ChangePositionTo", PhotonTargets.OthersBuffered, myposition);
    }

    [PunRPC]
    void ChangeDirTo(Vector3 mycurrentDir)
    {
        currentDir = mycurrentDir;
        if (photonView.isMine)
            photonView.RPC("ChangeDirTo", PhotonTargets.OthersBuffered, mycurrentDir);
    }

    [PunRPC]
    void ChangeColorTo(Vector3 color)
    {
        GetComponent<Renderer>().material.color = new Color (color.x, color.y, color.z, 1f);
        if (photonView.isMine)
            photonView.RPC("ChangeColorTo", PhotonTargets.OthersBuffered, color);
    }
}
