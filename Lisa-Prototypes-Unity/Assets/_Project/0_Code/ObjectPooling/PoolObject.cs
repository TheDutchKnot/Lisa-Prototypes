using UnityEngine;

public abstract class PoolObject : MonoBehaviour, IPoolObject {
    public IPoolObjectSettings Settings { get; set; }
    GameObject IPoolObject.GameObject => gameObject;
}

public interface IPoolObject {
    public IPoolObjectSettings Settings { get; set; }
    public GameObject GameObject { get; }
}
