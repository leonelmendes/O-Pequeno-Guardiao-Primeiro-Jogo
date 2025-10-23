using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject); // destrói o inimigo atingido
        }
    }
}
