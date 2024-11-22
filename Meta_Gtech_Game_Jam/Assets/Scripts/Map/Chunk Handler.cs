using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Map
{
    public class ChunkHandler : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject[] chunkPrefabs;
        
        public List<GameObject> chunksList = new List<GameObject>();
        private const int ChunkAmount = 10;
        private List<int> availablePrefabIndices = new List<int>();

        void Start()
        {
            SetupChunks();
        }

        private void SetupChunks()
        {
            chunksList.Clear();
            availablePrefabIndices = Enumerable.Range(0, chunkPrefabs.Length).ToList();
            ShuffleIndices();

            for (int i = 0; i < ChunkAmount; i++)
            {
                GameObject chunk = Instantiate(chunkPrefabs[GetRandomPrefabIndex()], transform);
                chunksList.Add(chunk);
                chunk.SetActive(false);
            }
        }

        private int GetRandomPrefabIndex()
        {
            if (availablePrefabIndices.Count == 0)
            {
                availablePrefabIndices = Enumerable.Range(0, chunkPrefabs.Length).ToList();
                ShuffleIndices();
            }

            int randomIndex = availablePrefabIndices[0];
            availablePrefabIndices.RemoveAt(0);
            return randomIndex;
        }

        private void ShuffleIndices()
        {
            for (int i = 0; i < availablePrefabIndices.Count; i++)
            {
                int temp = availablePrefabIndices[i];
                int randomIndex = Random.Range(i, availablePrefabIndices.Count);
                availablePrefabIndices[i] = availablePrefabIndices[randomIndex];
                availablePrefabIndices[randomIndex] = temp;
            }
        }

        public GameObject GetAvailableChunk()
        {
            foreach (var chunk in chunksList)
            {
                if (chunk.activeInHierarchy) continue;
                return chunk;
            }

            for (int i = 0; i < ChunkAmount; i++)
            {
                GameObject chunk = Instantiate(chunkPrefabs[GetRandomPrefabIndex()], transform);
                chunksList.Add(chunk);
                chunk.SetActive(false);
            }

            return chunksList.Last();
        }
    }
}
