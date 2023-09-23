using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    
    public Animator transition;

    public float trasnsitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LoadlNextLoader();
        }
    }

    public void LoadlNextLoader()
    {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    IEnumerator LoadLevel (int levelIndex)
    {
        //Plat animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(trasnsitionTime);

        //Load Scene
        SceneManager.LoadScene(levelIndex);
    }

}
