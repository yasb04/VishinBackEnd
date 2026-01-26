namespace backend_api.Data.Models;

public record FraudRequest(string Message, string? PhoneNumber, string? Email);