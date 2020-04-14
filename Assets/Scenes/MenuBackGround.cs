using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuBackGround : MonoBehaviour
{
    public GameObject RicardoPrefab;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRicardo());
    }
    IEnumerator SpawnRicardo()
    {
        while (true)
        {
            Instantiate(RicardoPrefab, new Vector3(Random.Range(-8, 8), 6.37f, 0), Quaternion.identity);
            yield return new WaitForSeconds(2);
            
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
