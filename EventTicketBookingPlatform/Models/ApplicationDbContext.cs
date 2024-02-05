using System;
using EventTicketBookingPlatform.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EventTicketBookingPlatform.Models
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

		public DbSet<Users> Users { get; set; }
		public DbSet<Eevent> Event { get; set; }
		public DbSet<EeventOrganizer> EventOrganizer { get; set; }
		public DbSet<Tickets> Tickets { get; set; }
	
		// Пример метода для выборки пользователей по имени
		public Users GetUserByName(string username)
		{
			return Users.FirstOrDefault(u => u.Username == username);
		}

		// Пример метода для вставки нового пользователя
		public void AddUser(Users user)
		{
			Users.Add(user);
			SaveChanges();
		}

		// Другие методы можно реализовать аналогично для других сущностей
	}
}