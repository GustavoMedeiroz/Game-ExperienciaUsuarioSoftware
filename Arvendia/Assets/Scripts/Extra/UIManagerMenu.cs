
using UnityEngine;

public class UIManagerMenu : MonoBehaviour
{
    [SerializeField] private GameObject optionsMenu; // Referência ao painel do menu de opções
    [SerializeField] private GameObject aboutMenu; // Referência ao painel 'Sobre'
    [SerializeField] private GameObject controlsMenu; // Referência ao painel de controles

    // Método para alternar a visibilidade do menu de opções
    public void ToggleOptionsMenu()
    {
        optionsMenu.SetActive(!optionsMenu.activeSelf);
    }

    // Método para abrir o menu de opções
    public void OpenOptionsMenu()
    {
        optionsMenu.SetActive(true);
    }

    // Método para fechar o menu de opções
    public void CloseOptionsMenu()
    {
        optionsMenu.SetActive(false);
    }

    // Método para alternar a visibilidade do menu 'Sobre'
    public void ToggleAboutMenu()
    {
        optionsMenu.SetActive(!optionsMenu.activeSelf);
        aboutMenu.SetActive(!aboutMenu.activeSelf);
    }


    // Método para alternar a visibilidade do menu de controles
    public void ToggleControlsMenu()
    {
        controlsMenu.SetActive(!controlsMenu.activeSelf);
        optionsMenu.SetActive(!optionsMenu.activeSelf);
    }

    // Método para abrir o menu de controles
    public void OpenControlsMenu()
    {
        controlsMenu.SetActive(true);
    }

    // Método para fechar o menu de controles
    public void CloseControlsMenu()
    {
        controlsMenu.SetActive(false);
    }
}
