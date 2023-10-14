using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey("InfoActive"))
            gameObject.SetActive(false);

        PlayerPrefs.SetInt("InfoActive", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
