using System;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    private Button button;
    private String text;
    private Text textButton;

    private int maxLevel = 1;

   
    private void Start()
    {
        
        maxLevel= PlayerPrefs.GetInt("MaxLevel");

        button =GetComponent<Button>();
        textButton=button.GetComponentInChildren<Text>();
        text = textButton.text;
        if (int.Parse(text)<=maxLevel) enableButton();
        else
        disableButton();
    }
    //disable buttons
    public void disableButton()
    {
        button.interactable = false;
        textButton.text = "";
    }
    //enable buttons
    public void enableButton()
    {
        button.interactable = true;
        textButton.text = text;
    }
}
