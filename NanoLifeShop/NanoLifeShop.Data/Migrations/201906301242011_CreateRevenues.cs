namespace NanoLifeShop.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreateRevenues : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("GetRevenuesStatistic",
            p => new
                {
                fromDate = p.String(),
                toDate = p.String()
                },
            @"SELECT MONTH(O.CreateDate) AS Month,SUM( OD.Quantity * OD.Price) AS RevenuesByMonth, sum((OD.Quantity * OD.Price)-(OD.Quantity * PRO.OriginalPrice)) as Benefit
                FROM dbo.Orders O INNER JOIN dbo.OrderDetails OD ON OD.ID_Order = O.ID
                INNER JOIN dbo.Products PRO ON PRO.ID = OD.ID_Product
                where O.CreateDate <= cast(@toDate as date) and O.CreateDate >= cast(@fromDate as date)
                GROUP BY O.CreateDate ");
        }

        public override void Down()
        {
            DropStoredProcedure("dbo.GetRevenuesStatistic");
        }
    }
}