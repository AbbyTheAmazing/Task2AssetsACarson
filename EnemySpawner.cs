using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameManager gameManager;

    public GameObject enemy;

    private float spawningCooldown;
    private bool hasSpawnedEnemy; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Spawns a new enemy everytime the time reaches 0
            spawningCooldown -= Time.deltaTime;
            if (spawningCooldown <= 0 && hasSpawnedEnemy == false)
            {
                hasSpawnedEnemy = true;
                SpawnEnemy();
                hasSpawnedEnemy = false;
            } 
    }
    private void SpawnEnemy()
    {
    //Spawns enemy
    Instantiate(enemy, transform.position, transform.rotation);
    spawningCooldown = 5;
    }
}
