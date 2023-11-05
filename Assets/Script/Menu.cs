using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public void playGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex + 1);
    }
    public void quitGame(){
        Application.Quit();
        Debug.Log("Quit");
    }
    public void pauseGame(){
        Time.timeScale = 1.0f;
		SceneManager.LoadScene("Menu");
    }

}
