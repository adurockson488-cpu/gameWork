using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int enemiesAlive = 0;
    public int round = 0;
    public GameObject[] spawnPoints;
    public GameObject enemyPrefab;
    public Text roundNumber;
    public Text RoundsSurvided;
    public GameObject endScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(enemiesAlive == 0)
        {
            round++;
            NextWave(round);
            roundNumber.text = "Round:"+round.ToString();
        }
    }
    public void NextWave(int round)
    {
        for(var x=0; x<round; x++)
        {
            GameObject spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            GameObject enemySpwned = Instantiate(enemyPrefab, spawnPoint.transform.position, Quaternion.identity);
            enemySpwned.GetComponent<enemyManager>().gameManager = GetComponent<GameManager>();
            enemiesAlive++;
        }

     
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }



    public void EndGame()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        endScreen.SetActive(true);
        RoundsSurvided.text=round.ToString();
    }


    
}
