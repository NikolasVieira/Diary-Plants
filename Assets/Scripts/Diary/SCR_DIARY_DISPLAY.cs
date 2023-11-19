using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCR_DIARY_DISPLAY : MonoBehaviour
{
    public SCR_DIARY_PAGE page;
    public Image Artwork;
    public Text NameCommon;
    public Text NameCientific;
    public Text Description;

    void Start()
    {
        Artwork.sprite = page.Artwork;
        NameCommon.text = page.NameCommon;
        NameCientific.text = page.NameCientific;
        Description.text = page.Description;
    }

}
