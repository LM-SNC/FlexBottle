using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudManager : MonoBehaviour
{
    public GameObject BigCloud;
    public GameObject SmallCloud;
    public float prespawnx;
    public float postspawnx;
    public float G_PosBig;
    public int rch;


    // Start is called before the first frame update
    void Start()
    {
    
            for (int i = 0; i < Random.Range(1,2); i++)
            {
                prespawnx = postspawnx;
                postspawnx = Random.Range(-6, 2);
                G_PosBig = postspawnx;
                if (prespawnx == postspawnx)
                {
                    i--;
                }
                else
                {
                    Instantiate(BigCloud, new Vector3(postspawnx, Random.Range(3.62f, 4.14f), 0),
                        Quaternion.identity);
                }
            }
            for (int i = 0; i < Random.Range(2,3); i++)
            {
                prespawnx = postspawnx;
                postspawnx = Random.Range(-6, 2);
                if (prespawnx == postspawnx || postspawnx == G_PosBig)
                {
                    i--;
                }
                else
                {
                    Instantiate(SmallCloud, new Vector3(postspawnx, Random.Range(2.76f,3.40f), 0),
                        Quaternion.identity);
                }
            }
    }
    //  for (int i = 0; i > Random.Range(1,4); i++)
       // {
     //       
      //  }
   // }

    // Update is called once per frame
    void Update()
    {
    }
}
