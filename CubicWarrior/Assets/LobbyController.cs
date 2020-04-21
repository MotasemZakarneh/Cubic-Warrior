using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class LobbyController : MonoBehaviourPunCallbacks
{
    [SerializeField] Button play = null;

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        play.onClick.AddListener(OnPlayPressed);
    }

    private void OnPlayPressed()
    {
        Debug.Log("Pressed play");
        PhotonNetwork.JoinRandomRoom();
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.Log("failed to create room");
        CreateRoom();
    }
    public override void OnJoinedRoom()
    {
        Debug.Log("Succefully joined room?");
        GetComponent<RoomController>().SuccefullyJoinedRoom();
    }

    private void CreateRoom()
    {
        Debug.Log("failed to create room");
        string roomName = UnityEngine.Random.Range(0, 100000).ToString();
        RoomOptions room = new RoomOptions();
        room.IsVisible = true;
        room.MaxPlayers = 4;
        room.IsOpen = true;
        PhotonNetwork.CreateRoom(roomName,room);
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        Debug.Log("Failed to create room, create again");
        CreateRoom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
