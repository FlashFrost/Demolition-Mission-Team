using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Slingshot : MonoBehaviour
{
    static private Slingshot S;

    [Header("Set In Inspector")]
    public GameObject prefabProjectile;
    public GameObject prefabCometProjectile;
    public float velocityMult = 8f;
    public TextMeshProUGUI projectileType;
    public int Asteroids;
    public int Comets;
    public TextMeshProUGUI asteroidCount;
    public TextMeshProUGUI cometCount;
    public GameObject outOfAmmoVoidbox;

    [Header("Set Dynamically")]
    private Rigidbody projectileRigidbody;
    public GameObject launchPoint;
    public Vector3 launchPos;
    static private bool shootComet;

    static public Vector3 LAUNCH_POS
    {
        get 
        { 
            if(S == null)
            {
                return Vector3.zero;
            }
            return S.launchPos;
        }
    }
    public GameObject projectile;
    public bool aimingMode;

    // Start is called before the first frame update
    void Start()
    {
        shootComet = false;
    }

    private void Awake()
    {
        S = this;
        Transform launchPointTrans = transform.Find("LaunchPoint");
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false);
        launchPos = launchPointTrans.position;
    }

    private void OnMouseEnter()
    {
        //print("Slingshot:OnMouseEnter()");
        launchPoint.SetActive(true);
    }

    private void OnMouseExit()
    {
        launchPoint.SetActive(false);
        //print("Slingshot:OnMouseExit()");
    }

    private void OnMouseDown()
    {
        aimingMode = true;
        if (shootComet == false)
        {
            if (Asteroids == 0)
            {
                //Insert something happening because you are out of basic shots.
            }
            else
            {
                projectile = Instantiate(prefabProjectile) as GameObject;
                Asteroids--;
                asteroidCount.text = ("Asteroids Remaining: " + Asteroids);
            }
        }
        else
        {
            if (Comets == 0)
            {
                //Insert something happening because you are out of comet shots.
            }
            else
            {
                projectile = Instantiate(prefabCometProjectile) as GameObject;
                Comets--;
                cometCount.text = ("Comets Remaining: " + Comets);
            }
        }
        projectile.transform.position = launchPos;
        projectile.GetComponent<Rigidbody>().isKinematic = true;
        projectileRigidbody = projectile.GetComponent<Rigidbody>();
        projectileRigidbody.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!aimingMode)
            return;

        Vector3 mousePos2d = Input.mousePosition;
        mousePos2d.z = -Camera.main.transform.position.z;
        Vector3 mousePos3d = Camera.main.ScreenToWorldPoint(mousePos2d);

        Vector3 mouseDelta = mousePos3d - launchPos;

        float maxMagnitude = this.GetComponent<SphereCollider>().radius;
        if(mouseDelta.magnitude > maxMagnitude)
        {
            mouseDelta.Normalize();
            mouseDelta *= maxMagnitude;
        }

        Vector3 projPos = launchPos + mouseDelta;
        projectile.transform.position = projPos;
        if(Input.GetMouseButtonUp(0))
        {
            aimingMode = false;
            projectileRigidbody.isKinematic = false;
            projectileRigidbody.velocity = -mouseDelta * velocityMult;
            FollowCam.POI = projectile;
            projectile = null;
            MissionDemolition.ShotFired();
            ProjectileLine.S.poi = projectile;
        }
    }

    public void ChangeProjectile()
    {
        if(shootComet == true)
        {
            shootComet = false;
            projectileType.text = "Currently Shooting: Asteroid";
        }
        else
        {
            shootComet = true;
            projectileType.text = "Currently Shooting: Comet";
        }
    }
}
