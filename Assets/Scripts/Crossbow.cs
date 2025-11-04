using UnityEngine;

public class Crossbow : MonoBehaviour
{

    
    public Transform firePoint;
    public GameObject arrowPrefab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);

    }
}
