using BankAccountProject.Dtos.TokenDtos;

namespace BankAccountProject.Presentation.ApiConnection
{
    public class ApiResponse
    {
        public ResponseData Response { get; set; }
        public Message[] Messages { get; set; }
    }
}
