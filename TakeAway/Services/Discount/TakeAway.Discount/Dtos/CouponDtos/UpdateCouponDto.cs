namespace TakeAway.Discount.Dtos.CouponDtos
{
    public class UpdateCouponDto
    {
        public int CouponId { get; set; }
        public string Code { get; set; }
        public int Rate { get; set; }
        public bool IsActive { get; set; }
    }
}
