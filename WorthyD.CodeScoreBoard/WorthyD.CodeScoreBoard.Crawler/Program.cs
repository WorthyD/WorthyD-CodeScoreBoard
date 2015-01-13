using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using WorthyD.CodeScoreBoard.DataAccess;

namespace WorthyD.CodeScoreBoard.Crawler {
    class Program {
        static void Main(string[] args) {
            string file = "cloc --exclude-dir=.nuget,packages,scripts D:\\Dev\\WorthyD-LiveCodeCounter --csv --quiet";

            string cmd = ExecuteCommand(file);
            List<string> rows = cmd.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None).ToList();


            //var projects = new List<WorthyD.CodeScoreBoard.DataAccess.Models.Project>{
            //    new WorthyD.CodeScoreBoard.DataAccess.Models.Project(){ ProjectDetails="Code Counter", ProjectPath="D:\\Dev\\WorthyD-LiveCodeCounter "}
            //};
            //projects.ForEach(p => context.Projects.Add(p));
            //var count = context.Projects.Count();

            ProcessRows(rows);

            //Console.WriteLine(count);
            Console.WriteLine(cmd);
            Console.ReadKey();
        }

        public static void ProcessRows(List<string> rows) {
            List<DataAccess.Models.CodeLog> logs = new List<DataAccess.Models.CodeLog>();

            CodeScoreBoardContext context = new CodeScoreBoardContext();
            foreach (var row in rows) {
                string[] parts = row.Split(',');
                int fileCount = 0;

                //CSV output is bringing in blank lines. We don't care about the header row.
                if (parts.Length != 0 && int.TryParse(parts[0], out fileCount)) {
                    try {
                        DataAccess.Models.CodeLog logItem = new DataAccess.Models.CodeLog();
                        logItem.FileCount = fileCount;
                        logItem.Language = parts[1];
                        logItem.BlankLines = int.Parse(parts[2]);
                        logItem.CommentLines = int.Parse(parts[3]);
                        logItem.CodeLines = int.Parse(parts[4]);

                        logItem.LogTime = DateTime.Now;//Refine this to be by 5 minutes
                        logItem.ProjectID = 1;

                        logs.Add(logItem);
                    } catch (Exception e) {
                        Console.WriteLine(e.Message);

                    }

                }

            }
            logs.ForEach(l => context.CodeLogs.Add(l));
            context.SaveChanges();
        }

        static string ExecuteCommand(string command) {
            int exitCode;
            ProcessStartInfo processInfo;
            Process process;

            processInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
            processInfo.CreateNoWindow = true;
            processInfo.UseShellExecute = false;
            // *** Redirect the output ***
            processInfo.RedirectStandardError = true;
            processInfo.RedirectStandardOutput = true;

            process = Process.Start(processInfo);
            process.WaitForExit();

            // *** Read the streams ***
            string output = process.StandardOutput.ReadToEnd();
            string error = process.StandardError.ReadToEnd();

            exitCode = process.ExitCode;

            Console.WriteLine("output>>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
            Console.WriteLine("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
            Console.WriteLine("ExitCode: " + exitCode.ToString(), "ExecuteCommand");
            process.Close();
            return output;
        }
    }
}
