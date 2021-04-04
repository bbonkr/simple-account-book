using System;

namespace SimpleAccountBook.Entities
{
    public class EntityBase
    {
        /// <summary>
        /// 식별자
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// 삭제여부
        /// </summary>
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 작성일시
        /// </summary>
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// 갱신일시
        /// </summary>
        public DateTimeOffset? UpdatedAt { get; set; }

        /// <summary>
        /// 삭제일시
        /// </summary>
        public DateTimeOffset? DeletedAt { get; set; }
    }
}
