using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Map
{
    public class ChunkHandler : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        [SerializeField] public GameObject[] chunkPrefabsMain;
        [SerializeField] public GameObject[] chunkPrefabsBorderR;
        [SerializeField] public GameObject[] chunkPrefabsBorderL;

        public List<GameObject> chunksListMain = new List<GameObject>();
        public List<GameObject> chunksListBorderR = new List<GameObject>();
        public List<GameObject> chunksListBorderL = new List<GameObject>();
        private const int ChunkAmount = 10;
        public List<int> availablePrefabIndicesMain = new List<int>();
        public List<int> availablePrefabIndicesBorderR = new List<int>();
        public List<int> availablePrefabIndicesBorderL = new List<int>();
        
        [Header("Light Settings")]
        [SerializeField] private LightManager lightManager;

        void Start()
        {
            SetupChunks();
        }

        private void SetupChunks()
        {
            if (lightManager.GetStateLight())
            {
                lightManager.TurnOnAllLights();
            }
            else
            {
                lightManager.TurnOffAllLights();
            }
            chunksListMain.Clear();
            chunksListBorderR.Clear();
            chunksListBorderL.Clear();

            availablePrefabIndicesMain = Enumerable.Range(0, chunkPrefabsMain.Length).ToList();
            availablePrefabIndicesBorderR = Enumerable.Range(0, chunkPrefabsBorderR.Length).ToList();
            availablePrefabIndicesBorderL = Enumerable.Range(0, chunkPrefabsBorderL.Length).ToList();

            availablePrefabIndicesMain = ShuffleIndices(availablePrefabIndicesMain);
            availablePrefabIndicesBorderR = ShuffleIndices(availablePrefabIndicesBorderR);
            availablePrefabIndicesBorderL = ShuffleIndices(availablePrefabIndicesBorderL);

            for (int i = 0; i < ChunkAmount; i++)
            {
                GameObject chunk = Instantiate(GetRandomPrefabForSide("Main"), transform);
                chunksListMain.Add(chunk);
                chunk.SetActive(false);

                chunk = Instantiate(GetRandomPrefabForSide("Right"), transform);
                chunksListBorderR.Add(chunk);
                chunk.SetActive(false);

                chunk = Instantiate(GetRandomPrefabForSide("Left"), transform);
                chunksListBorderL.Add(chunk);
                chunk.SetActive(false);
            }
            
        }

        private int GetRandomPrefabIndex(List<int> availableIndices, GameObject[] chunkPrefabs)
        {
            // Refill the available indices if empty
            if (availableIndices.Count == 0)
            {
                availableIndices = Enumerable.Range(0, chunkPrefabs.Length).ToList();
                availableIndices = ShuffleIndices(availableIndices);
            }

            int randomIndex = availableIndices[0];
            availableIndices.RemoveAt(0);
            return randomIndex;
        }

        private GameObject GetRandomPrefabForSide(string side)
        {
            GameObject chunkPrefab = null;

            switch (side)
            {
                case "Main":
                    int mainIndex = GetRandomPrefabIndex(availablePrefabIndicesMain, chunkPrefabsMain);
                    if (mainIndex == -1) return null;  // Handle error
                    chunkPrefab = chunkPrefabsMain[mainIndex];
                    break;
                case "Right":
                    int rightIndex = GetRandomPrefabIndex(availablePrefabIndicesBorderR, chunkPrefabsBorderR);
                    if (rightIndex == -1) return null;  // Handle error
                    chunkPrefab = chunkPrefabsBorderR[rightIndex];
                    break;
                case "Left":
                    int leftIndex = GetRandomPrefabIndex(availablePrefabIndicesBorderL, chunkPrefabsBorderL);
                    if (leftIndex == -1) return null;  // Handle error
                    chunkPrefab = chunkPrefabsBorderL[leftIndex];
                    break;
            }

            return chunkPrefab;
        }

        private List<int> ShuffleIndices(List<int> availableIndices)
        {
            if (availableIndices.Count == 0)
            {
                Debug.Log("No available indices to shuffle");
                return availableIndices;
            }
            
            for (int i = 0; i < availableIndices.Count; i++)
            {
                int temp = availableIndices[i];
                int randomIndex = Random.Range(i, availableIndices.Count);
                availableIndices[i] = availableIndices[randomIndex];
                availableIndices[randomIndex] = temp;
            }
            return availableIndices;
        }

        public GameObject GetAvailableChunk(GameObject[] chunkPrefab, List<GameObject> chunkList, List<int> availableIndices)
        {
            // Check for inactive chunks in the list
            foreach (var chunk in chunkList)
            {
                if (!chunk.activeInHierarchy) return chunk;
            }

            // If all chunks are active, instantiate a new one
            for (int i = 0; i < ChunkAmount; i++)
            {
                GameObject chunk = Instantiate(chunkPrefab[GetRandomPrefabIndex(availableIndices, chunkPrefab)], transform);
                chunkList.Add(chunk);
                chunk.SetActive(false);
            }

            return chunkList.Last();
        }
    }
}
