using System.Collections.Generic;
using UnityEngine.Pool;
using UnityEngine;
using UnityEditor;

namespace Tdk.FlyWeightPooling {
    public static class FlyWeightManager<TFlyWeightSettings, TFlyWeight>
        where TFlyWeightSettings    : ScriptableObject, IFlyWeightSettings  <TFlyWeightSettings, TFlyWeight> 
        where TFlyWeight            : Component,        IFlyWeight          <TFlyWeightSettings, TFlyWeight> {

        static readonly Dictionary<TFlyWeightSettings, IObjectPool<TFlyWeight>> _pools = new();

        public static TFlyWeight Spawn(TFlyWeightSettings s) => GetPoolFor(s).Get();
        public static void Despawn(TFlyWeight obj) => GetPoolFor(obj.Settings).Release(obj);

        public static void Buffer(TFlyWeightSettings s, int amount) {

            TFlyWeight[] instances = new TFlyWeight[amount];

            for (int i = 0; i < instances.Length; i++) {
                instances[i] = s.Create();
            }

            IObjectPool<TFlyWeight> pool = GetPoolFor(s);

            for (int i = 0; i < instances.Length; i++) {
                pool.Release(instances[i]);
            }
        }

        static IObjectPool<TFlyWeight> GetPoolFor(TFlyWeightSettings settings) {

            if (_pools.TryGetValue(settings, out IObjectPool<TFlyWeight> pool)) return pool;
            
            pool = new ObjectPool<TFlyWeight>(
                settings.Create,
                settings.OnGet,
                settings.OnRelease,
                settings.OnDestroyPoolObject
#if !DEBUG
                ,false
#endif
                );
            _pools.Add(settings, pool);
            return pool;
        }

        public static void Clear() => _pools.Clear();
    }
}