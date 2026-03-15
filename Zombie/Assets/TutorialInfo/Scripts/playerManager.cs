using UnityEngine;
using UnityEngine.UI;
public class playerManager : MonoBehaviour
{
    public float health = 100;
    public Text healthText;
    public GameManager gameManager;
    public void Hit(float damage)
    {
      health -= damage;
        healthText.text = "Heath:" + health.ToString();
        if (health <= 0)
        {
            gameManager.EndGame();
        }
    }
}
