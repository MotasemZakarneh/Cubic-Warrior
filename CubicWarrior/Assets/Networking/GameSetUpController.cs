using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class GameSetUpController : MonoBehaviour
{
    void Start()
    {
        PhotonNetwork.Instantiate("Player", UnityEngine.Random.onUnitSphere, Quaternion.identity);

    }
}
