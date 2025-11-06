using UnityEngine;

public class NextRoom : MonoBehaviour
{
    public Vector3 playerMove = new Vector3(35f, 0f, 0f); // How far to move the player
    public Vector3 cameraMove = new Vector3(35f, 0f, 0f); // How far to move the camera

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Moves the player
            other.transform.position += playerMove;

            // Moves the main camera
            Camera.main.transform.position += cameraMove;
        }
    }

}
