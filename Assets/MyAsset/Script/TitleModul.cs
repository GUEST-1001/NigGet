using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class TitleModul : MonoBehaviour
{
    public TMP_InputField inputName;
    public GameObject creditCanvas;
    public bool creditOpen = false;
    public TMP_Text creditText;

    private void Start()
    {

    }

    void Update()
    {
        if (FindObjectOfType<CustomNetwork>() != null)
        {
            Destroy(FindObjectOfType<CustomNetwork>().gameObject);
        }
    }


    public void GoPlay()
    {
        SceneManager.LoadScene("TestScene", LoadSceneMode.Single);
    }

    public void GoCredit()
    {
        if (!creditOpen)
        {
            creditOpen = !creditOpen;
            creditText.text = "Back";
            creditCanvas.SetActive(true);
        }
        else
        {
            creditOpen = !creditOpen;
            creditText.text = "Credit";
            creditCanvas.SetActive(false);
        }
    }

    public void GoExit()
    {
        Application.Quit();
    }
}
