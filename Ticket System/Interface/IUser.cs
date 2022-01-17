namespace Ticket_System.Interface
{
    public interface IUser
    {
        bool CanCreateErrorTask();
        bool CanEditErrorTask();
        bool CanDeleteErrorTask();
        bool CanResolveErrorTask();
        bool CanFeatureRequest();
        bool CanResolveFeatureRequest();
        bool CanCreateTestCase();
        bool CanResolveTestCase();
        

    }
}