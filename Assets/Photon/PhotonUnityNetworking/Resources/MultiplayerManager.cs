using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class MultiplayerManager : MonoBehaviourPunCallbacks
{
    void Start()
    {
        Debug.Log("Connecting to Photon...");
        PhotonNetwork.ConnectUsingSettings(); // Connect to Photon Cloud
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to Espil Online!");
        PhotonNetwork.JoinLobby(); // Automatically join the default lobby
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Enrolled!");
    }

    public void CreateRoom()
    {
        RoomOptions options = new RoomOptions
        {
            MaxPlayers = 20 // Limit the room to 20 players
        };
        PhotonNetwork.CreateRoom(null, options); // Create a room with default settings
    }

    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom(); // Join any open room
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room: " + PhotonNetwork.CurrentRoom.Name);
        PhotonNetwork.LoadLevel("GameScene"); // Load the game scene after joining a room
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Enrollment failed. Paying tuition...");
        CreateRoom();
    }
}
