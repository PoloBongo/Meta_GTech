using UnityEngine;

public class AITrap : MonoBehaviour
{
    [Header("SerializeField Trap")]
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject trapAIPrefab;
    [SerializeField] private RaycastingDetectionObject raycastingDetectionObject;
    
    [Header("Settings Trap")]
    [SerializeField] private float spawnDistanceToPlayer;
    [SerializeField] private int impulseForce;
    
    private Rigidbody rigidbody;
    
    public delegate void OnPutTrap();
    public static event OnPutTrap OnCanPutTrap;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        raycastingDetectionObject = GetComponent<RaycastingDetectionObject>();
        PlaceSingleTrap();
    }

    private void PlaceSingleTrap()
    {
        OnCanPutTrap?.Invoke();

        if (!raycastingDetectionObject.GetIsColliding())
        {
            Vector3 playerPos = player.transform.position;
            Vector3 playerDirection = player.transform.forward;
            float spawnDistance = spawnDistanceToPlayer;

            Vector3 spawnPos = playerPos + playerDirection * spawnDistance;
            Instantiate(trapAIPrefab, spawnPos, trapAIPrefab.transform.rotation);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Trap"))
        {
            rigidbody.AddForce(-transform.forward * impulseForce, ForceMode.Impulse);
        }
    }
}
