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
    public class WebsiteController : ControllerBase
    {
        private readonly Models.AppContext _context;

        public WebsiteController(Models.AppContext context)
        {
            _context = context;
        }

        [HttpPost("PayBill")]
        public async Task<ActionResult<string>> GetBillForBankingApp(long SubscriberNo,int Month, decimal PaymentAmount)
        {

            if (_context.Bills == null)
            {
                  return NotFound();
            }
            var bill = await _context.Bills.FirstOrDefaultAsync(x => x.SubscriberNo == SubscriberNo && x.Month == Month && x.PaymentStatus == (int)PaymentStatusEnum.NotPaid);          

            if (bill == null)
            {
                return NotFound();
            }

            bill.TotalAmount = bill.TotalAmount - PaymentAmount;

            if(bill.TotalAmount <= 0)
            {
                bill.TotalAmount = 0;
                bill.PaymentStatus = (int)PaymentStatusEnum.Paid;
            }

            await _context.SaveChangesAsync();
            return "Success";
        }

        [Authorize]
        [HttpPost("AddBill")]
        public async Task<ActionResult<string>> AddBill(AddBillDto bill)
        {
            Bill test = new Bill();
            test.SubscriberNo = bill.SubscriberNo;
            test.Month = bill.Month;
            test.PaymentStatus = bill.PaymentStatus;
            test.TotalAmount = 0;
            foreach (var item in bill.Details)
            {
                test.TotalAmount += item.PriceAmount;
            }
            await _context.Bills.AddAsync(test);
            await _context.SaveChangesAsync();

            List<BillDetails> billDetails = new List<BillDetails>();
            foreach (var item in bill.Details)
            {
                BillDetails detail = new BillDetails();
                detail.PriceMonth = item.PriceMonth;
                detail.BillId = test.Id;
                detail.CompanyName = item.CompanyName;
                detail.PriceAmount = item.PriceAmount;
                detail.PriceMonth = item.PriceMonth;
                billDetails.Add(detail);
            }

            await _context.BillDetails.AddRangeAsync(billDetails);
            await _context.SaveChangesAsync();
            return null;
        }
    }
}
