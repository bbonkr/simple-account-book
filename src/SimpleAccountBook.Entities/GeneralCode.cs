using System;
using System.Collections.Generic;

namespace SimpleAccountBook.Entities
{
    public class GeneralCode : EntityBase
    {
        /// <summary>
        /// 상위 코드 식별자
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// 상위코드
        /// </summary>
        public virtual GeneralCode Parent { get; set; }

        // TODO: 필요할까?
        /// <summary>
        /// 코드 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 출력
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 출력순서
        /// </summary>
        public int Ordinal { get; set; }

        public virtual ICollection<GeneralCode> SubCodes { get; set; }
    }
}
