using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntonScript : MonoBehaviour
{
    private RicardoSpawnManager _uiManager;
    public float MaxRotationG;
    private int speed = 4;
    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("SpawnManager").GetComponent<RicardoSpawnManager>();
        gameObject.GetComponent<Animator>().speed = 0;
    }

    // Update is called once per frame
    void Update()
    {
         {
       // if (transform.position.y < -4)
       // {
           // transform.position = new Vector3(transform.position.x,-4,transform.position.z);
      //  }
        
        if (!_uiManager.GamePause)
        {
            transform.Translate(new Vector3(speed * Time.deltaTime * Input.GetAxis("Horizontal"), 0, 0));
            if (Input.GetAxis("Horizontal") < 0f)
            {
                gameObject.GetComponent<Animator>().speed = 1;
                transform.rotation = new Quaternion( transform.rotation.x,0 ,transform.rotation.z, transform.rotation.w);
                speed = 4;
            }
            else if (Input.GetAxis("Horizontal") > 0f)
            {
                gameObject.GetComponent<Animator>().speed = 1;
                transform.rotation = new Quaternion( transform.rotation.x,180 ,transform.rotation.z, transform.rotation.w);
                speed = -4;
            }
            else
            {
                gameObject.GetComponent<Animator>().speed = 0;
            }
          


            
            Debug.Log(transform.localRotation.z);
            if (transform.localRotation.z > 0.5f)
            {
                speed = -4;
            }
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
            transform.position = new Vector3(8.5f,transform.position.y,transform.position.z);
        }
        if (transform.position.x < -8.5f)
        {
            transform.position = new Vector3(-8.5f,transform.position.y,transform.position.z);
        }

       // if (transform.rotation.z > 30)
       // {
           // transform.Rotate(0,0,-30f);
         //  }
       // Debug.Log(transform.rotation.z);
       // if (transform.localRotation.z < -MaxRotationGuard)
     //   {
     //       transform.Rotate(0,0,RotationGuard);
     //   }
     //   else if(transform.localRotation.z > MaxRotationGuard)
     //   {
      //     transform.Rotate(0,0,-RotationGuard);
      //  }
       // 
        if (transform.localRotation.z <= -MaxRotationG)
        {
            transform.localRotation = new Quaternion( transform.localRotation.x, transform.localRotation.y,-MaxRotationG, transform.localRotation.w);
        }
        else if(transform.localRotation.z >= MaxRotationG)
        {
            transform.localRotation = new Quaternion( transform.localRotation.x, transform.localRotation.y,MaxRotationG, transform.localRotation.w);
        }
        
    }
    }
}
