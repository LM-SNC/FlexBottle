using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopButton : MonoBehaviour
{
    public GameObject Panel;
    public GameObject Shop;
    public GameObject BackGround;
    // Start is called before the first frame update
    public void OnShopButton()
    {
        Panel.SetActive(false);
        Shop.SetActive(true);
        //BackGround.SetActive(true);
    }
}
