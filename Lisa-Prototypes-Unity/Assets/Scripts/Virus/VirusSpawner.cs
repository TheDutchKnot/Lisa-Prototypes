using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tdk.Systems.ObjectPooling
{
    [RequireComponent(typeof(Collider))]
    public class VirusSpawner : MonoBehaviour
    {
        [SerializeField] VirusSettings[] settings;

        [Header("Spawn Settings")]
        [SerializeField] float spawnInterval = 5.0f;
        [SerializeField] int spawnAmount = 2;

        Collider col;

        void Awake()
        {
            col = GetComponent<Collider>();
        }

        void Start()
        {
            InvokeRepeating(nameof(Spawnvirus), 0f, spawnInterval);
        }

        public void Spawnvirus()
        {
            for (int j = 0; j < spawnAmount; j++)
            {

                int randomIndex = Random.Range(0, settings.Length);
                VirusSettings selectedSettings = settings[randomIndex];
               
                IPoolObject obj = ObjectPoolManager.Spawn(selectedSettings);
                obj.Instance.transform.position = RandomPointInBounds(col.bounds);
            }
        }
        

        public static Vector2 RandomPointInBounds(Bounds bounds)
        {
            return new Vector2(
                Random.Range(bounds.min.x, bounds.max.x),
                Random.Range(bounds.min.y, bounds.max.y)
                );
        }
    }
}
