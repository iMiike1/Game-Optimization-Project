using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{

    private const string roomName = "RoomName";
    private TypedLobby lobbyName = new TypedLobby("New_Lobby", LobbyType.Default);
    private RoomInfo[] roomsList;
    public GameObject player;

    // Use this for initialization
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings("v4.2");
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
        if (PhotonNetwork.room.PlayerCount == 1) {
            GameObject mPLayer = (GameObject)PhotonNetwork.Instantiate(player.name, new Vector3(10, 2.5f, 10), Quaternion.identity, 0);
        }
        else if (PhotonNetwork.room.PlayerCount == 2) {
            GameObject mPLayer = (GameObject)PhotonNetwork.Instantiate(player.name, new Vector3(-10, 2.5f, -10), Quaternion.identity, 0);
        }
      
       //mPLayer.GetComponent<UnityStandardAssets.Characters.FirstPerson.PlayerController>().enabled = true;
    }
}
