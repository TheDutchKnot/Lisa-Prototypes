using System.Collections;
using UnityEngine;
using tdk.Utilities;

namespace Tdk.Systems.ObjectPooling
{
    public class CorruptedFiles : MonoBehaviour, IPoolObject
    {
        public IPoolObjectSettings Settings { get; set; }
        public GameObject Instance => gameObject;

        VirusSettings VirusSettings => (VirusSettings)Settings;

        void OnEnable()
        {
            if (VirusSettings == null) return;

            StartCoroutine(DespawnAfterDelay(VirusSettings.DespawnDelay));
        }

        void Update()
        {
            transform.Translate(VirusSettings.Speed * Time.deltaTime * Vector3.down);
        }

        IEnumerator DespawnAfterDelay(float delay)
        {
            yield return WaitForSecondsUtils.GetWaitForSeconds(delay);
            ObjectPoolManager.Despawn(this);
        }
    }
}
