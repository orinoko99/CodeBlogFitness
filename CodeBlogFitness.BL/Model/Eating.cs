using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// Прием пищи
    /// </summary>
    [Serializable]
    public class Eating
    {
        /// <summary>
        /// Момент приема пищи
        /// </summary>
        public DateTime Moment { get; }

        /// <summary>
        /// Список продуктов
        /// </summary>
        public Dictionary<Food, double> Foods { get; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public User User { get; }

        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть пустым. ", nameof(user));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }

        public void Add(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

            if(product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }
        }
    }
}
