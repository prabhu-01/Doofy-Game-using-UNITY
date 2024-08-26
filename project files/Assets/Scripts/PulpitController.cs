using UnityEngine;

public class PulpitController : MonoBehaviour
{
    private void OnDestroy()
    {
        PulpitManager pulpitManager = FindObjectOfType<PulpitManager>();
        if (pulpitManager != null)
        {
            pulpitManager.RemovePulpit();
        }
        else
        {
            Debug.LogWarning("PulpitManager not found. Cannot remove pulpit.");
        }
    }
}
