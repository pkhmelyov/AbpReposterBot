﻿using Abp.AutoMapper;
using pkhmelyov.AbpReposterBot.Roles.Dto;
using pkhmelyov.AbpReposterBot.Web.Models.Common;

namespace pkhmelyov.AbpReposterBot.Web.Models.Roles
{
    [AutoMapFrom(typeof(GetRoleForEditOutput))]
    public class EditRoleModalViewModel : GetRoleForEditOutput, IPermissionsEditViewModel
    {
        public EditRoleModalViewModel(GetRoleForEditOutput output)
        {
            output.MapTo(this);
        }

        public bool HasPermission(FlatPermissionDto permission)
        {
            return GrantedPermissionNames.Contains(permission.Name);
        }
    }
}
