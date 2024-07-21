using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainStory : MonoBehaviour
{

    private void OnEnable()
    {

        //Only specify the sceneName or sceneBuildIntex will load the scene with the single mode

        SceneManager.LoadScene(2, LoadSceneMode.Single);

    }

}
