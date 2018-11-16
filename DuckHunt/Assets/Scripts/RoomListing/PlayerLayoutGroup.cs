using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLayoutGroup : MonoBehaviour {

    [SerializeField]
    private GameObject _playerListingPrefab;
    private GameObject PlayerListingPrefab
    {
        get { return _playerListingPrefab; }
    }

    private List<PlayerListing> _playerListings = new List<PlayerListing>();
    private List<PlayerListing> PlayerListings
    {
        get { return _playerListings; }
    }


    private void OnJoinedRoom()
    {
        PhotonPlayer[] photonPlayers = PhotonNetwork.playerList;
        for (int i = 0; i < photonPlayers.Length; i++)
        {
            PlayerJoinedRoom(photonPlayers[i]);
        }
    }

    private void PlayerJoinedRoom(PhotonPlayer photonPlayer)
    {
    https://www.youtube.com/watch?v=tw_SyqxiVgQ&index=5&list=PLkx8oFug638qVMIrtqOnwmqnW6o8WDgQ1 (8.31)
    }

    private void PlayerLeftRoom(PhotonPlayer photonPlayer)

    {

    }

}
