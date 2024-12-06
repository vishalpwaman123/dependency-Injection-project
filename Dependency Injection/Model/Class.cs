namespace Dependency_Injection.Model
{
    public struct GetTaskResponse
    {
        public Guid transient1 { get; set; }
        public Guid transient2 { get; set; }
        public Guid scoped1 { get; set; }
        public Guid scoped2 { get; set; }
        public Guid singleton1 { get; set; }
        public Guid singleton2 { get; set; }
    }
}
