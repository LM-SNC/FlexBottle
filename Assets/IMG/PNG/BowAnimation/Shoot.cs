using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
        private Animator animshoot;

        private BowScript BS;

        public bool IsShootInBow;
    // Start is called before the first frame update
    void Start()
    {
        animshoot = GetComponent<Animator>();
        BS = GameObject.Find("BOW").GetComponent<BowScript>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void bowshoot()
    {
        if (BS.ammo > 0 && ! IsShootInBow)
        {
            BS.shoot();
            animshoot.SetBool("IsShoot", true);
            StartCoroutine(IsShootBow());
            StartCoroutine(BowSound());
            Debug.Log("Shooting!");
        }
    }
    IEnumerator IsShootBow()
        {
            IsShootInBow = true;
            yield return new WaitForSeconds(0.2f);
            animshoot.SetBool("IsShoot", false);
            IsShootInBow = false;
        }
        IEnumerator BowSound()
        {
            yield return new WaitForSeconds(0.5f);
            GetComponent <AudioSource> ().Play ();
        }

    }
