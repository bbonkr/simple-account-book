using System;
using System.Collections.Generic;

namespace SimpleAccountBook.Entities
{
    /// <summary>
    /// 내 사업장 정보
    /// </summary>
    public class Business : EntityBase
    {

        /// <summary>
        /// 상호
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 사업자등록번호
        /// </summary>
        public string RegistrationNumber { get; set; }

        /// <summary>
        /// 주소 식별자
        /// </summary>
        public Guid AddressId { get; set; }

        /// <summary>
        /// 주소
        /// </summary>
        public virtual Address Address { get; set; }

        /// <summary>
        /// 업종
        /// </summary>
        public string BusinessItem { get; set; }

        /// <summary>
        /// 주업종코드
        /// </summary>
        public string BusinessItemCode { get; set; }

        /// <summary>
        /// 소득종류코드
        /// </summary>
        public string TypeOfIncomeCode { get; set; }

        /// <summary>
        /// 사용자 식별자
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// 사용자
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// 거래
        /// </summary>
        public virtual ICollection<Transaction> Transactions { get; set; }

        /// <summary>
        /// 재고
        /// </summary>
        public virtual ICollection<Stock> Stocks { get; set; }
    }
}
