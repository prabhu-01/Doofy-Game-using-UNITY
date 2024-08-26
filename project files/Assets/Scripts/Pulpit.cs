using UnityEngine;

public class Pulpit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to Doofus
        if (other.CompareTag("Doofus"))
        {
            // Increase the score when Doofus touches the Pulpit
            ScoreManager.Instance.AddScore(1);

            // Optionally, destroy the Pulpit after scoring
            Destroy(gameObject);
        }
    }
}
