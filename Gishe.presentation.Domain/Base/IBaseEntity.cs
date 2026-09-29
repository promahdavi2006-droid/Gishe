namespace Gishe.presentation.Domain.Base;

public interface IBaseEntity<TKey>
{
    public TKey Id { get; }
}
