using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeBlogFitness.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void SetNewUserDataTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();
            var birthDate = DateTime.Now.AddYears(- 18);
            var weight = 70;
            var height = 170;
            var gender = "man";
            var controller = new UserController(userName);

            // Act
            controller.SetNewUserData(gender, birthDate, weight, height);
            var controller2 = new UserController(userName);

            // Assert
            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(birthDate, controller2.CurrentUser.BirthDate);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Height);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.Name);
        }

        [TestMethod()]
        public void SaveTest()
        {
            // Arrange - объявление - здесь задаются данные, которые подаются на вход и те, которые будут ожидаться на выходе
            var userName = Guid.NewGuid().ToString();

            // Act - действие, когда мы вызываем что-то
            var controller = new UserController(userName);

            // Assert - когда мы проверяем то, что получилось и то, что ожидалось
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }
    }
}