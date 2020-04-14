using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RicardoScript : MonoBehaviour
{
    private RicardoSpawnManager _uiManager;
    public float speed;
    public float prespeed;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(2.5f, 3.5f);
        prespeed = speed;
        _uiManager = GameObject.Find("SpawnManager").GetComponent<RicardoSpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_uiManager.GamePause)
        {

                transform.Translate(Vector3.down * speed * Time.deltaTime);

        }

        if (gameObject.GetComponent<Animator>())
        {
            if (_uiManager.freeze && gameObject.GetComponent<Animator>())
            {
                gameObject.GetComponent<Animator>().speed = 0;
                speed = 0;
            }
            else if (!_uiManager.freeze && gameObject.GetComponent<Animator>().speed < 1)
            {
                gameObject.GetComponent<Animator>().speed += 0.01f;
                if (speed < prespeed)
                {
                    speed += 0.03f;
                }
            }
        }


        if (transform.position.y < -6)
        {
            _uiManager.updateproebano();
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            _uiManager.updatescore();
            
        }
    }
}
