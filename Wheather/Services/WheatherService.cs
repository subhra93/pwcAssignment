using IronXL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wheather.Models;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using Cell = DocumentFormat.OpenXml.Spreadsheet.Cell;

namespace Wheather.Services
{
    public class WheatherService
    {
        public WheatherService() { }
        public static Task<ResponseModel> Getdata(RequestModel request)
        {
            ResponseModel res = new ResponseModel();


            
            string filepath = "Wheather/in.xlsx";
            using (SpreadsheetDocument document = SpreadsheetDocument.Open(filepath, false))
            {
                WorkbookPart workbookPart = document.WorkbookPart;
                WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();

                foreach (Row row in sheetData.Elements<Row>())
                {
                    foreach (Cell cell in row.Elements<Cell>())
                    {
                        string value = cell.CellValue.InnerText;
                        
                    }
                    
                }
            }
            return Task.FromResult(res);

        }
    }
}
