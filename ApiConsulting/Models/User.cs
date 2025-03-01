using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.ComponentModel.DataAnnotations.Schema;

/// <summary>
/// Definition of User Object
/// </summary>
public class User
{
    /// <summary>
    /// Id - int IDENTITY(1,1) - SQL generated ID
    /// </summary>
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    /// <summary>
    /// ErpID - nvarchar(20) - Id in ERP software
    /// </summary>
    public string? ErpId { get; set; }
    /// <summary>
    /// FirstName - nvarchar(50) - User's first name
    /// </summary>
    public string? FirstName { get; set; }
    /// <summary>
    /// LastName - nvarchar(50) - User's last name
    /// </summary>
    public string? LastName { get; set; }
    /// <summary>
    /// Username - nvarchar(50) - Username for login
    /// </summary>
    public string? Username { get; set; }
    /// <summary>
    /// Password - nvarchar(50) - Password for login
    /// </summary>
    public string? Password { get; set; }
    /// <summary>
    /// Active - is user curently active
    /// </summary>
    public bool? Active { get; set; }
}

