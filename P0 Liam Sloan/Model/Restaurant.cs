using System.Collections.Generic;

namespace Model
{
    public class Restaurant
    {
        public Restaurant()
        {
            Reviews = new HashSet<Review>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Zipcode { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}