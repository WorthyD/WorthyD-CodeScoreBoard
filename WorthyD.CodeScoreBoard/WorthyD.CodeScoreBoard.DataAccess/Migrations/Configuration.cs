namespace WorthyD.CodeScoreBoard.DataAccess.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WorthyD.CodeScoreBoard.DataAccess.CodeScoreBoardContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "WorthyD.CodeScoreBoard.DataAccess.CodeScoreBoardContext";
        }

        protected override void Seed(WorthyD.CodeScoreBoard.DataAccess.CodeScoreBoardContext context)
        {

            context.Projects.AddOrUpdate(x => x.ProjectDetails, new Models.Project
            {
                ProjectPath = "C:\\Dev\\PersonalProjects\\WorthyD",
                ProjectDetails = "Win8 App",
                IgnoreRegex = "WorthyD's Project",
                PrimaryLanguages = "JS,CSS,C#"
            });


            context.Projects.AddOrUpdate(x => x.ProjectDetails, new Models.Project
            {
                ProjectPath = "C:\\Dev\\PersonalProjects\\steamapp",
                ProjectDetails = "Win8 App",
                IgnoreRegex = ".nuget,packages,scripts",
                PrimaryLanguages = "Xaml,C#"
            });




            context.SaveChanges();

        }
    }
}
