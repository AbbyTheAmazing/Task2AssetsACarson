using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
 private Rigidbody2D rB;
 public float speed;
 public bool enemyProjectile;
 void Awake(){
    rB=GetComponent<Rigidbody2D>();
 }  
    void Start()
     
    {       
        rB.linearVelocity=transform.right*speed;
        Destroy(gameObject,5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Destroys the object if it hits something
        Destroy(gameObject);

        // Checks is the object hit is an enemy and removes 1HP if it is.
        if (enemyProjectile == false)
        {
            if (collision.gameObject.TryGetComponent<EnemyBehav>(out EnemyBehav enemy))
            {
                enemy.health--;
            }
        }
                if (enemyProjectile == true)
        {
            //Checks if the projectile is coming from an enemy
            if (collision.gameObject.TryGetComponent<PlayerMovement>(out PlayerMovement player))
            {
                player.health--;
            }
        }
    }
}
