using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneFolder : MonoBehaviour
{

    public string sceneNameToLoad;



    void Start()
    {

    }

    public void changeScene()
    {
        Ligne.viderList();
        SceneManager.LoadScene(sceneNameToLoad); // Change la scene

    }
}


