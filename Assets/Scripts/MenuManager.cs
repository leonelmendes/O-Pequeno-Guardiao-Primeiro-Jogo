using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject painelAlerta;

    void Start()
    {
        if (painelAlerta != null)
            painelAlerta.SetActive(false);
    }

    public void Jogar()
    {
        SceneManager.LoadScene("Garden"); // Coloque o nome EXATO da sua cena principal
    }

    public void Configuracoes()
    {
        if (painelAlerta != null)
            painelAlerta.SetActive(true);
    }

    public void FecharAlerta()
    {
        if (painelAlerta != null)
            painelAlerta.SetActive(false);
    }

    public void Sair()
    {
        Application.Quit();
    }
}
