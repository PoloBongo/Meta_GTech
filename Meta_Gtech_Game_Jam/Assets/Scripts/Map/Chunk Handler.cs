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

        void Start()
        {
            SetupChunks();
        }

        private void SetupChunks()
        {
            
            chunksList.Clear();
            for (int i = 0; i < ChunkAmount; i++)
            {
                GameObject chunk = Instantiate(chunkPrefabs[0], transform);
                chunksList.Add(chunk);
                chunk.SetActive(false);
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
                GameObject chunk = Instantiate(chunkPrefabs[0], transform);
                chunksList.Add(chunk);
                chunk.SetActive(false);
            }

            return chunksList.Last();
        }
        
        public void MoveChunkToFront(GameObject chunk)
        {
            chunk.transform.position = new Vector3(0, -2, player.transform.position.z + ChunkAmount * 7.5f);
            chunk.SetActive(true);
        }
        
    }
}
