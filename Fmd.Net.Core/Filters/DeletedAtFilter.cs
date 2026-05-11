using System.Linq.Expressions;
using Fmd.Net.Core.DomainObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Fmd.Net.Core.Filters;

public static class DeletedAtFilter
{
    public static void IgnoreDeletedAtFilter(this ModelBuilder builder)
    {
        foreach (IMutableEntityType entityType in builder.Model.GetEntityTypes())
        {
            if (ImplementsGenericBase(entityType.ClrType, typeof(Entity<>)))
            {
                var parameterExpression = Expression.Parameter(entityType.ClrType, "entity");
                var body = Expression.Equal(
                    Expression.Property(parameterExpression, nameof(Entity<>.DeletedAt)),
                    Expression.Constant(null, typeof(DateTime?))
                );
                
                builder
                    .Entity(entityType.ClrType)
                    .HasQueryFilter(Expression.Lambda(body, parameterExpression));
            }
        }
    }
    
    private static bool ImplementsGenericBase(Type type, Type genericBase)
    {
        while (type != null && type != typeof(object))
        {
            if (type.IsGenericType && type.GetGenericTypeDefinition() == genericBase)
                return true;
    
            type = type.BaseType;
        }
        
        return false;
    }

}