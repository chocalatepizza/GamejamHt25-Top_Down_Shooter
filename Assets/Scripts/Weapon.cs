using UnityEngine;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{
    [SerializeField] public AudioSource shotgunSoundEffect;

    //Crossbow
    public Transform crossbowFirePoint;
    public GameObject arrowPrefab;
    public float crossbowCooldown = 1f;
    private float lastArrowedFirerd = -Mathf.Infinity;


    //Shotgun

    public GameObject bulletPrefab;      // Assign your bullet prefab in the Inspector
    public Transform firePoint;          // Assign the fire point in the Inspector
    public int bulletCount = 9;          // Number of bullets to fire
    public float spreadAngle = 45f;      // Total spread angle in degrees
    public float shotgunFireCooldown = 1f;      // Cooldown in seconds
    private float lastShotgunFireTime = -Mathf.Infinity;



    //Laser beam wand
    public Transform laserbeamFirepoint;
    public GameObject laserbeamPrefab;
    public float laserbeamCooldown = 10f;
    private float lastLaserShoot = -Mathf.Infinity;

    //weapon keys
    KeyCode crossbowShoot = KeyCode.Mouse0;
    KeyCode shotgunShoot = KeyCode.None;
    KeyCode laserbeamShoot = KeyCode.None;

    //Animation
    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //weapon change
        
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            crossbowShoot = KeyCode.None;
            shotgunShoot = KeyCode.None;
            laserbeamShoot = KeyCode.Mouse0;
            animator.SetInteger("Weapon", 2);

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            crossbowShoot = KeyCode.None;
            shotgunShoot = KeyCode.Mouse0;
            laserbeamShoot = KeyCode.None;
            animator.SetInteger("Weapon", 1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            crossbowShoot = KeyCode.Mouse0;
            shotgunShoot = KeyCode.None;
            laserbeamShoot = KeyCode.None;
            animator.SetInteger("Weapon", 0);
        }

        //shooting
        if (Input.GetKeyDown(crossbowShoot) && Time.time >= lastArrowedFirerd + crossbowCooldown)
        {
            lastArrowedFirerd = Time.time;
            animator.SetTrigger("Shoot");
            CrossBowShoot();
        }

        if (Input.GetKeyDown(shotgunShoot) && Time.time >= lastShotgunFireTime + shotgunFireCooldown)
        {
            lastShotgunFireTime = Time.time;
            shotgunSoundEffect.Play();
            animator.SetTrigger("Shoot");
            ShootgunShoot();
        }

        if (Input.GetKeyDown(laserbeamShoot) && Time.time >= lastLaserShoot + laserbeamCooldown)
        {
            lastLaserShoot = Time.time;
            animator.SetTrigger("Shoot");
            LaserFire();
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



        for (int i = 0; i < bulletCount; i++ )
        {
            float angle = startAngle + i * angleStep;
            Quaternion rotation = Quaternion.Euler(0, 0, angle);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation * rotation);
        }

    }

    void LaserFire()
    {
        Instantiate(laserbeamPrefab, laserbeamFirepoint.position, laserbeamFirepoint.rotation);
    }
}
