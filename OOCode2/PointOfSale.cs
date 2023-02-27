using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOCode2_PointOfSale
{
    class PointOfSale
    {
    }
    class SaleItem
    {
        public double Rate { get; private set; }
        public string Desc { get; private set; }
        public SaleItem() { }
        public SaleItem(string desc, double rate)
        {
            Rate = rate;
            Desc = desc;
        }
    }
    class Sale
    {
        public int Qty { get; private set; }
        public double Discount { get; private set; }
        public SaleItem SaleItem { get; private set; }
        public Sale() { }
        public Sale(SaleItem item, int qty, double discount)
        {
            SaleItem = item;
            Qty = qty;
            Discount = discount;
        }
        public string GetDesc()
        {
            return SaleItem.Desc;
        }
    }
    class SaleList
    {
        public string dtSale { get; private set; }
        public string CustName { get; private set; }
        public List<Sale> Sales { get; private set; } = new List<Sale>();
        public SaleList() { }
        public SaleList(string dtSale, string custName)
        {
            this.dtSale = dtSale;
            this.CustName = custName;
        }
    }
    class BillingSys
    {
        public StdTaxCalc taxCalc { get; set; } = TaxCalcFactory.GetInstance().create(0);
        public void GenerateBill(List<SaleList> list)
        {
            foreach(SaleList sale in list)
            {
                
            }
        }
    }
    class TaxCalcFactory
    {
        TaxCalcFactory() { }
        static TaxCalcFactory instance = null;
        public static TaxCalcFactory GetInstance()
        {
            if(instance==null)instance = new TaxCalcFactory();
            return instance;
        }
        public StdTaxCalc create(int vendorType)
        {
            return new StdTaxCalc() {
                ISTPercent = 10,
                FedTaxPercent = 0.15
            };
        }
    }
    class StdTaxCalc
    {
        public double ISTPercent { get; set; }
        public double FedTaxPercent { get; set; }
        
    }
}
