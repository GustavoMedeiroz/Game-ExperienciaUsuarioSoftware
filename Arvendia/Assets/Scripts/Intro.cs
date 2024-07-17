using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour
{

    string[] textos = new string[5];
    GameObject[] imagens;
    GameObject texto;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(rotina());

        textos[0] = "Há muito tempo, Arvendia era uma terra próspera e mágica, cheia de vida e alegria.";
        textos[1] = "No entanto, essa paz foi destruída quando Frogor, o Sapo Gigante, lançou uma terrível maldição sobre o vilarejo.";
        textos[2] = "Motivado pela fome insaciável por poder, Frogor drenou a energia vital de Arvendia, levando-a para a Floresta Sombria, onde ele se escondeu.";
        textos[3] = "As colheitas murcharam, os rios secaram e os aldeões foram deixados desolados.";
        textos[4] = "Agora, a esperança recai sobre Aldrin, um lendário ninja, para enfrentar Frogor e restaurar a paz em Arvendia.";

        texto = GameObject.Find("textoo");
        texto.GetComponent<Text>().text = textos[0];
        // if (texto != null)
        // {
        //     texto.GetComponent<Text>().text = textos[0];
        // }
        // else
        // {
        //     Debug.LogError("NÃO ENCONTROU");
        // }
    }

    int cont = 0;

    public IEnumerator rotina()
    {
        //habilitar imagem
        // GameObject img = GameObject.Find("img" + cont);
        // if (img != null)
        // {
        //     img.GetComponent<RawImage>().gameObject.SetActive(true);
        //     texto.GetComponent<Text>().text = textos[cont];
        // }
        // else
        // {
        //     Debug.LogError("GameObject 'img" + cont + "' not found.");
        // }
        texto.GetComponent<Text>().text = textos[cont];
        cont++;

        if (cont < 5)
        {
            yield return new WaitForSeconds(5);
            StartCoroutine(rotina());
        }
        else
        {
            SceneManager.LoadScene(2);
        }


    }
}
