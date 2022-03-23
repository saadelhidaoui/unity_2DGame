using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickButton : MonoBehaviour
{ 
    private Sprite SoundOn;
    private Sprite SoundOff;
    private GameObject SoundObject;
private void Start()
    {
        
        SoundObject = GameObject.Find("Sound");
        SoundOff = Resources.Load<Sprite>("graphic/buttons/SoundOff");
        SoundOn = Resources.Load<Sprite>("graphic/buttons/SoundOn");

        if (SoundObject != null)
        {
            if(PlayerPrefs.GetInt("Sound") == 1) SoundObject.GetComponent<Image>().sprite = SoundOn;
            else SoundObject.GetComponent<Image>().sprite = SoundOff;
        }
        

    }
    public void  ClickSound()
    {
        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            gameObject.GetComponent<AudioSource>().Play();
           if(SoundObject!=null) SoundObject.GetComponent<Image>().sprite = SoundOn;
        }
        else if(SoundObject!=null)SoundObject.GetComponent<Image>().sprite = SoundOff;

    }
}
