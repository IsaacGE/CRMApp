namespace CRMApi.DataObjectModels
{
    public class RequestModel
    {
        public int? ParamString { get; set; }
        public int? ParamInt { get; set; }
        public dynamic? ParamObject { get; set; }
        public string? Token { get; set; }
    }
}
