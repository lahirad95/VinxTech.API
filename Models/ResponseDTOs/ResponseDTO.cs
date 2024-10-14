namespace VinxTech.API.Models.ResponseDTOs
{
    public class ResponseDTO
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
        public List<string> Errors { get; set; }
    }
}
