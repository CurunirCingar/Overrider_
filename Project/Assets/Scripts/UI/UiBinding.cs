using UnityEngine;

namespace UI
{
    public class UiBinding : MonoBehaviour
    {
        [SerializeField] private Command command;


        public void ProccedCommand()
        {
            //TODO: Check for point limits
            command.Activate();
        }
    }
}
