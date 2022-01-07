using System.IO;
using Score;
using UnityEngine;

namespace SaveAndLoadSystem
{
    public class Serializer : MonoBehaviour
    {
        // Create global object
        public static Serializer SaveLoadManager;
        
        // Game objects data to be saved / load
        [SerializeField] private ScoreSetup _score;
        
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
            if (SaveLoadManager) Destroy(gameObject);
            SaveLoadManager = this;
            
            _crypto = new AES(EncryptionKey, IvKey);
            _data = new GameData();
        }

        public void Save()
        {
            // Get all needed to save data
            _data.CollectDataToSave(
                _score.GetModel()
            );
        
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

        public void Load()
        {
            // Generate filename
            string filename = Path.Combine(Application.persistentDataPath, SaveFile);
            
            // Read data
            byte[] soupBackIn = File.ReadAllBytes(filename);

            // Decrypt data
            string jsonFromFile = _crypto.Decrypt(soupBackIn);

            // Create a copy object
            _copiedData = JsonUtility.FromJson<GameData>(jsonFromFile);

            // Load saved values
            _copiedData.LoadDataToGame();
        }
    }
}