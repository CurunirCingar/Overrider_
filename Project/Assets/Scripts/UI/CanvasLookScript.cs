using UnityEngine;

namespace UI
{
    public class CanvasLookScript : MonoBehaviour
    {
        [SerializeField] private Camera lookAtCamera;

        private void Start ()
        {
            if (lookAtCamera == null)
                lookAtCamera = Camera.main;
        }
	
        private void Update () {
		    transform.LookAt(lookAtCamera.transform.position);
        }
    }
}
