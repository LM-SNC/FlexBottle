using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class ExplorerScript : MonoBehaviour
{
    private String path;
    public RawImage image;

    public void OpenExplorer()
    {
        bool IsSelected = Convert.ToBoolean(PlayerPrefs.GetInt("IsSelected" + 22));
        if (IsSelected)
        {
            path = EditorUtility.OpenFilePanel("PanelImage", "", "png");
            PlayerPrefs.SetString("path", path);
            GetImage();
        }
    }

    void GetImage()
    {
        if (path != null)
        {
            UpdateImage();
        }
    }

    void UpdateImage()
    {
        WWW www = new WWW("file:///" + PlayerPrefs.GetString("path"))---;
        image.texture = www.texture;
    }
    

}
