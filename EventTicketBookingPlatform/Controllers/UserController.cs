using EventTicketBookingPlatform.Models;
using EventTicketBookingPlatform.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace EventTicketBookingPlatform.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IJwtService _jwtService;
        private readonly ITokenService _tokenService;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, ApplicationDbContext context, IJwtService jwtService, ITokenService tokenService, IUserService userService)
        {
            _logger = logger;
            _context = context;
            _tokenService = tokenService;
            _jwtService = jwtService;
            _userService = userService;
        }

        [HttpPost("Registration")]
        public IActionResult UserRegistration( UserRegistrationRequest userRegistrationRequest)
        {
            // Проверка проверки запроса на регистрацию пользователя
            if (!ModelState.IsValid)
            {
                return BadRequest("Некорректные данные пользователя");
            }
            // Создаем новый объект пользователя с предоставленными регистрационными данными
            var newUser = new Users
            {
                Username = userRegistrationRequest.Username,
                Email = userRegistrationRequest.Email,
                UserPassword = userRegistrationRequest.UserPassword,
            };
            // Добавляем нового пользователя в базу данных
            _context.Users.Add(newUser);
            _context.SaveChanges();
            // Генерируем токен JWT для нового пользователя
            var tokenString = _jwtService.GenerateToken(newUser);
            _tokenService.Token = tokenString;

            return Ok($"Вы успешно зарегистрированы! Добро пожаловать,  {newUser.Username}!");
        }

        [HttpPost("EditData")]
        // Извлекаем идентификатор пользователя из токена JWT
        public IActionResult EditUser( UserRegistrationRequest userUpdateRequest)
        {
            int userId = ExtractUserIdFromToken(_tokenService.Token);
            // Находим существующего пользователя в базе данных
            var existingUser = _context.Users.FirstOrDefault(u => u.Userid == userId);
            if (existingUser == null)
            {
                return NotFound("Пользователь не найден");
            }
            // Обновляем данные пользователя новыми значениями
            existingUser.Username = userUpdateRequest.Username;
            existingUser.UserPassword = userUpdateRequest.UserPassword;
            existingUser.Email = userUpdateRequest.Email;

            // Сохраняем изменения в базе данных
            _context.SaveChanges();

            return Ok($"Данные пользователя {existingUser.Username} успешно обновлены");
        }
        // Возвращаем сообщение об успехе с обновленным именем пользователя

        [HttpPost("Delete")]
        public IActionResult DeleteUser( UserDeleteRequest userDeleteRequest)
        {
            // Извлекаем идентификатор пользователя из токена JWT
            int userId = ExtractUserIdFromToken(_tokenService.Token);
            // Находим существующего пользователя в базе данных
            var existingUser = _context.Users.FirstOrDefault(u => u.Userid == userId);
            if (existingUser == null)
            {
                return NotFound("Пользователь не найден");
            }
            // Проверяем, совпадают ли предоставленные пароли
            if (existingUser.UserPassword != userDeleteRequest.Password || existingUser.UserPassword != userDeleteRequest.ConfirmPassword)
            {
                return BadRequest("Пароли не совпадают");
            }
            // Удаляем пользователя из базы данных
            _context.SaveChanges();


            return Ok($"Пользователь {existingUser.Username} успешно удален");
        }

        private int ExtractUserIdFromToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var decodedToken = tokenHandler.ReadJwtToken(token);

            var userIdClaim = decodedToken.Claims.FirstOrDefault(c => c.Type == "sub");
            if (userIdClaim != null && int.TryParse(userIdClaim.Value, out int userId))
            {
                return userId;
            }

            throw new InvalidOperationException("Unable to extract user id from token.");
        }
    }
}
