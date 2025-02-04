using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fmd.Net.Core.DomainObjects;

public abstract class Entity
{
    [Key] [Column("id")] public int Id { get; protected set; }
    [Column("nome")] public string? Nome { get; protected set; }
    [Column("descricao")] public string? Descricao { get; protected set; }
    [Column("criado_em")] public DateTime CreatedAt { get; protected set; }
    [Column("atualizado_em")] public DateTime UpdatedAt { get; protected set; }
    [Column("excluido_em")] public DateTime? DeletedAt { get; private protected set; }
    
    public void Delete()
    {
        DeletedAt = DateTime.Now;
    }
}