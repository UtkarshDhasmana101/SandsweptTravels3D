using UnityEngine;

public class AnimationControl : MonoBehaviour
{
    [SerializeField] Animator animController;

    private bool isJumping = false;

    void Update()
    {
        if (!isJumping && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            animController.SetBool("Jump", true);
        }
    }

    // Called by an animation event when the jump animation finishes
    public void EndJump()
    {
        isJumping = false;
        animController.SetBool("Jump", false); // Reset the jump parameter
    }
}
