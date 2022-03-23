
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    private GameObject[] Music;//for map's Music
    private GameObject[] MusicBG; //the rest 


    
    private Sprite MusicOff;
    private Sprite MusicOn;
    private Sprite SoundOn;
    private Sprite SoundOff;

    private GameObject MusicObject;
    private GameObject SoundObject;
    void Start()
    {
        //buttons
       
        MusicOff = Resources.Load<Sprite>("graphic/buttons/MusicOff");
        MusicOn = Resources.Load<Sprite>("graphic/buttons/MusicOn");
        SoundOff = Resources.Load<Sprite>("graphic/buttons/SoundOff");
        SoundOn = Resources.Load<Sprite>("graphic/buttons/SoundOn");


        MusicObject =GameObject.Find("Music");
        SoundObject = GameObject.Find("Sound");
       
    }

    void disableMusic()
    {
        
        MusicObject.GetComponent<Image>().sprite = MusicOff;

    }
    
    void enableMusic()
    {         
        MusicObject.GetComponent<Image>().sprite = MusicOn;
    }
   
    //turn off/on depend of User
   public  void ControlMusic()
    {
       
        
       

        //1 : Music Enabled
        //0 : Music disabled
        if (PlayerPrefs.GetInt("Music")==1)
        {
            disableMusic();
            PlayerPrefs.SetInt("Music", 0);
        }
        else
        {
            enableMusic();
            PlayerPrefs.SetInt("Music", 1);
        }

    }

    void  enableSound()
    {
        SoundObject.GetComponent<Image>().sprite = SoundOn;
    }

    void disableSound()
    {
        SoundObject.GetComponent<Image>().sprite = SoundOff;
    }

    public void ControlSound()
    {
        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            disableSound();
            PlayerPrefs.SetInt("Sound", 0);
        }
        else
        {
            enableSound();
            PlayerPrefs.SetInt("Sound", 1);
        }

    }
    public   void ClickSound()
    {
        if (PlayerPrefs.GetInt("Sound") == 1)
        {
            gameObject.GetComponent<AudioSource>().Play();
            enableSound();
        }
        else disableSound();
    }
}
