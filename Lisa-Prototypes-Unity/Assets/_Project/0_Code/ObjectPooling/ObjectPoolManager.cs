using System.Collections.Generic;
using UnityEngine.Pool;

public static class ObjectPoolManager {
    static readonly Dictionary<int, IObjectPool<IPoolObject>> _pools = new();

    public static IPoolObject Spawn(IPoolObjectSettings s) => GetPoolFor(s).Get();
    public static void Despawn(IPoolObject obj) => GetPoolFor(obj.Settings).Release(obj);

    static IObjectPool<IPoolObject> GetPoolFor(IPoolObjectSettings settings) {

        if (_pools.TryGetValue(settings.PoolID, out IObjectPool<IPoolObject> pool)) return pool;

        settings.PoolID = _pools.Count + 1;

        pool = new ObjectPool<IPoolObject>(
            settings.Create,
            settings.OnGet,
            settings.OnRelease,
            settings.OnDestroyPoolObject,
            settings.CollectionCheck,
            settings.DefaultCapacity,
            settings.MaxCapacity
            );
        _pools.Add(settings.PoolID, pool);
        return pool;
    }

    public static void Clear() => _pools.Clear();
}
