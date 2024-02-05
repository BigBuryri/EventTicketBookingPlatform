using EventTicketBookingPlatform.Models;
using System;
using System.Linq;

namespace EventTicketBookingPlatform.Services
{
    public interface IUserService
    {
        // Метод для аутентификации пользователя по электронной почте и паролю
        Users Authenticate(string email, string password);
        // Метод для получения пользователя по идентификатору
        Users GetById(int id);
    }

    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Users Authenticate(string email, string password)
        {
            // Ищем пользователя в базе данных по электронной почте и паролю
            var user = _context.Users.SingleOrDefault(x => x.Email == email && x.UserPassword == password);

            if (user == null)
                return null;

            // Аутентификация успешна
            return user;
        }

        public Users GetById(int id)
        {
            // Получаем пользователя из базы данных по идентификатору
            return _context.Users.Find(id);
        }

        public void UpdateUser(Users user)
        {
            // Обновляем пользователя в базе данных
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}
