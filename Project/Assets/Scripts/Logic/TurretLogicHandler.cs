namespace Logic     
{
    public sealed class TurretLogicHandler : AlaramableObject
    {
        private TurretController controller;

        private void Start()
        {
            controller = GetComponent<TurretController>();
        }

        private void Update()
        {
            if (Target != null)
            {
                controller.LookAt(Target.position);
            }
        }
    }
}