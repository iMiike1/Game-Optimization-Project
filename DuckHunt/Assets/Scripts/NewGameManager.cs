using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameManager : Photon.MonoBehaviour {

    private const string roomName = "RoomName";
    private TypedLobby lobbyName = new TypedLobby("New_Lobby", LobbyType.Default);
    private RoomInfo[] roomsList;
    public GameObject player;




    // Move this to game manager, or keep it here
    
    private SpawnPoint spawnPoints = new SpawnPoint();


    private void Start()
    {
        OnJoinedRoom();
    }


    //// Use this for initialization
    //void Start()
    //{
    //    PhotonNetwork.ConnectUsingSettings("v4.2");
    //}

    //void Update()
    //{
    //    if (PhotonNetwork.playerList.Length != null)
    //    {
    //        for (int i = 0; i < PhotonNetwork.playerList.Length; i++)
    //        {
    //            //    Debug.Log("Player name: " + PhotonNetwork.playerList[i].NickName + " Player Number: " + i);
    //        }
    //    }
    //}

    //private void OnGUI()
    //{
    //    if (!PhotonNetwork.connected)
    //    {
    //        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    //    }
    //    else if (PhotonNetwork.room == null)
    //    {
    //        //Create Room
    //        if (GUI.Button(new Rect(30, 30, 50, 50), "Start Server"))
    //        {
    //            PhotonNetwork.CreateRoom(roomName, new RoomOptions()
    //            { MaxPlayers = 4, IsOpen = true, IsVisible = true }, lobbyName);

    //        }

    //        if (roomsList != null)
    //        {
    //            for (int i = 0; i < roomsList.Length; i++)
    //            {
    //                if (GUI.Button(new Rect(100, 250 + (110 * i), 250, 100), "Join" + roomsList[i].Name))
    //                {
    //                    PhotonNetwork.JoinRoom(roomsList[i].Name);
    //                }
    //            }
    //        }
    //    }
    //}

    //void OnConnectedToMaster()
    //{
    //    PhotonNetwork.automaticallySyncScene = true;
    //    PhotonNetwork.JoinLobby(lobbyName);
    //}

    //void OnReceivedRoomListUpdate()
    //{
    //    Debug.Log("Room was created");
    //    roomsList = PhotonNetwork.GetRoomList();
    //}

    //void OnJoinedLobby()
    //{
    //    //if (!PhotonNetwork.inRoom)
    //    //    MainCanvasManager.Instance.LobbyCanvas.transform.SetAsLastSibling();
    //    Debug.Log("Joined Lobby");
    //}




    void OnJoinedRoom()
    {
        //If I am master, just spawn me, if I am not master, ask master for spawn position
        SpawnPlayer();  
         //if (PhotonNetwork.isMasterClient) SpawnPlayer();
         //   else photonView.RPC("PlayerIsAskingForSpawnPoint", PhotonTargets.MasterClient, PhotonNetwork.player.NickName);
    }

    [PunRPC]
    void PlayerIsAskingForSpawnPoint(string playerName)
    {
        Vector3 tempSpawnPoint = spawnPoints.AssignMeSpawnPoints(1);
        float[] tempPosCoordinates = new float[3];
        tempPosCoordinates[0] = tempSpawnPoint.x;
        tempPosCoordinates[1] = tempSpawnPoint.y;
        tempPosCoordinates[2] = tempSpawnPoint.z;

        // photonView.RPC("MasterIsSendingSpawnPoint", PhotonTargets.Others, tempPosCoordinates, playerName);
        Debug.Log("I am sednding RPC to player");
    }

    [PunRPC]
    void MasterIsSendingSpawnPoint(float[] spawnPointCoordinates, string playerName)
    {
        // If I was asking for the spawn point, execute this, otherwise not
        if (playerName == PhotonNetwork.player.NickName)
        {
            GameObject mPLayer = (GameObject)PhotonNetwork.Instantiate(player.name, new Vector3(spawnPointCoordinates[0], spawnPointCoordinates[1], spawnPointCoordinates[2]), Quaternion.identity, 0);
            Debug.Log("I have intialize player");
        }
    }


    void SpawnPlayer()
    {
        GameObject mPLayer = (GameObject)PhotonNetwork.Instantiate(player.name, spawnPoints.AssignMeSpawnPoints(0), Quaternion.identity, 0);
        
        mPLayer.GetComponent<UnityStandardAssets.Characters.FirstPerson.PlayerController>().enabled = true;
    }
}
