using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    [Header("Set In Inspector")]
    public GameObject menuVoidbox;
    public GameObject levelSelectVoidbox;

    // Start is called before the first frame update
    void Start()
    {
        menuVoidbox.SetActive(true);
        levelSelectVoidbox.SetActive(false);
    }

    public void playGame()
    {
        menuVoidbox.SetActive(false);
        levelSelectVoidbox.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("The game should quit here.");
    }

    public void Level1()
    {
        PlayerPrefs.SetInt("Level", 1);
        SceneManager.LoadScene(1);
        //bool debugBool = PlayerPrefs.HasKey("Level");
        //Debug.Log(debugBool);
        //int debugInt = PlayerPrefs.GetInt("Level");
        //Debug.Log(debugInt);
    }   
    public void Level2()
    {
        PlayerPrefs.SetInt("Level", 2);
        SceneManager.LoadScene(1);

    }
    public void Level3()
    {
        PlayerPrefs.SetInt("Level", 3);
        SceneManager.LoadScene(1);

    }
}
