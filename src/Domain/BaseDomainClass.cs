namespace GamingApi.Domain
{
    public class BaseDomainClass
    {
        public BaseDomainClass(long id) =>
            this.Id = id;

        public long Id { get; init; }
    }
}
