using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CreateRoom1 : MonoBehaviour {

    [SerializeField]
    private Text _roomName;
    private Text RoomName
    {
        get { return _roomName; }
    }

    public void onClick_CreateRoom()
    {
        if (PhotonNetwork.CreateRoom(RoomName.text))
        {
            print("create room successfully sent.");
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
