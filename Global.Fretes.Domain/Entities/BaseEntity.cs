namespace Global.Fretes.Domain.Entities;

public abstract class BaseEntity
{
    protected BaseEntity(
        Guid id, 
        long numero, 
        DateTime criadoEm, 
        DateTime? atualizadoEm)
    {
        Id = id;
        Numero = numero;
        CriadoEm = criadoEm;
        AtualizadoEm = atualizadoEm;
    }

    public Guid Id { get; protected set; }
    public long Numero { get; protected set; }
    public DateTime CriadoEm { get; protected set; }
    public DateTime? AtualizadoEm { get; protected set; }
}
