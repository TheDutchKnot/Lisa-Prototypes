using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tdk.Systems.ObjectPooling
{
    public class FileSpawner : MonoBehaviour
    {
        [SerializeField] Filesettings[] settings;
        public Collider myCollider;


        public static Vector2 RandomPointInBounds(Bounds bounds)
        {
            return new Vector2(
            Random.Range(bounds.min.x, bounds.max.x),
            Random.Range(bounds.min.y, bounds.max.y)
            );
        }

        void Start()
        {
            RandomPointInBounds(myCollider.bounds);
            Spawnfiles();
            InvokeRepeating(nameof(Spawnfiles), 0f, 5f);
        }

        void Update()
        {
            new Vector3(0, (5) * Time.deltaTime, 0);
            transform.position -= new Vector3();
        }

        public void Spawnfiles()
        {
            for (int i = 0; i < settings.Length; i++)
            {

                for (int j = 0; j < 2; j++)
                {

                    Vector2 randomPosition = RandomPointInBounds(myCollider.bounds);

                    IPoolObject obj = ObjectPoolManager.Spawn(settings[i]);
                    obj.Instance.transform.position = new Vector2(randomPosition.x, randomPosition.y);
                }

            }

        }
    }
}



