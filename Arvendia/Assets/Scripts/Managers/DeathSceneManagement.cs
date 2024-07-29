using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathSceneManagement : MonoBehaviour
{
    // Start is called before the first frame update
    void SetDeadAnimation()
    {
        // Outros códigos de morte, como animações, sons, etc.
        
        // Carregar a cena de morte
        SceneManager.LoadScene("DeathScene"); // Substitua "DeathScene" pelo nome da sua cena de morte
    }
    }

