using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class AK47 : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 MousePos;
    private RicardoSpawnManager _uiManager;
    public AKSHOOT As;

    public bool IsTripple;
    public bool IsBuutonPressed;
        
    public int speed;
    public GameObject[] cOPYBOTTLE;

    private float hui;
    // Start is called before the first frame update

    void Start()
    {
        As = GameObject.Find("pat").GetComponent<AKSHOOT>();
        _uiManager = GameObject.Find("SpawnManager").GetComponent<RicardoSpawnManager>();
        cOPYBOTTLE = new GameObject[2];
        speed = 90;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(hui);
        
        if (!_uiManager.GamePause)
        {
          //  Debug.Log(button.transform.position.x * 100);
            //Debug.Log(Input.mousePosition.y + "Mouse");


            if (transform.rotation.z < -0.65f)
            {
                transform.Rotate(0, 0, 1 * speed * Time.deltaTime);
            }
            else if (transform.rotation.z > 0.65f)
            {
                transform.Rotate(0, 0, -1 * speed * Time.deltaTime);
            }

            if (transform.position.y < -2.58f)
            {
                transform.Translate(Vector3.up * 0.1f * Time.deltaTime);
            }

            MousePos = Input.mousePosition;
            if (Input.GetMouseButton(0))
            {
                if (MousePos.x > 500 && transform.rotation.z > -0.6f && !IsBuutonPressed)
                    transform.Rotate(0, 0, -3 * speed * Time.deltaTime);

                else if (MousePos.x < 500 && transform.rotation.z < 0.6f)
                {
                    transform.Rotate(0, 0, 3 * speed * Time.deltaTime);
                }
            }

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 tp = Camera.main.ScreenToWorldPoint(touch.position);
                // Debug.Log(tp);
                if (tp.x > 0 && transform.rotation.z > -0.6f && !IsBuutonPressed)
                {
                    transform.Rotate(0, 0, -3 * speed * Time.deltaTime);
                }
                else if (tp.x < 0 && transform.rotation.z < 0.6f)
                {
                    transform.Rotate(0, 0, 3 * speed * Time.deltaTime);
                }
            }



        }
    }


    public IEnumerator RBCOR()
    {
        int DefualtSpeed = speed;
        speed *= 2;
        yield return new WaitForSeconds(5);
        speed = DefualtSpeed;
    }
    public IEnumerator FreezePeriod() 
    {
        
        _uiManager.freeze = true;
        yield return new WaitForSeconds(3); 
        _uiManager.freeze = false;
                
                    
    }

    
}
