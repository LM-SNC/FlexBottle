using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonOnGame : MonoBehaviour
{
    // Start is called before the first frame update
       public void OnLoadButton()
       {
            SceneManager.LoadScene("SampleScene");
       }
}
