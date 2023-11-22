using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instancia;
    public Button[] buttonsNiveis;
    public int desbloquearNiveis;


    // Start is called before the first frame update
    void Awake()
    {
        if(instancia == null)
        {
            instancia = this;
        }
    }

    // Update is called once per frame
    void Start()
    {
        if (buttonsNiveis.Length > 0)
        {
            for (int i = 0; i < buttonsNiveis.Length; i++)
            {
                buttonsNiveis[i].interactable = false;
            }
            
            for (int i = 0; i < PlayerPrefs.GetInt("niveisDesbloqueados", 1); i++)
            {
                buttonsNiveis[i].interactable |= true;
            }
        }
    }

    public void AumentarNiveis()
    {

        if(desbloquearNiveis > PlayerPrefs.GetInt("niveisDesbloqueados", 1))
        {
            PlayerPrefs.SetInt("niveisDesbloqueados", desbloquearNiveis);
        }

    }

}
