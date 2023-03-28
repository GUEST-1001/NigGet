using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class AniConP1 : NetworkBehaviour
{
    public Animator aniP1;
    [SerializeField] bool isWalk = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (this.isLocalPlayer)
        {
            AniSet();
            ChackIsWalk();
        }
    }

    void ChackIsWalk()
    {
        if (Mathf.Abs(Input.GetAxis("Horizontal")) > Mathf.Epsilon || Mathf.Abs(Input.GetAxis("Vertical")) > Mathf.Epsilon)
        {
            isWalk = true;
        }
        else
        {
            isWalk = false;
        }
    }

    void AniSet()
    {
        aniP1.SetBool("Run", isWalk);
    }
}
