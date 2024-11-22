using UnityEngine;
using TMPro;

using Dan.Main;

public class LeaderboardManager : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _entryTextObjects;
    [SerializeField] private TMP_InputField _usernameInputField;

// Make changes to this section according to how you're storing the player's score:
// ------------------------------------------------------------
    [SerializeField] private PlayerDistance _distance;
    
    private int Score => (int)_distance.GetDistance();
// ------------------------------------------------------------

    private void Start()
    {
        LoadEntries();
    }

    public void LoadEntries()
    {
        // Q: How do I reference my own leaderboard?
        // A: Leaderboards.<NameOfTheLeaderboard>
    
        Leaderboards.metaLeaderboard.GetEntries(entries =>
        {
            //1st
            _entryTextObjects[0].text = $"{entries[0].Rank}.";
            _entryTextObjects[1].text = $"{entries[1].Username} -";
            _entryTextObjects[2].text = $"{entries[2].Score}";
            
            //2nd
            _entryTextObjects[3].text = $"{entries[3].Rank}.";
            _entryTextObjects[4].text = $"{entries[4].Username} -";
            _entryTextObjects[5].text = $"{entries[5].Score}";
            
            //3rd
            _entryTextObjects[6].text = $"{entries[6].Rank}.";
            _entryTextObjects[7].text = $"{entries[7].Username} -";
            _entryTextObjects[8].text = $"{entries[8].Score}";
        });
    }
    
    public void UploadEntry()
    {
        Leaderboards.metaLeaderboard.UploadNewEntry(_usernameInputField.text, Score, isSuccessful =>
        {
            if (isSuccessful)
                LoadEntries();
        });
    }
}