using Ticket_System.Interface;

namespace Ticket_System.UserPermission
{
    public class RDPermission:IUser
    {
        public bool CanCreateErrorTask() => false;

        public bool CanEditErrorTask() => false;

        public bool CanDeleteErrorTask() => false;

        public bool CanResolveErrorTask() => true;

        public bool CanFeatureRequest() => false;

        public bool CanResolveFeatureRequest() => true;

        public bool CanCreateTestCase() => false;

        public bool CanResolveTestCase() => false;
    }
}