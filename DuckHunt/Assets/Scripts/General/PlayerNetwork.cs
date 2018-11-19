using UnityEngine;

public class PlayerNetwork : Photon.MonoBehaviour {

    public static PlayerNetwork Instance;
    public string PlayerName { get; private set; }


    public PhotonPlayer PhotonPlayer { get; private set; }
    // private PhotonView PhotonView;

    private void Awake()
    {
        Debug.Log("before");
        
        Instance = this;
        //PhotonView = GetComponent<PhotonView>();
       PlayerName = PhotonNetwork.player.name + Random.Range(1000, 9999);

        //PhotonPlayer.name = PlayerName;

        

        Debug.Log("after");

    }
}
