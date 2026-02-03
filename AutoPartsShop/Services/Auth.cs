using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoPartsShop.Dtos;
using AutoPartsShop.Entities;
using AutoPartsShop.Exceptions;
using AutoPartsShop.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace AutoPartsShop.Services
{
    public interface IAuthService
    {
        public Task<AuthResponse> RegisterAsync(RegisterRequest request);
        public Task<AuthResponse> LoginAsync(LoginRequest request);
    }

    public class AuthService : IAuthService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IPasswordHasher<CustomerEntity> _passwordHasher;
        private readonly IConfiguration _configuration;

        public AuthService(
            ICustomerRepository customerRepository,
            IPasswordHasher<CustomerEntity> passwordHasher,
            IConfiguration configuration
        )
        {
            _customerRepository = customerRepository;
            _passwordHasher = passwordHasher;
            _configuration = configuration;
        }

        public async Task<AuthResponse> RegisterAsync(RegisterRequest request)
        {
            var email = request.Email.Trim().ToLowerInvariant();
            var existing = await _customerRepository.GetCustomerByEmailAsync(email);
            if (existing != null)
            {
                throw new BadRequestException("Email already registered.");
            }

            var customer = new CustomerEntity
            {
                Email = email,
                Phone = request.Phone,
                IsAdmin = request.IsAdmin
            };

            customer.PasswordHash = _passwordHasher.HashPassword(customer, request.Password);
            await _customerRepository.AddCustomerAsync(customer);

            return new AuthResponse(customer.Id, customer.Email, customer.IsAdmin, CreateToken(customer));
        }

        public async Task<AuthResponse> LoginAsync(LoginRequest request)
        {
            var email = request.Email.Trim().ToLowerInvariant();
            var customer = await _customerRepository.GetCustomerByEmailAsync(email);
            if (customer == null || customer.PasswordHash == null)
            {
                throw new BadRequestException("Invalid credentials.");
            }

            var result = _passwordHasher.VerifyHashedPassword(customer, customer.PasswordHash, request.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new BadRequestException("Invalid credentials.");
            }

            return new AuthResponse(customer.Id, customer.Email, customer.IsAdmin, CreateToken(customer));
        }

        private string CreateToken(CustomerEntity customer)
        {
            var key = _configuration["Jwt:Key"] ?? throw new InvalidOperationException("Jwt:Key missing");
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var expMinutes = int.TryParse(_configuration["Jwt:ExpMinutes"], out var mins) ? mins : 480;

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, customer.Id.ToString()),
                new Claim(ClaimTypes.Email, customer.Email),
                new Claim(ClaimTypes.Role, customer.IsAdmin ? "Admin" : "User")
            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var creds = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                issuer,
                audience,
                claims,
                expires: DateTime.UtcNow.AddMinutes(expMinutes),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
