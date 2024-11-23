using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AITrap : MonoBehaviour
{
    [Header("SerializeField Trap")]
    [SerializeField] private GameObject player;
    [SerializeField] private List<GameObject> trapAIPrefab;
    [SerializeField] private RaycastingDetectionObject raycastingDetectionObject;
    private List<GameObject> trapAIlist1 = new List<GameObject>();
    private List<GameObject> trapAIlist2 = new List<GameObject>();
    private List<GameObject> trapAIlist3 = new List<GameObject>();
    [SerializeField] private int numberOfTraps;
    
    [Header("Settings Trap")]
    [SerializeField] private float spawnDistanceToPlayer;
    [SerializeField] private float impulseForce;
    
    private Rigidbody rigidbody;
    private int listTrapCount;
    
    public delegate void OnPutTrap();
    public static event OnPutTrap OnCanPutTrap;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        //raycastingDetectionObject = GetComponent<RaycastingDetectionObject>();
        listTrapCount = trapAIPrefab.Count;
        SetupPools();
    }
    private void SetupPools()
    {
        trapAIlist1.Clear();
        trapAIlist2.Clear();
        trapAIlist3.Clear();
        for (int i = 0; i < numberOfTraps; i++)
        {
            GameObject trap = Instantiate(trapAIPrefab[0], transform);
            trapAIlist1.Add(trap);
            trap.SetActive(false);
        }
        for (int i = 0; i < numberOfTraps; i++)
        {
            GameObject trap = Instantiate(trapAIPrefab[1], transform);
            trapAIlist2.Add(trap);
            trap.SetActive(false);
        }
        for (int i = 0; i < numberOfTraps; i++)
        {
            GameObject trap = Instantiate(trapAIPrefab[2], transform);
            trapAIlist3.Add(trap);
            trap.SetActive(false);
        }
    }

    public GameObject GetFirstAvailableTrap(int whichTrap)
    {
        if (whichTrap == 0)
        {
            foreach (var trap in trapAIlist1)
            {
                if(trap.activeInHierarchy) continue;
                return trap;
            }

            for (int i = 0; i < numberOfTraps / 2; i++)
            {
                GameObject trap = Instantiate(trapAIPrefab[0], transform);
                trapAIlist1.Add(trap);
                trap.SetActive(false);
            }
            return trapAIlist1.Last();
        }

        if (whichTrap == 1)
        {
            foreach (var trap in trapAIlist2)
            {
                if(trap.activeInHierarchy) continue;
                return trap;
            }

            for (int i = 0; i < numberOfTraps / 2; i++)
            {
                GameObject trap = Instantiate(trapAIPrefab[1], transform);
                trapAIlist2.Add(trap);
                trap.SetActive(false);
            }
            return trapAIlist2.Last();
        }
        foreach (var trap in trapAIlist3)
        {
            if (trap.activeInHierarchy) continue;
            return trap;
        }

        for (int i = 0; i < numberOfTraps / 2; i++)
        {
            GameObject trap = Instantiate(trapAIPrefab[2], transform);
            trapAIlist3.Add(trap);
            trap.SetActive(false);
        }

        return trapAIlist3.Last();
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
            int newTrap = Random.Range(0, listTrapCount);
            GameObject trap = GetFirstAvailableTrap(newTrap);
            trap.transform.position = spawnPos;
            trap.SetActive(true);
        }
    }
    
    private void OnEnable()
    {
        GameManager.OnCanPutTrapOnMap += HandleReturnCanPutTrapOnMap;
    }

    private void OnDisable()
    {
        GameManager.OnCanPutTrapOnMap -= HandleReturnCanPutTrapOnMap;
    }

    private void HandleReturnCanPutTrapOnMap()
    {
        PlaceSingleTrap();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Trap"))
        {
            rigidbody.AddForce(-transform.forward * impulseForce, ForceMode.Impulse);
        }
    }
}
