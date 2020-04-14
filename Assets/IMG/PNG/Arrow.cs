using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public BowScript BowPOsRot;
    public int speed = 7;
    // Start is called before the first frame update
    void Start()
    {
        BowPOsRot = GameObject.Find("BOW").GetComponent<BowScript>();
        transform.rotation = new Quaternion(BowPOsRot.QuatBow.x,BowPOsRot.QuatBow.y,BowPOsRot.QuatBow.z,BowPOsRot.QuatBow.w);
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.up * Time.deltaTime * speed);
        if (transform.position.y > 8)
        {
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("RB"))
        {

            BowPOsRot.StartCoroutine( BowPOsRot.RBCOR());
        }

        if (other.gameObject.CompareTag("FRZ"))
        {
            BowPOsRot.StartCoroutine(BowPOsRot.FreezePeriod());
        }

        if (other.gameObject.CompareTag("3BTL"))
        {
            if(!BowPOsRot.TrippleShoot){
                BowPOsRot.StartCoroutine(BowPOsRot.TrippleShootCor());
            }
            else
            {
                BowPOsRot.StopCoroutine(BowPOsRot.TrippleShootCor());
                BowPOsRot.StartCoroutine(BowPOsRot.TrippleShootCor());
            }
            

        }
    }
}