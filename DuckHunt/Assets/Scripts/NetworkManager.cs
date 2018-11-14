using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{

    private const string roomName = "RoomName";
    private TypedLobby lobbyName = new TypedLobby("New_Lobby", LobbyType.Default);
    private RoomInfo[] roomsList;
    public GameObject player;
    public GameObject defaultCamera;
    public GameObject pc;
    public GameObject cam;
    
    //public GameObject ball;

    // Use this for initialization
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings("v4.2");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnGUI()
    {
        if (!PhotonNetwork.connected)
        {
            GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
        }
        else if (PhotonNetwork.room == null)
        {
            //Create Room
            if (GUI.Button(new Rect(100, 100, 250, 100), "Start Server"))
            {
                PhotonNetwork.CreateRoom(roomName, new RoomOptions()
                { MaxPlayers = 4, IsOpen = true, IsVisible = true }, lobbyName);

            }

            if (roomsList != null)
            {
                for (int i = 0; i < roomsList.Length; i++)
                {
                    if (GUI.Button(new Rect(100, 250 + (110 * i), 250, 100), "Join" + roomsList[i].Name))
                    {
                        PhotonNetwork.JoinRoom(roomsList[i].Name);
                    }
                }
            }
        }
    }

    void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(lobbyName);
    }

    void OnReceivedRoomListUpdate()
    {
        Debug.Log("Room was created");
        roomsList = PhotonNetwork.GetRoomList();
    }

    void OnJoinedLobby()
    {
        Debug.Log("Joined Lobby");

    }

    void OnJoinedRoom()
    {
        SpawnPlayer();
    }


    void SpawnPlayer()
    {
      GameObject mPLayer= (GameObject) PhotonNetwork.Instantiate(player.name, new Vector3(-4f, 1.5f, -2f), Quaternion.identity, 0);
        ((MonoBehaviour)mPLayer.GetComponent("PlayerController")).enabled = true;
        mPLayer.transform.Find("MainCamera").gameObject.SetActive(true);
        
        
        
            //(mPLayer.GetComponent<"PlayerController"> (MonoBehaviour)).enabled = true;
        

    }
}
