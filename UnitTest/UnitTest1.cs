using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Comm;
using Aspose.Cells;
using System.Data;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ImportExcel_Method()
        {
            int dataCount = 0;
            string status = string.Empty;
            try
            {
                string savaPath = @"D:\LYJ_YJ222.xlsx";

                Workbook wb = new Workbook();
                wb.Open(savaPath);
                for (int i = 0; i < wb.Worksheets.Count; i++)
                {
                    if (wb.Worksheets[i].Name == "Sheet1")
                    {
                        Worksheet sheetMenu = wb.Worksheets["Sheet1"];
                        Cells csMenu = sheetMenu.Cells;
                        //去除空白行
                        csMenu.DeleteBlankRows();
                        DataTable dtMenu = csMenu.ExportDataTableAsString(0, 0, csMenu.MaxDataRow + 1, csMenu.MaxDataColumn + 1, true);
                        DataColumn drw1 = new DataColumn();
                        drw1.ColumnName = "Spring";

                        dtMenu.Columns.Add(drw1);
                        foreach (DataRow dr in dtMenu.Rows)
                        {
                            dataCount++;
                            string tempOrderID = string.Empty;
                            string orderid = dr[0].ToString().Trim();
                            string orderid1 = dr[1].ToString().Trim();

                            dr["Spring"] = "Autumn";

                            Cell cell = csMenu[dataCount, 2];
                            cell.PutValue("Mole");

                            Cell cell1 = csMenu[dataCount, 3];
                            cell1.PutValue("Ventilate");

                            Cell cell2 = csMenu[dataCount, 4];
                            cell2.PutValue("Supervision");

                            Cell cell3 = csMenu[dataCount, 5];
                            cell3.PutValue("Saber");

                            //
                            
                        }

                        int c = dataCount;
                        string kk = status;

                        var dkkk = dtMenu;


                        wb.Save(@"D:\NewInfo.xlsx");

                        //
                        

                    }

                }
            }
            catch (Exception ex)
            {
                var bh = dataCount;
                LogUtil.writeLog(ex.Message, "导出Excel异常");
            }
        }
    }
}
