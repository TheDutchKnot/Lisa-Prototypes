using UnityEngine;

namespace Tdk.Systems.ObjectPooling {
    public class BallSpawner : MonoBehaviour {
        [SerializeField] BallSettings[] settings;

        [ContextMenu("SpawnBalls")]
        public void SpawnBalls() {
            for (int i = 0; i < settings.Length; i++) {

                for (int j = 0; j < 2; j++) {

                    IPoolObject obj = ObjectPoolManager.Spawn(settings[i]);
                    obj.Instance.transform.position = transform.position;
                }
            }
        }
    }
}
