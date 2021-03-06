using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SimpleAccountBook.Entities;

namespace SimpleAccountBook.Data.Seeder
{
    public class GeneralCodeSeeder
    {
        public static IEnumerable<GeneralCode> GetCodes()
        {
            return new List<GeneralCode>
            {
                new GeneralCode
                {
                    Code = "00001",
                    Text= "수입",
                    Ordinal = 1,
                    SubCodes =CreateGeneralCodes("00001", "매출", "기타 (수입)"),
                },
                new GeneralCode
                {
                    Code = "00002",
                    Text="비용",
                    Ordinal = 2,
                    SubCodes = CreateGeneralCodes("00002",
                        "상품 매입", "급료", "제세공과금",
                        "임차료", "지급이자", "접대비",
                        "기부금", "감가상각비", "차량유지비",
                        "지급수수료", "소모품비", "복리후생비",
                        "운반비", "광고선전비", "여비교통비", "기타 (비용)"),
                },
                new GeneralCode
                {
                    Code = "00003",
                    Text="고정자산매입",
                    Ordinal = 3,
                    SubCodes = CreateGeneralCodes( "00003","건물 및 구축물", "차량운반구", "비품", "기계장치", "기타 (고정)"),
                },
                new GeneralCode
                {
                    Code = "00004",
                    Text= "증빙",
                    Ordinal = 4,
                    SubCodes = CreateGeneralCodes("00004","세금계산서", "계산서", "신용카드", "현금영수증", "간이영수증", "기타")
                },
            };
        }

        private static IList<GeneralCode> CreateGeneralCodes(string baseCode, params string[] texts) => texts.Select((text, index) => new GeneralCode
        {
            Code = $"{baseCode}{index.ToString().PadLeft(5, '0')}",
            Text = text,
            Ordinal = index + 1,
        }).ToList();
    }
}
