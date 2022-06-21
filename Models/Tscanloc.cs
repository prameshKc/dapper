namespace Jumbotron.Models
{
    public partial class Tscanloc
    {
        /// <summary>
        /// EventSequenceNr
        /// </summary>
        public string EvtRqtSeqNr { get; set; } = null!;
        /// <summary>
        /// EncodedData
        /// </summary>
        public string Epc { get; set; } = null!;
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
        /// DeviceLocation
        /// </summary>
        public string DvcLoc { get; set; } = null!;
        /// <summary>
        /// DeviceModel
        /// </summary>
        public string DvcMdlNr { get; set; } = null!;
        /// <summary>
        /// DeviceIpAddress
        /// </summary>
        public string DvcIp { get; set; } = null!;
        /// <summary>
        /// DeviceAntennaNumber
        /// </summary>
        public string DvcAntNr { get; set; } = null!;
        /// <summary>
        /// EventCode
        /// </summary>
        public string EvtCd { get; set; } = null!;
        /// <summary>
        /// RSS
        /// </summary>
        public string RssQy { get; set; } = null!;
        /// <summary>
        /// EncodedDataStatusCode
        /// </summary>
        public string EpcStsCd { get; set; } = null!;
        /// <summary>
        /// EncodedDataReadCount
        /// </summary>
        public int EpcReadQy { get; set; }
        /// <summary>
        /// DecodedTrackingNumber
        /// </summary>
        public string SnObjTckNr { get; set; } = null!;
        /// <summary>
        /// BarcodeLabelRefTrackingString
        /// </summary>
        public string BclRefTs { get; set; } = null!;
        /// <summary>
        /// DecodedPostalCode
        /// </summary>
        public string PslCd { get; set; } = null!;
        /// <summary>
        /// ScanLocationEventTimeStamp
        /// </summary>
        public DateTime EvtTs { get; set; }
        /// <summary>
        /// DataExtractTimestamp
        /// </summary>
        public DateTime DatXtcTs { get; set; }
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
        public string EmpIdNr { get; set; }
        /// <summary>
        /// Workarea
        /// </summary>
        public string Workarea { get; set; } = null!;
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
        /// Unit Load Device Number
        /// </summary>
        public string UloNr { get; set; } = null!;
        /// <summary>
        /// Label Applicator Sequence Number
        /// </summary>
        public int LblAplSeqNr { get; set; }
        /// <summary>
        /// Belt and Bay Number
        /// </summary>
        //public string BeltBayNr { get; set; }=null!;

        


    }
}
