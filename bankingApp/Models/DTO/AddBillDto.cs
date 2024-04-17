public class AddBillDto
{
    public long SubscriberNo { get; set; }
    public int Month { get; set; }
    public decimal TotalAmount { get; set; }
    public int PaymentStatus { get; set; }
    public List<AddBillDetailDto> Details { get; set; }

}

 public class AddBillDetailDto
{
    public decimal PriceAmount { get; set; }
    public int PriceMonth { get; set; }
    public string CompanyName { get; set; }
    public int BillId { get; set; }
}