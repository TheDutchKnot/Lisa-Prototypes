using UnityEngine;

namespace Tdk.FlyWeightPooling {
    public interface IFlyWeightSettings<TFlyWeightSettings, TFlyWeight> 
        where TFlyWeightSettings    : ScriptableObject, IFlyWeightSettings  <TFlyWeightSettings, TFlyWeight>
        where TFlyWeight            : Component,        IFlyWeight          <TFlyWeightSettings, TFlyWeight> {

        TFlyWeight Create();

        void OnGet(TFlyWeight obj);
        void OnRelease(TFlyWeight obj);
        void OnDestroyPoolObject(TFlyWeight obj);
    }
}