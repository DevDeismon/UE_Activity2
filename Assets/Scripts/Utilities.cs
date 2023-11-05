using Assets.Scripts.Intefaces;
using UnityEngine;

namespace Assets.Scripts
{
    public class Utilities : MonoBehaviour, IUtilities
    {
        /// <summary>
        /// Función auxiliar que permite acotar los valores del target entre -1 y 1
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public Vector3 ClampVector3(Vector3 target)
        {
            Vector3 result;
            float clampedX = Mathf.Clamp(target.x, -1f, 1f);
            float clampedY = Mathf.Clamp(target.y, -1f, 1f);
            float clampedZ = Mathf.Clamp(target.z, -1f, 1f);

            result = new(clampedX, clampedY, clampedZ);
            return result;
        }
    }
}