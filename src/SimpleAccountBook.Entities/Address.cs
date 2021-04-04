namespace SimpleAccountBook.Entities
{
    /// <summary>
    /// 주소
    /// </summary>
    public class Address : EntityBase
    {
        public string Zipcode { get; set; }

        /// <summary>
        /// 도, 시
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// 시, 구
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// 세부 주소 1
        /// </summary>
        public string StreetAddress1 { get; set; }

        /// <summary>
        /// 세부 주소 2
        /// </summary>
        public string StreetAddress2 { get; set; }

        /// <summary>
        /// 전화번호
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
