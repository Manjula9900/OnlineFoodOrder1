using NUnit.Framework.Interfaces;
using OnlinefoododeringFramewoek.GenericUtilityFolder;
using OnlinefoododeringFramewoek.POM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlinefoododeringFramewoek.Test
{
    [Parallelizable(ParallelScope.Self)]
    public class RunnerClass : BaseClass
    {
        [Test, TestCaseSource("AddTestDataConfig"),Ignore("igore")]
        [Parallelizable(ParallelScope.Children)]
        public void Register(string username, string firstname, string lastname, string email, string phno, string pass, string cpass, string deliveryadd)
        {
            RegisterPage r = new RegisterPage(driver);
            r.EnterUserName(username, firstname, lastname, email, phno, pass, cpass, deliveryadd);
        }
        public static IEnumerable<TestCaseData> AddTestDataConfig()
        {
            var dataParser = getDataParser();
            yield return new TestCaseData(
             dataParser.ExtractData("username"),
             dataParser.ExtractData("first_name"),
             dataParser.ExtractData("last_name"),
             dataParser.ExtractData("email_address"),
             dataParser.ExtractData("phone_number"),
             dataParser.ExtractData("password"),
             dataParser.ExtractData("confirm_password"),
             dataParser.ExtractData("delivery_address")
         );

        }
        [Test, TestCaseSource("PassingDatatoUser")]
        [Parallelizable(ParallelScope.Children)]
        public void UserLogin(string UserName, string UserPass)
        {
            UserMenuPage u=new UserMenuPage(driver);
           
            u.ClickONLogBtn().Click();
            u.Login(UserName, UserPass);
            u.ClickONRestoBtn();
            u.Run().Click();
            u.AddCartBtn().Click();
            u.CheckoutBtn().Click();
            u.CashonButton().Click();
            u.OrderButton().Click();
        }
       public static IEnumerable<TestCaseData> PassingDatatoUser()
        {
            var dataParser = getDataParser();
            yield return new TestCaseData(
             dataParser.ExtractData("UserNameLogin"),
             dataParser.ExtractData("Password")
            
         );

        }
    }
}
