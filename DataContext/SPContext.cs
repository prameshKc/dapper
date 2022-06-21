using Jumbotron.Models;
using Microsoft.EntityFrameworkCore;

namespace Jumbotron.DataContext
{
    public partial class SPContext : DbContext
    {
        public SPContext()
        {
        }

        public SPContext(DbContextOptions<SPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tcrilvl> Tcrilvls { get; set; } = null!;
        public virtual DbSet<Tdashbrd> Tdashbrds { get; set; } = null!;
        public virtual DbSet<Tlocblt> Tlocblts { get; set; } = null!;
        public virtual DbSet<Tlocetum> Tloceta { get; set; } = null!;
        public virtual DbSet<Tlocgrp> Tlocgrps { get; set; } = null!;
        public virtual DbSet<Tparpkg> Tparpkgs { get; set; } = null!;
        public virtual DbSet<Tscanloc> Tscanlocs { get; set; } = null!;
        public virtual DbSet<Tspaloc> Tspalocs { get; set; } = null!;
        public virtual DbSet<Tsvccd> Tsvccds { get; set; } = null!;
        public virtual DbSet<Tsvclvl> Tsvclvls { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tcrilvl>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TCRILVL");

                entity.Property(e => e.CsvcDesc)
                    .IsUnicode(false)
                    .HasColumnName("CSVC_DESC");

                entity.Property(e => e.CsvcLvl)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("CSVC_LVL");
            });

            modelBuilder.Entity<Tdashbrd>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TDASHBRD");

                entity.Property(e => e.ActlRte)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ACTL_RTE");

                entity.Property(e => e.BltClr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("BLT_CLR");

                entity.Property(e => e.ParEam)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PAR_EAM");

                entity.Property(e => e.PlnRte)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PLN_RTE");

                entity.Property(e => e.ShpNum)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SHP_NUM");

                entity.Property(e => e.SnObjTckNr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("SN_OBJ_TCK_NR");
            });

