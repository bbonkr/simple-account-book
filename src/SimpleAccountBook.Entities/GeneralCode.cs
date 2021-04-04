using System;

namespace SimpleAccountBook.Entities
{
    public class GeneralCode : EntityBase
    {
        /// <summary>
        /// 상위 코드 식별자
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// 코드
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 출력
        /// </summary>
        public string Text { get; set; }

    }
}
