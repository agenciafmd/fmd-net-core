using System.ComponentModel.DataAnnotations;
using Fmd.Net.Mediator.Interfaces;

namespace Fmd.Net.Core.Messages;

public abstract class Command : Message, IRequest<bool>
{
    public DateTime Timestamp { get; private set; }
    public ValidationResult ValidationResult { get; set; }

    protected Command()
    {
        Timestamp = DateTime.Now;
    }

    public virtual bool IsValid()
    {
        throw new NotImplementedException();
    }
}