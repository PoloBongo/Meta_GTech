using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Map;
using System.Linq;

public class ChunkLoader : MonoBehaviour
{
    public GameObject player;
    public ChunkHandler chunkHandler;
    private List<GameObject> chunksList = new List<GameObject>();
    public float chunkSize = 7.5f;
    private int renderDistance = 5;

    void Start()
    {
        chunkHandler = GetComponent<ChunkHandler>();

        if (chunkHandler.chunksList.Count > 0)
        {
            for (int i = 0; i < renderDistance; i++)
            {
                GameObject chunk = chunkHandler.GetAvailableChunk();
                chunk.transform.position = new Vector3(0, -2, i * chunkSize);
                chunk.SetActive(true);
                chunksList.Add(chunk);
            }
        }
    }

    void Update()
    {
        LoadChunks();
    }

    private void LoadChunks()
    {
        if (chunkHandler.chunksList.Count == 0) return;

        GameObject lastChunk = chunksList.Last();
        GameObject firstChunk = chunksList.First();

        if (player.transform.position.z > lastChunk.transform.position.z - (chunkSize * (renderDistance - 2)))
        {
            GameObject newChunk = chunkHandler.GetAvailableChunk();
            
            newChunk.transform.position = new Vector3(0, -2, lastChunk.transform.position.z + chunkSize);
            newChunk.SetActive(true);
            chunksList.Add(newChunk);
        }
        if (player.transform.position.z > firstChunk.transform.position.z + (chunkSize * 1.5))
        {
            firstChunk.SetActive(false);
            chunksList.Remove(firstChunk);
        }
    }
}