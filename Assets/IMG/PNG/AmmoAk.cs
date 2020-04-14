using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoAk : MonoBehaviour
{
    // Start is called before the first frame update
    public AKSHOOT BowPOsRot;
    public AK47 AKPOsRot;
    public GameObject Exp;
    public int speed = 15;
    // Start is called before the first frame update
    void Start()
    {
        BowPOsRot = GameObject.Find("pat").GetComponent<AKSHOOT>();
        AKPOsRot = GameObject.Find("AK-47").GetComponent<AK47>();
        transform.rotation = new Quaternion(BowPOsRot.QuatBow1.x,BowPOsRot.QuatBow1.y,BowPOsRot.QuatBow1.z,BowPOsRot.QuatBow1.w);
        //transform.position = new Vector3(BowPOsRot.transform.position.x ,BowPOsRot.transform.position.y,BowPOsRot.transform.position.z);
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

            AKPOsRot.StartCoroutine(AKPOsRot.RBCOR());
        }

        if (other.gameObject.CompareTag("FRZ"))
        {
            AKPOsRot.StartCoroutine(AKPOsRot.FreezePeriod());
        }
        if (other.gameObject.CompareTag("3BTL") && !BowPOsRot.IsTrippleShot)
        {
            BowPOsRot.StartCoroutine(BowPOsRot.TSS());
        }
        else if (other.gameObject.CompareTag("3BTL") && BowPOsRot.IsTrippleShot)
        {
            BowPOsRot.StopCoroutine(BowPOsRot.TSS());
            BowPOsRot.StartCoroutine(BowPOsRot.TSS());
        }


    }
}
