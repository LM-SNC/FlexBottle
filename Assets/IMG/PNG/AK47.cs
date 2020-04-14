using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47 : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 MousePos;
    private RicardoSpawnManager _uiManager;
    public AKSHOOT As;

    public bool IsTripple;

    public int speed;
    public GameObject[] cOPYBOTTLE;
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
        if (!_uiManager.GamePause)
        {
            if (Input.GetKey(KeyCode.Mouse0) && !As.isshoot)
            {
                MousePos = Input.mousePosition;
                if (MousePos.x > 500 && transform.rotation.z > -0.6f)
                {
                    transform.Rotate(0, 0, -3 * speed * Time.deltaTime);
                }
                else if (MousePos.x < 500 && transform.rotation.z < 0.6f)
                {
                    transform.Rotate(0, 0, 3 * speed * Time.deltaTime);
                }
            }


            if (transform.rotation.z < -0.65f)
            {
                transform.Rotate(0, 0, 1);
            }
            else if (transform.rotation.z > 0.65f)
            {
                transform.Rotate(0, 0, -1);
            }

            if (transform.position.y < -2.58f)
            {
                transform.Translate(Vector3.up * 0.1f * Time.deltaTime);
            }

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 tp = Camera.main.ScreenToWorldPoint(touch.position);
                // Debug.Log(tp);
                if (tp.x > 0)
                {
                    transform.Rotate(0, 0, -3 * speed * Time.deltaTime);
                }
                else if (tp.x < 0)
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
