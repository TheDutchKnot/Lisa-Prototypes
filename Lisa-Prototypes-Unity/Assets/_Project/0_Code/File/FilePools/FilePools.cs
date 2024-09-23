using UnityEngine;
using tdk.Systems;
using System.Collections.Generic;
using UnityEngine.Pool;

public class FilePools : Singleton<FilePools> {
    [SerializeField] bool collectionCheck = true;
    [SerializeField] int defaultCapacity = 10;
    [SerializeField] int maxSize = 100;

    readonly Dictionary<FileID, IObjectPool<File>> pools = new();

    public static File Spawn(FileSettings s) => instance.GetPoolFor(s).Get();
    public static void Despawn(File f) => instance.GetPoolFor(f.settings).Release(f);

    IObjectPool<File> GetPoolFor(FileSettings settings) {

        if (pools.TryGetValue(settings.ID, out IObjectPool<File> pool)) return pool;

        pool = new ObjectPool<File>(
            settings.CreateFile,
            settings.OnGet,
            settings.OnRelease,
            settings.OnDestroyPoolObject,
            collectionCheck,
            defaultCapacity,
            maxSize
            );
        pools.Add(settings.ID, pool);
        return pool;
    }
}

