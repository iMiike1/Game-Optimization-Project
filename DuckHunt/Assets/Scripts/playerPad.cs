using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerPad : Photon.MonoBehaviour {

    public float speed = 5f;
    public float jumpheight;
    public bool isFalling = false;
    public bool isGrounded = true;
    public GameObject bullet;
    public Transform bulletSpawn;
    private GameObject iBullet;
    float heading = 0;
    public float thrust = 500;
    public Vector3 position;
    Vector2 input;

    // CAMERA MOVEMENT
    public Transform cam;
    public Transform camPoint;


    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info) {
        if (stream.isWriting) {
            stream.SendNext(transform.position);
        }
        else {
            Vector3 startPosition = (Vector3)stream.ReceiveNext();
            position = startPosition;
        }
    }

     void Awake()
    {

        cam = GetComponent<Transform>();
        camPoint = GetComponent<Transform>();
       
        
    }


    // Use this for initialization
    void Start () {
        if (photonView.isMine) {
            //Camera.current.transform.parent = transform;
            //Camera.current.transform.localPosition = new Vector3(0, 0.35f, -0f);
            //Camera.current.transform.LookAt(this.transform.position);
           
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

        ////Camera Movement
        //heading += Input.GetAxis("Mouse X") * Time.deltaTime * 100;
        //camPoint.rotation = Quaternion.Euler(0, heading, 0);

        //input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        //input = Vector2.ClampMagnitude(input, 1);

        //Vector3 camF = cam.forward;
        //Vector3 camR = cam.right;

        //camF.y = 0;
        //camR.y = 0;
        //camF = camF.normalized;
        //camR = camR.normalized;


        //transform.position += ((camF * input.y + camR * input.x) * speed); 





        if (Input.GetMouseButtonDown(0))
            Shoot();

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


        if (Input.GetKey(KeyCode.Space) && isFalling == false && isGrounded == true)
        {
           
            GetComponent<Rigidbody>().AddForce(new Vector3(0, jumpheight, 0), ForceMode.Impulse);
            isFalling = true;
            isGrounded = false;
        }

        if (GetComponent<Rigidbody>().velocity.y == 0)
        {
            isGrounded = true;

            if (isGrounded == true)
            {
                isFalling = false;
            }
        }

    }

    void Shoot()
    {
      iBullet =  PhotonNetwork.Instantiate(bullet.name,bulletSpawn.transform.position,Quaternion.identity,0);

        Destroy(iBullet, 5.0f);

    }

}
