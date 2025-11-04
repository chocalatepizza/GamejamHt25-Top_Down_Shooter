using UnityEngine;

public class Weapon : MonoBehaviour
{

    
    public Transform crossbowFirePoint;
    public GameObject arrowPrefab;

    public Transform ShotgunFirePoint1;
    public Transform ShotgunFirePoint2;
    public Transform ShotgunFirePoint3;
    public Transform ShotgunFirePoint4;
    public Transform ShotgunFirePoint5;
    public Transform ShotgunFirePoint6;
    public Transform ShotgunFirePoint7;
    public Transform ShotgunFirePoint8;
    public Transform ShotgunFirePoint9;

    public GameObject shotgunPrefab; 

    KeyCode crossbowShoot = KeyCode.Mouse0;
    KeyCode shotgunShoot = KeyCode.None;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //weapon change
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            crossbowShoot = KeyCode.None;
            shotgunShoot = KeyCode.Mouse0;

        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            crossbowShoot = KeyCode.Mouse0;
            shotgunShoot = KeyCode.None;
        }

        //shooting
        if (Input.GetKeyDown(crossbowShoot))
        {
            CrossBowShoot();
        }

        if (Input.GetKeyDown(shotgunShoot))
        {
            ShootgunShoot();
        }
    }

    void CrossBowShoot()
    {
        Instantiate(arrowPrefab, crossbowFirePoint.position, crossbowFirePoint.rotation);

    }

    void ShootgunShoot()
    {
        Instantiate(shotgunPrefab, ShotgunFirePoint1.position, ShotgunFirePoint1.rotation);
        Instantiate(shotgunPrefab, ShotgunFirePoint2.position, ShotgunFirePoint2.rotation);
        Instantiate(shotgunPrefab, ShotgunFirePoint3.position, ShotgunFirePoint3.rotation);
        Instantiate(shotgunPrefab, ShotgunFirePoint4.position, ShotgunFirePoint4.rotation);
        Instantiate(shotgunPrefab, ShotgunFirePoint5.position, ShotgunFirePoint5.rotation);
        Instantiate(shotgunPrefab, ShotgunFirePoint6.position, ShotgunFirePoint6.rotation);
        Instantiate(shotgunPrefab, ShotgunFirePoint7.position, ShotgunFirePoint7.rotation);
        Instantiate(shotgunPrefab, ShotgunFirePoint8.position, ShotgunFirePoint8.rotation);
        Instantiate(shotgunPrefab, ShotgunFirePoint9.position, ShotgunFirePoint9.rotation);
    }
}
