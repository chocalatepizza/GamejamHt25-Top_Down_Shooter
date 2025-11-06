using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    [SerializeField] private string sceneToLoad = "NextScene"; // Set this in the Inspector

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Check if any enemies are still active
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            if (enemies.Length == 0)
            {
                // No enemies left — load the next scene
                SceneManager.LoadScene(sceneToLoad);
            }
            else
            {
                Debug.Log("You must defeat all enemies before entering the portal!");
            }
        }
    }
}
