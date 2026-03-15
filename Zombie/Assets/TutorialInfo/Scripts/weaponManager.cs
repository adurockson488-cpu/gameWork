using UnityEngine;

public class weaponManager : MonoBehaviour
{
    public GameObject playerCam;
    public float range= 100f;
    public float damage = 50f;
    public Animator playerAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerAnimator.GetBool("isShooting"))
        {
            playerAnimator.SetBool("isShooting", false);
        }



        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
   void Shoot()
    {

        playerAnimator.SetBool("isShooting", true);



        RaycastHit hit;
        if(Physics.Raycast(playerCam.transform.position, transform.forward, out hit, range))
        {
           // Debug.Log("hit");

            enemyManager Enemy = hit.transform.GetComponent<enemyManager>();
            if(Enemy != null)
            {
                Enemy.Hit(damage);
            }

        }
    }
}
