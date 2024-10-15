using Mailo.Models;

namespace Mailo.IRepo
{
	public interface IUnitOfWork : IDisposable
	{
		IBasicRepo<User> users {  get; }
		IBasicRepo<Employee> employees { get; }
		IBasicRepo<Order> orders { get; }
		IBasicRepo<Wishlist> wishlists { get; }
		IBasicRepo<Review> reviews { get; }
		IBasicRepo<Payment> payments { get; }
		int CommitChanges();

	}
}
