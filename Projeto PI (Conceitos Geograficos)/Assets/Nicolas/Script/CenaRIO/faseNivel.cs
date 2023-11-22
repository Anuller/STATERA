using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class faseNivel : MonoBehaviour
{
    // Start is called before the first frame update
    public void Liberar(string nome)
    {
        if(LevelManager.instancia != null)
        {
            LevelManager.instancia.AumentarNiveis();
        }
        SceneManager.LoadScene(nome);
    }
}
