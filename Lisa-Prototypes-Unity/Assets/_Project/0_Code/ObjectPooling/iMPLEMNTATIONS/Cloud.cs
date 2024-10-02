﻿using UnityEngine;
using System.Collections;

namespace Tdk.Systems.ObjectPooling
{
    public class Cloud : MonoBehaviour
    {
        public CustomTimer timer;
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent(out IPoolObject obj))
            {
                ObjectPoolManager.Despawn(obj);
                Filesettings fileSettings = obj.Settings as Filesettings; 
               
                if (fileSettings != null)
                {
                    timer.StartTimer(fileSettings.DownloadTime);
                }


                StartCoroutine(DespawnAfterDelay(obj, fileSettings.DespawnDelay));
            }

        }

        IEnumerator DespawnAfterDelay(IPoolObject obj, float delay)
        {
            yield return new WaitForSeconds(delay);
        }
    }
}

