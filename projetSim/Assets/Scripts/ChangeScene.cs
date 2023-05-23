using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{

    public string sceneNameToLoad;

    /// <summary>
    /// Permet de changer d'une scene à une autre.
    /// </summary>
    public void changeScene()
    {
        Ligne.viderList();
        SceneManager.LoadScene(sceneNameToLoad); // Changer la scène

    }
}

