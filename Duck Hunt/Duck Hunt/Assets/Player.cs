using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Photon.MonoBehaviour
{

    public float speed = 10f;
    private float lastsynchronizationTime = 0f;
    private float syncDelay = 0f;
    private float syncTime = 0f;
    private Vector3 syncStartPosition = Vector3.zero;
    private Vector3 syncEndPosition = Vector3.zero;
    [SerializeField] private GameObject playerCamera;
    [SerializeField] private MonoBehaviour[] playerControlScripts;

    private Quaternion syncStartPositionR = Quaternion.Euler(Vector3.zero);
    private Quaternion syncEndPositionR = Quaternion.Euler(Vector3.zero);

    //relative movement
    public Transform cam;
    public Transform camPivot;
    float heading = 0;

    private Vector3 Jump;
    public Component[] Renderer;
    public float jumpForce = 15.0f;
    Rigidbody rb;
    GameObject cap;
    
   

    Vector2 input;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Jump = new Vector3(0.0f, 2.0f, 0.0f);
        Initialize();
        
    }

    private void Update()
    {
        if (photonView.isMine)
        {
            // left or right
            float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            // forward or backwards
            float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
            transform.Translate(x, 0, z, Space.Self);



            InputMovement();
            //InputColorChange();
           
        }
        else
        {
            SyncMovement();
        }
    }

    private void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        Debug.Log(info.ToString());
        if (stream.isWriting)
        {
            stream.SendNext(GetComponent<Rigidbody>().position);
            stream.SendNext(GetComponent<Rigidbody>().velocity);
            stream.SendNext(GetComponent<Rigidbody>().rotation);
        }
        else
        {
            Vector3 syncPosition = (Vector3)stream.ReceiveNext();
            Vector3 syncVelocity = (Vector3)stream.ReceiveNext();
            Quaternion syncRotation = (Quaternion)stream.ReceiveNext();
            Debug.Log(syncPosition);
            syncTime = 0f;
            syncDelay = Time.time - lastsynchronizationTime;
            lastsynchronizationTime = Time.time;
            syncEndPosition = syncPosition + syncVelocity * syncDelay;
            syncEndPositionR = syncRotation * Quaternion.Euler(syncVelocity * syncDelay);
            syncStartPosition = GetComponent<Rigidbody>().position;
            syncStartPositionR = GetComponent<Rigidbody>().rotation;
        }
    }

    void InputMovement()
    {
        if (Input.GetKey(KeyCode.W))
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + Vector3.forward * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position - Vector3.forward * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + Vector3.right * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position - Vector3.right * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Jump * jumpForce, ForceMode.Impulse);
           
        }
        

    }

    private void Awake()
    {
        lastsynchronizationTime = Time.time;

    }

    private void SyncMovement()
    {
        syncTime += Time.deltaTime;
        transform.position = Vector3.Lerp(syncStartPosition,syncEndPosition,syncTime / syncDelay);
        GetComponent<Rigidbody>().rotation = Quaternion.Lerp(syncStartPositionR, syncEndPositionR, syncTime / syncDelay);
    }

    private void Initialize()
    {
        if (photonView.isMine)
        {

        }
        //handle functionality for non local character, disable camera and control scripts
        else
        {
            // disable camera
            playerCamera.SetActive(false);
            //disable control scripts
            foreach (MonoBehaviour m in playerControlScripts)
            {
                m.enabled = false;
            }
        }


    }

}
