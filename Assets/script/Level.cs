
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{

    [SerializeField] int GoLevel=0;
    private  GameObject Music ;
    private GameObject blackScreen;

    
    //go to StartPage
    public  void Home(){
        //stop Map's Music if Played
       
       
        Music =GameObject.FindWithTag("Music");
         Music.GetComponent<MusicClass>().StopMusic();
        GoLevel = 0;
    
       Invoke("LoadLevelInVar",0.4f);
   
    }
   

    //restart the game
    public void Restart(){

        Time.timeScale = 1;
        GoLevel = SceneManager.GetActiveScene().buildIndex;
        Invoke("LoadLevelInVar",0.4f);
        
        
    }

    //Load a giving Scene (Level) 
    public void LoadLevel(){
        //find the music of Maps


        int level = SceneManager.GetActiveScene().buildIndex;


        Music=GameObject.FindWithTag("Music");
        
        if ( level>13||level<11)
        {
            //Delete the music of map from levels
            if (Music != null)
            Destroy(Music);
            //wait 1.5 seceonds before load the scene
            Time.timeScale = 1.0f;
            Invoke("LoadLevelInVar", 0.4f);
            
        } 
        else{

            
            blackScreen = GameObject.FindGameObjectWithTag("BlackScreen");
            float time;

            //dont change the music if it's already Played 
            Music.GetComponent<MusicClass>().PlayMusic();



            if (GoLevel>10 && GoLevel< 14)
            { 
                if(level>GoLevel)
                    blackScreen.GetComponent<Animator>().SetInteger("pos",1);
                else
                    blackScreen.GetComponent<Animator>().SetInteger("pos", 2);

                time = 1.5f;
            }
            else
            {
                if (Music != null)
                    Destroy(Music);
                time = 0.0f;
            }
            Time.timeScale = 1.0f;
            Invoke("LoadLevelInVar", time);
            

        }  
    }

    //Load the map depends on LeveL where he left
    public void loadMap(){

        float go=(SceneManager.GetActiveScene().buildIndex-1)/5;
        GoLevel=(int) go+11;
        Time.timeScale = 1.0f;
        Invoke("LoadLevelInVar",0.4f);
        

    }
    //Play Sound effect after click on the button
  

    void LoadLevelInVar()
    {
        
        
        SceneManager.LoadScene(GoLevel);
    }
}
