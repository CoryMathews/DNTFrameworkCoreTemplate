using System.Linq;
using DNTFrameworkCore.Application.Models;
using DNTFrameworkCore.Application.Services;
using DNTFrameworkCore.EntityFramework.Application;
using DNTFrameworkCoreTemplateAPI.Application.Identity.Models;
using DNTFrameworkCoreTemplateAPI.Domain.Identity;
using Microsoft.EntityFrameworkCore;

namespace DNTFrameworkCoreTemplateAPI.Application.Identity
{
    public interface IRoleService : ICrudService<long, RoleReadModel, RoleModel>
    {
    }

    public class RoleService : CrudService<Role, long, RoleReadModel, RoleModel>, IRoleService
    {
        public RoleService(CrudServiceDependency dependency) : base(dependency)
        {
        }

        protected override IQueryable<Role> BuildFindQuery()
        {
            return base.BuildFindQuery()
                .Include(r => r.Permissions);
        }

        protected override IQueryable<RoleReadModel> BuildReadQuery(FilteredPagedQueryModel model)
        {
            return EntitySet.AsNoTracking().Select(r => new RoleReadModel
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                RowVersion = r.RowVersion
            });
        }

        protected override Role MapToEntity(RoleModel model)
        {
            return new Role
            {
                Id = model.Id,
                RowVersion = model.RowVersion,
                Name = model.Name,
                NormalizedName =
                    model.Name.ToUpperInvariant(), //Todo: In persian can use DNTPersianUtils.Core nuget package
                Description = model.Description,
                Permissions = model.Permissions.Select(p => new RolePermission
                {
                    Id = p.Id,
                    Name = p.Name,
                    TrackingState = p.TrackingState
                }).ToList()
            };
        }

        protected override RoleModel MapToModel(Role entity)
        {
            return new RoleModel
            {
                Id = entity.Id,
                RowVersion = entity.RowVersion,
                Name = entity.Name,
                Description = entity.Description,
                Permissions = entity.Permissions.Select(p => new PermissionModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    TrackingState = p.TrackingState
                }).ToList()
            };
        }
    }
}