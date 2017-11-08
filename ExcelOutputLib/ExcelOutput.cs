using System;
using System.Collections.Generic;

namespace ExcelOutputLib
{
    public static class ExcelOutput
    {
        /// <summary>
        /// Set item properties
        /// </summary>
        /// <param name="item">list box items</param>
        public static bool Output(string[] list)
        {
            bool ret = false;
            // Serialize list items.
            List<Bankin> bList = new List<Bankin>();
            Bankin bItem;
            foreach (string item in list)
            {
                string[] phraze = item.Split(' ');
                if (phraze.Length > 1)
                {
                    // Set properties if item is not empty.
                    bItem = new Bankin();
                    bItem.Quantity = Convert.ToInt32(phraze[1].Substring(phraze[1].IndexOf(':') + 1));
                    bItem.Type = phraze[2] + phraze[3];
                    bItem.UnitPrice = Convert.ToInt32(phraze[8].Substring(phraze[8].IndexOf(':') + 1));
                    bList.Add(bItem);
                }
            }
            if (bList.Count > 0)
            {
                // Output data into excel.
                DataExport de = new DataExport();
                ret = de.OpenExcel(bList);
            }
            return ret;
        }
    }
}
