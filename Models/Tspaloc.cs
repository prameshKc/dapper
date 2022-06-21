namespace Jumbotron.Models
{
    public partial class Tspaloc
    {
        /// <summary>
        /// DecodedTrackingNumber
        /// </summary>
        public string SnObjTckNr { get; set; } = null!;
        /// <summary>
        /// OutboundSortDate
        /// </summary>
        public DateTime OubSrtDt { get; set; }
        /// <summary>
        /// OutboundSortTypeCode
        /// </summary>
        public string OubSrtTypCd { get; set; } = null!;
        /// <summary>
        /// OutboundSortQualificationText
        /// </summary>
        public string OubSrtQlfTe { get; set; } = null!;
        /// <summary>
        /// ScanLocationEventTimeStamp
        /// </summary>
        public DateTime EvtTs { get; set; }
        /// <summary>
        /// EventCode
        /// </summary>
        public string EvtCd { get; set; } = null!;
        /// <summary>
        /// DecodedPostalCode
        /// </summary>
        public string PslCd { get; set; } = null!;
        /// <summary>
        /// RecordCreateTimeStamp
        /// </summary>
        public DateTime RecCrtTs { get; set; }
        /// <summary>
        /// RecordUpdateTimeStamp
        /// </summary>
        public DateTime RecUdtTs { get; set; }
        /// <summary>
        /// EmployeeIdNumber
        /// </summary>
        public string EmpIdNr { get; set; } = null!;
        /// <summary>
        /// PrimaryInstruction
        /// </summary>
        public string PriInstruction { get; set; } = null!;
        /// <summary>
        /// Barcode Event Type Code
        /// </summary>
        public string BcdEvtTypCd { get; set; } = null!;
        /// <summary>
        /// Plan HIN
        /// </summary>
        public string PlnPkgSpcNstTe { get; set; } = null!;
        /// <summary>
        /// Plan Route
        /// </summary>
        public string PlnPkgRteNr { get; set; } = null!;
        /// <summary>
        /// Actual ROUTE
        /// </summary>
        public string ActPkgRteNr { get; set; } = null!;
        /// <summary>
        /// ServiceLevelFromTrackingNumber
        /// </summary>
        public string BclUseTypCd { get; set; } = null!;
        /// <summary>
        /// ShipperNumFromTrackingNumber
        /// </summary>
        public string ShrAcNr { get; set; } = null!;
    }
}
