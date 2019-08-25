namespace SmallSnack.Microservice.Domain.Responses
{
    public class UserAuthenticatedResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}