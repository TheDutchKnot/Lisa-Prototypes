using System.Collections.Generic;
using UnityEngine.Pool;

namespace Tdk.Systems.ObjectPooling {
    public static class ObjectPoolManager {
        const bool CollectionCheck = true;
        const int DefaultCapacity = 10;
        const int MaxCapacity = 100;

        static readonly Dictionary<IPoolObjectSettings, IObjectPool<IPoolObject>> pools = new();

        public static IPoolObject Spawn(IPoolObjectSettings s) => GetPoolFor(s).Get();
        public static void Despawn(IPoolObject obj) => GetPoolFor(obj.Settings).Release(obj);

        static IObjectPool<IPoolObject> GetPoolFor(IPoolObjectSettings settings) {

            if (pools.TryGetValue(settings, out IObjectPool<IPoolObject> pool)) return pool;

            pool = new ObjectPool<IPoolObject>(
                settings.Create,
                settings.OnGet,
                settings.OnRelease,
                settings.OnDestroyPoolObject,
                CollectionCheck,
                DefaultCapacity,
                MaxCapacity
                );
            pools.Add(settings, pool);
            return pool;
        }

        public static void Clear() => pools.Clear();
    }
}