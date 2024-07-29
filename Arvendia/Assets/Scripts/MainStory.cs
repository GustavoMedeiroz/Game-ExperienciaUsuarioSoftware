using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainStory : MonoBehaviour
{

    private void OnEnable()
    {

        OnSkipPressed();

    }

    public void OnSkipPressed()
    {
        SceneManager.LoadScene(2, LoadSceneMode.Single);
    }

}
