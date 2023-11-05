using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.UI;  
  
public class Options : MonoBehaviour  
{  
    public Button level1Button; // attach these in the inspector  
    public Button level2Button;  
    public Button level3Button;  
      void Start()  
    {  
        int chosenLevel = PlayerPrefs.GetInt("chosenLevel", 1);  
        HandleButtonClick(chosenLevel); 
         
    }  
  
    public void HandleButtonClick(int buttonNumber)  
    {  
        // restore color of all buttons  
        ColorBlock cb1 = level1Button.colors;  
        ColorBlock cb2 = level2Button.colors;  
        ColorBlock cb3 = level3Button.colors;  
  
        cb1.colorMultiplier = 1;  
        cb2.colorMultiplier = 1;  
        cb3.colorMultiplier = 1;  
          
        level1Button.colors = cb1;  
        level2Button.colors = cb2;  
        level3Button.colors = cb3;  
  
        PlayerPrefs.SetInt("chosenLevel", buttonNumber);  
        switch(buttonNumber)  
        {  
            case 1:  
                cb1 = level1Button.colors;  
                cb1.colorMultiplier = 1; // reduce color of selected button  
                level1Button.colors = cb1;  
                level1Button.interactable = false;  
                level2Button.interactable = true;  
                level3Button.interactable = true;  
                Debug.Log("Select level 1");
                break;  
            case 2:  
                cb2 = level2Button.colors;  
                cb2.colorMultiplier = 1; // reduce color of selected button  
                level2Button.colors = cb2;  
                level2Button.interactable = false;  
                level1Button.interactable = true;  
                level3Button.interactable = true;  
                Debug.Log("Select level 2");
                break;  
            case 3:  
                cb3 = level3Button.colors;  
                cb3.colorMultiplier = 1; // reduce color of selected button  
                level3Button.colors = cb3;  
                level3Button.interactable = false;  
                level1Button.interactable = true;  
                level2Button.interactable = true;  
                Debug.Log("Select level 3");
                break;  
        }  
        int levelSelected =   PlayerPrefs.GetInt("chosenLevel");  

        Debug.Log("Value selected: " + levelSelected);
    }  
}  
