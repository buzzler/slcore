using System.Collections.Generic;

namespace SLCore.Data
{
    public class CardInfo
    {
        public int Id { get; private set; }
        public int Group { get; private set; }
        public bool Grade20 { get; private set; }
        public bool Grade10 { get; private set; }
        public bool Grade5 { get; private set; }
        public bool Grade0 { get; private set; }
        public bool Grade00 { get; private set; }
        public string Description { get; private set; }

        public static readonly int Count = 48;
        private static readonly Dictionary<int, CardInfo> Dictionary;

        static CardInfo()
        {
            Dictionary = new Dictionary<int, CardInfo>
            {
                {
                    1,
                    new CardInfo
                    {
                        Id = 1,
                        Group = 1,
                        Grade20 = true,
                        Grade10 = false,
                        Grade5 = false,
                        Grade0 = false,
                        Grade00 = false,
                        Description = "송/광"
                    }
                },
                {
                    2,
                    new CardInfo
                    {
                        Id = 2,
                        Group = 1,
                        Grade20 = false,
                        Grade10 = false,
                        Grade5 = true,
                        Grade0 = false,
                        Grade00 = false,
                        Description = "송/띠"
                    }
                },
                {
                    3,
                    new CardInfo
                    {
                        Id = 3,
                        Group = 1,
                        Grade20 = false,
                        Grade10 = false,
                        Grade5 = false,
                        Grade0 = true,
                        Grade00 = false,
                        Description = "송/피"
                    }
                },
                {
                    4,
                    new CardInfo
                    {
                        Id = 4,
                        Group = 1,
                        Grade20 = false,
                        Grade10 = false,
                        Grade5 = false,
                        Grade0 = true,
                        Grade00 = false,
                        Description = "송/피"
                    }
                },

                {
                    5,
                    new CardInfo
                    {
                        Id = 5,
                        Group = 2,
                        Grade20 = false,
                        Grade10 = true,
                        Grade5 = false,
                        Grade0 = false,
                        Grade00 = false,
                        Description = "매화/열끗"
                    }
                },
                {
                    6,
                    new CardInfo
                    {
                        Id = 6,
                        Group = 2,
                        Grade20 = false,
                        Grade10 = false,
                        Grade5 = true,
                        Grade0 = false,
                        Grade00 = false,
                        Description = "매화/띠"
                    }
                },
                {
                    7,
                    new CardInfo
                    {
                        Id = 7,
                        Group = 2,
                        Grade20 = false,
                        Grade10 = false,
                        Grade5 = false,
                        Grade0 = true,
                        Grade00 = false,
                        Description = "매화/피"
                    }
                },
                {
                    8,
                    new CardInfo
                    {
                        Id = 8,
                        Group = 2,
                        Grade20 = false,
                        Grade10 = false,
                        Grade5 = false,
                        Grade0 = true,
                        Grade00 = false,
                        Description = "매화/피"
                    }
                },

                {
                    9,
                    new CardInfo
                    {
                        Id = 9,
                        Group = 3,
                        Grade20 = true,
                        Grade10 = false,
                        Grade5 = false,
                        Grade0 = false,
                        Grade00 = false,
                        Description = "벚꽃/광"
                    }
                },
                {
                    10,
                    new CardInfo
                    {
                        Id = 10,
                        Group = 3,
                        Grade20 = false,
                        Grade10 = false,
                        Grade5 = true,
                        Grade0 = false,
                        Grade00 = false,
                        Description = "벚꽃/띠"
                    }
                },
                {
                    11,
                    new CardInfo
                    {
                        Id = 11,
                        Group = 3,
                        Grade20 = false,
                        Grade10 = false,
                        Grade5 = false,
                        Grade0 = true,
                        Grade00 = false,
                        Description = "벚꽃/피"
                    }
                },
                {
                    12,
                    new CardInfo
                    {
                        Id = 12,
                        Group = 3,
                        Grade20 = false,
                        Grade10 = false,
                        Grade5 = false,
                        Grade0 = true,
                        Grade00 = false,
                        Description = "벚꽃/피"
                    }
                },

                {
                    13,
                    new CardInfo
                    {
                        Id = 13,
                        Group = 4,
                        Grade20 = false,
                        Grade10 = true,
                        Grade5 = false,
                        Grade0 = false,
                        Grade00 = false,
                        Description = "등나무/열끗"
                    }
                },
                {
                    14,
                    new CardInfo
                    {
                        Id = 14,
                        Group = 4,
                        Grade20 = false,
                        Grade10 = false,
                        Grade5 = true,
                        Grade0 = false,
                        Grade00 = false,
                        Description = "등나무/띠"
                    }
                },
                {
                    15,
                    new CardInfo
                    {
                        Id = 15,
                        Group = 4,
                        Grade20 = false,
                        Grade10 = false,
                        Grade5 = false,
                        Grade0 = true,
                        Grade00 = false,
                        Description = "등나무/피"
                    }
                },
                {
                    16,
                    new CardInfo
                    {
                        Id = 16,
                        Group = 4,
                        Grade20 = false,
                        Grade10 = false,
                        Grade5 = false,
                        Grade0 = true,
                        Grade00 = false,
                        Description = "등나무/피"
                    }
                },

                {
                    17,
                    new CardInfo
                    {
                        Id = 17,
                        Group = 5,
                        Grade20 = false,
                        Grade10 = true,
                        Grade5 = false,
                        Grade0 = false,
                        Grade00 = false,
                        Description = "창포/열끗"
                    }
                },
                {
                    18,
                    new CardInfo
                    {
                        Id = 18,
                        Group = 5,
                        Grade20 = false,
                        Grade10 = false,
                        Grade5 = true,
                        Grade0 = false,
                        Grade00 = false,
                        Description = "창포/띠"
                    }
                },
                {
                    19,
                    new CardInfo
                    {
                        Id = 19,
                        Group = 5,
                        Grade20 = false,
                        Grade10 = false,
                        Grade5 = false,
                        Grade0 = true,
                        Grade00 = false,
                        Description = "창포/피"
                    }
                },
                {
                    20,
                    new CardInfo
                    {
                        Id = 20,
                        Group = 5,
                        Grade20 = false,
                        Grade10 = false,
                        Grade5 = false,
                        Grade0 = true,
                        Grade00 = false,
                        Description = "창포/피"
                    }
                },

                {
                    21,
                    new CardInfo
                    {
                        Id = 21,
                        Group = 6,
                        Grade20 = false,
                        Grade10 = true,
                        Grade5 = false,
                        Grade0 = false,
                        Grade00 = false,
                        Description = "모란/열끗"
                    }
                },
                {
                    22,
                    new CardInfo
                    {
                        Id = 22,
                        Group = 6,
                        Grade20 = false,
                        Grade10 = false,
                        Grade5 = true,
                        Grade0 = false,
                        Grade00 = false,
                        Description = "모란/띠"
                    }
                },
                {
                    23,
                    new CardInfo
                    {
                        Id = 23,
                        Group = 6,
                        Grade20 = false,
                        Grade10 = false,
                        Grade5 = false,
                        Grade0 = true,
                        Grade00 = false,
                        Description = "모란/피"
                    }
                },
                {
                    24,
                    new CardInfo
                    {
                        Id = 24,
                        Group = 6,
                        Grade20 = false,
                        Grade10 = false,
                        Grade5 = false,
                        Grade0 = true,
                        Grade00 = false,
                        Description = "모란/피"
                    }
                },

                {
                    25,
                    new CardInfo
                    {
                        Id = 25,
                        Group = 7,
                        Grade20 = false,
                        Grade10 = true,
                        Grade5 = false,
                        Grade0 = false,
                        Grade00 = false,
                        Description = "싸리/열끗"
                    }
                },
                {
                    26,
                    new CardInfo
                    {
                        Id = 26,
                        Group = 7,
                        Grade20 = false,
                        Grade10 = false,
                        Grade5 = true,
                        Grade0 = false,
                        Grade00 = false,
                        Description = "싸리/띠"
                    }
                },
                {
                    27,
                    new CardInfo
                    {
                        Id = 27,
                        Group = 7,
                        Grade20 = false,
                        Grade10 = false,
                        Grade5 = false,
                        Grade0 = true,
                        Grade00 = false,
                        Description = "싸리/피"
                    }
                },
                {
                    28,
                    new CardInfo
                    {
                        Id = 28,
                        Group = 7,
                        Grade20 = false,
                        Grade10 = false,
                        Grade5 = false,
                        Grade0 = true,
                        Grade00 = false,
                        Description = "싸리/피"
                    }
                },

                {
                    29,
                    new CardInfo
                    {
                        Id = 29,
                        Group = 8,
                        Grade20 = true,
                        Grade10 = false,
                        Grade5 = false,
                        Grade0 = false,
                        Grade00 = false,
                        Description = "들판/광"
                    }
                },
                {
                    30,
                    new CardInfo
                    {
                        Id = 30,
                        Group = 8,
                        Grade20 = false,
                        Grade10 = true,
                        Grade5 = false,
                        Grade0 = false,
                        Grade00 = false,
                        Description = "들판/열끗"
                    }
                },
                {
                    31,
                    new CardInfo
                    {
                        Id = 31,
                        Group = 8,
                        Grade20 = false,
                        Grade10 = false,
                        Grade5 = false,
                        Grade0 = true,
                        Grade00 = false,
                        Description = "들판/피"
                    }
                },
                {
                    32,
                    new CardInfo
                    {
                        Id = 32,
                        Group = 8,
                        Grade20 = false,
                        Grade10 = false,
                        Grade5 = false,
                        Grade0 = true,
                        Grade00 = false,
                        Description = "들판/피"
                    }
                },

                {
                    33,
                    new CardInfo
                    {
                        Id = 33,
                        Group = 9,
                        Grade20 = false,
                        Grade10 = true,
                        Grade5 = false,
                        Grade0 = false,
                        Grade00 = true,
                        Description = "국화/열끗"
                    }
                },
                {
                    34,
                    new CardInfo
                    {
                        Id = 34,
                        Group = 9,
                        Grade20 = false,
                        Grade10 = false,
                        Grade5 = true,
                        Grade0 = false,
                        Grade00 = false,
                        Description = "국화/띠"
                    }
                },
                {
                    35,
                    new CardInfo
                    {
                        Id = 35,
                        Group = 9,
                        Grade20 = false,
                        Grade10 = false,
                        Grade5 = false,
                        Grade0 = true,
                        Grade00 = false,
                        Description = "국화/피"
                    }
                },
                {
                    36,
                    new CardInfo
                    {
                        Id = 36,
                        Group = 9,
                        Grade20 = false,
                        Grade10 = false,
                        Grade5 = false,
                        Grade0 = true,
                        Grade00 = false,
                        Description = "국화/피"
                    }
                },

                {
                    37,
                    new CardInfo
                    {
                        Id = 37,
                        Group = 10,
                        Grade20 = false,
                        Grade10 = true,
                        Grade5 = false,
                        Grade0 = false,
                        Grade00 = false,
                        Description = "단풍/열끗"
                    }
                },
                {
                    38,
                    new CardInfo
                    {
                        Id = 38,
                        Group = 10,
                        Grade20 = false,
                        Grade10 = false,
                        Grade5 = true,
                        Grade0 = false,
                        Grade00 = false,
                        Description = "단풍/띠"
                    }
                },
                {
                    39,
                    new CardInfo
                    {
                        Id = 39,
                        Group = 10,
                        Grade20 = false,
                        Grade10 = false,
                        Grade5 = false,
                        Grade0 = true,
                        Grade00 = false,
                        Description = "단풍/피"
                    }
                },
                {
                    40,
                    new CardInfo
                    {
                        Id = 40,
                        Group = 10,
                        Grade20 = false,
                        Grade10 = false,
                        Grade5 = false,
                        Grade0 = true,
                        Grade00 = false,
                        Description = "단풍/피"
                    }
                },

                {
                    41,
                    new CardInfo
                    {
                        Id = 41,
                        Group = 11,
                        Grade20 = true,
                        Grade10 = false,
                        Grade5 = false,
                        Grade0 = false,
                        Grade00 = false,
                        Description = "오동/광"
                    }
                },
                {
                    42,
                    new CardInfo
                    {
                        Id = 42,
                        Group = 11,
                        Grade20 = false,
                        Grade10 = false,
                        Grade5 = false,
                        Grade0 = false,
                        Grade00 = true,
                        Description = "오동/쌍피"
                    }
                },
                {
                    43,
                    new CardInfo
                    {
                        Id = 43,
                        Group = 11,
                        Grade20 = false,
                        Grade10 = false,
                        Grade5 = false,
                        Grade0 = true,
                        Grade00 = false,
                        Description = "오동/피"
                    }
                },
                {
                    44,
                    new CardInfo
                    {
                        Id = 44,
                        Group = 11,
                        Grade20 = false,
                        Grade10 = false,
                        Grade5 = false,
                        Grade0 = true,
                        Grade00 = false,
                        Description = "오동/피"
                    }
                },

                {
                    45,
                    new CardInfo
                    {
                        Id = 45,
                        Group = 12,
                        Grade20 = true,
                        Grade10 = false,
                        Grade5 = false,
                        Grade0 = false,
                        Grade00 = false,
                        Description = "버드나무/광"
                    }
                },
                {
                    46,
                    new CardInfo
                    {
                        Id = 46,
                        Group = 12,
                        Grade20 = false,
                        Grade10 = true,
                        Grade5 = false,
                        Grade0 = false,
                        Grade00 = false,
                        Description = "버드나무/열끗"
                    }
                },
                {
                    47,
                    new CardInfo
                    {
                        Id = 47,
                        Group = 12,
                        Grade20 = false,
                        Grade10 = false,
                        Grade5 = true,
                        Grade0 = false,
                        Grade00 = false,
                        Description = "버드나무/띠"
                    }
                },
                {
                    48,
                    new CardInfo
                    {
                        Id = 48,
                        Group = 12,
                        Grade20 = false,
                        Grade10 = false,
                        Grade5 = false,
                        Grade0 = false,
                        Grade00 = true,
                        Description = "버드나무/쌍피"
                    }
                },
            };
        }

        public static CardInfo Get(int i)
        {
            return Dictionary[i];
        }

        public override string ToString()
        {
            return $"{Description}/{Id}";
        }
    }
}