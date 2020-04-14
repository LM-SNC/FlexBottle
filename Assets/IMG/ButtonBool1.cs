using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBool1 : MonoBehaviour
{
    public ShopCobtroller SC;
    public int coinsshop;
    public string namebottle;
    public bool DF = true;
    public bool skin1;
    public bool skin2;
    public bool skin3;
    public bool skin4;
    public bool skin5;
    public bool skin6;
    public bool skin7;
    public bool skin8;
    public bool skin9;
    // Start is called before the first frame update
    public void OnSelectBottle1()
    {
        skin1 = Convert.ToBoolean(PlayerPrefs.GetInt("SKIN1",0));
       skin2 = Convert.ToBoolean(PlayerPrefs.GetInt("SKIN2",0));
       skin3 = Convert.ToBoolean(PlayerPrefs.GetInt("SKIN3",0));
       skin4 = Convert.ToBoolean(PlayerPrefs.GetInt("SKIN4",0));
       skin5 = Convert.ToBoolean(PlayerPrefs.GetInt("SKIN5",0));
       skin6 = Convert.ToBoolean(PlayerPrefs.GetInt("SKIN6",0));
       skin7 = Convert.ToBoolean(PlayerPrefs.GetInt("SKIN7",0));
       skin8 = Convert.ToBoolean(PlayerPrefs.GetInt("SKIN8",0));
       skin9 = Convert.ToBoolean(PlayerPrefs.GetInt("SKIN9",0));
        //coinsshop = PlayerPrefs.GetInt("CoinS");
        coinsshop = 1000;
        SC = GameObject.Find("ShopController").GetComponent<ShopCobtroller>();
        namebottle = transform.parent.gameObject.name;
        //Debug.Log(name);
      // SC = GameObject.Find("ShopController").GetComponent<ShopCobtroller>();
      if (namebottle == "DF")
      {
          PlayerPrefs.SetString("BN",namebottle);
      }
      
      if (namebottle == "B1" && skin1)
      {
          PlayerPrefs.SetString("BN",namebottle);
      }
      else if(coinsshop >= 10 && !skin1 && namebottle == "B1")
      {
          coinsshop -= 10;
          PlayerPrefs.SetInt("CoinS",coinsshop);
          skin1 = true;
          PlayerPrefs.SetInt("SKIN1",1);
          PlayerPrefs.SetString("BN",namebottle);
      }
      else
      {
          Debug.Log("Монет не хватает или бутылка уже активна");
      }
      
      
      
      if (namebottle == "B2" && skin2)
      {
          PlayerPrefs.SetString("BN",namebottle);
      }
      else if(namebottle == "B2" && coinsshop >= 20 && !skin2)
      {
          coinsshop -= 20;
          PlayerPrefs.SetInt("CoinS",coinsshop);
          skin2 = true;
          PlayerPrefs.SetInt("SKIN2",1);
          PlayerPrefs.SetString("BN",namebottle);
      }
      else
      {
          Debug.Log("Монет не хватает или бутылка уже активна");
      }
      
      
      
      if (namebottle == "B3" && skin3)
      {
          PlayerPrefs.SetString("BN",namebottle);
      }
      else if(coinsshop >= 25 && namebottle == "B3" && !skin3)
      {
          coinsshop -= 25;
          PlayerPrefs.SetInt("CoinS",coinsshop);
          skin3 = true;
          PlayerPrefs.SetInt("SKIN3",1);
          PlayerPrefs.SetString("BN",namebottle);
      }
      
      if (namebottle == "B4" && skin4)
      {
          PlayerPrefs.SetString("BN",namebottle);
      }
      else if(coinsshop >= 30 && namebottle == "B4" && !skin4)
      {
          coinsshop -= 30;
          PlayerPrefs.SetInt("CoinS",coinsshop);
          skin3 = true;
          PlayerPrefs.SetInt("SKIN4",1);
          PlayerPrefs.SetString("BN",namebottle);
      }
      
      if (namebottle == "B5" && skin5)
      {
          PlayerPrefs.SetString("BN",namebottle);
      }
      else if(coinsshop >= 35 && namebottle == "B5" && !skin5)
      {
          coinsshop -= 35;
          PlayerPrefs.SetInt("CoinS",coinsshop);
          skin3 = true;
          PlayerPrefs.SetInt("SKIN5",1);
          PlayerPrefs.SetString("BN",namebottle);
      }
      
      if (namebottle == "B6" && skin6)
      {
          PlayerPrefs.SetString("BN",namebottle);
      }
      else if(coinsshop >= 40 && namebottle == "B6" && !skin6)
      {
          coinsshop -= 40;
          PlayerPrefs.SetInt("CoinS",coinsshop);
          skin3 = true;
          PlayerPrefs.SetInt("SKIN6",1);
          PlayerPrefs.SetString("BN",namebottle);
      }
      
      if (namebottle == "B7" && skin7)
      {
          PlayerPrefs.SetString("BN",namebottle);
      }
      else if(coinsshop >= 45 && namebottle == "B7" && !skin7)
      {
          coinsshop -= 45;
          PlayerPrefs.SetInt("CoinS",coinsshop);
          skin3 = true;
          PlayerPrefs.SetInt("SKIN7",1);
          PlayerPrefs.SetString("BN",namebottle);
      }
      
      if (namebottle == "B8" && skin8)
      {
          PlayerPrefs.SetString("BN",namebottle);
      }
      else if(coinsshop >= 50 && namebottle == "B8" && !skin8)
      {
          coinsshop -= 50;
          PlayerPrefs.SetInt("CoinS",coinsshop);
          skin3 = true;
          PlayerPrefs.SetInt("SKIN8",1);
          PlayerPrefs.SetString("BN",namebottle);
      }
      
      if (namebottle == "B9" && skin9)
      {
          PlayerPrefs.SetString("BN",namebottle);
      }
      else if(coinsshop >= 60 && namebottle == "B9" && !skin9)
      {
          coinsshop -= 60;
          PlayerPrefs.SetInt("CoinS",coinsshop);
          skin3 = true;
          PlayerPrefs.SetInt("SKIN9",1);
          PlayerPrefs.SetString("BN",namebottle);
      }

    }
}
