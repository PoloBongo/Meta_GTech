using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Sauvegarde : MonoBehaviour
{
    private string filePath;

    private class ScoreData
    {
        public float score;
    }

    private void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, "scoreData.json");

        if (IsFileCreated())
        {
            LoadScore();
        }
        else
        {
            Debug.Log("Aucun fichier trouvé. Le fichier sera créé lors de la sauvegarde.");
        }

        print(LoadScore());
    }

    public void SaveScore(float newScore)
    {
        ScoreData data = new ScoreData
        {
            score = newScore
        };

        string jsonData = JsonUtility.ToJson(data, true);

        File.WriteAllText(filePath, jsonData);

        Debug.Log($"Score sauvegardé : {newScore}");
    }

    public float LoadScore()
    {
        if (IsFileCreated())
        {
            string jsonData = File.ReadAllText(filePath);

            ScoreData data = JsonUtility.FromJson<ScoreData>(jsonData);

            Debug.Log($"Score chargé : {data.score}");
            return data.score;
        }
        else
        {
            Debug.LogWarning("Tentative de chargement d'un fichier inexistant.");
            return 0;
        }
    }

    private bool IsFileCreated()
    {
        return File.Exists(filePath);
    }
}
