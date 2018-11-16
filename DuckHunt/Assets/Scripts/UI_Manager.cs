using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    private NetworkManager networkManager;
    private InputField IF_playerName;


    // Use this for initialization
    void Start ()
    {
        // Get network manager component
        networkManager = GameObject.Find("NetworkManager").GetComponent<NetworkManager>();
        IF_playerName = GameObject.Find("InputPlayerName").GetComponent<InputField>();
    }

    private void Update()
    {
        // If player has pressed enter and text in input is greater than 4, assign player name into photon variable
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetKeyDown(KeyCode.Return) && IF_playerName.text != "" && IF_playerName.text.Length > 4)
        {
            PhotonNetwork.player.NickName = IF_playerName.text;
            IF_playerName.gameObject.SetActive(false);
        }
    }

}
