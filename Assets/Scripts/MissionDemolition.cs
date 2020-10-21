using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


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
        //if(eView == "")
        //{
        //    eView = uiButton.text;
        //}

        //showing = eView;
        //switch (showing)
        //{
        //    case "View Launcher":
        //        FollowCam.POI = null;
        //        uiButton.text = "Zoom Out";
        //        break;
        //    case "Zoom Out":
        //        FollowCam.POI
        //        uiButton.text = "View Launcher";
        //        break;
        //}

        FollowCam.POI = null;
    }

    public static void ShotFired()
    {
        S.shotsTaken++;
    }

    private void UpdateProjectiles()
    {
        switch (level)
        {
            case 0:
                Asteroids = 10;
                Comets = 5;                
                break;
            case 1:
                Asteroids = 2;
                Comets = 0;
                //asteroidCountText.text
                //cometCountText.text
                break;
            case 2:
                Asteroids = 2;
                Comets = 1;
                break;
            case 3:
                Asteroids = 5;
                Comets = 0;
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;
            case 11:
                break;
        }
        asteroidCountText.text = $"Asteroids Remaining: {Asteroids}";
        cometCountText.text = $"Comets Remaining: {Comets}";
    }
}
