using System.Collections.Generic;
using UnityEngine;

namespace Logic
{
    public class AlarmTrigger : MonoBehaviour
    {
        [SerializeField] private List<AlaramableObject> alarmRecievers;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;

            foreach (var reciever in alarmRecievers)
            {
                reciever.SetTarget(other.transform);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.gameObject.CompareTag("Player")) return;

            foreach (var reciever in alarmRecievers)
            {
                reciever.ResetTarget();
            }
        }
    }
}