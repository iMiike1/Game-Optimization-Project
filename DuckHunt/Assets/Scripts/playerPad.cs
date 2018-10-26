using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPad : Photon.MonoBehaviour {

    public float speed = 5f;
    public float jumpheight;
    public bool isFalling = false;
    public bool isGrounded = true;


    public Vector3 position;


    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if (stream.isWriting) {
            stream.SendNext(transform.position);
        }
        else {
            Vector3 startPosition = (Vector3)stream.ReceiveNext();
            position = startPosition;
        }
    }

    private void Awake()
    {
    }

    // Use this for initialization
    void Start () {
        if (photonView.isMine) {
            Camera.current.transform.parent = transform;
            Camera.current.transform.localPosition = new Vector3(0, 1.5f, -10f);
        }
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (photonView.isMine)
        {
            InputMovement();
            //Debug.Log(Camera.current.transform.parent.name);
        }
        else {
            SyncMovement();
            //Debug.Log(Camera.current.transform.parent.name + "outasdjkfl;asjdlfj;als");
        }

    }

    void SyncMovement() {
        transform.position = position;
    }

    void InputMovement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            transform.Translate(0.0f, 0.0f, 1, Space.Self);
        //GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + Vector3.forward * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.RightArrow))
            transform.Translate(1, 0.0f, 0.0f, Space.Self);
        //GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + Vector3.right * speed * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftArrow))
            transform.Translate(-1, 0.0f, 0.0f, Space.Self);
        //GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + Vector3.left * speed * Time.deltaTime);
 

        if (Input.GetKey(KeyCode.DownArrow))
            transform.Translate(0.0f, 0.0f, -1, Space.Self);
        //GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + Vector3.back * speed * Time.deltaTime);

        //if (Input.GetKey(KeyCode.Space) && isFalling == false && isGrounded == true)
        //{
        //    Debug.Log(new Vector3(0, 1 * jumpheight, 0));
        //    GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpheight, 0), ForceMode.Impulse);
        //    isFalling = true;
        //    isGrounded = false;
        //}
   
        //if(GetComponent<Rigidbody>().velocity.y == 0)
        //{
        //    isGrounded = true;

        //    if (isGrounded == true)
        //    {
        //        isFalling = false;
        //    }
        //}

    }
}
