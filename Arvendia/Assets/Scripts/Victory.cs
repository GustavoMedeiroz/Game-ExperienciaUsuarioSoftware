using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour
{
    public void OnExitButton()
    {
        SceneManager.LoadScene("MenuScene");
    }
}
