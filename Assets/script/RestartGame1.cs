using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame1 : MonoBehaviour
{
     public void Restart(){
        SceneManager.LoadScene(2);
    }
}
