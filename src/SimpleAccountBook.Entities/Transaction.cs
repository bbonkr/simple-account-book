using System;

namespace SimpleAccountBook.Entities
{
    /// <summary>
    /// 거래
    /// </summary>
    public class Transaction :EntityBase
    {
        public DateTime Date { get; set; }

        /// <summary>
        /// 거래구분 (수입, 비용, 고정자산)
        /// </summary>
        public Guid TransactionTypeId { get; set; }
        
        /// <summary>
        /// 거래구분 (수입, 비용, 고정자산)
        /// </summary>
        public virtual GeneralCode TransactionType { get; set; }

        /// <summary>
        /// 거래 내용 
        /// </summary>
        public Guid TransactionDetailsId { get; set; }

        public virtual GeneralCode TransactionDetails { get; set; }

        /// <summary>
        /// 거래내용 기록
        /// </summary>
        public string TransactionDetailsNote { get; set; }

        /// <summary>
        /// 거래처 식별자
        /// </summary>
        public Guid AccountId { get; set; }

        /// <summary>
        /// 거래처
        /// </summary>
        public virtual Account Account { get; set; }

        /// <summary>
        /// 거래처
        /// </summary>
        public Guid AmountId { get; set; }
        
        /// <summary>
        /// 금액
        /// </summary>
        public virtual Amount Amount { get; set; }

        /// <summary>
        /// 비고 식별자
        /// </summary>
        public Guid? RemarkId { get; set; }

        /// <summary>
        /// 비고
        /// </summary>
        public virtual GeneralCode Remark { get; set; }

        /// <summary>
        /// 비고 기록
        /// </summary>
        public string RemarkNote { get; set; }

        /// <summary>
        /// 사업장 식별자
        /// </summary>
        public Guid BusinessId { get; set; }

        /// <summary>
        /// 사업장
        /// </summary>
        public virtual Business Business { get; set; }
    }
}
