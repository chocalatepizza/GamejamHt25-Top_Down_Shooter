using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{  //Movement
    [SerializeField] KeyCode left = KeyCode.LeftArrow;
    [SerializeField] KeyCode right = KeyCode.RightArrow;
    [SerializeField] KeyCode up = KeyCode.UpArrow;
    [SerializeField] KeyCode down = KeyCode.DownArrow;
    [SerializeField] KeyCode shift = KeyCode.LeftShift;
    [SerializeField] KeyCode space = KeyCode.Space;

    float speed = 6f;
    bool canDash = true;
    bool isDashing = false;
    float dashTimer = 0;
    //Behövde ändra speed annars exploderade unity, sorry -Charlie

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //movement
        if (isDashing != true)
        {
            if (Input.GetKey(left))
            {
                transform.position -= new Vector3(1, 0, 0) * speed * Time.deltaTime;
            }

            if (Input.GetKey(right))
            {
                transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
            }

            if (Input.GetKey(up))
            {
                transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime;
            }

            if (Input.GetKey(down))
            {
                transform.position -= new Vector3(0, 1, 0) * speed * Time.deltaTime;
            }
            //spring
            if (Input.GetKey(shift))
            {
                speed = 10f;
            }
            else
            { speed = 5f; }

            if (Input.GetKey(space) && (canDash = true))
            {
                isDashing = true;
                canDash = false;
            }
        }
        if (isDashing == true)
        {
            



        }



    //rotation
    Vector3 mousePos = Input.mousePosition;
    mousePos = Camera.main.ScreenToWorldPoint(mousePos);

    Vector2 dir = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
    transform.up = dir;
    }
}


