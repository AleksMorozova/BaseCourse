using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Mapping;
using DomainModel.Entities;

namespace Server.fluentmapping
{
    class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table(StringConst.UserMapTableName);
            Id(x => x.Id).Column("Users_id").GeneratedBy.Identity();
            Map(x => x.Login);
            Map(x => x.Name).Column("UsersName");
            Map(x => x.Password);
            Map(x => x.Role).CustomType<Role>();
        }
    }
}
