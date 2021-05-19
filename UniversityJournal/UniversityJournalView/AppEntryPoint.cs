using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using UniversityJournalDb;
using UniversityJournalDb.Storages;

namespace UniversityJournalView
{
    public class AppEntryPoint
    {
        [STAThread]
        static void Main(string[] args)
        {
            string connectionStirng = null;
            foreach (ConnectionStringSettings conn in ConfigurationManager.ConnectionStrings)
            {
                if(conn.Name == "posgresql")
                {
                    connectionStirng = conn.ConnectionString;
                    break;
                }
            }
            UniversityJournalDbContext.SetConnectionString(connectionStirng);
            App a = new App();
            a.Exit += (o, e) => UniversityJournalDbContext.GetDbContext().Dispose();
            a.StartupUri = new Uri("/Views/StoragesWindow.xaml", UriKind.Relative);
            a.Run();
        }
    }
}
