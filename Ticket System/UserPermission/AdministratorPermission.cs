using Ticket_System.Interface;

namespace Ticket_System.UserPermission
{
    public class AdministratorPermission:IUser
    {
        public bool CanCreateErrorTask() => true;

        public bool CanEditErrorTask() => true;

        public bool CanDeleteErrorTask() => true;

        public bool CanResolveErrorTask() => true;

        public bool CanFeatureRequest() => true;

        public bool CanResolveFeatureRequest() => true;

        public bool CanCreateTestCase() => true;

        public bool CanResolveTestCase() => true;
    }
}