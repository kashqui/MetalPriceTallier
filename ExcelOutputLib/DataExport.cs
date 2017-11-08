using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Excel;

namespace ExcelOutputLib
{
    internal class DataExport
    {
        /// <summary>
        /// Fill excel cells
        /// </summary>
        internal bool OpenExcel(List<Bankin> list)
        {
            bool ret = false;
            // Get opening Excel book.
            Microsoft.Office.Interop.Excel.Application exApp = null;
            try
            {
                exApp = (Microsoft.Office.Interop.Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
            }
            catch
            {

            }
            finally
            {
                if (exApp == null)
                {
                    // Make a new book if no book is opened.
                    exApp = new Microsoft.Office.Interop.Excel.Application();
                }
                exApp.Visible = true;
                Workbook wb = exApp.Workbooks.Add();
                Worksheet sheet = wb.Sheets[1];
                sheet.Select(Type.Missing);
                // Set headline row.
                Range range = sheet.Cells[1, 1]; range.Value2 = "分　類"; range.ColumnWidth = 11; 
                range = sheet.Cells[1, 2]; range.Value2 = "メーカー";  range.ColumnWidth = 7;
                range = sheet.Cells[1, 3]; range.Value2 = "型　式";    range.ColumnWidth = 35;
                range = sheet.Cells[1, 4]; range.Value2 = "数　量";    range.ColumnWidth = 6;
                range = sheet.Cells[1, 5]; range.Value2 = "単位";      range.ColumnWidth = 4;
                range = sheet.Cells[1, 6]; range.Value2 = "仕入単価";  range.ColumnWidth = 9;
                range = sheet.Cells[1, 7]; range.Value2 = "仕入金額";  range.ColumnWidth = 9;
                range = sheet.Cells[1, 8]; range.Value2 = "仕入先";    range.ColumnWidth = 7;
                // Set data rows.
                for (int i = 0; i < list.Count; i++)
                {
                    int j = i + 2;
                    range = sheet.Cells[j, 1]; range.Value2 = " ・板金";
                    range = sheet.Cells[j, 3]; range.Value2 = list[i].Type;
                    range = sheet.Cells[j, 4]; range.Value2 = list[i].Quantity.ToString();
                    range = sheet.Cells[j, 6]; range.Value2 = list[i].UnitPrice.ToString();
                    range = sheet.Cells[j, 7]; range.Value2 = "=D" + j.ToString() + "*F" + j.ToString();
                }
                // Decorate cells.
                range = sheet.Range[sheet.Cells[1, 1], sheet.Cells[1, 8]]; 
                range.Interior.ColorIndex = 44;
                range = sheet.Range[sheet.Cells[2, 7], sheet.Cells[list.Count + 1, 7]]; 
                range.Interior.ColorIndex = 20;
                range = sheet.Range[sheet.Cells[1, 1], sheet.Cells[list.Count + 1, 8]];
                range.Borders.get_Item(XlBordersIndex.xlEdgeBottom).LineStyle = XlLineStyle.xlContinuous;
                range.Borders.get_Item(XlBordersIndex.xlEdgeLeft).LineStyle = XlLineStyle.xlContinuous;
                range.Borders.get_Item(XlBordersIndex.xlEdgeRight).LineStyle = XlLineStyle.xlContinuous;
                range.Borders.get_Item(XlBordersIndex.xlEdgeTop).LineStyle = XlLineStyle.xlContinuous;
                range.Borders.get_Item(XlBordersIndex.xlInsideHorizontal).LineStyle = XlLineStyle.xlContinuous;
                range.Borders.get_Item(XlBordersIndex.xlInsideVertical).LineStyle = XlLineStyle.xlContinuous;
                ret = true;
            }
            return ret;
        }
    }
}

