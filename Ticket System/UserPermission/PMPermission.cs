using Ticket_System.Interface;

namespace Ticket_System.UserPermission
{
    public class PMPermission:IUser
    {
        public bool CanCreateErrorTask() => false;

        public bool CanEditErrorTask() => false;

        public bool CanDeleteErrorTask() => false;

        public bool CanResolveErrorTask() => false;

        public bool CanFeatureRequest() => true;

        public bool CanResolveFeatureRequest() => false;

        public bool CanCreateTestCase() => false;

        public bool CanResolveTestCase() => false;
    }
}