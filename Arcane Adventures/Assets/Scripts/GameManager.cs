using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System.Runtime.CompilerServices;

public class GameManager : MonoBehaviour
{
    [SerializeField] Text textLastMessage;
    [SerializeField] InputField textMessageField;
    private PhotonView PhotonView;

    private void Start()
    {
        PhotonView = GetComponent<PhotonView>();
    }

    public void SetButton()
    {
        PhotonView.RPC("Send_Data", RpcTarget.AllBuffered, textMessageField.text);
    }

    [PunRPC]
    private void Send_Data(string msg)
    {
        textLastMessage.text = msg;
    }
}
