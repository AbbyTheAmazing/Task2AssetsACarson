using UnityEngine;

public class EnemyBehav : MonoBehaviour
{
    public  GameManager gameManager;

[Header("Movement")]
    private Transform target;
    public float speed;

    [Header("Attacking")]
[SerializeField] private GameObject projectile;
[SerializeField] private Transform originPoint;
private float attackCooldown;
[SerializeField] private float attackCooldownTime;
private bool hasAttacked;

    [Header("Health")]
public int health;

void Awake()
{
    gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        if (gameManager.playerIsAlive == true)
        {
            target = GameObject.Find("Character").GetComponent<Transform>();
    }
}

    // Update is called once per frame
    void Update()
    {
      // Movement
      if (gameManager.playerIsAlive == false)
      {
        return;
      }

    // Moves the enemy towards the player
    transform.position = Vector2.MoveTowards(transform.position, target.position, speed*Time.deltaTime);

    // Points the enemy in the direction of the player
    Vector3 direction = target.position - transform.position;
    float angle = Mathf.Atan2(direction.y, direction.x)*Mathf.Rad2Deg;
    transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    // Attacking
    attackCooldown -= Time.deltaTime;

    if (attackCooldown <= 0 && hasAttacked == false)
        {
            //Prevents attacks before cooldown reset
            hasAttacked = true;

            // Fire projectile 
            Instantiate(projectile, originPoint.position, originPoint.rotation);

            //Reset attack cooldown 
            attackCooldown = attackCooldownTime;

            hasAttacked = false;
        }

        //Destroys enemy when its health drops to 0
        if (health == 0)
        {
            gameManager.enemiesKilled++;
            Destroy(gameObject);
        }
    }
}
