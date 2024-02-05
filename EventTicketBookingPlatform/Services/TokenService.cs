using System;
namespace EventTicketBookingPlatform.Services
{
    public interface ITokenService
    {
        /// Интерфейс управления токеном, используемым для аутентификации
        string Token { get; set; }
    }
    /// Реализация интерфейса сервиса токенов.
    public class TokenService : ITokenService
    {
        private string _token;
        /// Токен аутентификации.
        public string Token
        {
            get => _token;
            set => _token = value;
        }
    }
}