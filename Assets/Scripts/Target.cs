using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Target : MonoBehaviour
{
    
    public string color;
    /// <summary>
    /// Rigidbody del objetivo.
    /// </summary>
    private Rigidbody targetRigidbody;

    /// <summary>
    /// Accesor del rigidbody. Se puede usar desde otras clases.
    /// </summary>
    public Rigidbody TargetRigidbody { get => targetRigidbody; }

    private void Start()
    {
        targetRigidbody = GetComponent<Rigidbody>();
    }
}