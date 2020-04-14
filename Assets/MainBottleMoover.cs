using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainBottleMoover : MonoBehaviour
{
    // Start is called before the first frame update

    public float RotationGuard;
    public float MaxRotationGuard;
    public float MaxRotationG;
    public int speed = 4;
    public bool RBCORBOOL;
    public GameObject[] cOPYBOTTLE;
    public bool IsTripple;
    private RicardoSpawnManager _uiManager;

    // Update is called once per frame
    public void Start()
    {
        _uiManager = GameObject.Find("SpawnManager").GetComponent<RicardoSpawnManager>();
        cOPYBOTTLE = new GameObject[2];

    }

    void Update()
    {
        // if (transform.position.y < -4)
        // {
        // transform.position = new Vector3(transform.position.x,-4,transform.position.z);
        //  }

        if (!_uiManager.GamePause)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime * Input.GetAxis("Horizontal"), 0, 0));
            



//                Debug.Log(transform.localRotation.z);

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 tp = Camera.main.ScreenToWorldPoint(touch.position);
                // Debug.Log(tp);
                if (tp.x > 0)
                {
                    transform.Translate(new Vector3(4f * Time.deltaTime, 0, 0));
                }
                else if (tp.x < 0)
                {
                    transform.Translate(new Vector3(-4f * Time.deltaTime, 0, 0));
                }
            }
        }

        if (transform.position.x > 8.5f)
        {
            transform.position = new Vector3(8.5f, transform.position.y, transform.position.z);
        }

        if (transform.position.x < -8.5f)
        {
            transform.position = new Vector3(-8.5f, transform.position.y, transform.position.z);
        }


    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("RB"))
        {

            StartCoroutine(RBCOR());
        }

        if (other.gameObject.CompareTag("FRZ"))
        {
            StartCoroutine(FreezePeriod());
        }

        if (other.gameObject.CompareTag("3BTL") && !IsTripple)
        {
            IsTripple = true;
            for (int i = 1; i < 3; i ++)
            {
                Debug.Log(i);
                cOPYBOTTLE[i-1] =  Instantiate(gameObject,
                    new Vector3(transform.position.x + i * 1.5F, transform.position.y, transform.position.z),
                    Quaternion.identity);
            }
            StartCoroutine(SpawnBottleX3());
        }
    }
    IEnumerator SpawnBottleX3()
    {
        yield return new WaitForSeconds(8);
        for (int i = 0; i < 2; i ++)
        {
            Destroy(cOPYBOTTLE[i]);
        }
        IsTripple = false;

    }
    

        IEnumerator RBCOR()
        {
            int DefualtSpeed = speed;
            speed = 8;
            yield return new WaitForSeconds(5);
            speed = DefualtSpeed;
        }
        IEnumerator FreezePeriod() 
        {
        
        _uiManager.freeze = true;
            yield return new WaitForSeconds(5); 
            _uiManager.freeze = false;
                
                    
        }
}
