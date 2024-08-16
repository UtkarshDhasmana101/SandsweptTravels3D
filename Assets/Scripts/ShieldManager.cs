using UnityEngine;

public class ShieldManager : MonoBehaviour
{
    public static ShieldManager Instance;

    
    public bool IsShieldActive { get; set; }

    private void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
