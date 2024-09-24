using System.Collections;
using tdk.Utilities;
using UnityEngine;

public class BasePoolObject : PoolObject {
    new BasePoolObjectSettings Settings => (BasePoolObjectSettings) base.Settings;

    void OnEnable() {
        StartCoroutine(DespawnAfterDelay(Settings.DespawnDelay));
    }

    IEnumerator DespawnAfterDelay(float delay) {
        yield return IEnumeratorHelpers.GetWaitForSeconds(delay);
        ObjectPoolManager.Despawn(this);
    }
}