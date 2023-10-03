using Models.Abstract.Entities;
using System.Reflection;
using System.Text;

namespace Repositories.Concrete.EFCore.Extensions
{
    public class OrderQueryBuilder<T>
        where T : class, IEntity, new()

    {
        public static string CreateQueryString(string orderByQueryString)

        {
            var type = typeof(T);
            var orderParams = orderByQueryString.Trim().Split(", ").ToList();
            var propertyInfos = type.GetProperties(BindingFlags.Instance | BindingFlags.Public).ToList();
            var orderQueryBuilder = new StringBuilder();

            foreach (var param in orderParams)
            {
                if (string.IsNullOrWhiteSpace(param))
                    continue;

                var propertyFromQueryName = param.Split(" ")[0];

                var matchingPropertyName = propertyInfos.FirstOrDefault(p => p.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase)).Name;

                if (matchingPropertyName is null)
                    continue;

                var direction = param.EndsWith("desc") ? "desc" : "asc";

                orderQueryBuilder.Append($"{matchingPropertyName} {direction},");

            }

            return orderQueryBuilder.ToString().TrimEnd(' ', ',');
        }
    }
}

