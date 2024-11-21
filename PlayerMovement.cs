using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
public GameManager gameManager;
 public Rigidbody2D characterController;
 public float playerSpeed;
 private Vector2 playerVelocity;

 public int health;
 void Awake()
 {
 characterController = GetComponent<Rigidbody2D>();
 }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    // Movement code:)
    {
        playerVelocity.x=Input.GetAxisRaw("Horizontal");
        playerVelocity.y=Input.GetAxisRaw("Vertical");
        playerVelocity.Normalize();
    //MouseMovementCode
        var direction=Input.mousePosition-Camera.main.WorldToScreenPoint(transform.position);
        var angle = Mathf.Atan2(direction.y,direction.x) *Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        //Updates the players health graphics to match current health
        if (health == 4)
        {
            gameManager.heart5.SetActive(false);
        }
        else if (health == 3)
        {
            gameManager.heart4.SetActive(false);
        }
         else if (health == 2)
        {
            gameManager.heart3.SetActive(false);
        }
        else if (health == 1)
        {
            gameManager.heart2.SetActive(false);
        }
        else if (health == 0)
        {
            //When player health reaches zero, player is deactivated and game ends
                gameManager.playerIsAlive = false;
                gameManager.heart1.SetActive(false);
        }
    }
private void FixedUpdate(){
    characterController.linearVelocity=playerVelocity*playerSpeed;
}
    
}
