using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Shuriken.Weixin;
using System.Diagnostics;

namespace Shuriken.Controllers
{
    public class WeixinController : Controller
    {
        //
        // GET: /Weixin/


        public readonly string Token = "ShurikenWX";

        [HttpGet]
        [ActionName("Index")]
        public ActionResult Get(string signature, string timestamp, string nonce, string echostr)
        {           

            if (!CheckSignature.IsValid(signature, timestamp, nonce))
            {
                App_Start.LogConfig.SaveByKey("LocalSignature", CheckSignature.GetLocal());

                return Content("签名验证失败。");       

            }

            return Content(echostr);
             
        }


        [HttpPost]
        [ActionName("Index")]
        public ActionResult Post(string signature, string timestamp, string nonce, string echostr)
        {
            if (!CheckSignature.IsValid(signature, timestamp, nonce, echostr))
            {
                return Content("无效的签名值: " + signature + "。");  
            }

            return Content(string.Empty);
        }
    }

}
