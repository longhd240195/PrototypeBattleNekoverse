using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTest
{
    public static List<NekoData> GetMyNekoDatas()
    {
        List<NekoData> listMyNekoData = new List<NekoData>();
        NekoData neko = new NekoData
        {
            id = "15c6b4ae-bcd5-4886-bf1e-ec98790e96f3",
            mint_address = "29MXryUw6xBBVQXiwQgD5ZqNrsbWYtA2xpLdkX6ZvC6D",
            nft_id = "5244",
            name = "NEKO #5244",
            className = "Fire",
            metadata = new MetaDataNeko
            {
                atk = 161,
                m_atk = 189,
                def = 186,
                m_def = 164,
                speed = 110,
                health = 255,
                mana = 100
            },
            level = 1,
            experience = 0,
            traits = new TraitsData[] {
                new TraitsData
                {
                    id = "62",
                    name = "Displeased Candy buddy",
                    trait_type = new TraitsType
                    {
                        id = "1",
                        name = "body",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "66",
                    name = "Nyan feline",
                    trait_type = new TraitsType
                    {
                        id = "3",
                        name = "ear",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "67",
                    name = "Big nose",
                    trait_type = new TraitsType
                    {
                        id = "4",
                        name = "nose",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "69",
                    name = "Fire stare",
                    trait_type = new TraitsType
                    {
                        id = "5",
                        name = "eye",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "73",
                    name = "Picky",
                    trait_type = new TraitsType
                    {
                        id = "6",
                        name = "eyebrow",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "75",
                    name = "Bronze pendant",
                    trait_type = new TraitsType
                    {
                        id = "7",
                        name = "medal",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "81",
                    name = "Fabric choker",
                    trait_type = new TraitsType
                    {
                        id = "8",
                        name = "necklaces",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "98",
                    name = "Bare",
                    trait_type = new TraitsType
                    {
                        id = "14",
                        name = "side face",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "101",
                    name = "Bare",
                    trait_type = new TraitsType
                    {
                        id = "11",
                        name = "arms",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "108",
                    name = "Ninja pad",
                    trait_type = new TraitsType
                    {
                        id = "12",
                        name = "accessories",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "112",
                    name = "Wyvern tail",
                    trait_type = new TraitsType
                    {
                        id = "13",
                        name = "back",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "242",
                    name = "Peach gradient",
                    trait_type = new TraitsType
                    {
                        id = "2",
                        name = "background",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "299",
                    name = "White cap",
                    trait_type = new TraitsType
                    {
                        id = "9",
                        name = "top",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "301",
                    name = "Neko frames",
                    trait_type = new TraitsType
                    {
                        id = "10",
                        name = "front face",
                        description = null
                    }
                }
            },
            skills = new SkillNekoData[]
            {
                new SkillNekoData
                {
                    id = "56f82d47-e8b1-4380-a181-a726420ee959",
                    name = "Neko-Skill-4-1",
                    metadata = new MetaDataSkill
                    {
                        function = "cover",
                        atk = 516,
                        def = 263,
                        speed = 1,
                        mana = 43
                    }
                },
                new SkillNekoData
                {
                    id = "64244d1b-9148-48f8-af9c-dfe8c4274b80",
                    name = "Neko-Skill-4-2",
                    metadata = new MetaDataSkill
                    {
                        function = "fire",
                        atk = 572,
                        def = 564,
                        speed = 5,
                        mana = 17
                    }
                }
            }
        };
        NekoData neko1 = new NekoData
        {
            id = "47e04355-7243-4f15-96e4-a8192fd5022a",
            mint_address = "4kixX7y4x536BT2xuk1EYidBQoucZMjGhFneQ4KytiwR",
            nft_id = "1841",
            name = "NEKO #1841",
            className = "Earth",
            metadata = new MetaDataNeko
            {
                atk = 161,
                m_atk = 189,
                def = 186,
                m_def = 164,
                speed = 110,
                health = 255,
                mana = 100
            },
            level = 1,
            experience = 0,
            traits = new TraitsData[] {
                new TraitsData
                {
                    id = "11",
                    name = "Frightening",
                    trait_type = new TraitsType
                    {
                        id = "5",
                        name = "eye",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "17",
                    name = "Long stone",
                    trait_type = new TraitsType
                    {
                        id = "6",
                        name = "eyebrow",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "19",
                    name = "Stone pendant",
                    trait_type =new TraitsType
                    {
                        id = "7",
                        name = "medal",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "38",
                    name = "Bare",
                    trait_type =new TraitsType
                    {
                        id = "10",
                        name = "front face",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "42",
                    name = "Earth cheek",
                    trait_type =new TraitsType
                    {
                        id = "14",
                        name = "side face",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "43",
                    name = "Bare",
                    trait_type = new TraitsType
                    {
                        id = "11",
                        name = "arms",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "56",
                    name = "Bare",
                    trait_type = new TraitsType
                    {
                        id = "13",
                        name = "back",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "231",
                    name = "Orange gradient",
                    trait_type = new TraitsType
                    {
                        id = "2",
                        name = "background",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "362",
                    name = "Hard hat",
                    trait_type = new TraitsType
                    {
                        id = "9",
                        name = "top",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "364",
                    name = "Spicky collar",
                    trait_type =new TraitsType
                    {
                        id = "8",
                        name = "necklaces",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "365",
                    name = "From the hood",
                    trait_type =new TraitsType
                    {
                        id = "3",
                        name = "ear",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "367",
                    name = "Nose ring",
                    trait_type =new TraitsType
                    {
                        id = "4",
                        name = "nose",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "369",
                    name = "First warrior",
                    trait_type = new TraitsType
                    {
                        id = "12",
                        name = "accessories",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "389",
                    name = "Ground buddy",
                    trait_type = new TraitsType
                    {
                        id = "1",
                        name = "body",
                        description = null
                    }
                }
            },
            skills = new SkillNekoData[]
            {
                new SkillNekoData
                {
                    id = "fb13956f-40af-48cb-bf1f-9c7238e25b46",
                    name = "Neko-Skill-3-1",
                    metadata = new MetaDataSkill
                    {
                        function = "cover",
                        atk = 473,
                        def = 348,
                        speed = 1,
                        mana = 15
                    }
                },
                new SkillNekoData
                {
                    id = "15449e11-0e3e-4e25-bbc4-55abff048f0e",
                    name = "Neko-Skill-3-2",
                    metadata = new MetaDataSkill
                    {
                        function = "fire",
                        atk = 455,
                        def = 632,
                        speed = 5,
                        mana = 12
                    }
                }
            }
        };
        NekoData neko2 = new NekoData
        {
            id = "fa681035-cddc-44be-8182-bd25057c5534",
            mint_address = "6uZWNsJPaF27uPM5rTVuHtGEz3RtFAcUa1hjJncCTQbN",
            nft_id = "12",
            name = "NEKO #12",
            className = "Earth",
            metadata = new MetaDataNeko
            {
                atk = 161,
                m_atk = 189,
                def = 186,
                m_def = 164,
                speed = 110,
                health = 255,
                mana = 100
            },
            level = 1,
            experience = 0,
            traits = new TraitsData[] {
                new TraitsData
                {
                    id = "12",
                    name = "Eye-opened",
                    trait_type = new TraitsType
                    {
                        id = "5",
                        name = "eye",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "13",
                    name = "Arched",
                    trait_type = new TraitsType
                    {
                        id = "6",
                        name = "eyebrow",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "21",
                    name = "Silver pendant",
                    trait_type =new TraitsType
                    {
                        id = "7",
                        name = "medal",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "29",
                    name = "Shining Unicorn horn",
                    trait_type =new TraitsType
                    {
                        id = "9",
                        name = "top",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "35",
                    name = "Rock Gem face",
                    trait_type =new TraitsType
                    {
                        id = "10",
                        name = "front face",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "40",
                    name = "Bare",
                    trait_type = new TraitsType
                    {
                        id = "14",
                        name = "side face",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "51",
                    name = "Ninja Pad",
                    trait_type = new TraitsType
                    {
                        id = "12",
                        name = "accessories",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "56",
                    name = "Bare",
                    trait_type = new TraitsType
                    {
                        id = "13",
                        name = "back",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "230",
                    name = "Mint gradient",
                    trait_type = new TraitsType
                    {
                        id = "2",
                        name = "background",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "357",
                    name = "Matt plier",
                    trait_type =new TraitsType
                    {
                        id = "11",
                        name = "arms",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "364",
                    name = "Spicky collar",
                    trait_type =new TraitsType
                    {
                        id = "8",
                        name = "necklaces",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "367",
                    name = "Nose ring",
                    trait_type =new TraitsType
                    {
                        id = "4",
                        name = "nose",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "388",
                    name = "Haft blood buddy",
                    trait_type = new TraitsType
                    {
                        id = "1",
                        name = "body",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "397",
                    name = "Flash",
                    trait_type = new TraitsType
                    {
                        id = "3",
                        name = "ear",
                        description = null
                    }
                }
            },
            skills = new SkillNekoData[]
            {
                new SkillNekoData
                {
                    id = "ccf77825-835b-4d90-a81b-96be3919e652",
                    name = "Neko-Skill-5-1",
                    metadata = new MetaDataSkill
                    {
                        function = "cover",
                        atk = 569,
                        def = 254,
                        speed = 5,
                        mana = 10
                    }
                },
                new SkillNekoData
                {
                    id = "6addb7d1-ec57-407b-b5fb-c3d1c06d5cd6",
                    name = "Neko-Skill-5-2",
                    metadata = new MetaDataSkill
                    {
                        function = "fire",
                        atk = 418,
                        def = 358,
                        speed = 3,
                        mana = 18
                    }
                }
            }
        };
        NekoData neko3 = new NekoData
        {
            id = "2a92913b-98c1-46ff-8427-aa3bfd08d75f",
            mint_address = "6PX72AkDUR1wH7kXcPuX2kqZ2XArLRA6cBs5W4vaN3MT",
            nft_id = "7135",
            name = "NEKO #7135",
            className = "Fire",
            metadata = new MetaDataNeko
            {
                atk = 161,
                m_atk = 189,
                def = 186,
                m_def = 164,
                speed = 110,
                health = 255,
                mana = 100
            },
            level = 1,
            experience = 0,
            traits = new TraitsData[] {
                new TraitsData
                {
                    id = "64",
                    name = "Bunny",
                    trait_type = new TraitsType
                    {
                        id = "3",
                        name = "ear",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "67",
                    name = "Big nose",
                    trait_type = new TraitsType
                    {
                        id = "4",
                        name = "nose",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "69",
                    name = "Fire stare",
                    trait_type =new TraitsType
                    {
                        id = "5",
                        name = "eye",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "73",
                    name = "Picky",
                    trait_type =new TraitsType
                    {
                        id = "6",
                        name = "eyebrow",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "78",
                    name = "Fire shining pendant",
                    trait_type =new TraitsType
                    {
                        id = "7",
                        name = "medal",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "82",
                    name = "Minimal gold",
                    trait_type = new TraitsType
                    {
                        id = "8",
                        name = "necklaces",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "83",
                    name = "Bare",
                    trait_type = new TraitsType
                    {
                        id = "9",
                        name = "top",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "93",
                    name = "Bare",
                    trait_type = new TraitsType
                    {
                        id = "10",
                        name = "front face",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "99",
                    name = "Gold cheek",
                    trait_type = new TraitsType
                    {
                        id = "14",
                        name = "side face",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "104",
                    name = "Molotov",
                    trait_type =new TraitsType
                    {
                        id = "11",
                        name = "arms",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "110",
                    name = "Bare",
                    trait_type =new TraitsType
                    {
                        id = "13",
                        name = "back",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "239",
                    name = "K Character",
                    trait_type =new TraitsType
                    {
                        id = "2",
                        name = "background",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "284",
                    name = "Shining warrior",
                    trait_type = new TraitsType
                    {
                        id = "12",
                        name = "accessories",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "360",
                    name = "Candy buddy",
                    trait_type = new TraitsType
                    {
                        id = "1",
                        name = "body",
                        description = null
                    }
                }
            },
            skills = new SkillNekoData[]
            {
                new SkillNekoData
                {
                    id = "80581b72-61c9-47c4-868c-202139c9cc66",
                    name = "Neko-Skill-2-1",
                    metadata = new MetaDataSkill
                    {
                        function = "cover",
                        atk = 450,
                        def = 352,
                        speed = 4,
                        mana = 12
                    }
                },
                new SkillNekoData
                {
                    id = "2621af68-5674-4136-ab5c-a8e4a4f01f6b",
                    name = "Neko-Skill-2-2",
                    metadata = new MetaDataSkill
                    {
                        function = "fire",
                        atk = 444,
                        def = 217,
                        speed = 1,
                        mana = 12
                    }
                }
            }
        };
        NekoData neko4 = new NekoData
        {
            id = "b4dedd83-cf0f-4dc9-852c-eb90a4cd3918",
            mint_address = "5F6RtVE1RhSdWQz274EW2NMjkCrLLSHDBHuVB7LFomtj",
            nft_id = "2822",
            name = "NEKO #2822",
            className = "Water",
            metadata = new MetaDataNeko
            {
                atk = 161,
                m_atk = 189,
                def = 186,
                m_def = 164,
                speed = 110,
                health = 255,
                mana = 100
            },
            level = 1,
            experience = 0,
            traits = new TraitsData[] {
                new TraitsData
                {
                    id = "163",
                    name = "Neutral buddy",
                    trait_type = new TraitsType
                    {
                        id = "1",
                        name = "body",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "167",
                    name = "Sharp feline",
                    trait_type = new TraitsType
                    {
                        id = "3",
                        name = "ear",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "175",
                    name = "Diamond gem",
                    trait_type = new TraitsType
                    {
                        id = "6",
                        name = "eyebrow",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "180",
                    name = "Water shining pendant",
                    trait_type = new TraitsType
                    {
                        id = "7",
                        name = "medal",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "184",
                    name = "Minimal gold",
                    trait_type = new TraitsType
                    {
                        id = "8",
                        name = "necklaces",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "200",
                    name = "Mermaid fin",
                    trait_type = new TraitsType
                    {
                        id = "14",
                        name = "side face",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "206",
                    name = "Bare",
                    trait_type = new TraitsType
                    {
                        id = "12",
                        name = "accessories",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "211",
                    name = "Bare",
                    trait_type = new TraitsType
                    {
                        id = "13",
                        name = "back",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "272",
                    name = "Red gradient",
                    trait_type = new TraitsType
                    {
                        id = "2",
                        name = "background",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "375",
                    name = "Heart nose",
                    trait_type = new TraitsType
                    {
                        id = "4",
                        name = "nose",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "379",
                    name = "Fire extinguisher",
                    trait_type = new TraitsType
                    {
                        id = "11",
                        name = "arms",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "380",
                    name = "Frappuccino bottle hat",
                    trait_type = new TraitsType
                    {
                        id = "9",
                        name = "top",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "387",
                    name = "Aqua cupid",
                    trait_type = new TraitsType
                    {
                        id = "10",
                        name = "front face",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "400",
                    name = "2 Colors",
                    trait_type = new TraitsType
                    {
                        id = "5",
                        name = "eye",
                        description = null
                    }
                }
            },
            skills = new SkillNekoData[]
            {
                new SkillNekoData
                {
                    id = "430e619c-5313-4a94-af3d-6b69e19fbd21",
                    name = "Neko-Skill-1-1",
                    metadata = new MetaDataSkill
                    {
                        function = "cover",
                        atk = 434,
                        def = 638,
                        speed = 5,
                        mana = 11
                    }
                },
                new SkillNekoData
                {
                    id = "6c055f33-6137-43e1-b0f8-1984cce3ea33",
                    name = "Neko-Skill-1-2",
                    metadata = new MetaDataSkill
                    {
                        function = "fire",
                        atk = 453,
                        def = 335,
                        speed = 2,
                        mana = 18
                    }
                }
            }
        };
        listMyNekoData.Add(neko);
        listMyNekoData.Add(neko1);
        listMyNekoData.Add(neko2);
        listMyNekoData.Add(neko3);
        listMyNekoData.Add(neko4);
        return listMyNekoData;
    }

    public static List<NekoData> GetNekoDataBattle()
    {
        List<NekoData> listMyNekoData = new List<NekoData>();
        NekoData neko = new NekoData
        {
            id = "15c6b4ae-bcd5-4886-bf1e-ec98790e96f3",
            mint_address = "29MXryUw6xBBVQXiwQgD5ZqNrsbWYtA2xpLdkX6ZvC6D",
            nft_id = "5244",
            name = "NEKO #5244",
            className = "Fire",
            metadata = new MetaDataNeko
            {
                atk = 161,
                m_atk = 189,
                def = 186,
                m_def = 164,
                speed = 110,
                health = 255,
                mana = 100
            },
            level = 1,
            experience = 0,
            traits = new TraitsData[] {
                new TraitsData
                {
                    id = "62",
                    name = "Displeased Candy buddy",
                    trait_type = new TraitsType
                    {
                        id = "1",
                        name = "body",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "66",
                    name = "Nyan feline",
                    trait_type = new TraitsType
                    {
                        id = "3",
                        name = "ear",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "67",
                    name = "Big nose",
                    trait_type = new TraitsType
                    {
                        id = "4",
                        name = "nose",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "69",
                    name = "Fire stare",
                    trait_type = new TraitsType
                    {
                        id = "5",
                        name = "eye",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "73",
                    name = "Picky",
                    trait_type = new TraitsType
                    {
                        id = "6",
                        name = "eyebrow",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "75",
                    name = "Bronze pendant",
                    trait_type = new TraitsType
                    {
                        id = "7",
                        name = "medal",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "81",
                    name = "Fabric choker",
                    trait_type = new TraitsType
                    {
                        id = "8",
                        name = "necklaces",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "98",
                    name = "Bare",
                    trait_type = new TraitsType
                    {
                        id = "14",
                        name = "side face",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "101",
                    name = "Bare",
                    trait_type = new TraitsType
                    {
                        id = "11",
                        name = "arms",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "108",
                    name = "Ninja pad",
                    trait_type = new TraitsType
                    {
                        id = "12",
                        name = "accessories",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "112",
                    name = "Wyvern tail",
                    trait_type = new TraitsType
                    {
                        id = "13",
                        name = "back",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "242",
                    name = "Peach gradient",
                    trait_type = new TraitsType
                    {
                        id = "2",
                        name = "background",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "299",
                    name = "White cap",
                    trait_type = new TraitsType
                    {
                        id = "9",
                        name = "top",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "301",
                    name = "Neko frames",
                    trait_type = new TraitsType
                    {
                        id = "10",
                        name = "front face",
                        description = null
                    }
                }
            },
            skills = new SkillNekoData[]
            {
                new SkillNekoData
                {
                    id = "56f82d47-e8b1-4380-a181-a726420ee959",
                    name = "Neko-Skill-4-1",
                    metadata = new MetaDataSkill
                    {
                        function = "cover",
                        atk = 516,
                        def = 263,
                        speed = 1,
                        mana = 43
                    }
                },
                new SkillNekoData
                {
                    id = "64244d1b-9148-48f8-af9c-dfe8c4274b80",
                    name = "Neko-Skill-4-2",
                    metadata = new MetaDataSkill
                    {
                        function = "fire",
                        atk = 572,
                        def = 564,
                        speed = 5,
                        mana = 17
                    }
                }
            }
        };
        NekoData neko1 = new NekoData
        {
            id = "47e04355-7243-4f15-96e4-a8192fd5022a",
            mint_address = "4kixX7y4x536BT2xuk1EYidBQoucZMjGhFneQ4KytiwR",
            nft_id = "1841",
            name = "NEKO #1841",
            className = "Earth",
            metadata = new MetaDataNeko
            {
                atk = 161,
                m_atk = 189,
                def = 186,
                m_def = 164,
                speed = 110,
                health = 255,
                mana = 100
            },
            level = 1,
            experience = 0,
            traits = new TraitsData[] {
                new TraitsData
                {
                    id = "11",
                    name = "Frightening",
                    trait_type = new TraitsType
                    {
                        id = "5",
                        name = "eye",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "17",
                    name = "Long stone",
                    trait_type = new TraitsType
                    {
                        id = "6",
                        name = "eyebrow",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "19",
                    name = "Stone pendant",
                    trait_type =new TraitsType
                    {
                        id = "7",
                        name = "medal",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "38",
                    name = "Bare",
                    trait_type =new TraitsType
                    {
                        id = "10",
                        name = "front face",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "42",
                    name = "Earth cheek",
                    trait_type =new TraitsType
                    {
                        id = "14",
                        name = "side face",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "43",
                    name = "Bare",
                    trait_type = new TraitsType
                    {
                        id = "11",
                        name = "arms",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "56",
                    name = "Bare",
                    trait_type = new TraitsType
                    {
                        id = "13",
                        name = "back",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "231",
                    name = "Orange gradient",
                    trait_type = new TraitsType
                    {
                        id = "2",
                        name = "background",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "362",
                    name = "Hard hat",
                    trait_type = new TraitsType
                    {
                        id = "9",
                        name = "top",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "364",
                    name = "Spicky collar",
                    trait_type =new TraitsType
                    {
                        id = "8",
                        name = "necklaces",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "365",
                    name = "From the hood",
                    trait_type =new TraitsType
                    {
                        id = "3",
                        name = "ear",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "367",
                    name = "Nose ring",
                    trait_type =new TraitsType
                    {
                        id = "4",
                        name = "nose",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "369",
                    name = "First warrior",
                    trait_type = new TraitsType
                    {
                        id = "12",
                        name = "accessories",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "389",
                    name = "Ground buddy",
                    trait_type = new TraitsType
                    {
                        id = "1",
                        name = "body",
                        description = null
                    }
                }
            },
            skills = new SkillNekoData[]
            {
                new SkillNekoData
                {
                    id = "fb13956f-40af-48cb-bf1f-9c7238e25b46",
                    name = "Neko-Skill-3-1",
                    metadata = new MetaDataSkill
                    {
                        function = "cover",
                        atk = 473,
                        def = 348,
                        speed = 1,
                        mana = 15
                    }
                },
                new SkillNekoData
                {
                    id = "15449e11-0e3e-4e25-bbc4-55abff048f0e",
                    name = "Neko-Skill-3-2",
                    metadata = new MetaDataSkill
                    {
                        function = "fire",
                        atk = 455,
                        def = 632,
                        speed = 5,
                        mana = 12
                    }
                }
            }
        };
        NekoData neko2 = new NekoData
        {
            id = "fa681035-cddc-44be-8182-bd25057c5534",
            mint_address = "6uZWNsJPaF27uPM5rTVuHtGEz3RtFAcUa1hjJncCTQbN",
            nft_id = "12",
            name = "NEKO #12",
            className = "Earth",
            metadata = new MetaDataNeko
            {
                atk = 161,
                m_atk = 189,
                def = 186,
                m_def = 164,
                speed = 110,
                health = 255,
                mana = 100
            },
            level = 1,
            experience = 0,
            traits = new TraitsData[] {
                new TraitsData
                {
                    id = "12",
                    name = "Eye-opened",
                    trait_type = new TraitsType
                    {
                        id = "5",
                        name = "eye",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "13",
                    name = "Arched",
                    trait_type = new TraitsType
                    {
                        id = "6",
                        name = "eyebrow",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "21",
                    name = "Silver pendant",
                    trait_type =new TraitsType
                    {
                        id = "7",
                        name = "medal",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "29",
                    name = "Shining Unicorn horn",
                    trait_type =new TraitsType
                    {
                        id = "9",
                        name = "top",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "35",
                    name = "Rock Gem face",
                    trait_type =new TraitsType
                    {
                        id = "10",
                        name = "front face",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "40",
                    name = "Bare",
                    trait_type = new TraitsType
                    {
                        id = "14",
                        name = "side face",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "51",
                    name = "Ninja Pad",
                    trait_type = new TraitsType
                    {
                        id = "12",
                        name = "accessories",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "56",
                    name = "Bare",
                    trait_type = new TraitsType
                    {
                        id = "13",
                        name = "back",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "230",
                    name = "Mint gradient",
                    trait_type = new TraitsType
                    {
                        id = "2",
                        name = "background",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "357",
                    name = "Matt plier",
                    trait_type =new TraitsType
                    {
                        id = "11",
                        name = "arms",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "364",
                    name = "Spicky collar",
                    trait_type =new TraitsType
                    {
                        id = "8",
                        name = "necklaces",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "367",
                    name = "Nose ring",
                    trait_type =new TraitsType
                    {
                        id = "4",
                        name = "nose",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "388",
                    name = "Haft blood buddy",
                    trait_type = new TraitsType
                    {
                        id = "1",
                        name = "body",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "397",
                    name = "Flash",
                    trait_type = new TraitsType
                    {
                        id = "3",
                        name = "ear",
                        description = null
                    }
                }
            },
            skills = new SkillNekoData[]
            {
                new SkillNekoData
                {
                    id = "ccf77825-835b-4d90-a81b-96be3919e652",
                    name = "Neko-Skill-5-1",
                    metadata = new MetaDataSkill
                    {
                        function = "cover",
                        atk = 569,
                        def = 254,
                        speed = 5,
                        mana = 10
                    }
                },
                new SkillNekoData
                {
                    id = "6addb7d1-ec57-407b-b5fb-c3d1c06d5cd6",
                    name = "Neko-Skill-5-2",
                    metadata = new MetaDataSkill
                    {
                        function = "fire",
                        atk = 418,
                        def = 358,
                        speed = 3,
                        mana = 18
                    }
                }
            }
        };
        NekoData neko3 = new NekoData
        {
            id = "2a92913b-98c1-46ff-8427-aa3bfd08d75f",
            mint_address = "6PX72AkDUR1wH7kXcPuX2kqZ2XArLRA6cBs5W4vaN3MT",
            nft_id = "7135",
            name = "NEKO #7135",
            className = "Fire",
            metadata = new MetaDataNeko
            {
                atk = 161,
                m_atk = 189,
                def = 186,
                m_def = 164,
                speed = 110,
                health = 255,
                mana = 100
            },
            level = 1,
            experience = 0,
            traits = new TraitsData[] {
                new TraitsData
                {
                    id = "64",
                    name = "Bunny",
                    trait_type = new TraitsType
                    {
                        id = "3",
                        name = "ear",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "67",
                    name = "Big nose",
                    trait_type = new TraitsType
                    {
                        id = "4",
                        name = "nose",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "69",
                    name = "Fire stare",
                    trait_type =new TraitsType
                    {
                        id = "5",
                        name = "eye",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "73",
                    name = "Picky",
                    trait_type =new TraitsType
                    {
                        id = "6",
                        name = "eyebrow",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "78",
                    name = "Fire shining pendant",
                    trait_type =new TraitsType
                    {
                        id = "7",
                        name = "medal",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "82",
                    name = "Minimal gold",
                    trait_type = new TraitsType
                    {
                        id = "8",
                        name = "necklaces",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "83",
                    name = "Bare",
                    trait_type = new TraitsType
                    {
                        id = "9",
                        name = "top",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "93",
                    name = "Bare",
                    trait_type = new TraitsType
                    {
                        id = "10",
                        name = "front face",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "99",
                    name = "Gold cheek",
                    trait_type = new TraitsType
                    {
                        id = "14",
                        name = "side face",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "104",
                    name = "Molotov",
                    trait_type =new TraitsType
                    {
                        id = "11",
                        name = "arms",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "110",
                    name = "Bare",
                    trait_type =new TraitsType
                    {
                        id = "13",
                        name = "back",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "239",
                    name = "K Character",
                    trait_type =new TraitsType
                    {
                        id = "2",
                        name = "background",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "284",
                    name = "Shining warrior",
                    trait_type = new TraitsType
                    {
                        id = "12",
                        name = "accessories",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "360",
                    name = "Candy buddy",
                    trait_type = new TraitsType
                    {
                        id = "1",
                        name = "body",
                        description = null
                    }
                }
            },
            skills = new SkillNekoData[]
            {
                new SkillNekoData
                {
                    id = "80581b72-61c9-47c4-868c-202139c9cc66",
                    name = "Neko-Skill-2-1",
                    metadata = new MetaDataSkill
                    {
                        function = "cover",
                        atk = 450,
                        def = 352,
                        speed = 4,
                        mana = 12
                    }
                },
                new SkillNekoData
                {
                    id = "2621af68-5674-4136-ab5c-a8e4a4f01f6b",
                    name = "Neko-Skill-2-2",
                    metadata = new MetaDataSkill
                    {
                        function = "fire",
                        atk = 444,
                        def = 217,
                        speed = 1,
                        mana = 12
                    }
                }
            }
        };
        NekoData neko4 = new NekoData
        {
            id = "b4dedd83-cf0f-4dc9-852c-eb90a4cd3918",
            mint_address = "5F6RtVE1RhSdWQz274EW2NMjkCrLLSHDBHuVB7LFomtj",
            nft_id = "2822",
            name = "NEKO #2822",
            className = "Water",
            metadata = new MetaDataNeko
            {
                atk = 161,
                m_atk = 189,
                def = 186,
                m_def = 164,
                speed = 110,
                health = 255,
                mana = 100
            },
            level = 1,
            experience = 0,
            traits = new TraitsData[] {
                new TraitsData
                {
                    id = "163",
                    name = "Neutral buddy",
                    trait_type = new TraitsType
                    {
                        id = "1",
                        name = "body",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "167",
                    name = "Sharp feline",
                    trait_type = new TraitsType
                    {
                        id = "3",
                        name = "ear",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "175",
                    name = "Diamond gem",
                    trait_type = new TraitsType
                    {
                        id = "6",
                        name = "eyebrow",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "180",
                    name = "Water shining pendant",
                    trait_type = new TraitsType
                    {
                        id = "7",
                        name = "medal",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "184",
                    name = "Minimal gold",
                    trait_type = new TraitsType
                    {
                        id = "8",
                        name = "necklaces",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "200",
                    name = "Mermaid fin",
                    trait_type = new TraitsType
                    {
                        id = "14",
                        name = "side face",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "206",
                    name = "Bare",
                    trait_type = new TraitsType
                    {
                        id = "12",
                        name = "accessories",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "211",
                    name = "Bare",
                    trait_type = new TraitsType
                    {
                        id = "13",
                        name = "back",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "272",
                    name = "Red gradient",
                    trait_type = new TraitsType
                    {
                        id = "2",
                        name = "background",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "375",
                    name = "Heart nose",
                    trait_type = new TraitsType
                    {
                        id = "4",
                        name = "nose",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "379",
                    name = "Fire extinguisher",
                    trait_type = new TraitsType
                    {
                        id = "11",
                        name = "arms",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "380",
                    name = "Frappuccino bottle hat",
                    trait_type = new TraitsType
                    {
                        id = "9",
                        name = "top",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "387",
                    name = "Aqua cupid",
                    trait_type = new TraitsType
                    {
                        id = "10",
                        name = "front face",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "400",
                    name = "2 Colors",
                    trait_type = new TraitsType
                    {
                        id = "5",
                        name = "eye",
                        description = null
                    }
                }
            },
            skills = new SkillNekoData[]
            {
                new SkillNekoData
                {
                    id = "430e619c-5313-4a94-af3d-6b69e19fbd21",
                    name = "Neko-Skill-1-1",
                    metadata = new MetaDataSkill
                    {
                        function = "cover",
                        atk = 434,
                        def = 638,
                        speed = 5,
                        mana = 11
                    }
                },
                new SkillNekoData
                {
                    id = "6c055f33-6137-43e1-b0f8-1984cce3ea33",
                    name = "Neko-Skill-1-2",
                    metadata = new MetaDataSkill
                    {
                        function = "fire",
                        atk = 453,
                        def = 335,
                        speed = 2,
                        mana = 18
                    }
                }
            }
        };
        NekoData neko5 = new NekoData
        {
            id = "3cf90864-53b1-4a5c-a7dd-c67c22cc24c1",
            mint_address = "ALnZQ361akmfnvC6ur7viWMPzvE5BYqLgxUjW6VdpGWN",
            nft_id = "7136",
            name = "NEKO #7136",
            className = "Fire",
            metadata = new MetaDataNeko
            {
                atk = 161,
                m_atk = 189,
                def = 186,
                m_def = 164,
                speed = 110,
                health = 255,
                mana = 100
            },
            level = 1,
            experience = 0,
            traits = new TraitsData[] {
                new TraitsData
                {
                    id = "62",
                    name = "spleased Candy buddy",
                    trait_type = new TraitsType
                    {
                        id = "1",
                        name = "body",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "66",
                    name = "Nyan feline",
                    trait_type = new TraitsType
                    {
                        id = "3",
                        name = "ear",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "68",
                    name = "Frightening",
                    trait_type =new TraitsType
                    {
                        id = "5",
                        name = "eye",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "75",
                    name = "Bronze pendant",
                    trait_type =new TraitsType
                    {
                        id = "7",
                        name = "medal",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "81",
                    name = "Fabric choker",
                    trait_type =new TraitsType
                    {
                        id = "8",
                        name = "necklaces",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "85",
                    name = "Fire ball hat",
                    trait_type = new TraitsType
                    {
                        id = "9",
                        name = "top",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "95",
                    name = "Thief",
                    trait_type = new TraitsType
                    {
                        id = "10",
                        name = "front face",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "98",
                    name = "Bare",
                    trait_type = new TraitsType
                    {
                        id = "14",
                        name = "side face",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "108",
                    name = "Ninja pad",
                    trait_type = new TraitsType
                    {
                        id = "12",
                        name = "accessories",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "224",
                    name = "Yellow gradient",
                    trait_type =new TraitsType
                    {
                        id = "2",
                        name = "background",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "282",
                    name = "Dragon tail",
                    trait_type =new TraitsType
                    {
                        id = "13",
                        name = "back",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "306",
                    name = "White Thug",
                    trait_type =new TraitsType
                    {
                        id = "6",
                        name = "eyebrow",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "307",
                    name = "Heart nose",
                    trait_type = new TraitsType
                    {
                        id = "4",
                        name = "nose",
                        description = null
                    }
                },
                new TraitsData
                {
                    id = "315",
                    name = "Scope",
                    trait_type = new TraitsType
                    {
                        id = "11",
                        name = "arms",
                        description = null
                    }
                }
            },
            skills = new SkillNekoData[]
            {
                new SkillNekoData
                {
                    id = "80581b72-61c9-47c4-868c-202139c9cc66",
                    name = "Neko-Skill-2-1",
                    metadata = new MetaDataSkill
                    {
                        function = "cover",
                        atk = 450,
                        def = 352,
                        speed = 4,
                        mana = 12
                    }
                },
                new SkillNekoData
                {
                    id = "2621af68-5674-4136-ab5c-a8e4a4f01f6b",
                    name = "Neko-Skill-2-2",
                    metadata = new MetaDataSkill
                    {
                        function = "fire",
                        atk = 444,
                        def = 217,
                        speed = 1,
                        mana = 12
                    }
                }
            }
        };
        listMyNekoData.Add(neko);
        listMyNekoData.Add(neko1);
        listMyNekoData.Add(neko2);
        listMyNekoData.Add(neko3);
        listMyNekoData.Add(neko4);
        listMyNekoData.Add(neko5);
        return listMyNekoData;
    }
    
    public static List<DataArea> GetDataAreas()
    {
        List<DataArea> listArea = new List<DataArea>();
        DataArea area = new DataArea
        {
            id = "bd81a30e-96f5-4522-bbfa-a0b29f9032bb",
            name = "area-1",
            description = "Fire",
            area_type = 0,
            metadata = new MetaDataBackground
            {
                background = "fire"
            },
            created_at = "2022-03-23T10:19:12.613Z",
            updated_at = "2022-03-23T10:19:12.613Z",
            deleted_at = null,
            max_map_level = 2
        };
        DataArea area1 = new DataArea
        {
            id = "0ddd676e-9c32-4e8a-88dd-b27685b9c905",
            name = "area-2",
            description = "Water",
            area_type = 1,
            metadata = new MetaDataBackground
            {
                background = "water"
            },
            created_at = "2022-03-23T10:19:12.613Z",
            updated_at = "2022-03-23T10:19:12.613Z",
            deleted_at = null,
            max_map_level = 4
        };
        DataArea area2 = new DataArea
        {
            id = "fbb9b471-dddb-4768-a3eb-577020a21063",
            name = "area-3",
            description = "Plant",
            area_type = 2,
            metadata = new MetaDataBackground
            {
                background = "plant"
            },
            created_at = "2022-03-23T10:19:12.613Z",
            updated_at = "2022-03-23T10:19:12.613Z",
            deleted_at = null,
            max_map_level = 2
        };
        DataArea area3 = new DataArea
        {
            id = "2bbd6514-05c0-4d7a-8eda-77c6ac4a8a0c",
            name = "area-4",
            description = "Inferno",
            area_type = 3,
            metadata = new MetaDataBackground
            {
                background = "inferno"
            },
            created_at = "2022-03-23T10:19:12.613Z",
            updated_at = "2022-03-23T10:19:12.613Z",
            deleted_at = null,
            max_map_level = 2
        };
        DataArea area4 = new DataArea
        {
            id = "0cc2ade4-fddf-4bbd-84c4-8eecd12a972f",
            name = "area-5",
            description = "Hell",
            area_type = 4,
            metadata = new MetaDataBackground
            {
                background = "hell"
            },
            created_at = "2022-03-23T10:19:12.613Z",
            updated_at = "2022-03-23T10:19:12.613Z",
            deleted_at = null,
            max_map_level = 2
        };
        DataArea area5 = new DataArea
        {
            id = "fc093330-fd2d-4f71-a734-a45336932dda",
            name = "area-6",
            description = "Land",
            area_type = 5,
            metadata = new MetaDataBackground
            {
                background = "land"
            },
            created_at = "2022-03-23T10:19:12.613Z",
            updated_at = "2022-03-23T10:19:12.613Z",
            deleted_at = null,
            max_map_level = 2
        };
        listArea.Add(area);
        listArea.Add(area1);
        listArea.Add(area2);
        listArea.Add(area3);
        listArea.Add(area4);
        listArea.Add(area5);
        return listArea;
    }

    public static List<DataAreaLevel> GetDataAreaLevels()
    {
        List<DataAreaLevel> listDataAreaLevel = new List<DataAreaLevel>();
        DataAreaLevel level = new DataAreaLevel()
        {
            id = "bd71bc34-8740-4cfc-aa7b-bb90bc44b8a4",
            level = 1,
            metadata = new MetaDataBackground
            {
                background = "color-0"
            },
            created_at = "2022-03-23T10:19:12.624Z",
            updated_at = "2022-03-23T10:19:12.624Z",
            deleted_at = null,
            area_id = "bd81a30e-96f5-4522-bbfa-a0b29f9032bb",
            enemies = new DataEnemy[]
            {
                new DataEnemy
                {
                    id = "cf35a082-5d3b-41b0-a46c-c1b20b429643",
                    name = "Enemy-1",
                    element_id = 1,
                    class_id = 1,
                    metadata = new MetaDataEnemies
                    {
                        atk = 310,
                        def = 106,
                        speed = 10,
                        health = 240
                    },
                    strategy = "EnemyStrategy1",
                    map_level_id = "bd71bc34-8740-4cfc-aa7b-bb90bc44b8a4",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                },
                new DataEnemy
                {
                    id = "0f4faef0-dfbf-4a1b-8492-def70e39cdcf",
                    name = "Enemy-0",
                    element_id = 1,
                    class_id = 2,
                    metadata = new MetaDataEnemies
                    {
                        atk = 309,
                        def = 110,
                        speed = 2,
                        health = 207
                    },
                    strategy = "EnemyStrategy1",
                    map_level_id = "bd71bc34-8740-4cfc-aa7b-bb90bc44b8a4",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                },
                new DataEnemy
                {
                    id = "02ae6b61-c1a5-4c5c-af71-5115135996fa",
                    name = "Enemy-2",
                    element_id = 1,
                    class_id = 3,
                    metadata = new MetaDataEnemies
                    {
                        atk = 367,
                        def = 99,
                        speed = 6,
                        health = 204
                    },
                    strategy = "EnemyStrategy3",
                    map_level_id = "bd71bc34-8740-4cfc-aa7b-bb90bc44b8a4",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                },
                new DataEnemy
                {
                    id = "02ae6b61-c1a5-4c5c-af71-5115135996fb",
                    name = "Enemy-3",
                    element_id = 1,
                    class_id = 4,
                    metadata = new MetaDataEnemies
                    {
                        atk = 367,
                        def = 99,
                        speed = 6,
                        health = 204
                    },
                    strategy = "EnemyStrategy4",
                    map_level_id = "bd71bc34-8740-4cfc-aa7b-bb90bc44b8a4",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                }
            }
        };
        DataAreaLevel level1 = new DataAreaLevel()
        {
            id = "3e531d27-2243-491e-92d0-449dbc69ad93",
            level = 2,
            metadata = new MetaDataBackground
            {
                background = "color-0"
            },
            created_at = "2022-03-23T10:19:12.624Z",
            updated_at = "2022-03-23T10:19:12.624Z",
            deleted_at = null,
            area_id = "bd81a30e-96f5-4522-bbfa-a0b29f9032bb",
            enemies = new DataEnemy[]
            {
                new DataEnemy
                {
                    id = "cf35a082-5d3b-41b0-a46c-c1b20b429643",
                    name = "Enemy-0",
                    element_id = 1,
                    class_id = 1,
                    metadata = new MetaDataEnemies
                    {
                        atk = 310,
                        def = 106,
                        speed = 10,
                        health = 240
                    },
                    strategy = "EnemyStrategy1",
                    map_level_id = "3e531d27-2243-491e-92d0-449dbc69ad93",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                },
                new DataEnemy
                {
                    id = "0f4faef0-dfbf-4a1b-8492-def70e39cdcf",
                    name = "Enemy-1",
                    element_id = 1,
                    class_id = 2,
                    metadata = new MetaDataEnemies
                    {
                        atk = 309,
                        def = 110,
                        speed = 2,
                        health = 207
                    },
                    strategy = "EnemyStrategy1",
                    map_level_id = "3e531d27-2243-491e-92d0-449dbc69ad93",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                },
                new DataEnemy
                {
                    id = "02ae6b61-c1a5-4c5c-af71-5115135996fa",
                    name = "Enemy-2",
                    element_id = 1,
                    class_id = 3,
                    metadata = new MetaDataEnemies
                    {
                        atk = 367,
                        def = 99,
                        speed = 6,
                        health = 204
                    },
                    strategy = "EnemyStrategy3",
                    map_level_id = "3e531d27-2243-491e-92d0-449dbc69ad93",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                },
                new DataEnemy
                {
                    id = "02ae6b61-c1a5-4c5c-af71-5115135996fb",
                    name = "Enemy-3",
                    element_id = 1,
                    class_id = 4,
                    metadata = new MetaDataEnemies
                    {
                        atk = 367,
                        def = 99,
                        speed = 6,
                        health = 204
                    },
                    strategy = "EnemyStrategy4",
                    map_level_id = "3e531d27-2243-491e-92d0-449dbc69ad93",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                }
            }
        };
        DataAreaLevel level2 = new DataAreaLevel()
        {
            id = "dd7a7491-6b54-4654-a6c7-97fce3afd586",
            level = 2,
            metadata = new MetaDataBackground
            {
                background = "color-1"
            },
            created_at = "2022-03-23T10:19:12.624Z",
            updated_at = "2022-03-23T10:19:12.624Z",
            deleted_at = null,
            area_id = "0ddd676e-9c32-4e8a-88dd-b27685b9c905",
            enemies = new DataEnemy[]
            {
                new DataEnemy
                {
                    id = "cf35a082-5d3b-41b0-a46c-c1b20b429643",
                    name = "Enemy-0",
                    element_id = 1,
                    class_id = 1,
                    metadata = new MetaDataEnemies
                    {
                        atk = 310,
                        def = 106,
                        speed = 10,
                        health = 240
                    },
                    strategy = "EnemyStrategy1",
                    map_level_id = "dd7a7491-6b54-4654-a6c7-97fce3afd586",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                },
                new DataEnemy
                {
                    id = "0f4faef0-dfbf-4a1b-8492-def70e39cdcf",
                    name = "Enemy-1",
                    element_id = 1,
                    class_id = 2,
                    metadata = new MetaDataEnemies
                    {
                        atk = 309,
                        def = 110,
                        speed = 2,
                        health = 207
                    },
                    strategy = "EnemyStrategy1",
                    map_level_id = "dd7a7491-6b54-4654-a6c7-97fce3afd586",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                },
                new DataEnemy
                {
                    id = "02ae6b61-c1a5-4c5c-af71-5115135996fa",
                    name = "Enemy-2",
                    element_id = 1,
                    class_id = 3,
                    metadata = new MetaDataEnemies
                    {
                        atk = 367,
                        def = 99,
                        speed = 6,
                        health = 204
                    },
                    strategy = "EnemyStrategy3",
                    map_level_id = "dd7a7491-6b54-4654-a6c7-97fce3afd586",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                },
                new DataEnemy
                {
                    id = "02ae6b61-c1a5-4c5c-af71-5115135996fb",
                    name = "Enemy-3",
                    element_id = 1,
                    class_id = 4,
                    metadata = new MetaDataEnemies
                    {
                        atk = 367,
                        def = 99,
                        speed = 6,
                        health = 204
                    },
                    strategy = "EnemyStrategy4",
                    map_level_id = "dd7a7491-6b54-4654-a6c7-97fce3afd586",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                }
            }
        };
        DataAreaLevel level3 = new DataAreaLevel()
        {
            id = "794f30aa-27ab-4de3-b29e-b9c538d84c04",
            level = 4,
            metadata = new MetaDataBackground
            {
                background = "color-3"
            },
            created_at = "2022-03-23T10:19:12.624Z",
            updated_at = "2022-03-23T10:19:12.624Z",
            deleted_at = null,
            area_id = "0ddd676e-9c32-4e8a-88dd-b27685b9c905",
            enemies = new DataEnemy[]
            {
                new DataEnemy
                {
                    id = "cf35a082-5d3b-41b0-a46c-c1b20b429643",
                    name = "Enemy-0",
                    element_id = 1,
                    class_id = 1,
                    metadata = new MetaDataEnemies
                    {
                        atk = 310,
                        def = 106,
                        speed = 10,
                        health = 240
                    },
                    strategy = "EnemyStrategy1",
                    map_level_id = "794f30aa-27ab-4de3-b29e-b9c538d84c04",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                },
                new DataEnemy
                {
                    id = "0f4faef0-dfbf-4a1b-8492-def70e39cdcf",
                    name = "Enemy-1",
                    element_id = 1,
                    class_id = 2,
                    metadata = new MetaDataEnemies
                    {
                        atk = 309,
                        def = 110,
                        speed = 2,
                        health = 207
                    },
                    strategy = "EnemyStrategy1",
                    map_level_id = "794f30aa-27ab-4de3-b29e-b9c538d84c04",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                },
                new DataEnemy
                {
                    id = "02ae6b61-c1a5-4c5c-af71-5115135996fa",
                    name = "Enemy-2",
                    element_id = 1,
                    class_id = 3,
                    metadata = new MetaDataEnemies
                    {
                        atk = 367,
                        def = 99,
                        speed = 6,
                        health = 204
                    },
                    strategy = "EnemyStrategy3",
                    map_level_id = "794f30aa-27ab-4de3-b29e-b9c538d84c04",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                },
                new DataEnemy
                {
                    id = "02ae6b61-c1a5-4c5c-af71-5115135996fb",
                    name = "Enemy-3",
                    element_id = 1,
                    class_id = 4,
                    metadata = new MetaDataEnemies
                    {
                        atk = 367,
                        def = 99,
                        speed = 6,
                        health = 204
                    },
                    strategy = "EnemyStrategy4",
                    map_level_id = "794f30aa-27ab-4de3-b29e-b9c538d84c04",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                }
            }
        };
        DataAreaLevel level4 = new DataAreaLevel()
        {
            id = "0f9fe263-1bf3-462c-baf1-45004e110d79",
            level = 1,
            metadata = new MetaDataBackground
            {
                background = "color-2"
            },
            created_at = "2022-03-23T10:19:12.624Z",
            updated_at = "2022-03-23T10:19:12.624Z",
            deleted_at = null,
            area_id = "fbb9b471-dddb-4768-a3eb-577020a21063",
            enemies = new DataEnemy[]
            {
                new DataEnemy
                {
                    id = "cf35a082-5d3b-41b0-a46c-c1b20b429643",
                    name = "Enemy-0",
                    element_id = 1,
                    class_id = 1,
                    metadata = new MetaDataEnemies
                    {
                        atk = 310,
                        def = 106,
                        speed = 10,
                        health = 240
                    },
                    strategy = "EnemyStrategy1",
                    map_level_id = "0f9fe263-1bf3-462c-baf1-45004e110d79",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                },
                new DataEnemy
                {
                    id = "0f4faef0-dfbf-4a1b-8492-def70e39cdcf",
                    name = "Enemy-1",
                    element_id = 1,
                    class_id = 2,
                    metadata = new MetaDataEnemies
                    {
                        atk = 309,
                        def = 110,
                        speed = 2,
                        health = 207
                    },
                    strategy = "EnemyStrategy1",
                    map_level_id = "0f9fe263-1bf3-462c-baf1-45004e110d79",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                },
                new DataEnemy
                {
                    id = "0f9fe263-1bf3-462c-baf1-45004e110d79",
                    name = "Enemy-2",
                    element_id = 1,
                    class_id = 3,
                    metadata = new MetaDataEnemies
                    {
                        atk = 367,
                        def = 99,
                        speed = 6,
                        health = 204
                    },
                    strategy = "EnemyStrategy3",
                    map_level_id = "0f9fe263-1bf3-462c-baf1-45004e110d79",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                },
                new DataEnemy
                {
                    id = "02ae6b61-c1a5-4c5c-af71-5115135996fb",
                    name = "Enemy-3",
                    element_id = 1,
                    class_id = 4,
                    metadata = new MetaDataEnemies
                    {
                        atk = 367,
                        def = 99,
                        speed = 6,
                        health = 204
                    },
                    strategy = "EnemyStrategy4",
                    map_level_id = "0f9fe263-1bf3-462c-baf1-45004e110d79",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                }
            }
        };
        DataAreaLevel level5 = new DataAreaLevel()
        {
            id = "f1294662-02c1-440b-b348-bdb45e0a4b6b",
            level = 2,
            metadata = new MetaDataBackground
            {
                background = "color-2"
            },
            created_at = "2022-03-23T10:19:12.624Z",
            updated_at = "2022-03-23T10:19:12.624Z",
            deleted_at = null,
            area_id = "fbb9b471-dddb-4768-a3eb-577020a21063",
            enemies = new DataEnemy[]
            {
                new DataEnemy
                {
                    id = "cf35a082-5d3b-41b0-a46c-c1b20b429643",
                    name = "Enemy-0",
                    element_id = 1,
                    class_id = 1,
                    metadata = new MetaDataEnemies
                    {
                        atk = 310,
                        def = 106,
                        speed = 10,
                        health = 240
                    },
                    strategy = "EnemyStrategy1",
                    map_level_id = "f1294662-02c1-440b-b348-bdb45e0a4b6b",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                },
                new DataEnemy
                {
                    id = "0f4faef0-dfbf-4a1b-8492-def70e39cdcf",
                    name = "Enemy-1",
                    element_id = 1,
                    class_id = 2,
                    metadata = new MetaDataEnemies
                    {
                        atk = 309,
                        def = 110,
                        speed = 2,
                        health = 207
                    },
                    strategy = "EnemyStrategy1",
                    map_level_id = "f1294662-02c1-440b-b348-bdb45e0a4b6b",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                },
                new DataEnemy
                {
                    id = "0f9fe263-1bf3-462c-baf1-45004e110d79",
                    name = "Enemy-2",
                    element_id = 1,
                    class_id = 3,
                    metadata = new MetaDataEnemies
                    {
                        atk = 367,
                        def = 99,
                        speed = 6,
                        health = 204
                    },
                    strategy = "EnemyStrategy3",
                    map_level_id = "f1294662-02c1-440b-b348-bdb45e0a4b6b",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                },
                new DataEnemy
                {
                    id = "02ae6b61-c1a5-4c5c-af71-5115135996fb",
                    name = "Enemy-3",
                    element_id = 1,
                    class_id = 4,
                    metadata = new MetaDataEnemies
                    {
                        atk = 367,
                        def = 99,
                        speed = 6,
                        health = 204
                    },
                    strategy = "EnemyStrategy4",
                    map_level_id = "f1294662-02c1-440b-b348-bdb45e0a4b6b",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                }
            }
        };
        DataAreaLevel level6 = new DataAreaLevel()
        {
            id = "4811fef4-9185-4a8d-b898-3fdb97c9c774",
            level = 1,
            metadata = new MetaDataBackground
            {
                background = "color-3"
            },
            created_at = "2022-03-23T10:19:12.624Z",
            updated_at = "2022-03-23T10:19:12.624Z",
            deleted_at = null,
            area_id = "2bbd6514-05c0-4d7a-8eda-77c6ac4a8a0c",
            enemies = new DataEnemy[]
            {
                new DataEnemy
                {
                    id = "cf35a082-5d3b-41b0-a46c-c1b20b429643",
                    name = "Enemy-0",
                    element_id = 1,
                    class_id = 1,
                    metadata = new MetaDataEnemies
                    {
                        atk = 310,
                        def = 106,
                        speed = 10,
                        health = 240
                    },
                    strategy = "EnemyStrategy1",
                    map_level_id = "4811fef4-9185-4a8d-b898-3fdb97c9c774",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                },
                new DataEnemy
                {
                    id = "0f4faef0-dfbf-4a1b-8492-def70e39cdcf",
                    name = "Enemy-1",
                    element_id = 1,
                    class_id = 2,
                    metadata = new MetaDataEnemies
                    {
                        atk = 309,
                        def = 110,
                        speed = 2,
                        health = 207
                    },
                    strategy = "EnemyStrategy1",
                    map_level_id = "4811fef4-9185-4a8d-b898-3fdb97c9c774",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                },
                new DataEnemy
                {
                    id = "0f9fe263-1bf3-462c-baf1-45004e110d79",
                    name = "Enemy-2",
                    element_id = 1,
                    class_id = 3,
                    metadata = new MetaDataEnemies
                    {
                        atk = 367,
                        def = 99,
                        speed = 6,
                        health = 204
                    },
                    strategy = "EnemyStrategy3",
                    map_level_id = "4811fef4-9185-4a8d-b898-3fdb97c9c774",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                },
                new DataEnemy
                {
                    id = "02ae6b61-c1a5-4c5c-af71-5115135996fb",
                    name = "Enemy-3",
                    element_id = 1,
                    class_id = 4,
                    metadata = new MetaDataEnemies
                    {
                        atk = 367,
                        def = 99,
                        speed = 6,
                        health = 204
                    },
                    strategy = "EnemyStrategy4",
                    map_level_id = "4811fef4-9185-4a8d-b898-3fdb97c9c774",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                }
            }
        };
        DataAreaLevel level7 = new DataAreaLevel()
        {
            id = "f9f5690d-17b4-4c65-8164-e9e1e32c3dbf",
            level = 2,
            metadata = new MetaDataBackground
            {
                background = "color-3"
            },
            created_at = "2022-03-23T10:19:12.624Z",
            updated_at = "2022-03-23T10:19:12.624Z",
            deleted_at = null,
            area_id = "2bbd6514-05c0-4d7a-8eda-77c6ac4a8a0c",
            enemies = new DataEnemy[]
            {
                new DataEnemy
                {
                    id = "cf35a082-5d3b-41b0-a46c-c1b20b429643",
                    name = "Enemy-0",
                    element_id = 1,
                    class_id = 1,
                    metadata = new MetaDataEnemies
                    {
                        atk = 310,
                        def = 106,
                        speed = 10,
                        health = 240
                    },
                    strategy = "EnemyStrategy1",
                    map_level_id = "f9f5690d-17b4-4c65-8164-e9e1e32c3dbf",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                },
                new DataEnemy
                {
                    id = "0f4faef0-dfbf-4a1b-8492-def70e39cdcf",
                    name = "Enemy-1",
                    element_id = 1,
                    class_id = 2,
                    metadata = new MetaDataEnemies
                    {
                        atk = 309,
                        def = 110,
                        speed = 2,
                        health = 207
                    },
                    strategy = "EnemyStrategy1",
                    map_level_id = "f9f5690d-17b4-4c65-8164-e9e1e32c3dbf",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                },
                new DataEnemy
                {
                    id = "0f9fe263-1bf3-462c-baf1-45004e110d79",
                    name = "Enemy-2",
                    element_id = 1,
                    class_id = 3,
                    metadata = new MetaDataEnemies
                    {
                        atk = 367,
                        def = 99,
                        speed = 6,
                        health = 204
                    },
                    strategy = "EnemyStrategy3",
                    map_level_id = "f9f5690d-17b4-4c65-8164-e9e1e32c3dbf",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                },
                new DataEnemy
                {
                    id = "02ae6b61-c1a5-4c5c-af71-5115135996fb",
                    name = "Enemy-3",
                    element_id = 1,
                    class_id = 4,
                    metadata = new MetaDataEnemies
                    {
                        atk = 367,
                        def = 99,
                        speed = 6,
                        health = 204
                    },
                    strategy = "EnemyStrategy4",
                    map_level_id = "f9f5690d-17b4-4c65-8164-e9e1e32c3dbf",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                }
            }
        };
        DataAreaLevel level8 = new DataAreaLevel()
        {
            id = "760821c9-a5d2-4ef5-a931-08c85001797a",
            level = 1,
            metadata = new MetaDataBackground
            {
                background = "color-4"
            },
            created_at = "2022-03-23T10:19:12.624Z",
            updated_at = "2022-03-23T10:19:12.624Z",
            deleted_at = null,
            area_id = "0cc2ade4-fddf-4bbd-84c4-8eecd12a972f",
            enemies = new DataEnemy[]
            {
                new DataEnemy
                {
                    id = "cf35a082-5d3b-41b0-a46c-c1b20b429643",
                    name = "Enemy-0",
                    element_id = 1,
                    class_id = 1,
                    metadata = new MetaDataEnemies
                    {
                        atk = 310,
                        def = 106,
                        speed = 10,
                        health = 240
                    },
                    strategy = "EnemyStrategy1",
                    map_level_id = "760821c9-a5d2-4ef5-a931-08c85001797a",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                },
                new DataEnemy
                {
                    id = "0f4faef0-dfbf-4a1b-8492-def70e39cdcf",
                    name = "Enemy-1",
                    element_id = 1,
                    class_id = 2,
                    metadata = new MetaDataEnemies
                    {
                        atk = 309,
                        def = 110,
                        speed = 2,
                        health = 207
                    },
                    strategy = "EnemyStrategy1",
                    map_level_id = "760821c9-a5d2-4ef5-a931-08c85001797a",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                },
                new DataEnemy
                {
                    id = "0f9fe263-1bf3-462c-baf1-45004e110d79",
                    name = "Enemy-2",
                    element_id = 1,
                    class_id = 3,
                    metadata = new MetaDataEnemies
                    {
                        atk = 367,
                        def = 99,
                        speed = 6,
                        health = 204
                    },
                    strategy = "EnemyStrategy3",
                    map_level_id = "760821c9-a5d2-4ef5-a931-08c85001797a",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                },
                new DataEnemy
                {
                    id = "02ae6b61-c1a5-4c5c-af71-5115135996fb",
                    name = "Enemy-3",
                    element_id = 1,
                    class_id = 4,
                    metadata = new MetaDataEnemies
                    {
                        atk = 367,
                        def = 99,
                        speed = 6,
                        health = 204
                    },
                    strategy = "EnemyStrategy4",
                    map_level_id = "760821c9-a5d2-4ef5-a931-08c85001797a",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                }
            }
        };
        DataAreaLevel level9 = new DataAreaLevel()
        {
            id = "d56fa7c2-0098-4248-9a9a-6a6a7264cbd3",
            level = 2,
            metadata = new MetaDataBackground
            {
                background = "color-4"
            },
            created_at = "2022-03-23T10:19:12.624Z",
            updated_at = "2022-03-23T10:19:12.624Z",
            deleted_at = null,
            area_id = "0cc2ade4-fddf-4bbd-84c4-8eecd12a972f",
            enemies = new DataEnemy[]
            {
                new DataEnemy
                {
                    id = "cf35a082-5d3b-41b0-a46c-c1b20b429643",
                    name = "Enemy-0",
                    element_id = 1,
                    class_id = 1,
                    metadata = new MetaDataEnemies
                    {
                        atk = 310,
                        def = 106,
                        speed = 10,
                        health = 240
                    },
                    strategy = "EnemyStrategy1",
                    map_level_id = "d56fa7c2-0098-4248-9a9a-6a6a7264cbd3",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                },
                new DataEnemy
                {
                    id = "0f4faef0-dfbf-4a1b-8492-def70e39cdcf",
                    name = "Enemy-1",
                    element_id = 1,
                    class_id = 2,
                    metadata = new MetaDataEnemies
                    {
                        atk = 309,
                        def = 110,
                        speed = 2,
                        health = 207
                    },
                    strategy = "EnemyStrategy1",
                    map_level_id = "d56fa7c2-0098-4248-9a9a-6a6a7264cbd3",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                },
                new DataEnemy
                {
                    id = "0f9fe263-1bf3-462c-baf1-45004e110d79",
                    name = "Enemy-2",
                    element_id = 1,
                    class_id = 3,
                    metadata = new MetaDataEnemies
                    {
                        atk = 367,
                        def = 99,
                        speed = 6,
                        health = 204
                    },
                    strategy = "EnemyStrategy3",
                    map_level_id = "d56fa7c2-0098-4248-9a9a-6a6a7264cbd3",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                },
                new DataEnemy
                {
                    id = "02ae6b61-c1a5-4c5c-af71-5115135996fb",
                    name = "Enemy-3",
                    element_id = 1,
                    class_id = 4,
                    metadata = new MetaDataEnemies
                    {
                        atk = 367,
                        def = 99,
                        speed = 6,
                        health = 204
                    },
                    strategy = "EnemyStrategy4",
                    map_level_id = "d56fa7c2-0098-4248-9a9a-6a6a7264cbd3",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                }
            }
        };
        DataAreaLevel level10 = new DataAreaLevel()
        {
            id = "b5e02df0-e3d9-4e01-ace2-1d44344cf6e8",
            level = 1,
            metadata = new MetaDataBackground
            {
                background = "color-5"
            },
            created_at = "2022-03-23T10:19:12.624Z",
            updated_at = "2022-03-23T10:19:12.624Z",
            deleted_at = null,
            area_id = "fc093330-fd2d-4f71-a734-a45336932dda",
            enemies = new DataEnemy[]
            {
                new DataEnemy
                {
                    id = "cf35a082-5d3b-41b0-a46c-c1b20b429643",
                    name = "Enemy-0",
                    element_id = 1,
                    class_id = 1,
                    metadata = new MetaDataEnemies
                    {
                        atk = 310,
                        def = 106,
                        speed = 10,
                        health = 240
                    },
                    strategy = "EnemyStrategy1",
                    map_level_id = "b5e02df0-e3d9-4e01-ace2-1d44344cf6e8",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                },
                new DataEnemy
                {
                    id = "0f4faef0-dfbf-4a1b-8492-def70e39cdcf",
                    name = "Enemy-1",
                    element_id = 1,
                    class_id = 2,
                    metadata = new MetaDataEnemies
                    {
                        atk = 309,
                        def = 110,
                        speed = 2,
                        health = 207
                    },
                    strategy = "EnemyStrategy1",
                    map_level_id = "b5e02df0-e3d9-4e01-ace2-1d44344cf6e8",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                },
                new DataEnemy
                {
                    id = "0f9fe263-1bf3-462c-baf1-45004e110d79",
                    name = "Enemy-2",
                    element_id = 1,
                    class_id = 3,
                    metadata = new MetaDataEnemies
                    {
                        atk = 367,
                        def = 99,
                        speed = 6,
                        health = 204
                    },
                    strategy = "EnemyStrategy3",
                    map_level_id = "b5e02df0-e3d9-4e01-ace2-1d44344cf6e8",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                },
                new DataEnemy
                {
                    id = "02ae6b61-c1a5-4c5c-af71-5115135996fb",
                    name = "Enemy-3",
                    element_id = 1,
                    class_id = 4,
                    metadata = new MetaDataEnemies
                    {
                        atk = 367,
                        def = 99,
                        speed = 6,
                        health = 204
                    },
                    strategy = "EnemyStrategy4",
                    map_level_id = "b5e02df0-e3d9-4e01-ace2-1d44344cf6e8",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                }
            }
        };
        DataAreaLevel level11 = new DataAreaLevel()
        {
            id = "df271b57-11bb-471c-a23f-7fb6d72345ff",
            level = 2,
            metadata = new MetaDataBackground
            {
                background = "color-5"
            },
            created_at = "2022-03-23T10:19:12.624Z",
            updated_at = "2022-03-23T10:19:12.624Z",
            deleted_at = null,
            area_id = "fc093330-fd2d-4f71-a734-a45336932dda",
            enemies = new DataEnemy[]
            {
                new DataEnemy
                {
                    id = "cf35a082-5d3b-41b0-a46c-c1b20b429643",
                    name = "Enemy-0",
                    element_id = 1,
                    class_id = 1,
                    metadata = new MetaDataEnemies
                    {
                        atk = 310,
                        def = 106,
                        speed = 10,
                        health = 240
                    },
                    strategy = "EnemyStrategy1",
                    map_level_id = "df271b57-11bb-471c-a23f-7fb6d72345ff",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                },
                new DataEnemy
                {
                    id = "0f4faef0-dfbf-4a1b-8492-def70e39cdcf",
                    name = "Enemy-1",
                    element_id = 1,
                    class_id = 2,
                    metadata = new MetaDataEnemies
                    {
                        atk = 309,
                        def = 110,
                        speed = 2,
                        health = 207
                    },
                    strategy = "EnemyStrategy1",
                    map_level_id = "df271b57-11bb-471c-a23f-7fb6d72345ff",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                },
                new DataEnemy
                {
                    id = "0f9fe263-1bf3-462c-baf1-45004e110d79",
                    name = "Enemy-2",
                    element_id = 1,
                    class_id = 3,
                    metadata = new MetaDataEnemies
                    {
                        atk = 367,
                        def = 99,
                        speed = 6,
                        health = 204
                    },
                    strategy = "EnemyStrategy3",
                    map_level_id = "df271b57-11bb-471c-a23f-7fb6d72345ff",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                },
                new DataEnemy
                {
                    id = "02ae6b61-c1a5-4c5c-af71-5115135996fb",
                    name = "Enemy-3",
                    element_id = 1,
                    class_id = 4,
                    metadata = new MetaDataEnemies
                    {
                        atk = 367,
                        def = 99,
                        speed = 6,
                        health = 204
                    },
                    strategy = "EnemyStrategy4",
                    map_level_id = "df271b57-11bb-471c-a23f-7fb6d72345ff",
                    created_at = "2022-03-23T10:19:12.726Z",
                    updated_at = "2022-03-23T10:19:12.726Z",
                    deleted_at = null
                }
            }
        };
        listDataAreaLevel.Add(level);
        listDataAreaLevel.Add(level1);
        listDataAreaLevel.Add(level2);
        listDataAreaLevel.Add(level3);
        listDataAreaLevel.Add(level4);
        listDataAreaLevel.Add(level5);
        listDataAreaLevel.Add(level6);
        listDataAreaLevel.Add(level7);
        listDataAreaLevel.Add(level8);
        listDataAreaLevel.Add(level9);
        listDataAreaLevel.Add(level10);
        listDataAreaLevel.Add(level11);
        return listDataAreaLevel;
    }
}
