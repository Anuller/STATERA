using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class newGame : MonoBehaviour
{
    // Start is called before the first frame update
    public void NovoJogo(string nome)
    {
        SceneManager.LoadScene(nome);
    }
}
