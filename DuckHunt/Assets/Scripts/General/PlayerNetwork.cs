using UnityEngine;

public class PlayerNetwork : MonoBehaviour {

    public static PlayerNetwork Instance;
    public string PlayerName { get; private set; }

    // private PhotonView PhotonView;

    private void Awake()
    {
        Instance = this;
        //PhotonView = GetComponent<PhotonView>();
        PlayerName = "Distul#" + Random.Range(1000, 9999);
      
    }
}
