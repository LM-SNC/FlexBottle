using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickHandlerBow : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public  BowScript akobj1;

    void Start()
    {
        int g_MaxBottles = GameObject.Find("Bottles").transform.childCount;
        for (int i = 1; i < g_MaxBottles + 1; i++)
        {
            bool IsSelected = Convert.ToBoolean(PlayerPrefs.GetInt("IsSelected" + i));
            if (IsSelected)
            {
                if (i == 9)
                {
                    if (GameObject.Find("BOW") != null)
                    {
                        akobj1 = GameObject.Find("BOW").GetComponent<BowScript>();
                    }
                    else
                    {
                        Debug.Log("Error");
                    }
                }
            }
        }
    }
    
    
    
    
    public void OnPointerDown(PointerEventData eventData)
    {
        akobj1.IsBuutonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        akobj1.IsBuutonPressed = false;
    }

    
    void Update()
    {
        
    }
}