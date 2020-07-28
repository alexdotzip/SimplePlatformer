using UnityEngine;

public class DestroyOverTime : MonoBehaviour
{

    [Header("Lifetime")]
    [SerializeField] private float lifetime;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        Destroy(gameObject, lifetime);
    }
}
