namespace Jumbotron.Models
{
    public partial class Tlocgrp
    {
        public int LocationId { get; set; }
        public string? CnyCd { get; set; }
        public string? OgzNr { get; set; }
        public int? DevLocGrpId { get; set; }
        public string? DevLocGrpTxt { get; set; }
        public string? DevLocTxt { get; set; }
        public string OubSrtTypCd { get; set; } = null!;
        public string? DevLocGrpDes { get; set; }
        public string? DevLocDes { get; set; }
        public DateTime? RecCrtTs { get; set; }
    }
}
