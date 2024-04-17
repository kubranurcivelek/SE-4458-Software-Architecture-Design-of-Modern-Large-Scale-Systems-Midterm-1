using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankingAppBillController : ControllerBase
    {
        private readonly Models.AppContext _context;

        public BankingAppBillController(Models.AppContext context)
        {
            _context = context;
        }


        [Authorize]
        [HttpGet("GetBillForBankingApp")]
        public async Task<ActionResult<IEnumerable<QueryBankingAppBillDto>>> GetBillForBankingApp(long SubscriberNo)
        {
            List<QueryBankingAppBillDto> queryBankingAppBillList = new List<QueryBankingAppBillDto>();

            if (_context.Bills == null)
              {
                  return NotFound();
            }
            var bill = await _context.Bills.OrderBy(p => p.Month).Where(x => x.SubscriberNo == SubscriberNo && x.PaymentStatus == (int)PaymentStatusEnum.NotPaid).ToListAsync();          

            if (bill == null)
            {
                return NotFound();
            }


            foreach (var item in bill)
            {
                QueryBankingAppBillDto queryBankingAppBill = new QueryBankingAppBillDto();
                queryBankingAppBill.Id = item.Id;
                queryBankingAppBill.Month = item.Month;
                queryBankingAppBill.PaidStatus = item.PaymentStatus;
                queryBankingAppBillList.Add(queryBankingAppBill);
            }

            return queryBankingAppBillList;
        }
    }
}
