namespace CoalPassDAL.Abstractions
{
    public interface IPassword
    {
        string Id { get; set; }
        string Title { get; set; }
        string Username { get; set; }
        string Email { get; set; }
        string Pass { get; set; }
        string Website { get; set; }
        int Category { get; set; }
        string ImageUrl { get; set; }
    }
}