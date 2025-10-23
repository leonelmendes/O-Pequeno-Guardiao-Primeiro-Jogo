using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int totalLives = 4;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public void TakeDamage(int amount)
    {
        totalLives -= amount;
        totalLives = Mathf.Clamp(totalLives, 0, hearts.Length);
        UpdateHearts();

        // Se a vida acabar, chama o GameOver
        if (totalLives <= 0)
        {
            // Chama o GameManager e mostra Game Over na tela
            FindObjectOfType<GameManager>().GameOver();
        }
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].sprite = i < totalLives ? fullHeart : emptyHeart;
        }
    }
}
