using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{

    public andar player;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.Count = player.KBtime;
            if (collision.transform.position.x <= transform.position.x)
            {
                player.isKnouk = false;
            }
            if (collision.transform.position.x > transform.position.x)
            {
                player.isKnouk = true;
            }
            
        }
    }

}
