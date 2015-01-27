using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WorthyD.CodeScoreBoard.DataAccess;

namespace WorthyD.CodeScoreBoard.WebUI.Controllers
{
    public class StatsAPIController : ApiController
    {
        private  CodeScoreBoardContext context;

        public StatsAPIController()
        {
            context = new CodeScoreBoardContext();
        }
        public Models.ProjectSnapShot GetProjectStats()
        {
            return Models.ProjectSnapShot.GenerateDummyData();

            return new Models.ProjectSnapShot(context.Projects.Include("CodeLogs").ToList());
        }
    }
}
