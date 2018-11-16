
using UnityEngine;
using UnityEngine.UI;

public class RoomListing : MonoBehaviour {

    [SerializeField]

    private Text _roomNameText;
    private Text RoomNameText
    {
        get { return _roomNameText; }
    }

    public string RoomName { get; private set; }
    public bool Updated { get; set; }

	// Use this for initialization
	private void Start ()
    {

        GameObject lobbycanvasObj = MainCanvasManager.Instance.LobbyCanvas.gameObject;
        if (lobbycanvasObj == null)
            return;

        LobbyCanvas lobbycanvas = lobbycanvasObj.GetComponent<LobbyCanvas>();
        Button button = GetComponent<Button>();

        button.onClick.AddListener(() => lobbycanvas.OnClickJoinRoom(RoomNameText.text));

	}

    private void OnDestroy()
    {
        Button button = GetComponent<Button>();
        button.onClick.RemoveAllListeners();
    }

    public void SetRoomNameText(string text)
    {
        RoomName = text;
        RoomNameText.text = RoomName;
    }

}
