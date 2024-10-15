﻿using Mailo.Data;
using Mailo.IRepo;
using Mailo.Models;

namespace Mailo.Repo
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext _db;
        public UnitOfWork(AppDbContext db)
        {
            _db = db;
			users=new BasicRepo<User>(_db);
			employees=new BasicRepo<Employee>(_db);
			orders=new BasicRepo<Order>(_db);
			products=new BasicRepo<Product>(_db);
			wishlists=new BasicRepo<Wishlist>(_db);
			reviews=new BasicRepo<Review>(_db);
			payments=new BasicRepo<Payment>(_db);
        }
		public IBasicRepo<User> users { get; private set; }
		public IBasicRepo<Employee> employees { get; private set; }
		public IBasicRepo<Order> orders { get; private set; }
		public IBasicRepo<Product> products { get; private set; }
		public IBasicRepo<Wishlist> wishlists { get; private set; }

		public IBasicRepo<Review> reviews { get; private set; }

		public IBasicRepo<Payment> payments { get; private set; }

		public int CommitChanges()
		{
			return _db.SaveChanges();
		}

		public void Dispose()
		{
			_db.Dispose();
		}
	}
}
