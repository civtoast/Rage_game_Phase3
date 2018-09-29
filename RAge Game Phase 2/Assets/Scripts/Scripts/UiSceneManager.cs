using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiSceneManager : MonoBehaviour
{

    public Button changeUiScene;
    //public Canvas changeCanvas;

    public string sceneName;

    // Use this for initialization
    void Start()
    {
        changeUiScene.onClick.AddListener(ChangeScene);
    }

    void ChangeScene()
    {
        print("Load new UI scene ");
        SceneManager.LoadScene(sceneName);
    }

    //public void ChangeScene()
   //{
  //      changeCanvas.enabled = true;
    //}
}

  
