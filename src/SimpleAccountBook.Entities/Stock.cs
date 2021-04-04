using System;

namespace SimpleAccountBook.Entities
{
    /// <summary>
    /// 재고
    /// </summary>
    public class Stock : EntityBase
    {
        /// <summary>
        /// 귀속년도
        /// </summary>
        public int Year { get; set; }
        /// <summary>
        /// 기초 상품 재고액
        /// </summary>
        public decimal ProductBeginningOfYear { get; set; }

        /// <summary>
        /// 기말 상품 재고액
        /// </summary>
        public decimal ProductEndYear { get; set; }

        /// <summary>
        /// 기초 재료 재고액 (제조업 한정)
        /// </summary>
        public decimal MaterialBeginningOfYear { get; set; }
        /// <summary>
        /// 기말 재료 재고액 (제조업 한정)
        /// </summary>
        public decimal MaterialEndYear { get; set; }

        public Guid BusinessId { get; set; }

        public virtual Business Business { get; set; }
    }
}
