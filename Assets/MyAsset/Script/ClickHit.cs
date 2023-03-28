using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ClickHit : NetworkBehaviour
{
    public GameObject HitBox;
    public bool HitDelay;

    void Awake()
    {
        HitDelay = true;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.isLocalPlayer)
        {
            if (Input.GetButton("Fire1") && HitDelay)
            {
                StartCoroutine(WaitHitDelay());
                StartCoroutine(WaitHit());
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
}
