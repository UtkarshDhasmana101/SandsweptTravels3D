using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AliveUIPanel : MonoBehaviour
{
    public RectTransform panelTransform; // Reference to the RectTransform of the panel
    public float scaleAmount = 1.2f; // Amount to scale the panel by
    public float animationDuration = 1f; // Duration of each animation cycle

    private Vector3 originalScale; // Original scale of the panel
    private bool isAnimating = false; // Flag to check if an animation is already in progress

    void Start()
    {
        // Get the original scale of the panel
        originalScale = panelTransform.localScale;

        // Start the animation coroutine
        StartCoroutine(AnimatePanel());
    }

    IEnumerator AnimatePanel()
    {
        while (true)
        {
            if (!isAnimating)
            {
                // Scale up
                yield return StartCoroutine(ScalePanel(originalScale * scaleAmount, animationDuration / 2f));

                // Scale down
                yield return StartCoroutine(ScalePanel(originalScale, animationDuration / 2f));
            }
            yield return null;
        }
    }

    IEnumerator ScalePanel(Vector3 targetScale, float duration)
    {
        isAnimating = true;

        float timer = 0f;
        Vector3 originalScale = panelTransform.localScale;

        while (timer < duration)
        {
            panelTransform.localScale = Vector3.Lerp(originalScale, targetScale, timer / duration);
            timer += Time.deltaTime;
            yield return null;
        }

        panelTransform.localScale = targetScale;

        isAnimating = false;
    }
}
