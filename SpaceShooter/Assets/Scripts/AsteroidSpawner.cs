using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[System.Serializable]
public class TextElements
{
    public Text gameOverText;
    public Text restartText;
    public Text quitText;
    public float flashTime;
}
public class AsteroidSpawner : MonoBehaviour
{

    public Vector3 spawnValues;
    public float spawnDelay;
    public float enemyCount;
    public GameObject Asteroid;
    public TextElements textManager;

    private bool gameOver;
    private bool restartGame;
    private void Initialize()
    {
        //set booleans to false, and text to empty
        gameOver = false;
        textManager.gameOverText.text = string.Empty;
        textManager.quitText.text = string.Empty;
        restartGame = false;
        textManager.restartText.text = string.Empty;
    }
    void Start()
    {
        Initialize();
        StartCoroutine(SpawnAsteroids()); //start spawning asteroids
    }
    private void Update()
    {
        if (gameOver)
            StartCoroutine(BlinkText()); // flash restart text
        if (restartGame)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Initialize();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // restart the game
            }
            else if (Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit(); // close the game
            }
        }
    }
    IEnumerator SpawnAsteroids()
    {
        yield return new WaitForSeconds(spawnDelay);// wait until spawning new wave
        while (true)
        {
            for (int i = 1; i < enemyCount; i++)
            {
                //get new random spawn position
                Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity; //set 0 rotation
                Instantiate(Asteroid, spawnPosition, spawnRotation); //instantiate asteroid GO
                yield return new WaitForSeconds(spawnDelay); //wait for another spawndelay seconds
                if (gameOver) //if player dies, show Restart&Quit options
                {
                    restartGame = true;
                    break;
                }
            }
            yield return new WaitForSeconds(spawnDelay);
            }
        }
    public void GameOver()
    {
        textManager.gameOverText.text = "Game Over !";
        gameOver = true;
    }
    //function to blink the restart& quit text
    public IEnumerator BlinkText()
    {
        //blink it forever
        while (true)
        {
            //set the Text's text to blank
            textManager.restartText.text = "";
            textManager.quitText.text = "";
            //display blank text for x seconds
            yield return new WaitForSeconds(textManager.flashTime);
            //display actual text for the next x seconds
            textManager.restartText.text = "Press 'R' for Restart";
            textManager.quitText.text = "Press 'Q' for Quit";
            yield return new WaitForSeconds(textManager.flashTime);
        }
    }
}

