using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using WorthyD.CodeScoreBoard.WebUI.Extensions;

namespace WorthyD.CodeScoreBoard.WebUI.Models {
    public class ProjectSnapShot {
        public List<ProjectStats> Projects { get; set; }

        public ProjectSnapShot() {
            this.Projects = new List<ProjectStats>();
        }
        public ProjectSnapShot(List<DataAccess.Models.Project> projects) {
            this.Projects = new List<ProjectStats>();
            foreach (var t in projects) {
                this.Projects.Add(new ProjectStats(t));
            }

        }

        public static ProjectSnapShot GenerateDummyData() {
            ProjectSnapShot p = new ProjectSnapShot();

            p.Projects = new List<ProjectStats>();
            var rnd = new Random();
            List<string> codeTypes = new List<string> { "C#", "JavaScript", "HTML", "CSS", "VB", "XAML", "JAVA", "MVC" };
            List<DateTime> dates = new List<DateTime>() { 
                DateTime.Now.AddDays(-5), 
                DateTime.Now.AddDays(-4), 
                DateTime.Now.AddDays(-3), 
                DateTime.Now.AddDays(-2), 
                DateTime.Now.AddDays(-1), 
                DateTime.Now, 
            };
            for (var i = 0; i < 5; i++) {
                ProjectStats ps = new ProjectStats();

                ps.ProjectName = string.Format("Project {0}", i);

                var cts = codeTypes.OrderBy(x => Guid.NewGuid()).Take(3);

                foreach (var c in cts) {
                    ProjectStats.CodeType ct = new ProjectStats.CodeType();
                    ct.CodeName = c;
                    ct.DateAndCounts = new List<KeyValuePair<long, int>>();

                    var ti = 1;
                    foreach (var d in dates) {

                        ct.DateAndCounts.Add(new KeyValuePair<long, int>(d.ToJavascriptTimestamp(), (rnd.Next(100, 200) * ti)));

                        ti++;
                    }

                    ps.CodeTypes.Add(ct);
                }

                p.Projects.Add(ps);

            }
            return p;


        }




        public class ProjectStats {
            public string ProjectName { get; set; }

            public List<CodeType> CodeTypes { get; set; }

            public ProjectStats() {
                this.ProjectName = string.Empty;
                this.CodeTypes = new List<CodeType>();
            }

            public ProjectStats(DataAccess.Models.Project p) {
                this.ProjectName = p.ProjectDetails;

                var stats = p.CodeLogs;

                var projType = p.PrimaryLanguages.Split(',').ToList();

                var mainTypes = stats.Where(x => projType.Contains(x.Language)).ToList();
                var subTypes = stats.Where(x => !projType.Contains(x.Language)).ToList();

                this.CodeTypes = new List<CodeType>();

                foreach (var t in projType) {
                    if (!string.IsNullOrEmpty(t)) {
                        CodeType ct = new CodeType();
                        ct.CodeName = t;
                        ct.DateAndCounts = new List<KeyValuePair<long, int>>();

                        var collectedData = mainTypes.Where(x => x.Language == t).OrderBy(x => x.LogTime).ToList();
                        foreach (var cd in collectedData) {
                            long ticks = cd.LogTime.Ticks;

                            ct.DateAndCounts.Add(new KeyValuePair<long, int>(cd.LogTime.ToJavascriptTimestamp(), cd.CodeLines));

                        }

                        this.CodeTypes.Add(ct);
                    }
                }


            }

            public class CodeType {
                public string CodeName { get; set; }
                public List<KeyValuePair<long, int>> DateAndCounts { get; set; }
            }

        }
    }
}