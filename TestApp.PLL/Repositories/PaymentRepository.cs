using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestApp.DAL.Context;
using TestApp.DAL.Entities;
using TestApp.PLL.Interfaces;

namespace TestApp.PLL.Repositories
{
    public class PaymentRepository : GenericRepository<PaymentProcess>, IPaymentRepository
    {
        private readonly StoreContext _storeContext;
        public PaymentRepository(StoreContext storeContext):base(storeContext)
        {
            _storeContext = storeContext;
        }



    }
}
