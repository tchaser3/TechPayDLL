/* Title:           Tech Pay Class
 * Date:            5-21-19
 * Author:          Terry Holmes
 * 
 * Description:     This class is used for Tech Pay */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace TechPayDLL
{
    public class TechPayClass
    {
        EventLogClass TheEventLogClass = new EventLogClass();

        TechPayItemDataSet aTechPayItemDataSet;
        TechPayItemDataSetTableAdapters.techpayitemTableAdapter aTechPayItemTableAdapter;

        InsertTechPayItemEntryTableAdapters.QueriesTableAdapter aInsertTechPayItemTableAdapter;

        UpdateTechPayItemPriceEntryTableAdapters.QueriesTableAdapter aUpdateTechPayItemPriceTableAdapter;

        FindSortedTechPayItemByCodeDataSet aFindSortedTechPayItemByCodeDataSet;
        FindSortedTechPayItemByCodeDataSetTableAdapters.FindSortedTechPayItemByCodeTableAdapter aFindSortedTechPayItemByCodeTableAdapter;

        FindSortedTechPayItemByJobDescriptionDataSet aFindSortedTechPayItemByJobDescriptionDataSet;
        FindSortedTechPayItemByJobDescriptionDataSetTableAdapters.FindSortedTechPayItemByJobDescriptionTableAdapter aFindSortedTechPayItemByJobDescriptionTableAdapter;

        FindTechPayItemByCodeDataSet aFindTechPayItemByCodeDataSet;
        FindTechPayItemByCodeDataSetTableAdapters.FindTechPayItemByCodeTableAdapter aFindTechPayItemByCodeTableAdapter;

        FindTechPayItemByDescriptionDataSet aFindTechPayItemByDescriptionDataSet;
        FindTechPayItemByDescriptionDataSetTableAdapters.FindTechPayItemByDescriptionTableAdapter aFindTechPayItemByDescriptionTableAdapter;

        ProjectTechPayItemsDataSet aProjectTechPayItemsDataSet;
        ProjectTechPayItemsDataSetTableAdapters.projecttechpayitemsTableAdapter aProjectTechPayItemsTableAdapter;

        InsertProjectTechPayItemEntryTableAdapters.QueriesTableAdapter aInsertProjectTechPayItemTableAdapter;

        UpdateProjectTechPayItemEntryTableAdapters.QueriesTableAdapter aUpdateProjectTechPayItemTableAdapter;

        FindProjectTechPayByProjectIDDataSet aFindProjectTechPayByProjectIDDataSet;
        FindProjectTechPayByProjectIDDataSetTableAdapters.FindProjectTechPaybyProjectIDTableAdapter aFindProjectTechPayByProjectIDTableAdapter;

        FindProjectTechPayTotalsDataSet aFindProjectTechPayTotalsDataSet;
        FindProjectTechPayTotalsDataSetTableAdapters.FindProjectTechPayTotalsTableAdapter aFindProjectTechpayTotalsTableAdapter;

        FindEmployeeTechPayByDateRangeDataSet aFindEmployeeTechPayByDateRangeDataSet;
        FindEmployeeTechPayByDateRangeDataSetTableAdapters.FindEmployeeTechPayByDateRangeTableAdapter aFindEmployeeTechPayByDateRangeTableAdapter;

        FindManagerEmployeeTechPayDataSet aFindManagerEmployeeTechPayDataSet;
        FindManagerEmployeeTechPayDataSetTableAdapters.FindManagerEmployeeTechPayTableAdapter aFindManagerEmployeeTechPayTableAdapter;

        public FindManagerEmployeeTechPayDataSet FindManagerEmployeeTechPay(int intManagerID, DateTime datStartDate, DateTime datEndDate)
        {
            try
            {
                aFindManagerEmployeeTechPayDataSet = new FindManagerEmployeeTechPayDataSet();
                aFindManagerEmployeeTechPayTableAdapter = new FindManagerEmployeeTechPayDataSetTableAdapters.FindManagerEmployeeTechPayTableAdapter();
                aFindManagerEmployeeTechPayTableAdapter.Fill(aFindManagerEmployeeTechPayDataSet.FindManagerEmployeeTechPay, intManagerID, datStartDate, datEndDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Tech Pay Class // Find Manager Employee Tech Pay " + Ex.Message);
            }

            return aFindManagerEmployeeTechPayDataSet;
        }
        public FindEmployeeTechPayByDateRangeDataSet FindEmployeeTechPayByDateRange(int intEmployeeID, DateTime datStartDate, DateTime datEndDate)
        {
            try
            {
                aFindEmployeeTechPayByDateRangeDataSet = new FindEmployeeTechPayByDateRangeDataSet();
                aFindEmployeeTechPayByDateRangeTableAdapter = new FindEmployeeTechPayByDateRangeDataSetTableAdapters.FindEmployeeTechPayByDateRangeTableAdapter();
                aFindEmployeeTechPayByDateRangeTableAdapter.Fill(aFindEmployeeTechPayByDateRangeDataSet.FindEmployeeTechPayByDateRange, intEmployeeID, datStartDate, datEndDate);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Tech Pay Class // Find Employee Tech Pay By Date Range " + Ex.Message);
            }

            return aFindEmployeeTechPayByDateRangeDataSet;
        }
        public FindProjectTechPayTotalsDataSet FindProjectTechPayTotals(int intProjectID, bool blnIsConstruction)
        {
            try
            {
                aFindProjectTechPayTotalsDataSet = new FindProjectTechPayTotalsDataSet();
                aFindProjectTechpayTotalsTableAdapter = new FindProjectTechPayTotalsDataSetTableAdapters.FindProjectTechPayTotalsTableAdapter();
                aFindProjectTechpayTotalsTableAdapter.Fill(aFindProjectTechPayTotalsDataSet.FindProjectTechPayTotals, intProjectID, blnIsConstruction);
            }
            catch (Exception ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Tech Pay Class // Find Project Tech Pay Total " + ex.Message);
            }

            return aFindProjectTechPayTotalsDataSet;
        }
        public FindProjectTechPayByProjectIDDataSet FindProjectTechPayByProjectID(int intProjectID, bool blnIsConstruction)
        {
            try
            {
                aFindProjectTechPayByProjectIDDataSet = new FindProjectTechPayByProjectIDDataSet();
                aFindProjectTechPayByProjectIDTableAdapter = new FindProjectTechPayByProjectIDDataSetTableAdapters.FindProjectTechPaybyProjectIDTableAdapter();
                aFindProjectTechPayByProjectIDTableAdapter.Fill(aFindProjectTechPayByProjectIDDataSet.FindProjectTechPaybyProjectID, intProjectID, blnIsConstruction);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Tech Pay Class // Find Project Tech Pay By Project ID " + Ex.Message);
            }

            return aFindProjectTechPayByProjectIDDataSet;
        }
        public bool UpdateProjectTechPayItem(int intTransactionID, int intQuantity, decimal decTechPayPrice, decimal decTotalTechPayPrice)
        {
            bool blnFatalError = false;

            try
            {
                aUpdateProjectTechPayItemTableAdapter = new UpdateProjectTechPayItemEntryTableAdapters.QueriesTableAdapter();
                aUpdateProjectTechPayItemTableAdapter.UpdateProjectTechPayItem(intTransactionID, intQuantity, decTechPayPrice, decTotalTechPayPrice);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Tech Pay Class // Update Project Tech Pay Item " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public bool InsertProjectTechpayItem(int intProjectID, bool blnIsConstruction, string strProjectType, int intEmployeeID, int intWarehouseID, int intTechPayID, decimal decTechPayPrice, int intQuantity, decimal decTotalTechPayPrice)
        {
            bool blnFatalError = false;

            try
            {
                aInsertProjectTechPayItemTableAdapter = new InsertProjectTechPayItemEntryTableAdapters.QueriesTableAdapter();
                aInsertProjectTechPayItemTableAdapter.InsertProjectTechPayItem(intProjectID, blnIsConstruction, strProjectType, intEmployeeID, intWarehouseID, intTechPayID, decTechPayPrice, intQuantity, decTotalTechPayPrice, DateTime.Now);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Tech Pay Class // Insert Project Techpay Item " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public ProjectTechPayItemsDataSet GetProjectTechPayItemsInfo()
        {
            try
            {
                aProjectTechPayItemsDataSet = new ProjectTechPayItemsDataSet();
                aProjectTechPayItemsTableAdapter = new ProjectTechPayItemsDataSetTableAdapters.projecttechpayitemsTableAdapter();
                aProjectTechPayItemsTableAdapter.Fill(aProjectTechPayItemsDataSet.projecttechpayitems);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Tech Pay Class // Get Project Tech Pay Items Info " + Ex.Message);
            }

            return aProjectTechPayItemsDataSet;
        }
        public void UpdateProjectTechPayItemsDB(ProjectTechPayItemsDataSet aProjectTechPayItemsDataSet)
        {
            try
            {
                aProjectTechPayItemsTableAdapter = new ProjectTechPayItemsDataSetTableAdapters.projecttechpayitemsTableAdapter();
                aProjectTechPayItemsTableAdapter.Update(aProjectTechPayItemsDataSet.projecttechpayitems);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Tech Pay Class // Update Project Tech Pay Items Update " + Ex.Message);
            }
        }
        public FindTechPayItemByDescriptionDataSet FindTechPayItemByDescription(string strJobDescription)
        {
            try
            {
                aFindTechPayItemByDescriptionDataSet = new FindTechPayItemByDescriptionDataSet();
                aFindTechPayItemByDescriptionTableAdapter = new FindTechPayItemByDescriptionDataSetTableAdapters.FindTechPayItemByDescriptionTableAdapter();
                aFindTechPayItemByDescriptionTableAdapter.Fill(aFindTechPayItemByDescriptionDataSet.FindTechPayItemByDescription, strJobDescription);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Tech Pay Class // Find Tech Pay Item By Description " + Ex.Message);
            }

            return aFindTechPayItemByDescriptionDataSet;
        }
        public FindTechPayItemByCodeDataSet FindTechPayItemByCode(string strTechPayCode)
        {
            try
            {
                aFindTechPayItemByCodeDataSet = new FindTechPayItemByCodeDataSet();
                aFindTechPayItemByCodeTableAdapter = new FindTechPayItemByCodeDataSetTableAdapters.FindTechPayItemByCodeTableAdapter();
                aFindTechPayItemByCodeTableAdapter.Fill(aFindTechPayItemByCodeDataSet.FindTechPayItemByCode, strTechPayCode);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Tech Pay Class // Find Tech Pay Item By Code " + Ex.Message);
            }

            return aFindTechPayItemByCodeDataSet;
        }
        public FindSortedTechPayItemByJobDescriptionDataSet FindSortedTechPayItemByJobDescription()
        {
            try
            {
                aFindSortedTechPayItemByJobDescriptionDataSet = new FindSortedTechPayItemByJobDescriptionDataSet();
                aFindSortedTechPayItemByJobDescriptionTableAdapter = new FindSortedTechPayItemByJobDescriptionDataSetTableAdapters.FindSortedTechPayItemByJobDescriptionTableAdapter();
                aFindSortedTechPayItemByJobDescriptionTableAdapter.Fill(aFindSortedTechPayItemByJobDescriptionDataSet.FindSortedTechPayItemByJobDescription);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Tech Pay Class // Find Sorted Tech Pay Item By Job Description " + Ex.Message);
            }

            return aFindSortedTechPayItemByJobDescriptionDataSet;
        }
        public FindSortedTechPayItemByCodeDataSet FindSortedTechPayItemByCode()
        {
            try
            {
                aFindSortedTechPayItemByCodeDataSet = new FindSortedTechPayItemByCodeDataSet();
                aFindSortedTechPayItemByCodeTableAdapter = new FindSortedTechPayItemByCodeDataSetTableAdapters.FindSortedTechPayItemByCodeTableAdapter();
                aFindSortedTechPayItemByCodeTableAdapter.Fill(aFindSortedTechPayItemByCodeDataSet.FindSortedTechPayItemByCode);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Tech Pay Class // Find Sorted Tech Pay Item By Code " + Ex.Message);
            }

            return aFindSortedTechPayItemByCodeDataSet;
        }
        public bool UpdateTechPayItemPrice(int intTechPayID, decimal decTechPayPrice)
        {
            bool blnFatalError = false;

            try
            {
                aUpdateTechPayItemPriceTableAdapter = new UpdateTechPayItemPriceEntryTableAdapters.QueriesTableAdapter();
                aUpdateTechPayItemPriceTableAdapter.UpdateTechPayItemPrice(intTechPayID, decTechPayPrice);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Tech Pay Class // Update Tech Pay Item Price " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public bool InsertTechPayItem(string strTechPayCode, string strJobDescription, Decimal decTechPayPrice)
        {
            bool blnFatalError = false;

            try
            {
                aInsertTechPayItemTableAdapter = new InsertTechPayItemEntryTableAdapters.QueriesTableAdapter();
                aInsertTechPayItemTableAdapter.InsertTechPayItem(strTechPayCode, strJobDescription, decTechPayPrice);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Tech Pay Class // Insert Tech Pay Item " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public TechPayItemDataSet GetTechPayItemInfo()
        {
            try
            {
                aTechPayItemDataSet = new TechPayItemDataSet();
                aTechPayItemTableAdapter = new TechPayItemDataSetTableAdapters.techpayitemTableAdapter();
                aTechPayItemTableAdapter.Fill(aTechPayItemDataSet.techpayitem);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Tech Pay Class // Get Tech Pay Item Info " + Ex.Message);
            }

            return aTechPayItemDataSet;
        }
        public void UpdateTechPayItemDB(TechPayItemDataSet aTechPayItemDataSet)
        {
            try
            {
                aTechPayItemTableAdapter = new TechPayItemDataSetTableAdapters.techpayitemTableAdapter();
                aTechPayItemTableAdapter.Update(aTechPayItemDataSet.techpayitem);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Tech Pay Class // Get Tech Pay Item Info " + Ex.Message);
            }
        }
    }
}
