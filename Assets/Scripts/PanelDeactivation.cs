using System.Collections;
using UnityEngine;

public class PanelDeactivation : MonoBehaviour
{
    public GameObject panel; // Reference to the panel GameObject

    void Start()
    {
        // Start the coroutine to deactivate the panel after 1 second
        StartCoroutine(DeactivatePanelAfterDelay());
    }

    IEnumerator DeactivatePanelAfterDelay()
    {
        // Wait for 1 second
        yield return new WaitForSeconds(1f);

        // Deactivate the panel
        panel.SetActive(false);
    }
}
