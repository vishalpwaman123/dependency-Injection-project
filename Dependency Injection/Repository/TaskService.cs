using Dependency_Injection.Interface;

namespace Dependency_Injection.Repository
{
    public class TaskService : ITransientService, IScopeService, ISingletonService
    {
        public Guid id;
        public TaskService()
        {
            id = Guid.NewGuid();
        }

        public Guid GetTaskId()
        {
            return id;
        }
    }
}
