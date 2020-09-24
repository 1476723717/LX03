using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return JsonOptions(DAL.UserInfo.Instance.GetCount());
        }
        [HttpPut("{username}")]
        public ActionResult put([FromBody]Model.UserInfo users)
        {
            try
            {
                var n = DAL.UserInfo.Instance.Update(users);
                if (n != 0)
                    return Json(result.ok("修改成功"));
                else
                    return Json(result.Err("用户名不存在"));
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("null"))
                    return Json(result.Err("密码、身份不能为空"));
                else
                    return Json(result.Err(ex.Message));
            }
           
        }
        [Httppost]
        public ActionResult Post([FromBody] Model.UserInfo usere)
        {
            try
            {
                int n = DAL.UserInfo.Instance.Add(users);
                return Json(result.ok("添加成功"));

            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Contains("primary"))
                    return Json(result.Err("用户名已存在"));
                else if (ex.Message.ToLower().Contains("null"))
                    return json(result.Err("用户名、密码、身份不能为空"));
                else
                    return Json(result.Err(ex.Message));
            }
}
