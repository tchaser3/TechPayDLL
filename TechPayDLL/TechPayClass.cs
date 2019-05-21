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
