using System.Collections;
using UnityEngine;
using tdk.Utilities;

namespace Tdk.Systems.ObjectPooling {
    public class Ball : MonoBehaviour, IPoolObject {
        public IPoolObjectSettings Settings { get; set; }
        public GameObject Instance => gameObject;

        BallSettings BallSettings => (BallSettings)Settings;

        private void OnEnable() {
            if (BallSettings == null) return;

            StartCoroutine(DespawnAfterDelay(BallSettings.DespawnDelay));
        }

        IEnumerator DespawnAfterDelay(float delay) {
            yield return WaitForSecondsUtils.GetWaitForSeconds(delay);
            ObjectPoolManager.Despawn(this);
        }
    }
}
