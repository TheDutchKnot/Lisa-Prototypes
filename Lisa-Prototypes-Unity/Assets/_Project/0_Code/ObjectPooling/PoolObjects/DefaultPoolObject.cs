using System.Collections;
using tdk.Utilities;

public class DefaultPoolObject : PoolObject {
    new DefaultPoolObjectSettings Settings => (DefaultPoolObjectSettings)base.Settings;

    void OnEnable() {
        if (Settings != null && Settings.AfterDelay != 0) {
            StartCoroutine(DespawnAfterDelay(Settings.AfterDelay));
        }
    }

    IEnumerator DespawnAfterDelay(float delay) {
        yield return IEnumeratorHelpers.GetWaitForSeconds(delay);
        ObjectPoolManager.Despawn(this);
    }
}
