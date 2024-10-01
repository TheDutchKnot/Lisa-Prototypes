using System.Collections;
using UnityEngine;
using tdk.Utilities;

namespace Tdk.Systems.ObjectPooling {
    public class File : MonoBehaviour, IPoolObject {
        public IPoolObjectSettings Settings { get; set; }
        public GameObject Instance => gameObject;

        Filesettings Filesettings => (Filesettings)Settings;

        void OnEnable() {
            if (Filesettings == null) return;

            StartCoroutine(DespawnAfterDelay(Filesettings.DespawnDelay));
        }

        void Update() {
            transform.Translate(Filesettings.Speed * Time.deltaTime * Vector3.down);
        }

        IEnumerator DespawnAfterDelay(float delay) {
            yield return WaitForSecondsUtils.GetWaitForSeconds(delay);
            ObjectPoolManager.Despawn(this);
        }
    }
}
