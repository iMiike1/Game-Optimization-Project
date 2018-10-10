using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNetwork : MonoBehaviour {

    [SerializeField] private GameObject playerCamera;
    [SerializeField] private MonoBehaviour[] playerControlScripts;
    
       private PhotonView photoView;


    private void Start()
    {
        photoView = GetComponent<PhotonView>();
        Initialize();
    }

    private void Initialize()
    {
        if (photoView.isMine)
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
