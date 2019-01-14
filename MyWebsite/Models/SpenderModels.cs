using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using static MyWebsite.BusinessLogic.SpenderLogic;

namespace MyWebsite.Models
{
    public class SpenderModels
    {
        public string Id { get; set; }

        [Required(ErrorMessage ="Please enter your nickname")]
        [MaxLength(15, ErrorMessage ="Please use a nickname 15 characters or less long")]
        public string Nickname { get; set; }

        public string Name { get; set; }

        public string SignupDate { get; set; }

        public SpenderModels(string id, string nickname, string name)
        {
            Name = name;

            Id = id;

            Nickname = nickname;

            SignupDate = DateTime.Now.ToShortDateString();
        }

        public SpenderModels()
        {
            
            SignupDate = DateTime.Now.ToShortDateString();
        }
    }

    public class UserSpendingModel
    {
        [Required(ErrorMessage = "Please input a value")]
        [Display(Name = "Amount Spent")]
        [DataType(DataType.Currency, ErrorMessage = "Please input a monetary value")]
        [Range(0.0, Double.MaxValue)]
        public double SpendingAmount { get; set; }

        public string Date { get; set; }

        public DateTime DateTime { get; set; }

        public string Category { get; set; }

        [Display(Name = "Category of Spending")]
        public IEnumerable<SelectListItem> SpendingCategories { get; set; }

        public string Id { get; set; }

        public UserSpendingModel()
        {
            Date = DateTime.Today.ToShortDateString();
        }

        public UserSpendingModel(double spendingAmount, string category, string id, string date)
        {
            SpendingAmount = spendingAmount;

            Category = category;

            Id = id;

            Date = date;
        }

    }

    public class SpendingCategoryModel
    {
        [Required(ErrorMessage ="Please input your category")]
        [MaxLength(50, ErrorMessage ="Categories cannot be more that 50 characters long")]
        public string Category { get; set; }

        public string Id { get; set; }

        public SpendingCategoryModel()
        {
           
        }  
    }

    public class SpenderStatModel
    {
        public List<CategoryStatistic> CategoryStats { get; set; }

        public string Nickname { get; set; }

        public double TotalSpending { get; set; }
        
        public string Id { get; set; }

        public SpenderStatModel(string id)
        {
            Nickname = GetNicknameById(id);

            List<UserSpendingModel> spendings = GetSpendings(id);

            TotalSpending = CalculateTotalSpending(spendings);

            List<string> categories = GetCategories(id);

            CategoryStats = CalculateStatistics(spendings, categories);
        }

        public SpenderStatModel()
        {

        }

 
    }

    public class CategoryStatistic
    {
        public string CategoryName { get; set; }

        public double WeeklyPercentage { get; set; }

        public double WeeklyAbsolute { get; set; }

        public double TotalPercentage { get; set; }

        public double TotalAbsolute { get; set; }

        public override string ToString()
        {
            return CategoryName;
        }
    }


}