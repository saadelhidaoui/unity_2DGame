
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    
    [SerializeField] GameObject image;
    [SerializeField] GameObject buttons;

    Button pause;
    Button Settings;
    

    void Start()
    {
       if(SceneManager.GetActiveScene().buildIndex!=0)
        pause= GameObject.Find("Pause").GetComponent<Button>();
        else
        { 
            if (!PlayerPrefs.HasKey("Music")) PlayerPrefs.SetInt("Music", 1);

            if (!PlayerPrefs.HasKey("Sound")) PlayerPrefs.SetInt("Sound", 1);

            Settings = GameObject.Find("Settings").GetComponent<Button>();
        }
       

    }
    public void PauseGame()
    {
        
        PauseAnimation();
        Pause();
       
    }

    public void ResumeGame()
    {
        ResumeAnimation();
        Resume();
        
    }
    public void OpenSetting()
    {
        PauseAnimation();
        Settings.interactable = false;
    }
    public void CloseSetting()
    {
        ResumeAnimation();
        Settings.interactable = true;
    }


    void PauseAnimation()
    {
        
        image.GetComponent<Animator>().SetBool("pauseGame", true);
        buttons.GetComponent<Animator>().SetBool("pauseGame", true);
        
        
    }
    void ResumeAnimation()
    {
        image.GetComponent<Animator>().SetBool("pauseGame", false);
        buttons.GetComponent<Animator>().SetBool("pauseGame", false);
       
    }
    
    void Pause()
    {
        
        pause.interactable=false;
        Time.timeScale = 0;

       
    }
    void Resume()
    {
       
        Time.timeScale = 1;
        pause.interactable=true;
    }

    
}
