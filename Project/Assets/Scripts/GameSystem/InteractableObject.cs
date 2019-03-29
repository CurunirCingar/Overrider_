using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameSystem
{
    [RequireComponent(typeof(MeshRenderer))]
    public class InteractableObject : MonoBehaviour
    {
        [SerializeField] private List<UI.Command> commands;

        int activeCommands;

        bool isGlitched;

        public List<UI.Command> Commands
        {
            get { return commands; }
        }

        public int ActiveCommands
        {
            get
            {
                return activeCommands;
            }

            set
            {
                activeCommands = value;
                IsGlitched = activeCommands >= 0;
            }
        }

        public bool IsGlitched
        {
            get
            {
                return isGlitched;
            }

            set
            {
                isGlitched = value;
            }
        }

        private void Awake()
        {
            activeCommands = 0;
            foreach (var comm in commands)
            {
                comm.OnCommandActivated += () =>
                {
                    ActiveCommands++;
                    Debug.Log(comm.Caption + " enabled");
                    EnableGlitchEffect(comm);
                };

                comm.OnCommandDisabled += () =>
                {
                    ActiveCommands--;
                    Debug.Log(comm.Caption + " disabled");
                };
            }

            GameRegimeManager.Instance.OnShowInteractable += delegate (bool state)
            {
                MeshRenderer rend = GetComponent<MeshRenderer>();
                if (state)
                {
                    rend.material = GameRegimeManager.Instance.interactableMaterial;
                }
                else
                {
                    if (IsGlitched)
                    {
                        rend.material = GameRegimeManager.Instance.glitchMaterial;
                    }
                    else
                    {
                        rend.material = GameRegimeManager.Instance.standardMaterial;
                    }
                }

            };
        }

        private void EnableGlitchEffect(UI.Command com)
        {
            StartCoroutine(GlitchEffectCourutine(com));
        }

        IEnumerator GlitchEffectCourutine(UI.Command com)
        {
            float timeDelay = com.ActiveTime;
            MeshRenderer rend = GetComponent<MeshRenderer>();
            rend.material = GameRegimeManager.Instance.glitchMaterial;
            float notBlinkingTime = timeDelay - 1;
            yield return new WaitForSeconds(notBlinkingTime);

            bool flag = false;
            for (float i = notBlinkingTime; i < timeDelay; i += 0.1f)
            {
                yield return new WaitForSeconds(0.1f);
                rend.material = flag ?
                    GameRegimeManager.Instance.CurrentStandardMaterial :
                    GameRegimeManager.Instance.glitchMaterial;
                flag = !flag;
            }
            rend.material = GameRegimeManager.Instance.standardMaterial;
            com.Disable();
        }
    }
}