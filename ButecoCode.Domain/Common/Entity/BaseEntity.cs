namespace ButecoCode.Domain.Common.Entity
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public DateTime DataCriacao { get; private set; } = DateTime.Now;

    }
}
