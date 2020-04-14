using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oNrESTARTbUTTON : MonoBehaviour
{
    private RicardoSpawnManager _RestartManager;
    // Start is called before the first frame update
    
    public void OnRestartButton()
       {
           _RestartManager = GameObject.Find("SpawnManager").GetComponent<RicardoSpawnManager>();
           _RestartManager.restartmanager();
           
       }
    
}
