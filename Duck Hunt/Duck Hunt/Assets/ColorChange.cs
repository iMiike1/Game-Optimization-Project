using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : Photon.MonoBehaviour {


    private void Update()
    {
        if (photonView.isMine)
        {
            //// left or right
            //float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
            //// forward or backwards
            //float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;
            //transform.Translate(x, 0, z, Space.Self);

           
            InputColorChange();
        }
       
    }

    private void InputColorChange()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeColorTo(new Vector3(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)));
        }
    }

    [PunRPC]
    void ChangeColorTo(Vector3 color)
    {
        GetComponent<Renderer>().material.color = new Color(color.x, color.y, color.z, 1f);
        Debug.Log("ColorHasChanged");
        if (photonView.isMine)
        {
            photonView.RPC("ChangeColorTo", PhotonTargets.OthersBuffered, color);
        }
    }
}
