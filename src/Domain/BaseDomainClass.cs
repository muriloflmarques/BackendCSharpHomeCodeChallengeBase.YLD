namespace GamingApi.Domain
{
    public class BaseDomainClass
    {
        public BaseDomainClass(ulong id) =>
            this.Id = id;

        public ulong Id { get; init; }
    }
}
