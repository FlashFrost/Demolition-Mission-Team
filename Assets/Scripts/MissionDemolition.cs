using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
        level = PlayerPrefs.GetInt("Level", 0) - 1;
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

        levelCreation = Instantiate<GameObject>(levels[level]); //Instantiates a level.
        //moon.transform.position = castlePos;
        shotsTaken = 0;

        SwitchView("Show Both");
        ProjectileLine.S.Clear();

        Goal.goalMet = false;

        UpdateGUI();
        mode = GameMode.playing;
    }

    void UpdateGUI()
    {
        uiLevel.text = "Level: " + (level + 1) + " of " + levelMax;
        uiShots.text = "Shots Taken: " + shotsTaken;
    }

    private void Update()
    {
        UpdateGUI();
        if ((mode == GameMode.playing) && Goal.goalMet)
        {
            mode = GameMode.levelEnd;
            SwitchView("Show Both");
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
            case "Zoom In":
                FollowCam.POI = null;
                uiButton.text = "Zoom Out";
                break;
            case "Zoom Out":
                FollowCam.POI = S.moon;
                uiButton.text = "Zoom In";
                break;
        }
    }

    public static void ShotFired()
    {
        S.shotsTaken++;
    }
}
