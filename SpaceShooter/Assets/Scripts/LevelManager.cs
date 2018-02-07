using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void LoadLevel()
    {
        SceneManager.LoadScene("GameScene"); // load game
    }
        
    public void QuitRequest()
    {
        Application.Quit(); //exit the game
    }
 }
