using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioMixer AM;
    public AudioMixer AMWEAPON;
    public AudioMixer AMBOTTLE;
    public float volume;
    public float volumeWeapon;
    public float volumeBottle;
    public GameObject slider;
    public GameObject sliderweapon;
    public GameObject sliderbottle;
    public void Start()
    {
        volume = PlayerPrefs.GetFloat("VolumeSafe",0);
        AM.SetFloat("volume",Mathf.Log10(volume) * 20);
        slider.GetComponent<Slider>().value = volume;
        
        volumeWeapon = PlayerPrefs.GetFloat("VolumeSafeWeapon",0);
        AMWEAPON.SetFloat("volumeweapon",Mathf.Log10(volumeWeapon) * 20);
        sliderweapon.GetComponent<Slider>().value = volumeWeapon;
        
        volumeBottle = PlayerPrefs.GetFloat("VolumeSafeBottle",0);
        AMBOTTLE.SetFloat("volumebottle",Mathf.Log10(volumeBottle) * 20);
        sliderbottle.GetComponent<Slider>().value = volumeBottle;
    }

    public void SetVolume(float volume)
    {
        AM.SetFloat("volume",Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("VolumeSafe",volume);
    } 
    
    public void SetVolumeWeapon(float volumeWeapon)
    {
        AMWEAPON.SetFloat("volumeweapon",Mathf.Log10(volumeWeapon) * 20);
        PlayerPrefs.SetFloat("VolumeSafeWeapon",volumeWeapon);
    } 
    
    public void SetVolumeBottle(float volumeBottle)
    {
        AMBOTTLE.SetFloat("volumebottle",Mathf.Log10(volumeBottle) * 20);
        PlayerPrefs.SetFloat("VolumeSafeBottle",volumeBottle);
    } 
}
