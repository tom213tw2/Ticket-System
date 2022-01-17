using Ticket_System.Interface;

namespace Ticket_System.UserPermission
{
    public class QAPermission : IUser
    {
        public bool CanCreateErrorTask() => true;

        public bool CanResolveFeatureRequest() => false;

        public bool CanCreateTestCase() => true;

        public bool CanDeleteErrorTask() => true;

        public bool CanEditErrorTask() => true;

        public bool CanFeatureRequest() => false;

        public bool CanResolveErrorTask() => false;

        public bool CanResolveTestCase() => true;
    }
}