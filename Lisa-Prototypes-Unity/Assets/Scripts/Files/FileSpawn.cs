using UnityEngine;

namespace Tdk.Systems.ObjectPooling {
    public class FileSpawn : MonoBehaviour {
        [SerializeField] Filesettings[] settings;

        [ContextMenu("FileSpawn")]
        public void SpawnFiles() {
            for (int i = 0; i < settings.Length; i++) {

                for (int j = 0; j < 2; j++) {

                    IPoolObject obj = ObjectPoolManager.Spawn(settings[i]);
                    obj.Instance.transform.position = transform.position;
                }
            }
        }
    }
}