            modelBuilder.Entity<Tlocblt>(entity =>
            {
                entity.HasKey(e => e.DvcLoc)
                    .HasName("PK__TLOCBLT__992AB1616E018520");

                entity.ToTable("TLOCBLT");

                entity.Property(e => e.DvcLoc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DVC_LOC");

                entity.Property(e => e.BltClr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("BLT_CLR");
            });

            modelBuilder.Entity<Tlocetum>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TLOCETA");

                entity.Property(e => e.DstLoc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DST_LOC");

                entity.Property(e => e.Eta)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("ETA");

                entity.Property(e => e.SrcLoc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SRC_LOC");
            });

            modelBuilder.Entity<Tlocgrp>(entity =>
            {
                entity.HasKey(e => e.LocationId)
                    .HasName("PK__TLOCGRP__D2BA00C2805E7017");

                entity.ToTable("TLOCGRP");

                entity.Property(e => e.LocationId).HasColumnName("Location_ID");

                entity.Property(e => e.CnyCd)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("CNY_CD");

                entity.Property(e => e.DevLocDes)
                    .IsUnicode(false)
                    .HasColumnName("DEV_LOC_DES");

                entity.Property(e => e.DevLocGrpDes)
                    .IsUnicode(false)
                    .HasColumnName("DEV_LOC_GRP_DES");

                entity.Property(e => e.DevLocGrpId).HasColumnName("DEV_LOC_GRP_ID");

                entity.Property(e => e.DevLocGrpTxt)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DEV_LOC_GRP_TXT");

                entity.Property(e => e.DevLocTxt)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DEV_LOC_TXT");

                entity.Property(e => e.OgzNr)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("OGZ_NR");

                entity.Property(e => e.OubSrtTypCd)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("OUB_SRT_TYP_CD")
                    .HasDefaultValueSql("('06')");

                entity.Property(e => e.RecCrtTs)
                    .HasColumnName("REC_CRT_TS")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Tparpkg>(entity =>
            {
                entity.HasKey(e => e.PkgTckNr)
                    .HasName("PK__TPARPKG__E22DF9D1555E0494");

                entity.ToTable("TPARPKG");

                entity.Property(e => e.PkgTckNr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("PKG_TCK_NR");

                entity.Property(e => e.DatXtcTs).HasColumnName("DAT_XTC_TS");

                entity.Property(e => e.EamIr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EAM_IR");

                entity.Property(e => e.EvtTs).HasColumnName("EVT_TS");

                entity.Property(e => e.OubSrtDt).HasColumnName("OUB_SRT_DT");

                entity.Property(e => e.OubSrtTypCd)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("OUB_SRT_TYP_CD");

                entity.Property(e => e.ParIr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PAR_IR");

                entity.Property(e => e.RecUdtTs).HasColumnName("REC_UDT_TS");

                entity.Property(e => e.SvcTypCd)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("SVC_TYP_CD");
            });

            modelBuilder.Entity<Tscanloc>(entity =>
            {
                entity.HasKey(e => new { e.EvtRqtSeqNr, e.Epc, e.DvcLoc, e.OubSrtDt, e.OubSrtTypCd, e.DvcMdlNr, e.DvcIp, e.BcdEvtTypCd })
                    .HasName("IScanObject");

                entity.ToTable("TSCANLOC");

                entity.HasIndex(e => e.EmpIdNr, "NonClusteredIndex-EmpId")
                    .HasFillFactor(80);

                entity.HasIndex(e => e.SnObjTckNr, "NonClusteredIndex-TckNr")
                    .HasFillFactor(80);

                entity.Property(e => e.EvtRqtSeqNr)
                    .HasMaxLength(32)
                    .IsUnicode(false)
                    .HasColumnName("EVT_RQT_SEQ_NR")
                    .HasComment("EventSequenceNr");

                entity.Property(e => e.Epc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EPC")
                    .HasComment("EncodedData");

                entity.Property(e => e.DvcLoc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DVC_LOC")
                    .HasComment("DeviceLocation");

                entity.Property(e => e.OubSrtDt)
                    .HasColumnName("OUB_SRT_DT")
                    .HasComment("OutboundSortDate");

                entity.Property(e => e.OubSrtTypCd)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("OUB_SRT_TYP_CD")
                    .HasComment("OutboundSortTypeCode");

                entity.Property(e => e.DvcMdlNr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DVC_MDL_NR")
                    .HasComment("DeviceModel");

                entity.Property(e => e.DvcIp)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("DVC_IP")
                    .HasComment("DeviceIpAddress");

                entity.Property(e => e.BcdEvtTypCd)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("BCD_EVT_TYP_CD")
                    .HasComment("Barcode Event Type Code");

                entity.Property(e => e.ActPkgRteNr)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("ACT_PKG_RTE_NR")
                    .HasComment("Actual ROUTE");

                entity.Property(e => e.BclRefTs)
                    .HasMaxLength(160)
                    .IsUnicode(false)
                    .HasColumnName("BCL_REF_TS")
                    .HasComment("BarcodeLabelRefTrackingString");

                entity.Property(e => e.DatXtcTs)
                    .HasColumnName("DAT_XTC_TS")
                    .HasComment("DataExtractTimestamp");

                entity.Property(e => e.DvcAntNr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DVC_ANT_NR")
                    .HasComment("DeviceAntennaNumber");

                entity.Property(e => e.EmpIdNr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EMP_ID_NR")
                    .HasComment("EmployeeIdNumber");

                entity.Property(e => e.EpcReadQy)
                    .HasColumnName("EPC_READ_QY")
                    .HasComment("EncodedDataReadCount");

                entity.Property(e => e.EpcStsCd)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("EPC_STS_CD")
                    .HasComment("EncodedDataStatusCode");

                entity.Property(e => e.EvtCd)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("EVT_CD")
                    .HasComment("EventCode");

                entity.Property(e => e.EvtTs)
                    .HasColumnName("EVT_TS")
                    .HasComment("ScanLocationEventTimeStamp");

                entity.Property(e => e.LblAplSeqNr)
                    .HasColumnName("LBL_APL_SEQ_NR")
                    .HasComment("Label Applicator Sequence Number");

                //entity.Property(e => e.BeltBayNr)
                //    .HasMaxLength(3)
                //    .IsUnicode(false)
                //    .HasColumnName("BELT_BAY_NR")
                //    .HasComment("Belt and Bay Number");

                entity.Property(e => e.Workarea)
                    .HasColumnName("WORKAREA")
                    .HasComment("WORK AREA");


                entity.Property(e => e.OubSrtQlfTe)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("OUB_SRT_QLF_TE")
                    .HasComment("OutboundSortQualificationText");

                entity.Property(e => e.PlnPkgRteNr)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("PLN_PKG_RTE_NR")
                    .HasComment("Plan Route");

                entity.Property(e => e.PlnPkgSpcNstTe)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("PLN_PKG_SPC_NST_TE")
                    .HasComment("Plan HIN");

                entity.Property(e => e.PriInstruction)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PRI_INSTRUCTION")
                    .HasComment("PrimaryInstruction");

                entity.Property(e => e.PslCd)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("PSL_CD")
                    .HasComment("DecodedPostalCode");

                entity.Property(e => e.RecCrtTs)
                    .HasColumnName("REC_CRT_TS")
                    .HasComment("RecordCreateTimeStamp");

                entity.Property(e => e.RecUdtTs)
                    .HasColumnName("REC_UDT_TS")
                    .HasComment("RecordUpdateTimeStamp");

                entity.Property(e => e.RssQy)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RSS_QY")
                    .HasComment("RSS");

                entity.Property(e => e.SnObjTckNr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("SN_OBJ_TCK_NR")
                    .HasComment("DecodedTrackingNumber");

                entity.Property(e => e.UloNr)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("ULO_NR")
                    .HasComment("Unit Load Device Number");

                entity.Property(e => e.Workarea)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("WORKAREA")
                    .HasComment("Workarea");
            });

            modelBuilder.Entity<Tspaloc>(entity =>
            {
                entity.HasKey(e => new { e.SnObjTckNr, e.OubSrtDt, e.OubSrtTypCd, e.EvtTs })
                    .HasName("ISPAScanObject");

                entity.ToTable("TSPALOC");

                entity.Property(e => e.SnObjTckNr)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("SN_OBJ_TCK_NR")
                    .HasComment("DecodedTrackingNumber");

                entity.Property(e => e.OubSrtDt)
                    .HasColumnName("OUB_SRT_DT")
                    .HasComment("OutboundSortDate");

                entity.Property(e => e.OubSrtTypCd)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("OUB_SRT_TYP_CD")
                    .HasComment("OutboundSortTypeCode");

                entity.Property(e => e.EvtTs)
                    .HasColumnName("EVT_TS")
                    .HasComment("ScanLocationEventTimeStamp");

                entity.Property(e => e.ActPkgRteNr)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("ACT_PKG_RTE_NR")
                    .HasComment("Actual ROUTE");

                entity.Property(e => e.BcdEvtTypCd)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("BCD_EVT_TYP_CD")
                    .HasComment("Barcode Event Type Code");

                entity.Property(e => e.BclUseTypCd)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("BCL_USE_TYP_CD")
                    .HasComment("ServiceLevelFromTrackingNumber");

                entity.Property(e => e.EmpIdNr)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("EMP_ID_NR")
                    .HasComment("EmployeeIdNumber");

                entity.Property(e => e.EvtCd)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("EVT_CD")
                    .HasComment("EventCode");

                entity.Property(e => e.OubSrtQlfTe)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("OUB_SRT_QLF_TE")
                    .HasComment("OutboundSortQualificationText");

                entity.Property(e => e.PlnPkgRteNr)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("PLN_PKG_RTE_NR")
                    .HasComment("Plan Route");

                entity.Property(e => e.PlnPkgSpcNstTe)
                    .HasMaxLength(9)
                    .IsUnicode(false)
                    .HasColumnName("PLN_PKG_SPC_NST_TE")
                    .HasComment("Plan HIN");

                entity.Property(e => e.PriInstruction)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PRI_INSTRUCTION")
                    .HasComment("PrimaryInstruction");

                entity.Property(e => e.PslCd)
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("PSL_CD")
                    .HasComment("DecodedPostalCode");

                entity.Property(e => e.RecCrtTs)
                    .HasColumnName("REC_CRT_TS")
                    .HasComment("RecordCreateTimeStamp");

                entity.Property(e => e.RecUdtTs)
                    .HasColumnName("REC_UDT_TS")
                    .HasComment("RecordUpdateTimeStamp");

                entity.Property(e => e.ShrAcNr)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SHR_AC_NR")
                    .HasComment("ShipperNumFromTrackingNumber");
            });

            modelBuilder.Entity<Tsvccd>(entity =>
            {
                entity.HasKey(e => e.SvcCd)
                    .HasName("PK__TSVCCD__B3373B7AF469C5C9");

                entity.ToTable("TSVCCD");

                entity.Property(e => e.SvcCd)
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("SVC_CD");

                entity.Property(e => e.SvcDes)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SVC_DES");
            });

            modelBuilder.Entity<Tsvclvl>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TSVCLVL");

                entity.Property(e => e.SvcDesc)
                    .IsUnicode(false)
                    .HasColumnName("SVC_DESC");

                entity.Property(e => e.SvcInc)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SVC_INC");

                entity.Property(e => e.SvcLvl)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("SVC_LVL");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
