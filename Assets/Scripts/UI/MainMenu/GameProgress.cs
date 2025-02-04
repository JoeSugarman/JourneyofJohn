using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class GameProgress : MonoBehaviour
{
    public static GameProgress Instance { get; private set; }
    private Dictionary<int, bool> unlockedLevels = new Dictionary<int, bool>();


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadProgress();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadProgress()
    {
        string json = PlayerPrefs.GetString("UnlockedLevels", "{}"); 
        unlockedLevels = JsonUtility.FromJson<LevelData>(json)?.ToDictionary() ?? new Dictionary<int, bool>();

        
        if (!unlockedLevels.ContainsKey(1))
        {
            unlockedLevels[1] = true;
        }
    }

    public void UnlockLevel(int level)
    {
        if (!unlockedLevels.ContainsKey(level))
        {
            unlockedLevels[level] = true;
            SaveProgress();
        }
    }

    public bool IsLevelUnlocked(int level)
    {
        return unlockedLevels.ContainsKey(level) && unlockedLevels[level];
    }

    private void SaveProgress()
    {
        string json = JsonUtility.ToJson(new LevelData(unlockedLevels));
        PlayerPrefs.SetString("UnlockedLevels", json);
        PlayerPrefs.Save();
    }

    [System.Serializable]
    private class LevelData
    {
        public List<int> keys;
        public List<bool> values;

        public LevelData(Dictionary<int, bool> dict)
        {
            keys = dict.Keys.ToList();
            values = dict.Values.ToList();
        }

        public Dictionary<int, bool> ToDictionary()
        {
            Dictionary<int, bool> dict = new Dictionary<int, bool>();
            for (int i = 0; i < keys.Count; i++)
            {
                dict[keys[i]] = values[i];
            }
            return dict;
        }
    }
}
