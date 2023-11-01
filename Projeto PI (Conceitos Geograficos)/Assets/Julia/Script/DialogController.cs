using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogController : MonoBehaviour
{
    [SerializeField] float timePerLetter;

    [SerializeField] TextMeshProUGUI textDialog;

    private string[] pages;

    private int currentPage;

    private bool finalizePage;

    private IEnumerator routineDitar;

    void Update()
    {
        if (Input.GetKeyDown("e"))
        {
            NextPage();
        }
    }

    void NextPage()
    {
        if (finalizePage)
        {
            currentPage++;
            if (currentPage >= pages.Length)
            {

                EndDialog();
                return;
            }
            routineDitar = Ditar();
            StartCoroutine(routineDitar);

        }
        else
        {

            finalizePage = true;
            textDialog.text = pages[currentPage];
            StopCoroutine(routineDitar);

        }

    }
    void EndDialog()
    {
        StopCoroutine(routineDitar);
        gameObject.SetActive(false);
    }
    public void OpenDialog(string[] pages)
    {
        if (gameObject.activeInHierarchy)
            return;

        gameObject.SetActive(true);
        this.pages = pages;
        currentPage = 0;
        finalizePage = false;
        routineDitar = Ditar();
        StartCoroutine(routineDitar);
    }

    IEnumerator Ditar()

    {
        var page = pages[currentPage];
        textDialog.text = "";
        finalizePage = false;

        foreach (var letter in page)
        {
            textDialog.text += letter;
            yield return new WaitForSeconds(timePerLetter);
        }

        finalizePage = true;
    }

}