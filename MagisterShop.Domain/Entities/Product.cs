using System;
using System.Collections.Generic;
using System.Text;

namespace MagisterShop.Domain.Entities
{
    public class Product
    {
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public int Status { get; protected set; }
        public DateTime DateOfAddition { get; protected set; }
        public virtual User User { get; protected set; }

        protected Product() { }

        public Product(User user, string title, string description, int status = 1)
        {
            User = user;
            SetTitle(title);
            SetDescription(description);
            SetStatus(status);
        }

        public void SetTitle(string title)
        {
            if (title.Length > 30) throw new Exception();
            if (title.Length < 3) throw new Exception();
            Title = title;
        }

        public void SetDescription(string description)
        {
            if (description.Length > 500) throw new Exception();
            if (description.Length < 5) throw new Exception();
        }

        public void SetStatus(int status)
        {
            if (status != 1 | status != 0) throw new Exception();
            Status = status;
        }
    }
}
