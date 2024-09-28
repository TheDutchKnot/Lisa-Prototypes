using UnityEngine;

namespace Tdk.Systems.ObjectPooling {
    public interface IPoolObject {
        public IPoolObjectSettings Settings { get; set; }
        public GameObject Instance { get; }
    }
}