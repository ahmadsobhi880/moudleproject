using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using IdintityProject.Models;
namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void UserRequestsTest()
        {
            var p = new UserRequestsModel();
        }




        [TestMethod]
        public void HomeTest()
        {
            var p = new HomeWorksModel { homeworkFile = "1", homeworkName = "1" };
        }


        [TestMethod]
        public void GradesTest()
        {
            var p = new GradesModel { Course_Name="java", Student_Name="bb",Mygrade="67" };
        }
        [TestMethod]
        public void CoursesTest()
        {
            var p = new CourseModel { CourseDescription="asdasd",   Teacher_Course="mhmd"};
        }
        [TestMethod]
        public void StudentReqTest()
        {
            var p = new StudentRequest
            {
                 EmailRequest = "wasme@gmail.com",
                  RequestStatus="approval",
                   SubjectName= " change time",
                    UserNameRequest="foze"
            };
        }
        [TestMethod]
        public void AddNumberTest()
        {
            var p = new AddPhoneNumberViewModel();
        }

    }
}
