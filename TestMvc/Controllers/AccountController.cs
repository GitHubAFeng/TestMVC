using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;


namespace TestMvc.Controllers
{
    public class AccountController : Controller
    {

        // GET: Account
        public ActionResult Index()
        {
            List<SysUser> users = null;
            using (var db = new testmvcEntities())
            {
                users = db.SysUser.ToList();
            }
            //传递数据给视图
            return View(users);
        }


        public ActionResult Login()
        {
            ViewBag.LoginState = "登录前……";
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {
            //获取表单数据
            string email = fc["inputEmail3"];
            string password = fc["inputPassword3"];

            using (var db = new testmvcEntities())
            {
                var user = db.SysUser.AsNoTracking().Where(t => t.Email == email && t.Password == password).FirstOrDefault();

                if (user != null)
                {
                    //登录后
                    ViewBag.LoginState = email + "登录后";
                }
                else
                {
                    ViewBag.LoginState = email + "此用户不存在……";
                }
            }

            return View();
        }


        public ActionResult Register()
        {
            return View();
        }



        //新建用户

        public ActionResult Create()
        {

            return View();

        }


        [HttpPost]
        public ActionResult Create(SysUser sysUser)
        {
            using (var db = new testmvcEntities())
            {
                db.SysUser.Add(sysUser);
                db.SaveChanges();
            }


            return RedirectToAction("Index");

        }

        //修改用户
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue) return View("没有值");
            SysUser sysUser = null;
            using (var db = new testmvcEntities())
            {
                sysUser = db.SysUser.Find(id);
            }

            return View(sysUser);

        }

        [HttpPost]
        public ActionResult Edit(SysUser sysUser)
        {
            using (var db = new testmvcEntities())
            {
                db.Entry(sysUser).State = EntityState.Modified;

                db.SaveChanges();
            }


            return RedirectToAction("Index");

        }



        //删除用户
        public ActionResult Delete(int id)
        {
            SysUser sysUser = null;
            using (var db = new testmvcEntities())
            {
                 sysUser = db.SysUser.Find(id);
            }

            return View(sysUser);

        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var db = new testmvcEntities())
            {
                SysUser sysUser = db.SysUser.Find(id);

                db.SysUser.Remove(sysUser);

                db.SaveChanges();
            }

            return RedirectToAction("Index");

        }


    }
}