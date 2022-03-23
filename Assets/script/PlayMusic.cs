using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayMusic : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject[] Music;
    private Sprite MusicOff;
    private Sprite MusicOn;
    private GameObject MusicObject;
    private void Start()
    {
        MusicOff = Resources.Load<Sprite>("graphic/buttons/MusicOff");
        MusicOn = Resources.Load<Sprite>("graphic/buttons/MusicOn");
        MusicObject = GameObject.Find("Music");
        
        PlayingMusic();
       
    }
    public void PlayingMusic()
    {
        int level = SceneManager.GetActiveScene().buildIndex;
        if (level >= 11 && level <= 13) Music = GameObject.FindGameObjectsWithTag("Music");
        if (PlayerPrefs.GetInt("Music") == 1)
        {
            foreach (GameObject music in Music)
            {
                if(!music.GetComponent<AudioSource>().isPlaying)
                music.GetComponent<AudioSource>().Play();

            }
            MusicObject.GetComponent<Image>().sprite = MusicOn;

            
        }
        else
        {
            foreach (GameObject music in Music)
            {
                music.GetComponent<AudioSource>().Stop();
                
            }
            MusicObject.GetComponent<Image>().sprite = MusicOff;
        } 
       
    }
}
