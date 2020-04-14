using System;
using System.Collections;
using System.Collections.Generic;
//using UnityEditor.VersionControl;
using UnityEngine;

public class ScrollMagazine : MonoBehaviour
{

    public GameObject TovarInShop;
    public float _lockedYpos;
    private Vector3 screenPoint, offset;
    public Vector3 curPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(TovarInShop.transform.position.x);
        //Debug.Log(TovarInShop.transform.localPosition.x + "LocalPos");
        if (TovarInShop.transform.position.x > 0)
        {
            TovarInShop.transform.position = Vector3.MoveTowards(TovarInShop.transform.position,
                new Vector3(0 ,transform.position.y, transform.position.z), Time.deltaTime * 8f); 
        }
        else if(TovarInShop.transform.position.x < -25f)
        {
            TovarInShop.transform.position = Vector3.MoveTowards(TovarInShop.transform.position,
                new Vector3(-15f, transform.position.y, transform.position.z), Time.deltaTime * 8f); 
        }


    }

    private void OnMouseDown()
    {
        _lockedYpos = screenPoint.x;
        offset = TovarInShop.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,Input.mousePosition.z));
        
    }

    public void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x,Input.mousePosition.y,screenPoint.z);
         curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        curPosition.y = _lockedYpos;
        TovarInShop.transform.position = curPosition;




    }

    public void editvalue()
    {
        TovarInShop.transform.position = new Vector3(0, TovarInShop.transform.position.y, TovarInShop.transform.position.z);
        //TovarInShop.transform.position = new Vector3(0,0,0);
    }
}
