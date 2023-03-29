using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.SceneManagement;

public class CustomNetwork : NetworkManager
{
    public GameObject PlayerPreFab2;

    public GameObject HostConnect_go;
    public int nigget = 3;
    public int kaTi = 1;

    public override void OnStartServer()
    {
        base.OnStartServer();
        NetworkServer.RegisterHandler<CharCreartMessage>(OnCreateCharacter);
    }

    public override void OnClientConnect()
    {
        base.OnClientConnect();
        CharCreartMessage CharCreartMessage = new CharCreartMessage
        {
            character = PlayerPrefs.GetString("type")
        };
        NetworkClient.Send(CharCreartMessage);
        HostConnect_go.SetActive(false);
    }

    void OnCreateCharacter(NetworkConnectionToClient conn, CharCreartMessage message)
    {

        if (numPlayers == 0)
        {
            GameObject gameObject = Instantiate(PlayerPreFab2);
            Player2 player = gameObject.GetComponent<Player2>();
            NetworkServer.AddPlayerForConnection(conn, gameObject);
        }
        else
        {
            GameObject gameObject = Instantiate(playerPrefab);
            FirstPersonController player = gameObject.GetComponent<FirstPersonController>();
            NetworkServer.AddPlayerForConnection(conn, gameObject);
        }

        // if (message.character.Equals("player2"))
        // {
        //     GameObject gameObject = Instantiate(PlayerPreFab2);
        //     Player2 player = gameObject.GetComponent<Player2>();
        //     NetworkServer.AddPlayerForConnection(conn, gameObject);
        // }
        // else
        // {
        //     GameObject gameObject = Instantiate(playerPrefab);
        //     FirstPersonController player = gameObject.GetComponent<FirstPersonController>();
        //     NetworkServer.AddPlayerForConnection(conn, gameObject);
        // }
    }



    public void MinNigget()
    {
        nigget -= 1;
    }
    public void MinKaTi()
    {
        kaTi -= 1;
    }

    public int SendKaTi()
    {
        return kaTi;
    }
    public int SendNigget()
    {
        return nigget;
    }


    public void CmdNigetWin()
    {
        NigetWin();
    }


    public void NigetWin()
    {
        SceneManager.LoadScene(0);
        NetworkManager.singleton.StopClient();
        NetworkManager.singleton.StopServer();
        Cursor.lockState = CursorLockMode.None;
        Destroy(gameObject);
    }


    public void CmdKaTiWin()
    {
        KaTiWin();
    }


    public void KaTiWin()
    {
        SceneManager.LoadScene(0);
        NetworkManager.singleton.StopClient();
        NetworkManager.singleton.StopServer();
        Cursor.lockState = CursorLockMode.None;
        Destroy(gameObject);
    }
}
