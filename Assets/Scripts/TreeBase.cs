using UnityEngine;

public class TreeBase : MonoBehaviour
{
    public void DestroyTree()
    {
        Debug.Log("A árvore foi destruída! Game Over.");
        FindObjectOfType<GameManager>().GameOver();
        Destroy(gameObject);
    }
}
