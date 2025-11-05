using UnityEngine;

public class Weapon : MonoBehaviour
{

    //Crossbow
    public Transform crossbowFirePoint;

    public GameObject arrowPrefab;

    [SerializeField] float crossbowCooldown;

    //Shotgun
    public Transform shotgunFirePoint1;
    public Transform shotgunFirePoint2;
    public Transform shotgunFirePoint3;
    public Transform shotgunFirePoint4;
    public Transform shotgunFirePoint5;
    public Transform shotgunFirePoint6;
    public Transform shotgunFirePoint7;
    public Transform shotgunFirePoint8;
    public Transform shotgunFirePoint9;

    public GameObject shotgunPrefab;

    [SerializeField] float shotgunCooldown;

    //Laser beam wand
    public Transform laserbeamFirepoint;

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
        Instantiate(shotgunPrefab, shotgunFirePoint1.position, shotgunFirePoint1.rotation);
        Instantiate(shotgunPrefab, shotgunFirePoint2.position, shotgunFirePoint2.rotation);
        Instantiate(shotgunPrefab, shotgunFirePoint3.position, shotgunFirePoint3.rotation);
        Instantiate(shotgunPrefab, shotgunFirePoint4.position, shotgunFirePoint4.rotation);
        Instantiate(shotgunPrefab, shotgunFirePoint5.position, shotgunFirePoint5.rotation);
        Instantiate(shotgunPrefab, shotgunFirePoint6.position, shotgunFirePoint6.rotation);
        Instantiate(shotgunPrefab, shotgunFirePoint7.position, shotgunFirePoint7.rotation);
        Instantiate(shotgunPrefab, shotgunFirePoint8.position, shotgunFirePoint8.rotation);
        Instantiate(shotgunPrefab, shotgunFirePoint9.position, shotgunFirePoint9.rotation);
    }
}
