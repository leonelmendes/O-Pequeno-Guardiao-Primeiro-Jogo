using UnityEngine;

public class TreeBase : MonoBehaviour
{
    public void DestroyTree()
    {
        Debug.Log("A �rvore foi destru�da! Game Over.");
        FindObjectOfType<GameManager>().GameOver();
        Destroy(gameObject);
    }
}
