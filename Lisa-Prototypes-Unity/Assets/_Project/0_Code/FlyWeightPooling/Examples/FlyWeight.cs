using UnityEngine;

namespace Tdk.FlyWeightPooling.Examples {
    public class FlyWeight : MonoBehaviour, IFlyWeight<FlyWeightSettings, FlyWeight> {
        public FlyWeightSettings Settings { get; set; }
    }
}
