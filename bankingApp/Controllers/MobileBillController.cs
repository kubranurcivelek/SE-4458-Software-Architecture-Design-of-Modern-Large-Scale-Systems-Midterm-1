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
    public class MobileBillController : ControllerBase
    {
        private readonly Models.AppContext _context;

        public MobileBillController(Models.AppContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpGet("GetBillForMobile")]
        public async Task<ActionResult<QueryMobileBillDto>> GetBillForMobile(long SubscriberNo, int Month)
        {
            QueryMobileBillDto queryMobileBill = new QueryMobileBillDto();

          if (_context.Bills == null)
          {
              return NotFound();
          }
            var bill = await _context.Bills.FirstOrDefaultAsync(x=> x.SubscriberNo == SubscriberNo && x.Month == Month);

            queryMobileBill.PaidStatus = bill.PaymentStatus;
            queryMobileBill.BillTotal = bill.TotalAmount;

            if (queryMobileBill.PaidStatus == (int)PaymentStatusEnum.NotPaid)
            {
                queryMobileBill.PaidStatusDescription = "Not Paid!";
            }
            else
            {
                queryMobileBill.PaidStatusDescription = "Paid!";
            }

            if (bill == null)
            {
                return NotFound();
            }

            return queryMobileBill;
        }

        [Authorize]
        [HttpGet("GetBillDetailsForMobile")]
        public async Task<ActionResult<QueryMobileBillDetailsDto>> GetBillDetailsForMobile(long SubscriberNo, int Month,int pageNo, int itemPerPage)
        {
            QueryMobileBillDetailsDto queryMobileBillDetails = new QueryMobileBillDetailsDto();
            queryMobileBillDetails.BillTotal = 0;
            queryMobileBillDetails.BillDetails = new List<Detail>();
            int lowerInterval = (pageNo * itemPerPage) - itemPerPage;


            if (_context.Bills == null)
            {
                return NotFound();
            }
            var bill = await _context.Bills.FirstOrDefaultAsync(x => x.SubscriberNo == SubscriberNo && x.Month == Month);

            if (bill == null)
            {
                return NotFound();
            }

            var billDetails = await _context.BillDetails.OrderBy(p => p.Id).Where(detail => detail.BillId == bill.Id).Skip(lowerInterval).Take(itemPerPage).ToListAsync();


            queryMobileBillDetails.BillTotal = bill.TotalAmount ;

            foreach (var item in billDetails)
            {
                Detail detail = new Detail();
                detail.PriceMonth = item.PriceMonth;
                detail.CompanyName = item.CompanyName;
                detail.PriceAmount = item.PriceAmount;
                queryMobileBillDetails.BillDetails.Add(detail);
            }


            

            return queryMobileBillDetails;
        }

     
    }
}
