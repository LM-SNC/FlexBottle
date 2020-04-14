using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowScript : MonoBehaviour
{
    public GameObject Bow;
    public GameObject BowTripple;
    private Vector3 MousePos;
    private RicardoSpawnManager _uiManager;
    public Quaternion QuatBow;
    public Shoot st;
    public int ammo;
    public bool TrippleShoot;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ReloadBow());
        st = gameObject.GetComponent<Shoot>();
        _uiManager = GameObject.Find("SpawnManager").GetComponent<RicardoSpawnManager>();
        speed = 80;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_uiManager.GamePause)
        {
            if (Input.GetKey(KeyCode.Mouse0) && !st.IsShootInBow)
            {
                MousePos = Input.mousePosition;
                if (MousePos.x > 500 && transform.rotation.z > -0.75f)
                {
                    transform.Rotate(0, 0, -2 * speed * Time.deltaTime);
                }
                else if (MousePos.x < 500 && transform.rotation.z < 0.75f)
                {
                    transform.Rotate(0, 0, 2 * speed * Time.deltaTime);
                }
            }
            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                Vector3 tp = Camera.main.ScreenToWorldPoint(touch.position);
                // Debug.Log(tp);
                if (tp.x > 0)
                {
                    if (MousePos.x > 500 && transform.rotation.z > -0.75f)
                    {
                        transform.Rotate(0, 0, -2 * speed * Time.deltaTime);
                    }
                }
                else if (tp.x < 0)
                {
                    if (MousePos.x < 500 && transform.rotation.z < 0.75f)
                    {
                        transform.Rotate(0, 0, 2 * speed * Time.deltaTime);
                    }
                }
            }
        }
    }
    public void shoot()
    {
        if (ammo > 0)
        {
            StartCoroutine(ShootCor());
            ammo--;
        }

        
    }

    IEnumerator ShootCor()
    {
        yield return new WaitForSeconds(0.5f);
        if (!TrippleShoot)
        {
            QuatBow = transform.rotation;
            Instantiate(Bow, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z));
        }
        else
        {
            QuatBow = transform.rotation;
            Instantiate(Bow, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z));
            StartCoroutine(Tss());
        }
    }
    IEnumerator ReloadBow()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            if (ammo < 1)
            {
                ammo++;
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
    public IEnumerator TrippleShootCor()
    {
        TrippleShoot = true;
        yield return new WaitForSeconds(5);
        TrippleShoot = false;
    }
    public IEnumerator Tss()
    {
        yield return new WaitForSeconds(0.15f);
        Instantiate(Bow, new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z),
            Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z));
        Instantiate(Bow, new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z),
            Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z));
            
    }
}
