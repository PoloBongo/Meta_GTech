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
                chunk.transform.position = new Vector3(i * chunkSize, -2, 0);
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

        if (player.transform.position.x > lastChunk.transform.position.x - (chunkSize * (renderDistance - 2)))
        {
            GameObject newChunk = chunkHandler.GetAvailableChunk();
            
            newChunk.transform.position = new Vector3(lastChunk.transform.position.x + chunkSize, -2, 0);
            newChunk.SetActive(true);
            chunksList.Add(newChunk);
        }
        if (player.transform.position.x > firstChunk.transform.position.x + (chunkSize * 2))
        {
            firstChunk.SetActive(false);
            chunksList.Remove(firstChunk);
        }
    }
}