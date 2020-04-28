using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class RicardoSpawnManager : MonoBehaviour
{
    public GameObject[] RicardoPrefab;
    public int numberprefub;
    public GameObject CoinPrefab;
    public Text TextScore;
    public Text TextCoin;
    public Text TextBestScore;
    public Text TextProebano;
    public GameObject gameover;
    public GameObject[] ABILITIES;
    public GameObject exitbutton;
    public String BottleInShop;
    public float time;
    private String path;
    public float timeOnSpawnRicardo = 3;
    public int score;
    public bool gameoverbool;
    public int NumberBonus;
    public int proebano;
    public int coin;
    public int BestScore;
    public bool freeze;
    public bool YourSelfIMG;
    public bool GamePause;
    public bool coinsx2;
    public GameObject[] HeartSollo;
    public bool secondlife;
    public bool prelife;
    public RawImage image;
    public RawImage gject;
    public bool[] PrefabIsActive;
    public  bool spawnis;
    public GameObject ShootButton;
    public GameObject ShootButton1;
    
    // Start is called before the first frame update
    IEnumerator SpawnRicardo()
    {
        while (true)
        {
            if (!gameoverbool)
            {
                if (!GamePause)
                {
                    if (!freeze)
                    {
                        Instantiate(RicardoPrefab[numberprefub], new Vector3(Random.Range(-8, 8), 6.37f, 0), Quaternion.identity);
                    }
                }
            }
            yield return new WaitForSeconds(timeOnSpawnRicardo);
            
        }
    }
    IEnumerator YSIMG()
    {
        while (true)
        {
            if (!gameoverbool)
            {
                if (!GamePause)
                {
                    if (!freeze)
                    {
                        gject = Instantiate(image, new Vector3(Random.Range(-8, 8), 6.37f, 0), Quaternion.identity);
                        gject.transform.SetParent(GameObject.FindGameObjectWithTag("Finish").transform, false);
                    }
                }
            }
            yield return new WaitForSeconds(timeOnSpawnRicardo);
            
        }
    }
    IEnumerator TimeRicardo()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            if (!gameoverbool)
            {
                if (!GamePause)
                {
                    if (!freeze)
                    {
                        time += 1;
                        if (time / 10 > timeOnSpawnRicardo && timeOnSpawnRicardo > 1)
                        {
                            time = 0;
                            timeOnSpawnRicardo -= 0.2f;
                        }
                    }
                }
            }

        }
    }
    IEnumerator SpawnCoin()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            if (!gameoverbool)
            {
                if (!GamePause)
                {
                    if (!freeze)
                    { 
                        Instantiate(CoinPrefab, new Vector3(Random.Range(-8, 8), 6.37f, 0), Quaternion.identity);
                    }
                }
            }
        }
    }

    void Start()
    {
        PrefabIsActive = new bool[3];
        StartCoroutine(TimeRicardo());
        StartCoroutine(SpawnCoin());

        BestScore = PlayerPrefs.GetInt("BS");
        coin = PlayerPrefs.GetInt("CoinS");
        TextCoin.text = "COIN: " + coin;
        TextBestScore.text = "BEST SCORE: " + BestScore;
        Debug.Log(BottleInShop);
        int g_MaxBottles = GameObject.Find("Bottles").transform.childCount;
        Debug.Log(g_MaxBottles);
        for (int i = 1; i < g_MaxBottles + 1; i++)
        {
            bool IsSelected = Convert.ToBoolean(PlayerPrefs.GetInt("IsSelected" + i));
            if (IsSelected)
            {
                GameObject.Find("Bottles").transform.GetChild(i - 1).gameObject.SetActive(true);
                Debug.Log(i + "SelectedBottle");
                if (i == 9)
                {
                    ShootButton1.SetActive(true);
                }
                else if (i == 10)
                {
                    ShootButton.SetActive(true);
                }
            }
            else
            {
                GameObject.Find("Bottles").transform.GetChild(i - 1).gameObject.SetActive(false);
            }
        }

        for (int ID = 11; ID < 22; ID++)
        {
            bool IsSelected = Convert.ToBoolean(PlayerPrefs.GetInt("IsSelected" + ID));
            if (IsSelected)
            {
                Debug.Log(ID);
                if (ID == 11)
                {
                    coinsx2 = true;
                }
                if (ID == 12)
                {
                    PrefabIsActive[0] = true;
                    spawnis = true;
                }
                if (ID == 13)
                {
                    PrefabIsActive[1] = true;
                    spawnis = true;
                }
                if (ID == 14)
                {
                    PrefabIsActive[2] = true;
                    spawnis = true;
                }
                if (ID == 15)
                {
                    secondlife = true;
                } 
                if (ID == 16)
                {
                    //ricardo
                    numberprefub = 0;
                }
                if (ID == 17)
                {
                    //navalni
                    numberprefub = 1;
                }
                if (ID == 18)
                {
                    //putin
                    numberprefub = 2;
                }
                if (ID == 19)
                {
                    //zelenskiy
                    numberprefub = 3;
                }
                if (ID == 20)
                {
                    //diamond ricardo
                    numberprefub = 4;
                }
                if (ID == 21)
                {
                  // ultra ricardo
                  numberprefub = 5;
                }

                if (ID == 22)
                {
                    YourSelfIMG = true;
                }
                
               // numberprefub = 0;
                path = PlayerPrefs.GetString("path");
                if (path != null)
                {
                    WWW www = new WWW("file:///" + PlayerPrefs.GetString("path"));
                    image.texture = www.texture;
                }

            }
        }
        

        if (spawnis)
        {
            StartCoroutine(BonusSpawn());
        }
        prelife = secondlife;

        if (!YourSelfIMG)
        {
            StartCoroutine(SpawnRicardo());
        }
        else
        {
            StartCoroutine(YSIMG());
        }
    }



    IEnumerator BonusSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(20, 40));
            if (!gameoverbool)
            {
                if (!GamePause)
                {
                    if (!freeze)
                    {
                        while (true)
                        {
                            NumberBonus = Random.Range(0, PrefabIsActive.Length);
                            if (PrefabIsActive[NumberBonus])
                            {
                                Instantiate(ABILITIES[NumberBonus], new Vector3(Random.Range(-8, 8), 6.37f, 0),
                                    Quaternion.identity);
                                break;
                            }

                            numberprefub = Random.Range(0, PrefabIsActive.Length);
                        }
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void updatescore()
    {
        GetComponents<AudioSource>()[1].Play();
        if (!gameoverbool)
        {
            score++;
            TextScore.text = "Score: " + score;
            if (score > BestScore)
            {
                BestScore++;
                PlayerPrefs.SetInt("BS", score);
                TextBestScore.text = "BEST SCORE: " + BestScore.ToString();
            }
        }
    }
    public void updatecoin()
    {
        GetComponents<AudioSource>()[2].Play();
        if (!gameoverbool)
        {
            if (!coinsx2)
            {
                coin++;
            }
            else
            {
                coin += 2;
            }

            PlayerPrefs.SetInt("CoinS", coin);
            TextCoin.text = "Coin: " + coin.ToString();
        }
    }
    public void updateproebano()
    {
        if (!gameoverbool)
        {
            proebano++;
            TextProebano.text = "Proebano: " + proebano + "/5";
            if (proebano > 4)
            {
                if (!secondlife)
                {
                    TextProebano.text = "Proebano: " + proebano + "/5";
                    gameoverbool = true;
                    gameover.SetActive(true);
                    exitbutton.SetActive(true);
                }
                else
                {
                    HeartSollo[0].SetActive(true);
                    HeartSollo[1].SetActive(true);
                    StartCoroutine(rth());
                    proebano--;
                    secondlife = false;
                }
            }
        }
    }

    public  void restartmanager()
    {
        score = 0;
        proebano = 0;
        timeOnSpawnRicardo = 3;
        secondlife = prelife;
        gameoverbool = false;
        gameover.SetActive(false);
        TextProebano.text = "Proebano: " + proebano + "/5";
        TextScore.text = "Score: " + score;
        exitbutton.SetActive(false);
        freeze = false;
        timeOnSpawnRicardo = 3;
        time = 0;

        StopAllCoroutines();

        StartCoroutine(BonusSpawn());
        StartCoroutine(SpawnCoin());
        StartCoroutine(SpawnRicardo());
        StartCoroutine(TimeRicardo());


    }

    IEnumerator rth()
    {
        for(int i = 0; i < 50;i++)
        {
            HeartSollo[0].transform.Rotate(0,5,0,0);
            yield return new WaitForSeconds(0.04f);
        }
        HeartSollo[0].SetActive(false);
        HeartSollo[1].SetActive(false);
    }
    
}
