using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using TMPro;

public class ClickHitP2 : NetworkBehaviour
{
    public GameObject HitBox;
    public bool HitDelay;
    public float timeCount = 0f;
    public TMP_Text timeText;
    // Start is called before the first frame update
    void Start()
    {
        HitDelay = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isLocalPlayer)
        {
            if (timeCount >= 0)
            {
                timeCount -= Time.deltaTime;
                timeText.text = Mathf.Ceil(timeCount).ToString();
            }
            else
            {
                if (Input.GetButton("Fire1") && HitDelay)
                {
                    StartCoroutine(WaitHitDelay());
                    StartCoroutine(WaitHit());
                }
            }
        }
    }
    IEnumerator WaitHit()
    {
        CmdSendHitTrue();
        yield return new WaitForSeconds(0.1f);
        CmdSendHitfalse();
    }
    IEnumerator WaitHitDelay()
    {
        HitDelay = false;
        yield return new WaitForSeconds(1f);
        HitDelay = true;
    }

    [Command]
    void CmdSendHitTrue()
    {
        SendHitTrue();
    }

    [ClientRpc]
    void SendHitTrue()
    {
        HitBox.SetActive(true);
    }
    [Command]
    void CmdSendHitfalse()
    {
        SendHitfalse();
    }

    [ClientRpc]
    void SendHitfalse()
    {
        HitBox.SetActive(false);
    }

    public void LogHP(int hp)
    {
        Debug.Log(hp);
    }

}
