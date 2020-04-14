using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopCobtroller : MonoBehaviour
{
    // Start is called before the first frame update;
    public Text coins;
    public int coinint;
    public GameObject[] MainItems;
    public int startvalue;
    private String path;
    public RawImage image;


    void Start()
    {
        //PlayerPrefs.DeleteAll();
        coinint = 500;
        coins.text = PlayerPrefs.GetInt("CoinS", 0).ToString();
        _UpdateValue();
        path = PlayerPrefs.GetString("path");
        if (path != null)
        {
            WWW www = new WWW("file:///" + PlayerPrefs.GetString("path"));
            image.texture = www.texture;
        }
    }

    // Update is called once per frame
    void Update()
    {
        coins.text = "" + coinint;
    }
        
    public void BuyButtonSC(int ID,int PRICE,int GROUP)
    {
        int g_MaxMainItemsId = MainItems.Length;
        int resultat = 0;
        bool BuyStatus = Convert.ToBoolean(PlayerPrefs.GetInt(ID.ToString()));
       bool IsSelected = Convert.ToBoolean(PlayerPrefs.GetInt("IsSelected" + ID));
       
        if (coinint >= PRICE && !BuyStatus)
        {
            PlayerPrefs.SetInt(ID.ToString(),1);
            Debug.Log("Предмет под ID " + ID + "Был успешно куплен!");
            coinint -= PRICE;
            coins.text = PlayerPrefs.GetInt("CoinS", 0).ToString();
            coinint -= PRICE;
            PlayerPrefs.SetInt("CoinS",coinint);
            coins.text = PlayerPrefs.GetInt("CoinS", 0).ToString();
            _UpdateValue();
        }
        else if(BuyStatus && !IsSelected)
        {
          

                PlayerPrefs.SetInt("IsSelected" + ID, 1);

              
                    Debug.Log("Предмет под ID " + ID + " Был успешно выбран!");
                    for (int b = 1; b < g_MaxMainItemsId + 1; b++)
                    {
                        int MaxId = MainItems[b - 1].transform.childCount;
                        resultat += MaxId;
                        int g_ItemFull = 0;
                        for (int resultpre = (resultat - MaxId) + 1; resultpre < resultat + 1; resultpre++)
                        {
                            Debug.Log(resultpre);
                            if (resultpre != ID && GROUP == 0 && resultpre < 11)
                            {

                                PlayerPrefs.SetInt("IsSelected" + resultpre, 0);
                            }
                            if (resultpre != ID && GROUP == 2 && resultpre > 15)
                            {
                                Debug.Log(resultat);
                                PlayerPrefs.SetInt("IsSelected" + resultpre, 0);
                            }

                        }

                        _UpdateValue();
                    }

        }
        else if((BuyStatus && IsSelected && GROUP == 1 ))
        {
            
                    
                    if (GROUP == 1 && ID >= 11)
                    {

                        PlayerPrefs.SetInt("IsSelected" + ID, 0);
                    }

                    _UpdateValue();
        }
    }

    public void _UpdateValue()
    {
        int g_MaxMainItemsId = MainItems.Length;
        int resultat = 0;
        for (int b = 1; b < g_MaxMainItemsId + 1; b++)
        {
             // Debug.Log(g_MaxMainItemsId);
              int g_MaxId = MainItems[b - 1].transform.childCount;
              resultat += g_MaxId;
              int g_ItemFull = 0;


              for (int resultpre = (resultat - g_MaxId) + 1; resultpre < resultat + 1; resultpre++)
              {
                  bool BuyStatus = Convert.ToBoolean(PlayerPrefs.GetInt(resultpre.ToString()));
                  bool IsSelected = Convert.ToBoolean(PlayerPrefs.GetInt("IsSelected" + resultpre));
                //  Debug.Log(resultpre + " InWhile");
                   BuyStatus = Convert.ToBoolean(PlayerPrefs.GetInt(resultpre.ToString()));
                  IsSelected = Convert.ToBoolean(PlayerPrefs.GetInt("IsSelected" + resultpre));

                  if (BuyStatus && !IsSelected)
                  {
                      if (resultpre != 1)
                      {
                          MainItems[b - 1].transform.GetChild(g_ItemFull).transform.GetChild(0).transform.GetChild(1)
                              .gameObject
                              .SetActive(false);
                      }

                      MainItems[b - 1].transform.GetChild(g_ItemFull).GetChild(0).GetChild(0)
                          .GetComponentInChildren<TextMeshProUGUI>()
                          .fontSize = 15;
                      MainItems[b - 1].transform.GetChild(g_ItemFull).GetChild(0).GetChild(0)
                          .GetComponentInChildren<TextMeshProUGUI>()
                          .text = "Disable";
                      Debug.Log(BuyStatus && IsSelected);
                      if (resultpre > 15 && MainItems[b - 1].transform.GetChild(g_ItemFull).GetComponent<Animator>())
                      {
                          MainItems[b - 1].transform.GetChild(g_ItemFull).GetComponent<Animator>().speed = 0;
                      }
                  }
                  else if (BuyStatus && IsSelected)
                  {
                      if (resultpre != 1)
                      {
                          MainItems[b - 1].transform.GetChild(g_ItemFull).transform.GetChild(0).transform.GetChild(1)
                              .gameObject
                              .SetActive(false);
                      }

                      MainItems[b - 1].transform.GetChild(g_ItemFull).GetChild(0).GetChild(0)
                          .GetComponentInChildren<TextMeshProUGUI>()
                          .fontSize = 15;
                      MainItems[b - 1].transform.GetChild(g_ItemFull).GetChild(0).GetChild(0)
                          .GetComponentInChildren<TextMeshProUGUI>()

                          .text = "Selected";
                      if (resultpre > 15 && MainItems[b - 1].transform.GetChild(g_ItemFull).GetComponent<Animator>())
                      {
                          MainItems[b - 1].transform.GetChild(g_ItemFull).GetComponent<Animator>().speed = 1;
                      }
                      
                  }

                  if (resultpre > 50)
                  {
                      Debug.Log("Error!");
                      break;

                  }

                  g_ItemFull++;
                  //Debug.Log(g_ItemFull + "FullInt");
              }
          }
    }
}
