using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelExp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DExp());
    }

    IEnumerator DExp()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
