using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Map;
using System.Linq;

public class ChunkLoader : MonoBehaviour
{
    public GameObject player;
    public ChunkHandler chunkHandler;
            
    public List<GameObject> chunksListMain = new List<GameObject>();
    public List<GameObject> chunksListBorderR = new List<GameObject>();
    public List<GameObject> chunksListBorderL = new List<GameObject>();
    
    public int chunkSize = 15;
    private int renderDistance = 5;

    void Start()
    {
        chunkHandler = GetComponent<ChunkHandler>();

        if (chunkHandler.chunksListMain.Count > 0 && chunkHandler.chunksListBorderR.Count > 0 && chunkHandler.chunksListBorderL.Count > 0)
        {
            for (int i = 0; i < renderDistance; i++)
            {
                GameObject chunkMain = chunkHandler.GetAvailableChunk(chunkHandler.chunkPrefabsMain, chunkHandler.chunksListMain, chunkHandler.availablePrefabIndicesMain);
                chunkMain.transform.position = new Vector3(chunkSize * i, -3, 0);
                chunkMain.SetActive(true);
                chunksListMain.Add(chunkMain);

                GameObject chunkRight = chunkHandler.GetAvailableChunk(chunkHandler.chunkPrefabsBorderR, chunkHandler.chunksListBorderR, chunkHandler.availablePrefabIndicesBorderR);
                chunkRight.transform.position = new Vector3(chunkSize * i, -3, chunkSize);
                chunkRight.SetActive(true);
                chunksListBorderR.Add(chunkRight);

                GameObject chunkLeft = chunkHandler.GetAvailableChunk(chunkHandler.chunkPrefabsBorderL, chunkHandler.chunksListBorderL, chunkHandler.availablePrefabIndicesBorderL);
                chunkLeft.transform.position = new Vector3(chunkSize * i, -3, -chunkSize);
                chunkLeft.SetActive(true);
                chunksListBorderL.Add(chunkLeft);
            }
        }
    }

    void Update()
    {
        LoadChunks(true, false, false);
        LoadChunks(false, true, false);
        LoadChunks(false, false, true);
    }

    private void LoadChunks(bool main, bool right, bool left)
    {
        if (main)
        {
            LoadMainChunks();
        }
        if (right)
        {
            LoadRightChunks();
        }
        if (left)
        {
            LoadLeftChunks();
        }
    }
    
    private void LoadMainChunks()
    {
        if (chunkHandler.chunksListMain.Count == 0) return;

        GameObject lastChunk = chunksListMain.Last();
        GameObject firstChunk = chunksListMain.First();

        if (player.transform.position.x > lastChunk.transform.position.x - (chunkSize * (renderDistance - 2)))
        {
            GameObject newChunkMain = chunkHandler.GetAvailableChunk(chunkHandler.chunkPrefabsMain, chunkHandler.chunksListMain, chunkHandler.availablePrefabIndicesMain);
            newChunkMain.transform.position = new Vector3(lastChunk.transform.position.x + chunkSize, -3, 0);
            newChunkMain.SetActive(true);
            chunksListMain.Add(newChunkMain);
        }
        if (player.transform.position.x > firstChunk.transform.position.x + (chunkSize * 2))
        {
            firstChunk.SetActive(false);
            chunksListMain.Remove(firstChunk);
        }
    }
    
    private void LoadRightChunks()
    {
        if (chunkHandler.chunksListBorderR.Count == 0) return;

        GameObject lastChunk = chunksListBorderR.Last();
        GameObject firstChunk = chunksListBorderR.First();

        if (player.transform.position.x > lastChunk.transform.position.x - (chunkSize * (renderDistance - 2)))
        {
            GameObject newChunkRight = chunkHandler.GetAvailableChunk(chunkHandler.chunkPrefabsBorderR, chunkHandler.chunksListBorderR, chunkHandler.availablePrefabIndicesBorderR);
            newChunkRight.transform.position = new Vector3(lastChunk.transform.position.x + chunkSize, -3, chunkSize);
            newChunkRight.SetActive(true);
            chunksListBorderR.Add(newChunkRight);
        }
        if (player.transform.position.x > firstChunk.transform.position.x + (chunkSize * 2))
        {
            firstChunk.SetActive(false);
            chunksListBorderR.Remove(firstChunk);
        }
    }
    
    private void LoadLeftChunks()
    {
        if (chunkHandler.chunksListBorderL.Count == 0) return;

        GameObject lastChunk = chunksListBorderL.Last();
        GameObject firstChunk = chunksListBorderL.First();

        if (player.transform.position.x > lastChunk.transform.position.x - (chunkSize * (renderDistance - 2)))
        {
            GameObject newChunkLeft = chunkHandler.GetAvailableChunk(chunkHandler.chunkPrefabsBorderL, chunkHandler.chunksListBorderL, chunkHandler.availablePrefabIndicesBorderL);
            newChunkLeft.transform.position = new Vector3(lastChunk.transform.position.x + chunkSize, -3, -chunkSize);
            newChunkLeft.SetActive(true);
            chunksListBorderL.Add(newChunkLeft);
        }
        if (player.transform.position.x > firstChunk.transform.position.x + (chunkSize * 2))
        {
            firstChunk.SetActive(false);
            chunksListBorderL.Remove(firstChunk);
        }
    }
}
