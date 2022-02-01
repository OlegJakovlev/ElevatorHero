using System.IO;
using Components.Score;
using SaveAndLoadSystem.HighScore;
using UnityEngine;

namespace SaveAndLoadSystem
{
    [RequireComponent(typeof(ScoreSetup))]
    public class Serializer : MonoBehaviour
    {
        public static Serializer SaveLoadManager
        {
            get
            {
                if (_instance == null)
                    _instance = FindObjectOfType(typeof(Serializer)) as Serializer;
 
                return _instance;
            }
            
            private set => _instance = _instance == null ? value : null;
        }
        
        private static Serializer _instance;

        // Object to get/set data
        private GameData _data;
        private GameData _copiedData;
        
        // Name of save file & encryption settings
        private const string SaveFile = "player.dat";
        private const string IvKey = "4437772310107691";
        private const string EncryptionKey = "aPdSgVkYp3s6v9y$B&E)H@MbQeThWmZq";

        // AES object to encrypt/decrypt data
        private AES _crypto;

        private void Awake()
        {
            SaveLoadManager = this;

            _crypto = new AES(EncryptionKey, IvKey);
            _data = new GameData();

            Load();
        }

        public void Save(string playerName = "Jimmy")
        {
            // Get all needed to save data
            _data.CollectDataToSave(playerName, HighScoreManager.Instance.NewHighScore);

            // Convert data to json
            string json = JsonUtility.ToJson(_data);

            // Encrypt data
            byte[] soup = _crypto.Encrypt(json);

            // Generate filename
            string filename = Path.Combine(Application.persistentDataPath, SaveFile);

            // If previous save exists, delete it
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }

            // Write new save
            File.WriteAllBytes(filename, soup);
        }

        private void Load()
        {
            // Generate filename
            string filename = Path.Combine(Application.persistentDataPath, SaveFile);

            // If no save file, create new one
            if (!File.Exists(filename)) Save();

            // Read data
            byte[] soupBackIn = File.ReadAllBytes(filename);

            // Decrypt data
            string jsonFromFile = _crypto.Decrypt(soupBackIn);

            // Create a copy object
            _copiedData = JsonUtility.FromJson<GameData>(jsonFromFile);

            // Load saved values
            _data.LoadDataToGame(_copiedData);
        }

        public GameData GetModel()
        {
            return _data;
        }
    }
}