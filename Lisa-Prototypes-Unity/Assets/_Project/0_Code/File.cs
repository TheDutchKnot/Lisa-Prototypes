using UnityEngine;
using tdk.Utilities;
using System.Collections;

public class File : MonoBehaviour {
    public FileSettings settings;

    void OnEnable() {
        StartCoroutine(DespawnAfterDelay(settings.DespawnDelay));
    }

    IEnumerator DespawnAfterDelay(float delay) {
        yield return IEnumeratorHelpers.GetWaitForSeconds(delay);
        FilePools.Despawn(this);
    }
}

