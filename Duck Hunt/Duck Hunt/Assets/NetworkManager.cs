using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{

    private const string roomName = "RoomName";
    private TypedLobby lobbyName = new TypedLobby("New_Lobby", LobbyType.Default);
    private RoomInfo[] roomList;
    public GameObject player;
    public Camera PlayerCamera;
    public GameObject Spawn;
    // Use this for initialization
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings("v4.2");
    }

    void OnGUI()
    {
        if (!PhotonNetwork.connected)
        {
            GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
        }
        else if (PhotonNetwork.room == null)
        {
            if (GUI.Button(new Rect(100, 100, 250, 100), "Start Server"))
            {
                PhotonNetwork.CreateRoom(
                    roomName,
                    new RoomOptions() { MaxPlayers = 4, IsOpen = true, IsVisible = true },
                    lobbyName
                );
            }
            if (roomList != null)
            {
                GUILayout.Label("ROOM LIST: ");
                for (int i = 0; i < roomList.Length; i++)
                {
                    if (GUI.Button(
                        new Rect(100, 250 + (110 * i), 250, 100),
                        "Join " + roomList[i].Name + " " + i)
                    )
                    {
                        PhotonNetwork.JoinRoom(roomList[i].Name);
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
        roomList = PhotonNetwork.GetRoomList();
    }

    void OnJoinedLobby()
    {
        Debug.Log("Joined lobby");
    }

    void OnJoinedRoom()
    {
        Debug.Log("Connected to Room");
        PhotonNetwork.Instantiate(player.name, Spawn.transform.position, Quaternion.identity, 0);
            //camera.Target = player.transform;
    }
}
