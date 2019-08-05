using System.Collections.Generic;
using pkhmelyov.AbpReposterBot.Roles.Dto;

namespace pkhmelyov.AbpReposterBot.Web.Models.Common
{
    public interface IPermissionsEditViewModel
    {
        List<FlatPermissionDto> Permissions { get; set; }
    }
}