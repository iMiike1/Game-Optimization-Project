using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CreateRoom1 : MonoBehaviour {

    public PhotonPlayer PhotonPlayer { get; private set; }

    [SerializeField]
    private Text _roomName;
    private Text RoomName
    {
        get { return _roomName; }
    }

    public void onClick_CreateRoom()
    {
        RoomOptions roomOptions = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = 4 };
        print("create room successfully sent.");
        //PhotonNetwork.player.name = PhotonPlayer.name;

        if (PhotonNetwork.CreateRoom(RoomName.text, roomOptions, TypedLobby.Default))
        {
           

           Debug.Log("name:..." + PhotonNetwork.player.name);
        }
        else
        {
            print("create room failed to send");
        }

    }

    private void OnPhotonCreateRoomFailed(object[] codeAndMessage)
    {
        print("Create room failed" + codeAndMessage[1]);
    }

    void OnCreatedRoom()
    {
        print("Room created successfully.");
    }
}
