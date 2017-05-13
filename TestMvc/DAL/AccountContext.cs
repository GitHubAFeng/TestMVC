using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using TestMvc.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TestMvc.DAL
{
    /// <summary>
    /// 中间访问层
    /// </summary>
    public class AccountContext: DbContext
    {
        public AccountContext() : base("AccountContext")
        {
            //指定一个连接字符串

        }

        public DbSet<SysUser> SysUsers { get; set; }
        public DbSet<SysRole> SysRoles { get; set; }
        public DbSet<SysUserRole> SysUserRoles { get; set; }

        //指定单数形式的表名,默认情况下会生成复数形式的表，如SysUsers
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


    }
}