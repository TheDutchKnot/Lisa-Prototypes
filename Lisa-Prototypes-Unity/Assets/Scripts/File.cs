using System.Collections;
using UnityEngine;
using tdk.Utilities;

namespace Tdk.Systems.ObjectPooling {
    public class File : MonoBehaviour, IPoolObject {
        public IPoolObjectSettings Settings { get; set; }
        public GameObject Instance => gameObject;

       Filesettings Filesettings => (Filesettings)Settings;

        private void OnEnable() {
            if (Filesettings== null) return;

            StartCoroutine(DespawnAfterDelay(Filesettings.DespawnDelay));
        }

        IEnumerator DespawnAfterDelay(float delay) {
            yield return WaitForSecondsUtils.GetWaitForSeconds(delay);
            ObjectPoolManager.Despawn(this);
        }
    }
}
