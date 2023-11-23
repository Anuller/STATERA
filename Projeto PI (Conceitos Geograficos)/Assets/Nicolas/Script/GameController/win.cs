using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class win : MonoBehaviour
{
    public GameObject final;
    public GameObject Dialog;
    private void Start()
    {
        Time.timeScale = 1.0f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Win")
        {
            final.SetActive(true);
            Time.timeScale = 0f;
            //liga a tela, variavel gameobject que ira ativa aqui

        }
        if (collision.tag == "Dialog")
        {
            Dialog.SetActive(true);
        }
    }
}
