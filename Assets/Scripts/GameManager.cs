using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverText;
    public GameObject winText;

    public void GameOver()
    {
        StartCoroutine(ShowGameOverAndReturnToMenu());
    }

    IEnumerator ShowGameOverAndReturnToMenu()
    {
        gameOverText.SetActive(true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Menu"); // Substitua pelo nome real da sua cena de menu
    }

    IEnumerator ShowWinAndReturnToMenu()
    {
        winText.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Menu"); // Nome da sua cena de menu
    }

    public void Win()
    {
        StartCoroutine(ShowWinAndReturnToMenu());
    }
}
