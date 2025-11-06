using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Movement
    [SerializeField] KeyCode left = KeyCode.LeftArrow;
    [SerializeField] KeyCode right = KeyCode.RightArrow;
    [SerializeField] KeyCode up = KeyCode.UpArrow;
    [SerializeField] KeyCode down = KeyCode.DownArrow;
    [SerializeField] KeyCode shift = KeyCode.LeftShift;
    float speed = 6f;
    //Behövde ändra speed annars exploderade unity, sorry -Charlie

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //movement
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
            speed = 9f;
        }
        else
        { speed = 6f; }

            //rotation
            Vector3 mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            Vector2 dir = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);

            transform.up = dir;




        }
    }

