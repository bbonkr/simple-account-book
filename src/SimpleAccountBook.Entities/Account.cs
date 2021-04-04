using System;

namespace SimpleAccountBook.Entities
{
    /// <summary>
    /// 거래처
    /// </summary>
    public class Account : EntityBase
    {
        /// <summary>
        /// 상호, 법인명
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 사업자등록번호 / 법인등록번호
        /// </summary>
        public string RegistrationNumber { get; set; }

        public Guid? AddressId { get; set; }

        public virtual Address Address { get; set; }
    }
}
