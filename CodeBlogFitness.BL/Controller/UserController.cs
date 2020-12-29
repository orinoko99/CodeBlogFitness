using CodeBlogFitness.BL.Model;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CodeBlogFitness.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь приложения. 
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Создание нового контроллера пользователя. 
        /// </summary>
        /// <param name="userName"> Имя. </param>
        /// <param name="genderName"> Пол. </param>
        /// <param name="birthDay"> Дата рождения. </param>
        /// <param name="weight"> Вес. </param>
        /// <param name="height"> Рост. </param>
        public UserController(string userName, string genderName, DateTime birthDay, double weight, double height)
        {
            // TODO: проверка 

            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDay, weight, height);
        }

        /// <summary>
        /// Создание нового контроллера пользователя без параметров. 
        /// </summary>
        public UserController()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }

                // TODO: что делать, если пользователя не прочитали?
            }
        }

        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using(var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }


    }
}