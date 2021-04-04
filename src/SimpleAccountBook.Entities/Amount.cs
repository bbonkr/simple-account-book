namespace SimpleAccountBook.Entities
{
    public class Amount : EntityBase
    {
        /// <summary>
        /// 공급가액
        /// </summary>
        public decimal SupplyPrice { get; set; } = 0;

        /// <summary>
        /// 세액
        /// </summary>
        public decimal Tax { get; set; } = 0;
    }
}
