using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public enum GameMode
{
    idle,
    playing,
    levelEnd
}
public class MissionDemolition : MonoBehaviour
{
    static private MissionDemolition S;

    [Header("Set in Inspector")]
    public Text uiLevel;
    public Text uiShots;
    public Text uiButton;
    public Vector3 castlePos;
    public GameObject[] levels;
    public GameObject moon;

    public static int Comets = 3;
    public static int Asteroids = 3;
    public TextMeshProUGUI asteroidCountText;
    public TextMeshProUGUI cometCountText;

    [Header("Set Dynamically")]
    public int levelMax;
    public int shotsTaken;
    public GameMode mode = GameMode.idle;
    public string showing = "Show Slingshot";
    public GameObject levelCreation;
    private int level;

    private void Start()
    {
        S = this;
        level = PlayerPrefs.GetInt("Level", 1) - 1;
        levelMax = levels.Length;
        StartLevel();
    }

    void StartLevel()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("Projectile");
        foreach(GameObject ptemp in gos)
        {
            Destroy(ptemp);
        }
        gos = GameObject.FindGameObjectsWithTag("Comet");
        foreach(GameObject ptemp in gos)
        {
            Destroy(ptemp);
        }

        Destroy(levelCreation);
        levelCreation = Instantiate<GameObject>(levels[level]); //Instantiates a level.
        //moon.transform.position = castlePos;

        UpdateProjectiles();
        shotsTaken = 0;

        SwitchView("Show Level");
        ProjectileLine.S.Clear();

        Goal.goalMet = false;

        UpdateGUI();
        mode = GameMode.playing;
    }

    void UpdateGUI()
    {
        uiLevel.text = "Level: " + (level + 1) + " of " + levelMax;
        uiShots.text = "Shots Taken: " + shotsTaken;
        asteroidCountText.text = "Asteroids Remaining: " + Asteroids.ToString();
        cometCountText.text = "Comets Remaining: " + Comets.ToString();
    }

    private void Update()
    {
        UpdateGUI();
        if ((mode == GameMode.playing) && Goal.goalMet)
        {
            mode = GameMode.levelEnd;
            SwitchView("View Launcher");
            Invoke("NextLevel", 2f);
        }
    }

    void NextLevel()
    {
        string pref = (level + "Completed");
        PlayerPrefs.SetString(pref, "Yes");

        level++;
        if(level == levelMax)
        {
            level = 0;
        }
        StartLevel();
    }

    public void SwitchView(string eView = "")
    {
        if(eView == "")
        {
            eView = uiButton.text;
        }

        showing = eView;
        switch (showing)
        {
            case "View Launcher":
                FollowCam.POI = null;
                uiButton.text = "Zoom Out";
                break;
            case "Zoom Out":
                FollowCam.POI = GameObject.FindGameObjectWithTag("FocusPoint");
                Camera.main.orthographicSize = 45;
                uiButton.text = "View Launcher";
                break;
        }
    }

    public static void ShotFired()
    {
        S.shotsTaken++;
    }

    public void RestartLevel()
    {
        StartLevel();
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void UpdateProjectiles()
    {
        switch (level)
        {
            case 0:
                Asteroids = 2;
                Comets = 0;                
                break;
            case 1:
                Asteroids = 7;
                Comets = 0;
                break;
            case 2:
                Asteroids = 3;
                Comets = 1;
                break;
            case 3:
                Asteroids = 5;
                Comets = 0;
                break;
            case 4:
                Asteroids = 3;
                Comets = 1;
                break;
            case 5:
                Asteroids = 3;
                Comets = 1;
                break;
            case 6:
                Asteroids = 3;
                Comets = 1;
                break;
            case 7:
                Asteroids = 3;
                Comets = 1;
                break;
            case 8:
                Asteroids = 3;
                Comets = 1;
                break;
            case 9:
                Asteroids = 3;
                Comets = 1;
                break;
            case 10:
                Asteroids = 3;
                Comets = 1;
                break;
            case 11:
                Asteroids = 5;
                Comets = 2;
                break;
        }
        asteroidCountText.text = $"Asteroids Remaining: {Asteroids}";
        cometCountText.text = $"Comets Remaining: {Comets}";
    }
}
