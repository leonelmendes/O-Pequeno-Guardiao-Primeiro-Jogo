using UnityEngine;

public class EnemySpawner : MonoBehaviour 
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public Transform treeTarget;
    public float spawnInterval = 5f;

    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), 1f, spawnInterval);
    }

    void SpawnEnemy()
    {
        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        EnemyAI ai = enemy.GetComponent<EnemyAI>();
        if (ai != null)
        {
            ai.target = treeTarget; // árvore
            ai.player = GameObject.FindGameObjectWithTag("Player").transform;

        }
    }
}
