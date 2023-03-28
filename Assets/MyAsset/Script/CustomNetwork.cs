using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CustomNetwork : NetworkManager
{
    public GameObject PlayerPreFab2;

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
    }

    void OnCreateCharacter(NetworkConnectionToClient conn, CharCreartMessage message)
    {
        if (message.character.Equals("player2"))
        {
            GameObject gameObject = Instantiate(PlayerPreFab2);
            // Player2 player = gameObject.GetComponent<Player2>();
            NetworkServer.AddPlayerForConnection(conn, gameObject);
        }
        else
        {
            GameObject gameObject = Instantiate(playerPrefab);
            FirstPersonController player = gameObject.GetComponent<FirstPersonController>();
            NetworkServer.AddPlayerForConnection(conn, gameObject);
        }
    }
}
