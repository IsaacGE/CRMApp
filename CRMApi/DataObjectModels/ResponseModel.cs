namespace CRMApi.DataObjectModels
{
    public class ResponseModel
    {
        public int? StatusCode { get; set; }
        public string? Message { get; set; }
        public string? Title { get; set; }
        public string? Token { get; set; }
        public dynamic? ObjectResponse { get; set; }
    }
}
