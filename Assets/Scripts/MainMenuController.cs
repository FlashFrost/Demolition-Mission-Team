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
    public GameObject levelLoadingVoidbox;
    public TextMeshProUGUI levelLoadingtext;

    // Start is called before the first frame update
    void Start()
    {
        menuVoidbox.SetActive(true);
        levelSelectVoidbox.SetActive(false);
        levelLoadingVoidbox.SetActive(false);
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
        NowLoading(1);
    }
    public void Level2()
    {
        NowLoading(2);
    }
    public void Level3()
    {
        NowLoading(3);
    }
    public void Level4()
    {
        NowLoading(4);
    }
    public void Level5()
    {
        NowLoading(5);
    }
    public void Level6()
    {
        NowLoading(6);
    }
    public void Level7()
    {
        NowLoading(7);
    }
    public void Level8()
    {
        NowLoading(8);
    }
    public void Level9()
    {
        NowLoading(9);
    }
    public void Level10()
    {
        NowLoading(10);
    }
    public void Level11()
    {
        NowLoading(11);
    }
    public void Level12()
    {
        NowLoading(12);
    }

    private void NowLoading(int levelCall)
    {
        levelSelectVoidbox.SetActive(false);
        levelLoadingtext.text = ("Now Loading Level: " + levelCall);
        levelLoadingVoidbox.SetActive(true);

        Debug.Log(levelCall);
        //PlayerPrefs.SetInt("Level", levelCall);
        //SceneManager.LoadScene(1);
    }
}
