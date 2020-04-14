using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackOnShop : MonoBehaviour
{
    public GameObject panel;

    public GameObject shop;
    // Start is called before the first frame update
    public void BackFromShop()
    {
        shop.SetActive(false);
        panel.SetActive(true);
    }
}
