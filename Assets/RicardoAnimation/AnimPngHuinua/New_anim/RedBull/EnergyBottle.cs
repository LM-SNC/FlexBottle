using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBottle : MonoBehaviour
{
    private RicardoSpawnManager _uiManager;
    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("SpawnManager").GetComponent<RicardoSpawnManager>();
        StartCoroutine(DelBonus());
    }

    // Update is called once per frame
    IEnumerator DelBonus()
    {
        yield return new WaitForSeconds(13);
        Destroy(gameObject);
    }
    void Update()
    {
        if (!_uiManager.GamePause)
        {
            if (transform.position.y > -3.5f)
            {
                if (!_uiManager.freeze)
                {
                    transform.Translate(Vector3.down * 2 * Time.deltaTime);
                }
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
