namespace WorkersProject.Model.Requests.Worker
{
    public class UpdateWorkerRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DocumentType { get; set; }
        public string DocumentNumber { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string? Photo { get; set; }
        public string Address { get; set; }
    }
}