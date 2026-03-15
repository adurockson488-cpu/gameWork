using UnityEngine;
using UnityEngine.AI;

public class enemyManager : MonoBehaviour
{

    public GameObject Player;

    public Animator enemyAnimator;
    public float damage = 10f;
    public float health = 100f;
    public GameManager gameManager;

    public void Hit(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            gameManager.enemiesAlive--;
            //Destroy the enemy
            Destroy(gameObject);
        }
    }
   



    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = Player.transform.position;
        if (GetComponent<NavMeshAgent>().velocity.magnitude > 1)
        {
            enemyAnimator.SetBool("isWalking", true);
        }
        else
        {
            enemyAnimator.SetBool("isWalking", false); 
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == Player)
        {
           Player.GetComponent<playerManager>().Hit(damage);
        }
    }
}
