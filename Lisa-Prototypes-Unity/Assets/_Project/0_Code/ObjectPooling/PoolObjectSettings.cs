using UnityEngine;

public abstract class PoolObjectSettings : ScriptableObject, IPoolObjectSettings {
    [field: SerializeField] public bool CollectionCheck { get; private set; } = true;
    [field: SerializeField] public int DefaultCapacity { get; private set; } = 10;
    [field: SerializeField] public int MaxCapacity { get; private set; } = 100;

    [Header("Pool Object")]
    [SerializeField] GameObject Prefab;

    int IPoolObjectSettings.PoolID { get; set; }

    public virtual IPoolObject Create() {
        GameObject instance = Instantiate(Prefab);
        instance.SetActive(false);
        instance.name = Prefab.name;

        if (instance.TryGetComponent(out IPoolObject obj)) {
            obj.Settings = this;
            return obj;
        }
        throw new System.Exception("The GameObject is not poolable, inherit IPoolObject");
    }

    public virtual void OnGet(IPoolObject obj) => obj.GameObject.SetActive(true);
    public virtual void OnRelease(IPoolObject obj) => obj.GameObject.SetActive(false);
    public virtual void OnDestroyPoolObject(IPoolObject obj) => Destroy(obj.GameObject);
}

public interface IPoolObjectSettings {
    public bool CollectionCheck { get; }
    public int DefaultCapacity { get; }
    public int MaxCapacity { get; }

    public int PoolID { get; set; }

    public IPoolObject Create();

    public void OnGet(IPoolObject obj);
    public void OnRelease(IPoolObject obj);
    public void OnDestroyPoolObject(IPoolObject obj);
}