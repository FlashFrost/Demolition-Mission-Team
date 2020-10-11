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

    private SceneManager SM;

    // Start is called before the first frame update
    void Start()
    {
        menuVoidbox.SetActive(true);
        levelSelectVoidbox.SetActive(false);
        SM = new SceneManager();
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
    }   
    public void Level2()
    {
        PlayerPrefs.SetInt("Level", 2);
    }
    public void Level3()
    {
        PlayerPrefs.SetInt("Level", 3);
    }
}
