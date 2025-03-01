using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Runtime.InteropServices.JavaScript.JSType;

/// <summary>
/// Definition of Document Object
/// </summary>
public class Document
{
    /// <summary>
    /// Id - int IDENTITY(1,1) - SQL generated ID
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    /// <summary>
    /// [FileName] - [nvarchar](250): Name of source PDF file
    /// </summary>
    public string? FileName { get; set; }
    /// <summary>
    /// [FullPath] - [nvarchar](250): Full path to the archived PDF file
    /// </summary>
    public string? FullPath { get; set; }

    /// <summary>
    /// [Date] - [smalldatetime]: When PDF file was received
    /// </summary>
    public DateTime? Date { get; set; }

    /// <summary>
    /// [Pages] - [int]: Number of pages in bank report
    /// </summary>
    public int? Pages { get; set; }
    /// <summary>
    /// [Format] - [nvarchar](250): Bank report format of the PDF
    /// </summary>
    public string? Format { get; set; }
    /// <summary>
    /// [AcctIdOthr] - [nvarchar](50): Account number in old format
    /// </summary>
    public string? AcctIdOthr { get; set; }
    /// <summary>
    /// [IBAN] - [nvarchar](50): Account format by IBAN standard
    /// </summary>
    public string? IBAN { get; set; }
    /// <summary>
    /// [AcctName] - [nvarchar](50): Account owner's name
    /// </summary>
    public string? AcctName { get; set; }
    /// <summary>
    /// [BIC] - [nvarchar](50): Bic bank code
    /// </summary>
    public string? BIC { get; set; }
    /// <summary>
    /// [FinInstId] - [nvarchar](50): Bank code in old format
    /// </summary>
    public string? FinInstId { get; set; }
    /// <summary>
    /// [Bank] - [nvarchar](250): Bank name
    /// </summary>
    public string? Bank { get; set; }
    /// <summary>
    /// [Currency] - [nvarchar](50): Currency on bank report
    /// </summary>
    public string? Currency { get; set; }
    /// <summary>
    /// [SeqNo] - [int]: Sequence number of periodic bank reports, can be daily, monthly, ...
    /// </summary>
    public int? SeqNo { get; set; }
    /// <summary>
    /// [IssueDate] - [smalldatetime]: Date of bank report issuing
    /// </summary>
    public DateTime? IssueDate { get; set; }
    /// <summary>
    /// [FrDtTm] - [smalldatetime]: Movments on account from date (inclusive) are on this bank report
    /// </summary>
    public DateTime? FrDtTm { get; set; }
    /// <summary>
    /// [ToDtTm] - [smalldatetime]: Movments on account until date (inclusive) are on this bank report
    /// </summary>
    public DateTime? ToDtTm { get; set; }
    /// <summary>
    /// [SumOpening] - [money]: Account balance before first listed transaction from this report (just successfull payments are registered)
    /// </summary>
    public decimal? SumOpening { get; set; }
    /// <summary>
    /// [SumClosing] - [money]: Account balance before after last listed transaction from this report (just successful payments are registered)
    /// </summary>
    public decimal? SumClosing { get; set; }
    /// <summary>
    /// [TotalNbOfNtries] - [int]: Total number of entries on this bank report
    /// </summary>
    public int? TotalNbOfNtries { get; set; }
    /// <summary>
    /// [TotalSum] - [money]: Absolut amount of money transferred over period of report ABS(Σdebet)+ABS(Σkredit)
    /// </summary>
    public decimal? TotalSum { get; set; }
    /// <summary>
    /// [TotalAmt] - [money]: Differential sum of transfers over period of report Σkredit-Σdebet
    /// </summary>
    public decimal? TotalAmt { get; set; }
    /// <summary>
    /// [CdtNbOfEntries] - [int]: Total number of credit entries on this bank report
    /// </summary>
    public int? CdtNbOfEntries { get; set; }
    /// <summary>
    /// [CdtSum] - [money]: Sum of all credit entrie's amounts on this bank report
    /// </summary>
    public decimal? CdtSum { get; set; }
    /// <summary>
    /// [DbtNbOfEntries] - [int]: Total number of debet entries on this bank report
    /// </summary>
    public int? DbtNbOfEntries { get; set; }
    /// <summary>
    /// [DbtSum] - [money]: Sum of all debet entrie's amounts on this bank report
    /// </summary>
    public decimal? DbtSum { get; set; }
    /// <summary>
    /// [XmlFile] - [nvarchar](250): Name of created XML file (located in the same folder as source PDF file)
    /// </summary>
    public string? XmlFile { get; set; }

}
