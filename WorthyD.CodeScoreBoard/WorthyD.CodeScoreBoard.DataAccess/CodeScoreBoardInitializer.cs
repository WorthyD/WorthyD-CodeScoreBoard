using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorthyD.CodeScoreBoard.DataAccess {
    public class CodeScoreBoardInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<CodeScoreBoardContext> {


        protected override void Seed(CodeScoreBoardContext context) {
            //var people = new List<Models.Person>{
            //    new Models.Person(){ FirstName="Daniel", LastName="Worthy",UserTokenId="D3 75 19 D0"},
            //    new Models.Person(){ FirstName="Jarrod", LastName="Ramsey",UserTokenId="D3 75 19 D1"},
            //    new Models.Person(){ FirstName="Tim", LastName="Velzy", UserTokenId="D3 75 19 D2"},
            //    new Models.Person(){ FirstName="John", LastName="Jacobsen", UserTokenId="D3 75 19 D3"}
            //};
            //people.ForEach(s => context.People.Add(s));
            var projects = new List<Models.Project>{
                new Models.Project(){ ProjectDetails="Code Counter", ProjectPath="D:\\Dev\\WorthyD-LiveCodeCounter "}
            };
            projects.ForEach(p => context.Projects.Add(p));
            context.SaveChanges();
        }
    }
}
