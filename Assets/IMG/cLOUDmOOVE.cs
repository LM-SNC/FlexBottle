using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cLOUDmOOVE : MonoBehaviour
{
    public float speed;
    private RicardoSpawnManager _uiManager;
    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(1f, 1.8f);
        _uiManager = GameObject.Find("SpawnManager").GetComponent<RicardoSpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_uiManager.GamePause)
        {
            if (!_uiManager.freeze)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
                if (transform.position.x < -5.92f)
                {
                    speed *= -1;
                }
                else if (transform.position.x > 5.92f)
                {
                    speed *= -1;
                }
            }
        }
    }
}
