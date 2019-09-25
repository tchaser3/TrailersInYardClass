/* Title:           Trailers In Yard Class
 * Date:            9-17-18
 * Author:          Terry Holmes
 * 
 * Description:     This is the class for trailers in yard */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewEventLogDLL;

namespace TrailersInYardDLL
{
    public class TrailersInYardClass
    {
        EventLogClass TheEventLogClass = new EventLogClass();

        TrailersInYardDataSet aTrailersInYardDataSet;
        TrailersInYardDataSetTableAdapters.trailersinyardTableAdapter aTrailersInYardTableAdapter;

        InsertTrailerInYardEntryTableAdapters.QueriesTableAdapter aInsertTrailerInYardTableAdapter;

        FindTrailersInYardDateRangeDataSet aFindTrailersInYardDateRangeDataSet;
        FindTrailersInYardDateRangeDataSetTableAdapters.FindTrailersInYardDateRangeTableAdapter aFindTrailersInYardDateRangeTableAdapter;

        public FindTrailersInYardDateRangeDataSet FindTrailersInYardDateRange(DateTime datStartDate, DateTime datEndDate)
        {
            try
            {
                aFindTrailersInYardDateRangeDataSet = new FindTrailersInYardDateRangeDataSet();
                aFindTrailersInYardDateRangeTableAdapter = new FindTrailersInYardDateRangeDataSetTableAdapters.FindTrailersInYardDateRangeTableAdapter();
                aFindTrailersInYardDateRangeTableAdapter.Fill(aFindTrailersInYardDateRangeDataSet.FindTrailersInYardDateRange, datStartDate, datEndDate);
            }
            catch  (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Trailers In Yard Class // Find Trailers In Yard Date Range " + Ex.Message);
            }

            return aFindTrailersInYardDateRangeDataSet;
        }
        public bool InsertTrailerInYard(int intTrailerID)
        {
            bool blnFatalError = false;

            try
            {
                aInsertTrailerInYardTableAdapter = new InsertTrailerInYardEntryTableAdapters.QueriesTableAdapter();
                aInsertTrailerInYardTableAdapter.InsertTrailerInYard(DateTime.Now, intTrailerID);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Trailers in Yard Class // Insert Trailer In Yard " + Ex.Message);

                blnFatalError = true;
            }

            return blnFatalError;
        }
        public TrailersInYardDataSet GetTrailersInYardInfo()
        {
            try
            {
                aTrailersInYardDataSet = new TrailersInYardDataSet();
                aTrailersInYardTableAdapter = new TrailersInYardDataSetTableAdapters.trailersinyardTableAdapter();
                aTrailersInYardTableAdapter.Fill(aTrailersInYardDataSet.trailersinyard);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Trailers In Yard Class // Get Trailers In Yard Info " + Ex.Message);
            }

            return aTrailersInYardDataSet;
        }
        public void UpdateTrailersInYardDB(TrailersInYardDataSet aTrailersInYardDataSet)
        {
            try
            {
                aTrailersInYardTableAdapter = new TrailersInYardDataSetTableAdapters.trailersinyardTableAdapter();
                aTrailersInYardTableAdapter.Update(aTrailersInYardDataSet.trailersinyard);
            }
            catch (Exception Ex)
            {
                TheEventLogClass.InsertEventLogEntry(DateTime.Now, "Trailers In Yard Class // Update Trailers In Yard DB " + Ex.Message);
            }
        }
    }
}
