using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Data.Sqlite;
using MyWebsite.Models;
using static MyWebsite.DataAccess;

namespace MyWebsite.BusinessLogic
{
    public static class SpenderLogic
    {
        public static int CreateSpender(SpenderModels model)
        {
            using (SqliteConnection db = new SqliteConnection("DataSource=app.db"))
            {
                string query = @"INSERT INTO main.Spenders (Id, Nickname, SignupDate, Name) Values (@Id, @Nickname, @SignupDate, @Name);";
                return db.Execute(query, model);
            }
        }

        /// <summary>
        /// Checks if the user has registered in the spender section
        /// </summary>
        /// <param name="id">The id of the user to be checked</param>
        /// <returns></returns>
        public static bool HasSpenderRegistered(string id)
        {
            string query = "Select * from main.Spenders where Id = @Id";

            List<dynamic> result = QueryDb(query, new { Id = id }).AsList();

            return result.Count != 0;
        }

        /// <summary>
        /// Gets a list of all the categories associated with the given user id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<string> GetCategories(string id)
        {
            List<dynamic> result = QueryDb("SELECT Category FROM main.Categories WHERE Id = @Id", new { Id = id }).AsList();

            List<string> categories = new List<string>();

            foreach (dynamic row in result)
            {
                categories.Add(row.Category);
            }

            return categories;
        }

        public static void AddCategory(SpendingCategoryModel model)
        {
            ExecuteDb("INSERT INTO main.Categories (Id, Category) VALUES (@Id, @Category)", model);
        }

        public static void AddSpendingToDb(UserSpendingModel model)
        {
            ExecuteDb("INSERT INTO main.Spendings (Id, Category, Amount, Date) VALUES (@Id, @Category, @SpendingAmount, @Date)", model);
        }

        public static string GetNicknameById(string id)
        {
            string sql = "SELECT Nickname FROM main.Spenders WHERE Id = @Id";
            return DataAccess.QueryDb(sql, new { Id = id }).FirstOrDefault().Nickname;
        }

        public static List<UserSpendingModel> GetSpendings(string id)
        {
            string sql = "SELECT * FROM main.Spendings WHERE Id = @Id";

            List<dynamic> dyList = DataAccess.QueryDb(sql, new { Id = id }).AsList();

            List<UserSpendingModel> nuList = new List<UserSpendingModel>();

            foreach (dynamic var in dyList)
            {
                
                nuList.Add(new UserSpendingModel(double.Parse(var.Amount), var.Category.ToString(), var.Id.ToString(), var.Date.ToString()));
            }

            return nuList ;
        }

        public static double CalculateTotalSpending(List<UserSpendingModel> spendings)
        {
            double total = 0;
            foreach (UserSpendingModel spending in spendings)
            {
                total += spending.SpendingAmount;
            }

            return total;
        }

        public static List<CategoryStatistic> CalculateStatistics(List<UserSpendingModel> spendings, List<string> categories)
        {
            // Step 0: Convert data to date time objects
            for (int i = 0; i < spendings.Count; i++)
            {
                spendings[i].DateTime = DateTime.Parse(spendings[i].Date.Replace(" ", ""));
            }

            // Step 1: Calculate Totals
            double alltimeTotal = 0;
            foreach (UserSpendingModel spending in spendings)
            {
                alltimeTotal += spending.SpendingAmount;
            }
            
            // Filter out all spendings pre last week
            DateTime today = DateTime.Today;

            DateTime lastWeek = today.AddDays(-8);
            
            List<UserSpendingModel> lastWeekSpendings = new List<UserSpendingModel>();

            foreach (UserSpendingModel spending in spendings)
            {
                if (spending.DateTime > lastWeek)
                {
                    lastWeekSpendings.Add(spending);
                }
            }

            double lastWeekTotal = 0;

            foreach (UserSpendingModel spending in lastWeekSpendings)
            {
                lastWeekTotal += spending.SpendingAmount;
            }
            
            // Step 2: Add statistic object for each category
            
            List<CategoryStatistic> categoryStatistics = new List<CategoryStatistic>();

            foreach (string category in categories)
            {
                CategoryStatistic statistic = new CategoryStatistic();

                statistic.CategoryName = category;
                
                // Calculate absolute spending for this category
                double categoryTotal = 0;
                foreach (UserSpendingModel spending in spendings)
                {
                    if (spending.Category == statistic.CategoryName)
                    {
                        categoryTotal += spending.SpendingAmount;
                    }
                }

                double weeklyCategoryTotal = 0;
                foreach (UserSpendingModel spending in lastWeekSpendings)
                {
                    if (spending.Category == statistic.CategoryName)
                    {
                        weeklyCategoryTotal += spending.SpendingAmount;
                    }
                }

                statistic.TotalAbsolute = categoryTotal;
                statistic.WeeklyAbsolute = weeklyCategoryTotal;
                statistic.TotalPercentage = categoryTotal / alltimeTotal;
                statistic.WeeklyPercentage = weeklyCategoryTotal / lastWeekTotal;
                
                categoryStatistics.Add(statistic);

            }


            return categoryStatistics;
        }
    }
}