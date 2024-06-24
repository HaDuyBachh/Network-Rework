using UnityEngine;
namespace Game.GameManager
{
    public class TrashSpawnManager : MonoBehaviour
    {
        public static TrashSpawnManager Instance { get; private set; }
        [SerializeField] private string _trashPath;
        [SerializeField] private GameObject[] _trashPrefabs;
        [SerializeField] private Transform _center;
        [SerializeField] private float _radius;
        [SerializeField] private int _trashCount = 100;
        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            SpawnTrash();
        }

        public void SpawnTrash()
        {
            for (int i = 0; i < _trashCount; i++)
            {
                Vector3 spawnPosition = _center.position + Random.insideUnitSphere * _radius;
                spawnPosition.y = _center.position.y + 1;
                GameObject trash = Instantiate(_trashPrefabs[Random.Range(0, _trashPrefabs.Length)], spawnPosition, Quaternion.identity);
            }
        }

#if UNITY_EDITOR
        [ContextMenu("Load Trash")]
        public void LoadTrash()
        {
            string[] prefabGUIDs = UnityEditor.AssetDatabase.FindAssets("t:Prefab", new string[] { _trashPath });
            _trashPrefabs = new GameObject[prefabGUIDs.Length];
            for (int i = 0; i < prefabGUIDs.Length; i++)
            {
                string path = UnityEditor.AssetDatabase.GUIDToAssetPath(prefabGUIDs[i]);
                _trashPrefabs[i] = UnityEditor.AssetDatabase.LoadAssetAtPath<GameObject>(path);
            }
        }
#endif

    }
}