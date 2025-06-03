using OfficeOpenXml;
using Kris.Models;
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;

namespace Kris.Services;

public class ExcelExportService
{
    static ExcelExportService()
    {
        // Set EPPlus license for version 8+
        ExcelPackage.License.SetNonCommercialOrganization("My Noncommercial organization"); //This will also set the Company property to the organization name provided in the argument.
    }

    public async Task<byte[]> ExportRegistrationsToExcel(Dictionary<string, Dictionary<string, List<Registration>>> registrations)
    {

        using var package = new ExcelPackage();
        var worksheet = package.Workbook.Worksheets.Add("Registrations");

        // Add headers
        worksheet.Cells[1, 1].Value = "Tahun";
        worksheet.Cells[1, 2].Value = "Kelas";
        worksheet.Cells[1, 3].Value = "Nama Murid";
        worksheet.Cells[1, 4].Value = "Persatuan/Kelab";
        worksheet.Cells[1, 5].Value = "Pertandingan";
        worksheet.Cells[1, 6].Value = "Tarikh Pendaftaran";

        // Style headers
        var headerRange = worksheet.Cells[1, 1, 1, 6];
        headerRange.Style.Font.Bold = true;
        headerRange.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
        headerRange.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(79, 175, 80)); // Match our theme
        headerRange.Style.Font.Color.SetColor(System.Drawing.Color.White);

        int row = 2;
        foreach (var yearGroup in registrations)
        {
            foreach (var classGroup in yearGroup.Value)
            {
                foreach (var registration in classGroup.Value)
                {
                    worksheet.Cells[row, 1].Value = yearGroup.Key;
                    worksheet.Cells[row, 2].Value = classGroup.Key;
                    worksheet.Cells[row, 3].Value = registration.Student?.Name;
                    worksheet.Cells[row, 4].Value = registration.Association?.Name;
                    worksheet.Cells[row, 5].Value = registration.Competition?.Name;
                    worksheet.Cells[row, 6].Value = registration.RegistrationDate.ToString("yyyy-MM-dd");

                    // Alternate row colors
                    if (row % 2 == 0)
                    {
                        var dataRange = worksheet.Cells[row, 1, row, 6];
                        dataRange.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        dataRange.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(242, 247, 242)); // Light green tint
                    }

                    row++;
                }
            }
        }

        // Auto-fit columns
        worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

        // Add border
        var border = worksheet.Cells[1, 1, row - 1, 6].Style.Border;
        border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
        border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
        border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
        border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

        return await package.GetAsByteArrayAsync();
    }
}
