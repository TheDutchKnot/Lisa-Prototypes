using UnityEngine;

namespace Tdk.FlyWeightPooling {
    public interface IFlyWeight<TFlyWeightSettings, TFlyWeight>
        where TFlyWeightSettings    : ScriptableObject, IFlyWeightSettings  <TFlyWeightSettings, TFlyWeight>
        where TFlyWeight            : Component,        IFlyWeight          <TFlyWeightSettings, TFlyWeight> {

        TFlyWeightSettings Settings { get; set; }
    }
}