using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCR_DIARY : MonoBehaviour
{
    public GameObject GO_CanvaDiary; //Janela do Diario
    public GameObject GO_CanvaDiaryCommand; //Icone do Diario
    public bool isShowing; //Janela esta visível
    // Paginas
    public GameObject Page00;
    public GameObject Page01;
    public GameObject Page02;
    public GameObject Page03;
    // Controles
    public GameObject ArrowLeft;
    public GameObject ArrowRight;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!GO_CanvaDiary.active)
            {
                GO_CanvaDiary.SetActive(true);
            }
            else
            {
                GO_CanvaDiary.SetActive(false);
            }

        }
        if (GO_CanvaDiary.active)
        {
            GO_CanvaDiaryCommand.SetActive(false);
        }
        else
        {
            GO_CanvaDiaryCommand.SetActive(true);
        }
    }

    public void NextPage()
    {
        switch (true)
        {

            case true when Page00.active:
                Page00.SetActive(false);
                Page01.SetActive(true);
                ArrowLeft.SetActive(true);
                break;
            case true when Page01.active:
                Page01.SetActive(false);
                Page02.SetActive(true);
                break;
            case true when Page02.active:
                Page02.SetActive(false);
                Page03.SetActive(true);
                ArrowRight.SetActive(false);
                break;
        }
    }

    public void PreviousPage()
    {
        switch (true)
        {
            case true when Page03.active:
                Page03.SetActive(false);
                Page02.SetActive(true);
                ArrowRight.SetActive(true);
                break;
            case true when Page02.active:
                Page02.SetActive(false);
                Page01.SetActive(true);
                break;
            case true when Page01.active:
                Page01.SetActive(false);
                Page00.SetActive(true);
                ArrowLeft.SetActive(false);
                break;
        }
    }
}
