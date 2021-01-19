using Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Common.WebEntity;

namespace StatisticalAnalysis.Controllers.StatisticalAnalysis
{
    public class ActivityController : Controller
    {
        public JsonR Index()
        {
            return Common.ComEnum.Code.A_操作失败.JsonR();
        }
    }
}
