using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AKSHOOT : MonoBehaviour
{
    public GameObject Bow;
    public Quaternion QuatBow1;
    private AK47 akrotat;
    public bool IsTrippleShot;
    public ExpSpawn EP; 
    public int ammo;

    public bool isshoot;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ReloadBow());
        akrotat = GameObject.Find("AK-47").GetComponent<AK47>();
        EP = GameObject.Find("ExpSpawn").GetComponent<ExpSpawn>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ammo > 0 && !isshoot)
        {
            GetComponent <AudioSource> ().Play ();
            StartCoroutine(shootstart());
            EP.ExpSpawnN();
            QuatBow1 = transform.rotation;
            if (!IsTrippleShot)
            {
                Instantiate(Bow, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                    Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z));
            }
            else
            {
                Instantiate(Bow, new Vector3(transform.position.x, transform.position.y, transform.position.z),
                    Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z));
                StartCoroutine(TrippleShoot());
            }

            ammo--;
            akrotat.transform.Rotate(0,0,-6);
            akrotat.transform.Translate(Vector3.down * 3 * Time.deltaTime);
            
        }
    }

    IEnumerator shootstart()
    {
        isshoot = true;
        yield return new WaitForSeconds(0.15f);
        isshoot = false;
    }
    
        IEnumerator ReloadBow()
        {
            while (true)
            {
                yield return new WaitForSeconds(0.5f);
                if (ammo < 1)
                {
                    ammo++;
                }
            }
        }
        public IEnumerator TSS()
        {
            IsTrippleShot = true;
            yield return new WaitForSeconds(5);
            IsTrippleShot = false;
        }
        public IEnumerator TrippleShoot()
        {
            yield return new WaitForSeconds(0.08f);
            Instantiate(Bow, new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z),
                Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z));
            Instantiate(Bow, new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z),
                Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z));
            
        }
}
