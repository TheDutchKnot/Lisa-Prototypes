using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Tdk.Systems.ObjectPooling
{
    [CreateAssetMenu(fileName = "Filesettings")]
    public class Filesettings : ScriptableObject, IPoolObjectSettings
    {
        [SerializeField] GameObject prefab;

        public float DespawnDelay = 5f;
        public float Speed;
        public float DownloadTime = 5f;
        public int Score = 5;


        #region Interface
        public IPoolObject Create()
        {
            GameObject instance = Instantiate(prefab);
            instance.SetActive(false);
            instance.name = prefab.name;

            if (instance.TryGetComponent(out IPoolObject obj))
            {
                obj.Settings = this;
                Speed = Random.Range(1f, 10f);
                return obj;
            }
            throw new System.Exception("Object not poolable, no Ipoolobject found");
        }



        public void OnDestroyPoolObject(IPoolObject obj) => Destroy(obj.Instance);
        public void OnGet(IPoolObject obj) => obj.Instance.SetActive(true);
        public void OnRelease(IPoolObject obj) => obj.Instance.SetActive(false);
        #endregion
    }
}

