using UnityEngine;

public class ObjectSpawner : MonoBehaviour {
    [SerializeField] PoolObjectSettings[] _settings;

    void OnEnable() {
        for (int i = 0; i < _settings.Length; i++) {
            ObjectPoolManager.Spawn(_settings[i]);
        }
    }
}
