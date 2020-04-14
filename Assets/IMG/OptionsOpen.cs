using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsOpen : MonoBehaviour
{
    private RicardoSpawnManager _uimanager;
    // Start is called before the first frame update
    public void OnPauseButton()
    {
        _uimanager = GameObject.Find("SpawnManager").GetComponent<RicardoSpawnManager>();
        _uimanager.GamePause = true;
        Debug.Log("GamePause: " + _uimanager.GamePause);
    }
}
