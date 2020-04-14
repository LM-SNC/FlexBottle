using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpSpawn : MonoBehaviour
{
    public AKSHOOT BowPOsRot;
    public GameObject Exp;
    // Start is called before the first frame update
    void Start()
    {
        BowPOsRot = GameObject.Find("pat").GetComponent<AKSHOOT>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ExpSpawnN()
    {
        Instantiate(Exp, new Vector3(transform.position.x, transform.position.y, transform.position.z),
            Quaternion.Euler(BowPOsRot.QuatBow1.x,BowPOsRot.QuatBow1.y,BowPOsRot.QuatBow1.z));
    }
}
