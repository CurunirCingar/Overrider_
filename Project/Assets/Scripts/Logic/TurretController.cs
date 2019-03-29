using UnityEngine;

namespace Logic
{
    public class TurretController : MonoBehaviour
    {
        [SerializeField] private Transform baseTransform;
        [SerializeField] private Transform muzzleTransform;
        [SerializeField] private float rotateSpeed = 0.5f;

        private void Update()
        {

        }


        public void LookAt(Vector3 point)
        {
            var localPoint = point - baseTransform.position;
            var height = localPoint.y;
            localPoint.y = 0;

            var targetBaseRotation = Quaternion.LookRotation(localPoint);
            baseTransform.rotation =
                Quaternion.Slerp(baseTransform.rotation, targetBaseRotation, Time.deltaTime * rotateSpeed);

            var muzzleTarget = baseTransform.forward * localPoint.magnitude;
            muzzleTarget.y = height;

            var targetMuzzleRotation = Quaternion.LookRotation(muzzleTarget);
            muzzleTransform.rotation =
                Quaternion.Slerp(muzzleTransform.rotation, targetMuzzleRotation, Time.deltaTime * rotateSpeed);
        }
    }
}