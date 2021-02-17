﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MagisterShop.Domain.Entities
{
    public class Comment
    {
        public Guid Id { get; protected set; }
        public string Content { get; protected set; }
        public Guid ProductId { get; protected set; }
        public DateTime DateOfAddition { get; protected set; }

        public virtual User User { get; protected set; }

        protected Comment()
        {

        }
        public Comment(string content, User user, Product product)
        {
            Id = Guid.NewGuid();
            SetContent(content);
            User = user;
            ProductId = product.Id;
            DateOfAddition = DateTime.Now;
        }

        public void SetContent(string content)
        {
            if (content.Length < 20) throw new Exception();
            if (content.Length > 200) throw new Exception();
            Content = content;
        }
    }
}
