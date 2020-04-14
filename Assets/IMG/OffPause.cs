using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffPause : MonoBehaviour
{
    private RicardoSpawnManager _uimanager;
    // Start is called before the first frame update
    public void OffPauseButton()
    {
        _uimanager = GameObject.Find("SpawnManager").GetComponent<RicardoSpawnManager>();
        _uimanager.GamePause = false;
        Debug.Log("GamePause: " + _uimanager.GamePause);
    }
}
