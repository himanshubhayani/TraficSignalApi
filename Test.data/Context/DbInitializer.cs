using Microsoft.EntityFrameworkCore;
using System.IO;
using System;

namespace Test.data
{
    public static class DbInitializer
    {
        public static void Initialize(TestContext context)
        {
            var exists = new DatabaseChecker().DatabaseExists(context);

            if (exists == DatabaseExistenceState.Exists)
            {
                try
                {
                    context.Database.EnsureCreated();

                    //Entity Insert
                    // context.Database.ExecuteSqlCommand(File.ReadAllText("../Test.data/SqlScript/DateTimeToUNIX.sql"));
                    // context.Database.ExecuteSqlCommand(File.ReadAllText("../Test.data/SqlScript/GetSearchErrorLog.sql"));
                    // context.Database.ExecuteSqlCommand(File.ReadAllText("../Test.data/SqlScript/GetClientSurveyForTree.sql"));
                    // context.Database.ExecuteSqlCommand(File.ReadAllText("../Test.data/SqlScript/GetSearchUsers.sql"));
                    // context.Database.ExecuteSqlCommand(File.ReadAllText("../Test.data/SqlScript/GetSearchClient.sql"));
                    // context.Database.ExecuteSqlCommand(File.ReadAllText("../Test.data/SqlScript/SendMailUserPasswordCreate.sql"));
                    // context.Database.ExecuteSqlCommand(File.ReadAllText("../Test.data/SqlScript/GetSeachUserActivityLog.sql"));
                    // context.Database.ExecuteSqlCommand(File.ReadAllText("../Test.data/SqlScript/GetSearchedEmailLog.sql"));
                    // context.Database.ExecuteSqlCommand(File.ReadAllText("../Test.data/SqlScript/SplitStrings.sql"));
                    // context.Database.ExecuteSqlCommand(File.ReadAllText("../Test.data/SqlScript/InsertDataToSurveyPage.sql"));
                    // context.Database.ExecuteSqlCommand(File.ReadAllText("../Test.data/SqlScript/GetSearchSurveys.sql"));
                    // context.Database.ExecuteSqlCommand(File.ReadAllText("../Test.data/SqlScript/GetSearchLanguage.sql"));
                    // context.Database.ExecuteSqlCommand(File.ReadAllText("../Test.data/SqlScript/GetSearchQuestionBank.sql"));
                    // context.Database.ExecuteSqlCommand(File.ReadAllText("../Test.data/SqlScript/GetSearchHris.sql"));
                    // context.Database.ExecuteSqlCommand(File.ReadAllText("../Test.data/SqlScript/DeleteHRIS.sql"));
                    // context.Database.ExecuteSqlCommand(File.ReadAllText("../Test.data/SqlScript/GetRawDataByHRISId.sql"));
                    // context.Database.ExecuteSqlCommand(File.ReadAllText("../Test.data/SqlScript/SaveNewHRISRawData.sql"));
                    // context.SaveChanges();
                }
                catch (Exception ex)
                {
                    //This exception will be thrown if the model has changed
                    //if the context model has changed, then run migrations
                    //runAppMigrations(context);
                }
            }
            else
            {
                context.Database.EnsureCreated();
            }
        }
    }
}