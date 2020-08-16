using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenButton : MonoBehaviour
{
    public Image OpenImage;

    public void Open()
    {
        OpenImage.gameObject.SetActive(!OpenImage.gameObject.activeSelf);
    }
}
