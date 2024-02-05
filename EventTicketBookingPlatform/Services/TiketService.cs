using EventTicketBookingPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using System.IdentityModel.Tokens.Jwt;

namespace EventTicketBookingPlatform.Services
{
    public interface ITiketService
    {
        IEnumerable<Tickets> GetAllTickets();
        IEnumerable<Tickets> GetAllUserTickets();
        IEnumerable<Tickets> GetAllCurrentEventTickets(int eventId);
        void AddTicket(int ticketId);
        void RemoveTicket(int ticketId);
    }

    public class TiketService : ITiketService
    {
        private readonly ApplicationDbContext _zxc;
        private readonly ITokenService _qwerty;

        public TiketService(ApplicationDbContext zxc, ITokenService qwerty)
        {
            _zxc = zxc;
            _qwerty = qwerty;
        }

        public void AddTicket(int ticketId)
        {
            // Получаем билет по идентификатору
            var ticket = _zxc.Tickets.Find(ticketId);
            if (ticket != null)
            {
                // Устанавливаем новый идентификатор билета
                ticket.TicketId = 1000 + ticketId;
                // Извлекаем идентификатор пользователя из токена
                ticket.Userid = ExtractUserIdFromToken();
                ticket.TicketStatus = "purchased";
                ticket.PurchaseDate = DateTime.Now;
                // Добавляем билет в контекст базы данных и сохраняем изменения
                _zxc.Tickets.Add(ticket);
                _zxc.SaveChanges();
            }
        }

        public IEnumerable<Tickets> GetAllCurrentEventTickets(int eventId)
        {
            // Возвращаем все билеты для указанного события
            return _zxc.Tickets.Where(c => c.EventId == eventId);
        }

        public IEnumerable<Tickets> GetAllTickets()
        {
            // Возвращаем все билеты
            return _zxc.Tickets;
        }

        public IEnumerable<Tickets> GetAllUserTickets()
        {
            // Возвращаем все билеты пользователя, извлекая идентификатор пользователя из токена
            return _zxc.Tickets.Where(c => c.Userid == ExtractUserIdFromToken()).ToList();
        }
        public void RemoveTicket(int ticketId)
        {
            // Получаем билет по идентификатору
            var ticket = _zxc.Tickets.Find(ticketId);
            if (ticket != null)
            {
                // Удаляем билет из контекста базы данных и сохраняем изменения
                _zxc.Tickets.Remove(ticket);
                _zxc.SaveChanges();
            }
        }

        private int ExtractUserIdFromToken()
        {
            // Извлекаем идентификатор пользователя из токена
            var tokenHandler = new JwtSecurityTokenHandler();
            var decodedToken = tokenHandler.ReadJwtToken(_qwerty.Token);

            var userIdClaim = decodedToken.Claims.FirstOrDefault(c => c.Type == "sub");
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                return userId;
            }

            throw new InvalidOperationException("Unable to extract user id from token.");
        }
    }
}
