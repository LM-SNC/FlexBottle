using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDbuybutton : MonoBehaviour
{
    // Start is called before the first frame update
    public string GamoObjectName;
    public ItemShopId __shopiditem;
    public ShopCobtroller _ShopController;
    public int iditem;
    public void BuyOnId()
    {
        GamoObjectName = transform.parent.gameObject.name;
        __shopiditem = GameObject.Find(GamoObjectName).GetComponent<ItemShopId>();
        _ShopController = GameObject.Find("ShopController").GetComponent<ShopCobtroller>();
        _ShopController.BuyButtonSC(__shopiditem._ItemId,__shopiditem._ItemPrice,__shopiditem._Group);
    }
}
