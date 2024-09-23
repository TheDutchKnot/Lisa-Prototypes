using UnityEngine;

namespace tdk.Components
{
    [CreateAssetMenu(fileName = "HealthConfig", menuName = "HealthSystem/HealthConfig")]
    public class HealthConfig : ScriptableObject
    {
        public int HealthMin = 0;
        public int HealthMax = 3;
    }
}