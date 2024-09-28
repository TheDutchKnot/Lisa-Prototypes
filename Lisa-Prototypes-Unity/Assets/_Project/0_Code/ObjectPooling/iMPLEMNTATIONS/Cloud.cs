using UnityEngine;

namespace Tdk.Systems.ObjectPooling {
    public class Cloud : MonoBehaviour {
        void OnTriggerEnter(Collider other) {
            if (other.gameObject.TryGetComponent(out IPoolObject obj)) {
                ObjectPoolManager.Despawn(obj);
            }
        }
    }
}
