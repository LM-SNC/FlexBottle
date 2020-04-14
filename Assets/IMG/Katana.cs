using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Katana : MonoBehaviour
{
    // Start is called before the first frame update
public float RotationGuard;
    public float MaxRotationGuard;
    public float MaxRotationG;
    public int speed = 4;
    public bool RBCORBOOL;

    private RicardoSpawnManager _uiManager;

    // Update is called once per frame
    public void Start()
    {
        _uiManager = GameObject.Find("SpawnManager").GetComponent<RicardoSpawnManager>();

    }

    void Update()
    {
        // if (transform.position.y < -4)
        // {
        // transform.position = new Vector3(transform.position.x,-4,transform.position.z);
        //  }

        if (!_uiManager.GamePause)
        {
            Debug.Log(transform.rotation.z);
            transform.Translate(new Vector3(speed * Time.deltaTime * Input.GetAxis("Horizontal"), 0, 0));
            if (Input.GetAxis("Horizontal") > 0)
            {
                gameObject.transform.GetChild(0).GetComponent<Rigidbody2D>().transform.Rotate(0,0,-2f);
            }
            if (Input.GetAxis("Horizontal") < 0)
            {
                gameObject.transform.GetChild(0).GetComponent<Rigidbody2D>().transform.Rotate(0,0,2f);
            }

            if (transform.position.y < -3.5)
            {
                transform.position = new Vector3(transform.position.x,-3.5F,transform.position.z);
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

        IEnumerator RBCOR()
        {
            int DefualtSpeed = speed;
            speed = 8;
            yield return new WaitForSeconds(5);
            speed = DefualtSpeed;
        }
    }
}
