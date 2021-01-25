using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatisticalAnalysis.Controllers
{
    [Produces("application/json")] //返回数据的格式 直接约定为Json
    [EnableCors("UseCore")]   //跨域方案名称 可以在StartUp 内查看设置内容
    [Route("api/[controller]/[action]")]  //路由
    [AllowAnonymous]   //允许匿名访问
    //[ExecutedFilter]  // 业务程序处理完成之后 （存储访问日志 以及处理程序中的异常）
    public class BaseController : Controller
    {
        
    }
}
