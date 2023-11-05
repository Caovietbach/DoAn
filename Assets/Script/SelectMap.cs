using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectMap : MonoBehaviour
{
    public void openMap(int index){
        string map = "Map " + index;
        SceneManager.LoadScene(map);

    }
}
