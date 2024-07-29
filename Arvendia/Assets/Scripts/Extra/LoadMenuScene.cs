using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadMenuScene : MonoBehaviour
{
    public void OnExitButton()
    {
        SceneManager.LoadScene("MenuScene"); // Certifique-se de que o nome da cena inicial esteja correto
    }
}
