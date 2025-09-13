using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Netrilo.Infrastructure.Common.Abstractions
{
    public static class Mapping
    {
        public static TTarget Map<TSource, TTarget>(TSource value)
            where TSource : class
            where TTarget : class
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<TSource, TTarget>());

            var mapper = new Mapper(config);
            var result = mapper.Map<TSource, TTarget>(value);


            return result;
        }

        public static IServiceCollection AddMappingProfiles(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            return services;
        }

        public static Task<List<TDestination>> ProjectToListAsync<TDestination>(this IQueryable queryable, IConfigurationProvider configuration) where TDestination : class
            => queryable.ProjectTo<TDestination>(configuration).AsNoTracking().ToListAsync();
    }
}
