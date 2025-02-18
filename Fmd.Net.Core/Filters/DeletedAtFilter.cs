using System.Linq.Expressions;
using Fmd.Net.Core.DomainObjects;
using Microsoft.EntityFrameworkCore;

namespace Fmd.Net.Core.Filters;

public static class DeletedAtFilter
{
    public static void IgnoreDeletedAtFilter(this ModelBuilder builder)
    {
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            if (!typeof(Entity).IsAssignableFrom(entityType.ClrType)) continue;

            var parameterName = Expression.Parameter(entityType.ClrType, "entity");
            var property = Expression.Property(parameterName, nameof(Entity.DeletedAt));
            var comparison = Expression.Equal(property, Expression.Constant(null, typeof(DateTime?)));    
            builder.Entity(entityType.ClrType).HasQueryFilter(Expression.Lambda(comparison, parameterName));
        }
    }
}