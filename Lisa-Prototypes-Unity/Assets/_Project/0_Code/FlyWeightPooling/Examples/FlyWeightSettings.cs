using UnityEngine;

namespace Tdk.FlyWeightPooling.Examples {
    [CreateAssetMenu(menuName = "Tdk/FlyWeightPooling/Examples/FlyWeight Settings")]
    public class FlyWeightSettings : ScriptableObject, IFlyWeightSettings<FlyWeightSettings, FlyWeight> {

        [SerializeField] GameObject _prefab;

        public FlyWeight Create() {
            GameObject obj = Instantiate(_prefab);
            obj.name = _prefab.name;
            obj.SetActive(false);

            if (obj.TryGetComponent(out FlyWeight flyWeight)) {
                flyWeight.Settings = this;
                return flyWeight;
            }
            throw new System.Exception(_prefab.name + "Does not contain a Flyweight component.");
        }

        public void OnGet(FlyWeight obj) => obj.gameObject.SetActive(true);
        public void OnRelease(FlyWeight obj) => obj.gameObject.SetActive(false);
        public void OnDestroyPoolObject(FlyWeight obj) => Destroy(obj.gameObject);
    }
}
