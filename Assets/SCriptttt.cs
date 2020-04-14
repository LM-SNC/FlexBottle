using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SCriptttt : MonoBehaviour
{
    public SwordMoove SM;

    public String NameObject;
    // Start is called before the first frame update
    void Start()
    {
        SM = GameObject.Find(NameObject).GetComponent<SwordMoove>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(SM.transform.position.x,SM.transform.position.y - 0.3f,SM.transform.position.z);
    }
}
