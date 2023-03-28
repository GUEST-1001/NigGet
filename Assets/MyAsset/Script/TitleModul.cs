using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TitleModul : MonoBehaviour
{
    public TMP_InputField inputName;

    public void GetPlayerOne()
    {
        PlayerPrefs.SetString("fullname", inputName.text);
        PlayerPrefs.SetString("type", "player1");
        SceneManager.LoadScene("TestScene", LoadSceneMode.Single);
    }

    public void GetPlayerTwo()
    {
        PlayerPrefs.SetString("fullname", inputName.text);
        PlayerPrefs.SetString("type", "player2");
        SceneManager.LoadScene("TestScene", LoadSceneMode.Single);
    }
}
