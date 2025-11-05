using UnityEngine;

public class Weapon : MonoBehaviour
{

    //Crossbow
    public Transform crossbowFirePoint;

    public GameObject arrowPrefab;

    [SerializeField] float crossbowCooldown;

    //Shotgun

    public GameObject bulletPrefab;      // Assign your bullet prefab in the Inspector
    public Transform firePoint;          // Assign the fire point in the Inspector
    public int bulletCount = 9;          // Number of bullets to fire
    public float spreadAngle = 45f;      // Total spread angle in degrees
    public float shotgunFireCooldown = 1f;      // Cooldown in seconds
    private float LastFireTime = -Mathf.Infinity;


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
            LastFireTime = Time.time;

        }
    }

    void CrossBowShoot()
    {
        Instantiate(arrowPrefab, crossbowFirePoint.position, crossbowFirePoint.rotation);

    }

    void ShootgunShoot()
    {
        float angleStep = spreadAngle / (bulletCount - 1);
        float startAngle = -spreadAngle / 2;

        for (int i = 0; i < bulletCount; i++)
        {
            float angle = startAngle + i * angleStep;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * rotation);
        }

    }
}
