public class QueryMobileBillDetailsDto
{
    public decimal BillTotal { get; set; }
    public List<Detail> BillDetails { get; set; }
   

}

public class Detail
{   
    public decimal PriceAmount { get; set; }
    public int PriceMonth { get; set; }
    public string CompanyName { get; set; }
}