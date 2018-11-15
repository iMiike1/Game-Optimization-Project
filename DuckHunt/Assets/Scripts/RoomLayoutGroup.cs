using System.Collections.Generic;
using UnityEngine;

public class RoomLayoutGroup : MonoBehaviour {


    [SerializeField]
    private GameObject _roomListingPrefab;
    private GameObject RoomListingPrefab
    {
        get { return _roomListingPrefab; }
    }
    private List<RoomListing> _roomListingButton = new List<RoomListing>();
    private List<RoomListing> RoomListingButtons
    {
        get { return _roomListingButton; }
    }


    private void OnRecievedRoomListUpdate()
    {
        RoomInfo[] rooms = PhotonNetwork.GetRoomList();

        foreach (RoomInfo room in rooms)
        {
            RoomRecieved(room);
        }
    }


    private void RoomRecieved(RoomInfo room)
    {
    https://www.youtube.com/watch?v=SBVyCNpg9X8 (17.38)
    }

    private void RemoveOldRooms()
    {

    }

}
