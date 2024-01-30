namespace StudentPortal.Web.Models
{
    public class AddFeeViewModel
    {
        public int CourseID { get; set; }
        public string FeeType { get; set; }
        public decimal LateFee { get; set; }
        public decimal Amount { get; set; }
        public DateTime? PaymentDate { get; set; }
    }
}
