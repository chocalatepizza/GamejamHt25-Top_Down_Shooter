using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{  //Movement
    [SerializeField] KeyCode left = KeyCode.LeftArrow;
    [SerializeField] KeyCode right = KeyCode.RightArrow;
    [SerializeField] KeyCode up = KeyCode.UpArrow;
    [SerializeField] KeyCode down = KeyCode.DownArrow;
    [SerializeField] KeyCode dash = KeyCode.Space;
    float speed = 6f;
    bool canDash = true;
    bool isDashing = false;
    float dashTimer = 0;
    float dashCooldown = 0;
    float dirTimer = 0;
    Vector3 dashDir = new Vector3();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        //movement
        if (isDashing == false)
        {
            if (Input.GetKey(left))
            {transform.position -= new Vector3(1, 0, 0) * speed * Time.deltaTime;}
            if (Input.GetKey(right))
            {transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;}
            if (Input.GetKey(up))
            { transform.position += new Vector3(0, 1, 0) * speed * Time.deltaTime; }
            if (Input.GetKey(down))
            {transform.position -= new Vector3(0, 1, 0) * speed * Time.deltaTime;}
            
            if (Input.GetKey(dash) && (canDash = true))
            {
                isDashing = true;
                canDash = false;
                dashCooldown = 0;
                dashTimer= 0;
                dirTimer = 0;
            }
        }

        if (Input.GetKey(left) && (dirTimer < 0.05f))
        {dashDir = new Vector3(-3, 0, 0);}
        if (Input.GetKey(right) && (dirTimer < 0.05f))
        {dashDir = new Vector3(3, 0, 0);}
        if (Input.GetKey(up) && (dirTimer < 0.05f))
        {dashDir = new Vector3(0, 3, 0);}
        if (Input.GetKey(down) && (dirTimer < 0.05f))
        {dashDir = new Vector3(0, -3, 0);}
        //diagonals
        if (Input.GetKey(left) && (Input.GetKey(up) && (dirTimer < 0.05f)))
        { dashDir = new Vector3(-3, 3, 0); }
        if (Input.GetKey(right) && (Input.GetKey(up) && (dirTimer < 0.05f)))
        { dashDir = new Vector3(3, 3, 0); }
        if(Input.GetKey(left) && (Input.GetKey(down) && (dirTimer < 0.05f)))
        { dashDir = new Vector3(-3, -3, 0); }
if (Input.GetKey(right) && (Input.GetKey(down) && (dirTimer < 0.05f)))
        { dashDir = new Vector3(3, -3, 0); }

        if (isDashing == true)
        {
            dashTimer += Time.deltaTime;
            dirTimer += Time.deltaTime;
            transform.position += dashDir * speed * Time.deltaTime;
        }
        if (dashTimer >= 0.3)
        {
            isDashing = false;
            canDash = false;
            dashCooldown = 0;
        }
        
        if (dashCooldown < 2)
        {dashCooldown += Time.deltaTime; }

        if (dashCooldown >= 1)
        {canDash = true;}

        //rotation
        Vector3 mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector2 dir = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y);
        transform.up = dir;

    }
}