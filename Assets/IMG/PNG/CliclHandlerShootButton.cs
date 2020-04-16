using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CliclHandlerShootButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public  AK47 akobj;

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
                    
                    if (GameObject.Find("AK-47") != null)
                    {
                        akobj = GameObject.Find("AK-47").GetComponent<AK47>();
                    }
                    else
                    {
                        Debug.Log("Error");
                    }
                }
                else if (i == 10)
                {
                    
                    if (GameObject.Find("AK-47") != null)
                    {
                        akobj = GameObject.Find("AK-47").GetComponent<AK47>();
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
        akobj.IsBuutonPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        akobj.IsBuutonPressed = false;
    }

    
    void Update()
    {
        
    }
}
