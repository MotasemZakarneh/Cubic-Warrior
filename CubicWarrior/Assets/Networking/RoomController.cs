using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System;

public class RoomController : MonoBehaviourPunCallbacks
{
    public override void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }
    public override void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }
    public override void OnJoinedRoom()
    {
        SuccefullyJoinedRoom();
    }
    public void SuccefullyJoinedRoom()
    {
        StartGame();
    }
    private void StartGame()
    {
        Debug.Log("Trying to start game");
        if(PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel(1);
        }
    }
}