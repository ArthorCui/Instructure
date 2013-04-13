using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using Model.OTA;
using Domain.Extensions;
using DataTable = System.Data.DataTable;
using Common.Const;
using NCore;

namespace Domain.Service
{
    public class ReportService
    {
        public void Write()
        {
            Application excel = new Application();
            Workbook excelBook = excel.Workbooks.Add(Type.Missing);
            excel.Visible = false;
            Dictionary<DataTable, Worksheet> dicWorkSheet = new Dictionary<DataTable, Worksheet>();
            try
            {
                var dataTableList = GetOTAInterfaceDTList();
                var workSheetList = GetWorkSheetList(excelBook);
                for (int i = 0; i < dataTableList.Count; i++)
                {
                    dicWorkSheet.Add(dataTableList[i], workSheetList[i]);
                    DataTableToExcel(dataTableList[i], workSheetList[i]);
                }
                excel.DisplayAlerts = false;
                excel.AlertBeforeOverwriting = false;
                excelBook.SaveAs(string.Format("{0}{1} OTA统计详细.xls", AppConfigKeys.OTA_STAT_FILE_PATH_PREFIX.ConfigValue(), DateTime.Now.AddDays(AppConfigKeys.OTA_FILE_DAYS_AGO.ConfigValue().ToInt32()).ToString("yyyy-MM-dd")));
                excel.Save();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                //System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
                excel.Quit();
                excel = null;
                GC.Collect();
            }
        }

        public List<Worksheet> GetWorkSheetList(Workbook excelBook)
        {
            var workSheetList = new List<Worksheet>();
            var upgradeFailedWorkSheet = (Worksheet)excelBook.Worksheets.Add(Missing.Value, Missing.Value, Missing.Value, Missing.Value);

            var checkupdateWorkSheet = (Worksheet)excelBook.Worksheets.get_Item("Sheet4");
            var downloadWorkSheet = (Worksheet)excelBook.Worksheets.get_Item("Sheet1");
            var upgradeSuccessWorkSheet = (Worksheet)excelBook.Worksheets.get_Item("Sheet2");
            upgradeFailedWorkSheet = (Worksheet)excelBook.Worksheets.get_Item("Sheet3");
            checkupdateWorkSheet.Name = "checkupdate";
            //checkupdateWorkSheet.Columns.AutoFit();
            downloadWorkSheet.Name = "download";
            //downloadWorkSheet.Columns.AutoFit();
            upgradeSuccessWorkSheet.Name = "upgradeSuccess";
            //upgradeSuccessWorkSheet.Columns.AutoFit();
            upgradeFailedWorkSheet.Name = "upgradeFailed";
            //upgradeFailedWorkSheet.Columns.AutoFit();

            workSheetList.Add(checkupdateWorkSheet);
            workSheetList.Add(downloadWorkSheet);
            workSheetList.Add(upgradeSuccessWorkSheet);
            workSheetList.Add(upgradeFailedWorkSheet);

            return workSheetList;
        }

        public void DataTableToExcel(DataTable dt, Worksheet excelSheet)
        {
            int rowCount = dt.Rows.Count;
            int colCount = dt.Columns.Count;
            object[,] dataArray = new object[rowCount + 1, colCount];
            for (int k = 0; k < colCount; k++)
            {
                dataArray[0, k] = dt.Columns[k].ColumnName;
            }
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    dataArray[i + 1, j] = dt.Rows[i][j];
                }
            }
            excelSheet.get_Range("A1", excelSheet.Cells[rowCount + 1, colCount] as object).Value2 = dataArray;
        }

        public List<DataTable> GetOTAInterfaceDTList()
        {
            OTAService otaService = new OTAService();
            var retList = new List<System.Data.DataTable>();
            var checkupdateList = otaService.Repository.All<EveryDayCheckupdate>().ToList();
            var downloadList = otaService.Repository.All<EveryDayDownload>().ToList();
            var upgradeSuccessList = otaService.Repository.All<EveryDayUpgradeSuccess>().ToList();
            var upgradeFailedList = otaService.Repository.All<EveryDayUpgradeFailed>().ToList();

            checkupdateList = ConvertDateFormat<EveryDayCheckupdate>(checkupdateList);
            downloadList = ConvertDateFormat<EveryDayDownload>(downloadList);
            upgradeSuccessList = ConvertDateFormat<EveryDayUpgradeSuccess>(upgradeSuccessList);
            upgradeFailedList = ConvertDateFormat<EveryDayUpgradeFailed>(upgradeFailedList);


            retList.Add(Domain.Extensions.DataTableExtensions.ToDataTable(checkupdateList));
            retList.Add(Domain.Extensions.DataTableExtensions.ToDataTable(downloadList));
            retList.Add(Domain.Extensions.DataTableExtensions.ToDataTable(upgradeSuccessList));
            retList.Add(Domain.Extensions.DataTableExtensions.ToDataTable(upgradeFailedList));

            return retList;
        }

        public List<T> ConvertDateFormat<T>(List<T> list)
            where T : EveryDayCheckupdate
        {
            if (list != null)
            {
                foreach (var item in list)
                {
                    item.Date = "(" + Convert.ToDateTime(item.Date).ToString("yyyy-MM-dd") + ")";
                }
                return list;
            }
            return null;
        }

    }
}
