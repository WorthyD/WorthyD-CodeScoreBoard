using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WorthyD.CodeScoreBoard.WebUI.Extensions;

namespace WorthyD.CodeScoreBoard.WebUI.Models
{
    public class ProjectSnapShot
    {
        public List<ProjectStats> Projects { get; set; }


        public ProjectSnapShot(List<DataAccess.Models.Project> projects)
        {
            this.Projects = new List<ProjectStats>();
            foreach (var t in projects)
            {
                this.Projects.Add(new ProjectStats(t));
            }

        }

        public class ProjectStats
        {
            public string ProjectName { get; set; }

            public List<CodeType> CodeTypes { get; set; }

            public ProjectStats(DataAccess.Models.Project p)
            {
                this.ProjectName = p.ProjectDetails;

                var stats = p.CodeLogs;

                var projType = p.PrimaryLanguages.Split(',').ToList();

                var mainTypes = stats.Where(x => projType.Contains(x.Language)).ToList();
                var subTypes = stats.Where(x => !projType.Contains(x.Language)).ToList();

                this.CodeTypes = new List<CodeType>();

                foreach (var t in projType)
                {
                    if (!string.IsNullOrEmpty(t))
                    {
                        CodeType ct = new CodeType();
                        ct.CodeName = t;
                        ct.DateAndCounts = new List<KeyValuePair<long, int>>();

                        var collectedData = mainTypes.Where(x => x.Language == t).OrderBy(x => x.LogTime).ToList();
                        foreach (var cd in collectedData)
                        {
                            long ticks = cd.LogTime.Ticks;

                            ct.DateAndCounts.Add(new KeyValuePair<long, int>(cd.LogTime.ToJavascriptTimestamp(), cd.CodeLines));

                        }

                        this.CodeTypes.Add(ct);
                    }
                }


            }

            public class CodeType
            {
                public string CodeName { get; set; }
                public List<KeyValuePair<long, int>> DateAndCounts { get; set; }
            }

        }
    }
}