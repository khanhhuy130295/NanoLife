namespace NanoLifeShop.Data.Infastructures
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDBFactory _dBFactory;
        private NanoLifeShopDBContext dBContext;

        public UnitOfWork(IDBFactory dBFactory)
        {
            this._dBFactory = dBFactory;
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }

        public NanoLifeShopDBContext DbContext
        {
            get { return dBContext ?? (_dBFactory.Initialize()); }
        }
    }
}