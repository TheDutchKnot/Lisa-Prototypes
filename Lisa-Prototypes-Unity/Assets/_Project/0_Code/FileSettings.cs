using UnityEngine;
using tdk.Utilities;

public abstract class FileSettings : ScriptableObject {
    public GameObject Prefab;
    public int DespawnDelay;

    public FileID ID { get; private set; }

    void OnEnable() {
        ID = FileIDBinder.Bind(this);
    }

    public virtual File CreateFile() {
        GameObject instance = Instantiate(Prefab);
        instance.SetActive(false);
        instance.name = Prefab.name;

        File file = instance.GetOrAdd<File>();
        file.settings = this;
        return file;
    }

    public virtual void OnGet(File f) => f.gameObject.SetActive(true);
    public virtual void OnRelease(File f) => f.gameObject.SetActive(false);
    public virtual void OnDestroyPoolObject(File f) => Destroy(f.gameObject);
}

