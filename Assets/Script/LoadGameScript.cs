using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGameScript : MonoBehaviour
{

    public void loadGame(string sceneName){
        SceneManager.LoadScene(sceneName);
    }
}
