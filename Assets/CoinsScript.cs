using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsScript : MonoBehaviour
{
    // Start is called before the first frame update
    private RicardoSpawnManager _uiManager;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = -3;
        _uiManager = GameObject.Find("SpawnManager").GetComponent<RicardoSpawnManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!_uiManager.GamePause)
        {
            if (!_uiManager.freeze)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
                if (transform.position.y < -6)
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            _uiManager.updatecoin();
        }
    }
}
