using System.Collections.Generic;
using project.Entities;

public interface IReport
{
    IEnumerable<Report> GetReport(string startDate, string endDate);
}