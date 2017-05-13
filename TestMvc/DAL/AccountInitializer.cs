using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestMvc.Models;
using TestMvc.DAL;

namespace TestMvc.DAL
{
    /// <summary>
    /// 添加测试数据
    /// </summary>
    public class AccountInitializer : DropCreateDatabaseIfModelChanges<AccountContext>
    {
        //NOTE 不一定要在每个entity组后面都调用SaveChanges方法，可以在所有组结束后调用一次也可以。这样做是因为如果写入数据库代码出错，比较容易定位代码的错误位置。

        protected override void Seed(AccountContext context)
        {
            var sysUsers = new List<SysUser>
            {
                new SysUser{UserName="Tom",Email="a@qq.com",Password="1"},
                new SysUser{UserName="Jerry",Email="b@qq.com",Password="2"}
            };

            sysUsers.ForEach(s => context.SysUsers.Add(s));
            context.SaveChanges();

            var sysRole = new List<SysRole>
            {
                new SysRole{RoleName="Tom",RoleDesc="1"},
                new SysRole{RoleName="Jerry",RoleDesc="2"}
            };

            sysRole.ForEach(s => context.SysRoles.Add(s));
            context.SaveChanges();

        }

    }
}