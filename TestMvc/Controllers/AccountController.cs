using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using TestMvc.DAL;
using TestMvc.Models;

namespace TestMvc.Controllers
{
    public class AccountController : Controller
    {
        private AccountContext db = new AccountContext();

        // GET: Account
        public ActionResult Index()
        {
            //传递数据给视图
            return View(db.SysUsers);
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

            var user = db.SysUsers.Where(t => t.Email == email && t.Password == password).FirstOrDefault();

            if (user != null)
            {
                //登录后
                ViewBag.LoginState = email + "登录后";
            }
            else
            {
                ViewBag.LoginState = email + "此用户不存在……";
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

            db.SysUsers.Add(sysUser);

            db.SaveChanges();

            return RedirectToAction("Index");

        }

        //修改用户
        public ActionResult Edit(int id)
        {

            SysUser sysUser = db.SysUsers.Find(id);

            return View(sysUser);

        }

        [HttpPost]
        public ActionResult Edit(SysUser sysUser)
        {

            db.Entry(sysUser).State = EntityState.Modified;

            db.SaveChanges();

            return RedirectToAction("Index");

        }



        //删除用户
        public ActionResult Delete(int id)
        {

            SysUser sysUser = db.SysUsers.Find(id);

            return View(sysUser);

        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {

            SysUser sysUser = db.SysUsers.Find(id);

            db.SysUsers.Remove(sysUser);

            db.SaveChanges();

            return RedirectToAction("Index");

        }


    }
}