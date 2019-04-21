namespace NanoLifeShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class RevenuesStatistic : DbMigration
    {
        public override void Up()
        {

            CreateStoredProcedure("GetRevenuesStatistic",
                p => new 
                {
                    fromDate = p.String(),
                    toDate = p.String()
                }, @" SELECT O.CreateDate AS Date1,SUM(OD.TotalPrice) AS TT
                    FROM dbo.Orders O INNER JOIN dbo.OrderDetails OD ON OD.ID_Order = O.ID
                    INNER JOIN dbo.Products PRO ON PRO.ID = OD.ID_Product
                    where O.CreateDate <= cast(@toDate as date) and O.CreateDate >= cast(@fromDate as date)
                    GROUP BY O.CreateDate");
           
        }

        public override void Down()
        {
        }
    }
}
