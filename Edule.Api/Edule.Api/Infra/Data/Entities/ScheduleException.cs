using System.ComponentModel;

namespace Edule.Api.Infra.Data.Entities;

public class ScheduleException : BaseEntity 
{
    public DateTime Day { get; set; }
    public DateTime Begin { get; set; }
    public DateTime End { get; set; }
    public string Description { get; set; } = string.Empty;
    public EScheduleExceptionsFrequency? Frequency { get; set; }
    public DateTime? EndRecurrentDate { get; set; }
    public Schedule Schedule { get; set; } = null!;
}

public enum EScheduleExceptionsFrequency {
    [Description("diariamente")]
    Daily = 1,
    [Description("A cada semana")]
    Weekly = 2,
    [Description("A cada mês")]
    Monthly = 3,
    [Description("A cada trimestre")]
    Bimonthly = 4,
    [Description("A cada quatro meses")]
    Quarterly = 5,
    [Description("A cada semestre")]
    Biannual = 6,
    [Description("A cada ano")]
    Yearly = 7
}