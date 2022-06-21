namespace Jumbotron.Models
{
    public partial class Tparpkg
    {
        public string PkgTckNr { get; set; } = null!;
        public string ParIr { get; set; } = null!;
        public string EamIr { get; set; } = null!;
        public string SvcTypCd { get; set; } = null!;
        public DateTime EvtTs { get; set; }
        public DateTime RecUdtTs { get; set; }
        public DateTime OubSrtDt { get; set; }
        public DateTime DatXtcTs { get; set; }
        public string OubSrtTypCd { get; set; } = null!;
    }
}
