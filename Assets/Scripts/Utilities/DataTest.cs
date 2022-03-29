using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTest
{
    public static string[] listTraitNames = new[]
        {
        ModelConst.Body, ModelConst.Ear, ModelConst.Nose, ModelConst.Eye, ModelConst.Eyebrow, ModelConst.Medal,
        ModelConst.Necklaces, ModelConst.FrontFace, ModelConst.Arms, ModelConst.Accessories,
        ModelConst.Back, ModelConst.SideFace
    };

    public static List<NekoData> GetMyNekoDatas()
    {
        List<NekoData> listMyNekoData = new List<NekoData>(); 
        NekoData neko = new NekoData
        {
            id = "15c6b4ae-bcd5-4886-bf1e-ec98790e96f3",
            mint_address = "29MXryUw6xBBVQXiwQgD5ZqNrsbWYtA2xpLdkX6ZvC6D",
            nft_id = "5244",
            name = "NEKO #5244",
            metadata = new MetaData
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
                    id = "164",
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
                    trait_type =new TraitsType
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
                    trait_type =new TraitsType
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
                    trait_type =new TraitsType
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
                    trait_type =new TraitsType
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
                    trait_type =new TraitsType
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
                    trait_type =new TraitsType
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
                }
            }
        };
        
        

        NekoData neko1 = new NekoData
        {
            id = "47e04355-7243-4f15-96e4-a8192fd5022a",
            mint_address = "4kixX7y4x536BT2xuk1EYidBQoucZMjGhFneQ4KytiwR",
            nft_id = "1841",
            name = "NEKO #1841",
            metadata = new MetaData
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
            }
        };
        NekoData neko2 = new NekoData
        {
            id = "fa681035-cddc-44be-8182-bd25057c5534",
            mint_address = "6uZWNsJPaF27uPM5rTVuHtGEz3RtFAcUa1hjJncCTQbN",
            nft_id = "12",
            name = "NEKO #12",
            metadata = new MetaData
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
            }
        };
        NekoData neko3 = new NekoData
        {
            id = "2a92913b-98c1-46ff-8427-aa3bfd08d75f",
            mint_address = "6PX72AkDUR1wH7kXcPuX2kqZ2XArLRA6cBs5W4vaN3MT",
            nft_id = "7135",
            name = "NEKO #7135",
            metadata = new MetaData
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
            }
        };
        listMyNekoData.Add(neko);
        listMyNekoData.Add(neko1);
        listMyNekoData.Add(neko2);
        listMyNekoData.Add(neko3);
        return listMyNekoData;
    }
    public static List<Neko> GetListNeko()
    {
        List<Neko> listNeko = new List<Neko>();


        //data neko
        Neko neko = new Neko();
        neko.NekoName = "Neko #12312";
        neko.NekoClass = NekoClass.Fire;
        neko.UrlImage = "https://d1j8r0kxyu9tj8.cloudfront.net/neko/neko/origin/200x200/5001.png";

        List<NekoSkill> nekoListSkills = new List<NekoSkill>();

        NekoSkill nekoSkill1 = new NekoSkill();
        nekoSkill1.NameSkill = "Fire Shocking";

        NekoSkill nekoSkill2 = new NekoSkill();
        nekoSkill2.NameSkill = "Fire Discard";

        NekoSkill nekoSkill3 = new NekoSkill();
        nekoSkill3.NameSkill = "Fire Virus";

        NekoSkill nekoSkill4 = new NekoSkill();
        nekoSkill4.NameSkill = "Fire Hell Boy";

        NekoSkill nekoSkill5 = new NekoSkill();
        nekoSkill5.NameSkill = "Fire Last Man Stand";

        NekoSkill nekoSkill6 = new NekoSkill();
        nekoSkill6.NameSkill = "Fire Supreme";




        nekoListSkills.Add(nekoSkill1);
        nekoListSkills.Add(nekoSkill2);
        nekoListSkills.Add(nekoSkill3);
        nekoListSkills.Add(nekoSkill4);
        nekoListSkills.Add(nekoSkill5);
        nekoListSkills.Add(nekoSkill6);

        neko.traitsNeko.Add(listTraitNames[0], 1);
        neko.traitsNeko.Add(listTraitNames[1], 2);
        neko.traitsNeko.Add(listTraitNames[2], 1);
        neko.traitsNeko.Add(listTraitNames[3], 2);
        neko.traitsNeko.Add(listTraitNames[4], 4);
        neko.traitsNeko.Add(listTraitNames[5], 3);
        neko.traitsNeko.Add(listTraitNames[6], 4);
        neko.traitsNeko.Add(listTraitNames[7], 9);
        neko.traitsNeko.Add(listTraitNames[8], 8);
        neko.traitsNeko.Add(listTraitNames[9], 4);
        neko.traitsNeko.Add(listTraitNames[10], 4);
        neko.traitsNeko.Add(listTraitNames[11], 3);

        neko.NekoSkill = nekoListSkills;
        neko.Atk = 90;
        neko.Speed = 160;
        neko.HP = 160;



        Neko neko1 = new Neko();
        neko1.NekoName = "Neko #12300";
        neko1.NekoClass = NekoClass.Fire;
        neko1.UrlImage = "https://d1j8r0kxyu9tj8.cloudfront.net/neko/neko/origin/200x200/5002.png";

        List<NekoSkill> neko1ListSkills = new List<NekoSkill>();

        NekoSkill neko1Skill1 = new NekoSkill();
        neko1Skill1.NameSkill = "Fire Shocking";

        NekoSkill neko1Skill2 = new NekoSkill();
        neko1Skill2.NameSkill = "Fire Discard";

        NekoSkill neko1Skill3 = new NekoSkill();
        neko1Skill3.NameSkill = "Fire Virus";

        NekoSkill neko1Skill4 = new NekoSkill();
        neko1Skill4.NameSkill = "Fire Hell Boy";

        NekoSkill neko1Skill5 = new NekoSkill();
        neko1Skill5.NameSkill = "Fire Last Man Stand";


        neko1ListSkills.Add(neko1Skill1);
        neko1ListSkills.Add(neko1Skill2);
        neko1ListSkills.Add(neko1Skill3);
        neko1ListSkills.Add(neko1Skill4);
        neko1ListSkills.Add(neko1Skill5);

        neko1.traitsNeko.Add(listTraitNames[0], 2);
        neko1.traitsNeko.Add(listTraitNames[1], 1);
        neko1.traitsNeko.Add(listTraitNames[2], 1);
        neko1.traitsNeko.Add(listTraitNames[3], 2);
        neko1.traitsNeko.Add(listTraitNames[4], 3);
        neko1.traitsNeko.Add(listTraitNames[5], 2);
        neko1.traitsNeko.Add(listTraitNames[6], 3);
        neko1.traitsNeko.Add(listTraitNames[7], 7);
        neko1.traitsNeko.Add(listTraitNames[8], 7);
        neko1.traitsNeko.Add(listTraitNames[9], 3);
        neko1.traitsNeko.Add(listTraitNames[10], 3);
        neko1.traitsNeko.Add(listTraitNames[11], 2);

        neko1.NekoSkill = neko1ListSkills;
        neko1.Atk = 100;
        neko1.Speed = 200;
        neko1.HP = 170;



        Neko neko2 = new Neko();
        neko2.NekoName = "Neko #12301";
        neko2.NekoClass = NekoClass.Fire;
        neko2.UrlImage = "https://d1j8r0kxyu9tj8.cloudfront.net/neko/neko/origin/200x200/5003.png";

        List<NekoSkill> neko2ListSkills = new List<NekoSkill>();

        NekoSkill neko2Skill1 = new NekoSkill();
        neko2Skill1.NameSkill = "Fire Shocking";

        NekoSkill neko2Skill2 = new NekoSkill();
        neko2Skill2.NameSkill = "Fire Discard";

        NekoSkill neko2Skill3 = new NekoSkill();
        neko2Skill3.NameSkill = "Fire Virus";

        NekoSkill neko2Skill4 = new NekoSkill();
        neko2Skill4.NameSkill = "Fire Hell Boy";

        NekoSkill neko2Skill5 = new NekoSkill();
        neko2Skill5.NameSkill = "Fire Last Man Stand";

        NekoSkill neko2Skill6 = new NekoSkill();
        neko2Skill6.NameSkill = "Fire Supreme";

        NekoSkill neko2Skill7 = new NekoSkill();
        neko2Skill7.NameSkill = "Fire Buring Sun";
        neko2Skill7.IsLockSkill = true;


        neko2ListSkills.Add(neko2Skill1);
        neko2ListSkills.Add(neko2Skill2);
        neko2ListSkills.Add(neko2Skill3);
        neko2ListSkills.Add(neko2Skill4);
        neko2ListSkills.Add(neko2Skill5);
        neko2ListSkills.Add(neko2Skill6);
        neko2ListSkills.Add(neko2Skill7);

        neko2.NekoSkill = neko2ListSkills;
        neko2.Atk = 170;
        neko2.Speed = 115;
        neko2.HP = 200;


        neko2.traitsNeko.Add(listTraitNames[0], 3);
        neko2.traitsNeko.Add(listTraitNames[1], 1);
        neko2.traitsNeko.Add(listTraitNames[2], 1);
        neko2.traitsNeko.Add(listTraitNames[3], 2);
        neko2.traitsNeko.Add(listTraitNames[4], 4);
        neko2.traitsNeko.Add(listTraitNames[5], 2);
        neko2.traitsNeko.Add(listTraitNames[6], 4);
        neko2.traitsNeko.Add(listTraitNames[7], 2);
        neko2.traitsNeko.Add(listTraitNames[8], 5);
        neko2.traitsNeko.Add(listTraitNames[9], 2);
        neko2.traitsNeko.Add(listTraitNames[10], 2);
        neko2.traitsNeko.Add(listTraitNames[11], 1);

        // neko earth
        Neko neko3 = new Neko();
        neko3.NekoName = "Neko #12211";
        neko3.NekoClass = NekoClass.Earth;
        neko3.UrlImage = "https://d1j8r0kxyu9tj8.cloudfront.net/neko/neko/origin/200x200/1.png";

        List<NekoSkill> neko3ListSkills = new List<NekoSkill>();

        NekoSkill neko3Skill1 = new NekoSkill();
        neko3Skill1.NameSkill = "Earth Shocking";

        NekoSkill neko3Skill2 = new NekoSkill();
        neko3Skill2.NameSkill = "Earth Scratch";

        NekoSkill neko3Skill3 = new NekoSkill();
        neko3Skill3.NameSkill = "Earth Blast";

        NekoSkill neko3Skill4 = new NekoSkill();
        neko3Skill4.NameSkill = "Earth Element Burn";

        NekoSkill neko3Skill5 = new NekoSkill();
        neko3Skill5.NameSkill = "Earth Discard";

        NekoSkill neko3Skill6 = new NekoSkill();
        neko3Skill6.NameSkill = "Earth Virus";
        neko3Skill6.IsLockSkill = true;

        NekoSkill neko3Skill7 = new NekoSkill();
        neko3Skill7.NameSkill = "Earth Hell Boy";


        neko3ListSkills.Add(neko3Skill1);
        neko3ListSkills.Add(neko3Skill2);
        neko3ListSkills.Add(neko3Skill3);
        neko3ListSkills.Add(neko3Skill4);
        neko3ListSkills.Add(neko3Skill5);
        neko3ListSkills.Add(neko3Skill6);
        neko3ListSkills.Add(neko3Skill7);

        neko3.NekoSkill = neko3ListSkills;
        neko3.Atk = 170;
        neko3.Speed = 140;
        neko3.HP = 150;


        neko3.traitsNeko.Add(listTraitNames[0], 4);
        neko3.traitsNeko.Add(listTraitNames[1], 4);
        neko3.traitsNeko.Add(listTraitNames[2], 1);
        neko3.traitsNeko.Add(listTraitNames[3], 1);
        neko3.traitsNeko.Add(listTraitNames[4], 1);
        neko3.traitsNeko.Add(listTraitNames[5], 1);
        neko3.traitsNeko.Add(listTraitNames[6], 2);
        neko3.traitsNeko.Add(listTraitNames[7], 1);
        neko3.traitsNeko.Add(listTraitNames[8], 3);
        neko3.traitsNeko.Add(listTraitNames[9], 4);
        neko3.traitsNeko.Add(listTraitNames[10], 1);
        neko3.traitsNeko.Add(listTraitNames[11], 1);

        Neko neko4 = new Neko();
        neko4.NekoName = "Neko #12212";
        neko4.NekoClass = NekoClass.Earth;
        neko4.UrlImage = "https://d1j8r0kxyu9tj8.cloudfront.net/neko/neko/origin/200x200/2.png";

        List<NekoSkill> neko4ListSkills = new List<NekoSkill>();

        NekoSkill neko4Skill1 = new NekoSkill();
        neko4Skill1.NameSkill = "Earth Shocking";

        NekoSkill neko4Skill2 = new NekoSkill();
        neko4Skill2.NameSkill = "Earth Scratch";

        NekoSkill neko4Skill3 = new NekoSkill();
        neko4Skill3.NameSkill = "Earth Blast";

        NekoSkill neko4Skill4 = new NekoSkill();
        neko4Skill4.NameSkill = "Earth Element Burn";

        NekoSkill neko4Skill5 = new NekoSkill();
        neko4Skill5.NameSkill = "Earth Discard";

        NekoSkill neko4Skill6 = new NekoSkill();
        neko4Skill6.NameSkill = "Earth Virus";
        neko4Skill6.IsLockSkill = true;

        NekoSkill neko4Skill7 = new NekoSkill();
        neko4Skill7.NameSkill = "Earth Hell Boy";


        NekoSkill neko4Skill8 = new NekoSkill();
        neko4Skill8.NameSkill = "Earth Last Man Stand";

        neko4ListSkills.Add(neko4Skill1);
        neko4ListSkills.Add(neko4Skill2);
        neko4ListSkills.Add(neko4Skill3);
        neko4ListSkills.Add(neko4Skill4);
        neko4ListSkills.Add(neko4Skill5);
        neko4ListSkills.Add(neko4Skill6);
        neko4ListSkills.Add(neko4Skill7);
        neko4ListSkills.Add(neko4Skill8);

        neko4.NekoSkill = neko4ListSkills;
        neko4.Atk = 140;
        neko4.Speed = 125;
        neko4.HP = 190;


        neko4.traitsNeko.Add(listTraitNames[0], 5);
        neko4.traitsNeko.Add(listTraitNames[1], 4);
        neko4.traitsNeko.Add(listTraitNames[2], 1);
        neko4.traitsNeko.Add(listTraitNames[3], 1);
        neko4.traitsNeko.Add(listTraitNames[4], 1);
        neko4.traitsNeko.Add(listTraitNames[5], 1);
        neko4.traitsNeko.Add(listTraitNames[6], 2);
        neko4.traitsNeko.Add(listTraitNames[7], 1);
        neko4.traitsNeko.Add(listTraitNames[8], 3);
        neko4.traitsNeko.Add(listTraitNames[9], 7);
        neko4.traitsNeko.Add(listTraitNames[10], 1);
        neko4.traitsNeko.Add(listTraitNames[11], 1);

        Neko neko5 = new Neko();
        neko5.NekoName = "Neko #12212";
        neko5.NekoClass = NekoClass.Earth;
        neko5.UrlImage = "https://d1j8r0kxyu9tj8.cloudfront.net/neko/neko/origin/200x200/3.png";

        List<NekoSkill> neko5ListSkills = new List<NekoSkill>();

        NekoSkill neko5Skill1 = new NekoSkill();
        neko5Skill1.NameSkill = "Earth Shocking";

        NekoSkill neko5Skill2 = new NekoSkill();
        neko5Skill2.NameSkill = "Earth Scratch";

        NekoSkill neko5Skill3 = new NekoSkill();
        neko5Skill3.NameSkill = "Earth Blast";

        NekoSkill neko5Skill4 = new NekoSkill();
        neko5Skill4.NameSkill = "Earth Element Burn";

        NekoSkill neko5Skill5 = new NekoSkill();
        neko5Skill5.NameSkill = "Earth Discard";

        NekoSkill neko5Skill6 = new NekoSkill();
        neko5Skill6.NameSkill = "Earth Virus";
        neko5Skill6.IsLockSkill = true;

        NekoSkill neko5Skill7 = new NekoSkill();
        neko5Skill7.NameSkill = "Earth Hell Boy";


        NekoSkill neko5Skill8 = new NekoSkill();
        neko5Skill8.NameSkill = "Earth Last Man Stand";

        neko5ListSkills.Add(neko5Skill1);
        neko5ListSkills.Add(neko5Skill2);
        neko5ListSkills.Add(neko5Skill3);
        neko5ListSkills.Add(neko5Skill4);
        neko5ListSkills.Add(neko5Skill5);
        neko5ListSkills.Add(neko5Skill6);
        neko5ListSkills.Add(neko5Skill7);
        neko5ListSkills.Add(neko5Skill8);

        neko5.NekoSkill = neko5ListSkills;
        neko5.Atk = 140;
        neko5.Speed = 125;
        neko5.HP = 190;


        neko5.traitsNeko.Add(listTraitNames[0], 3);
        neko5.traitsNeko.Add(listTraitNames[1], 2);
        neko5.traitsNeko.Add(listTraitNames[2], 1);
        neko5.traitsNeko.Add(listTraitNames[3], 1);
        neko5.traitsNeko.Add(listTraitNames[4], 1);
        neko5.traitsNeko.Add(listTraitNames[5], 1);
        neko5.traitsNeko.Add(listTraitNames[6], 1);
        neko5.traitsNeko.Add(listTraitNames[7], 1);
        neko5.traitsNeko.Add(listTraitNames[8], 2);
        neko5.traitsNeko.Add(listTraitNames[9], 5);
        neko5.traitsNeko.Add(listTraitNames[10], 1);
        neko5.traitsNeko.Add(listTraitNames[11], 1);

        listNeko.Add(neko);
        listNeko.Add(neko1);
        listNeko.Add(neko2);
        listNeko.Add(neko3);
        listNeko.Add(neko4);
        listNeko.Add(neko5);
        return listNeko;
    }
    public static Neko GetNeko()
    {
        Neko neko = new Neko();
        neko.NekoName = "Neko #12312";
        neko.NekoClass = NekoClass.Fire;
        neko.UrlImage = "https://d1j8r0kxyu9tj8.cloudfront.net/neko/neko/origin/200x200/5001.png";
        neko.Level = 30;

        List<NekoSkill> nekoListSkills = new List<NekoSkill>();

        NekoSkill nekoSkill1 = new NekoSkill();
        nekoSkill1.NameSkill = "Fire Shocking";

        NekoSkill nekoSkill2 = new NekoSkill();
        nekoSkill2.NameSkill = "Fire Discard";

        NekoSkill nekoSkill3 = new NekoSkill();
        nekoSkill3.NameSkill = "Fire Virus";

        NekoSkill nekoSkill4 = new NekoSkill();
        nekoSkill4.NameSkill = "Fire Hell Boy";

        NekoSkill nekoSkill5 = new NekoSkill();
        nekoSkill5.NameSkill = "Fire Last Man Stand";

        NekoSkill nekoSkill6 = new NekoSkill();
        nekoSkill6.NameSkill = "Fire Supreme";




        nekoListSkills.Add(nekoSkill1);
        nekoListSkills.Add(nekoSkill2);
        nekoListSkills.Add(nekoSkill3);
        nekoListSkills.Add(nekoSkill4);
        nekoListSkills.Add(nekoSkill5);
        nekoListSkills.Add(nekoSkill6);

        neko.traitsNeko.Add(listTraitNames[0], 1);
        neko.traitsNeko.Add(listTraitNames[1], 2);
        neko.traitsNeko.Add(listTraitNames[2], 1);
        neko.traitsNeko.Add(listTraitNames[3], 2);
        neko.traitsNeko.Add(listTraitNames[4], 4);
        neko.traitsNeko.Add(listTraitNames[5], 3);
        neko.traitsNeko.Add(listTraitNames[6], 4);
        neko.traitsNeko.Add(listTraitNames[7], 9);
        neko.traitsNeko.Add(listTraitNames[8], 8);
        neko.traitsNeko.Add(listTraitNames[9], 4);
        neko.traitsNeko.Add(listTraitNames[10], 4);
        neko.traitsNeko.Add(listTraitNames[11], 3);

        neko.NekoSkill = nekoListSkills;
        neko.Atk = 90;
        neko.Speed = 160;
        neko.HP = 160;
        neko.Magic = 140;
        neko.def = 150;
        neko.Resist = 130;
        return neko;
    }
    public static List<Neko> GetNekoBattle()
    {
        List<Neko> listNeko = new List<Neko>();


        //data neko
        Neko neko = new Neko();
        neko.NekoName = "Neko #12312";
        neko.NekoClass = NekoClass.Fire;
        neko.UrlImage = "https://d1j8r0kxyu9tj8.cloudfront.net/neko/neko/origin/200x200/5001.png";
        neko.Level = 30;

        List<NekoSkill> nekoListSkills = new List<NekoSkill>();

        NekoSkill nekoSkill1 = new NekoSkill();
        nekoSkill1.NameSkill = "Fire Shocking";

        NekoSkill nekoSkill2 = new NekoSkill();
        nekoSkill2.NameSkill = "Fire Discard";

        NekoSkill nekoSkill3 = new NekoSkill();
        nekoSkill3.NameSkill = "Fire Virus";

        NekoSkill nekoSkill4 = new NekoSkill();
        nekoSkill4.NameSkill = "Fire Hell Boy";

        NekoSkill nekoSkill5 = new NekoSkill();
        nekoSkill5.NameSkill = "Fire Last Man Stand";

        NekoSkill nekoSkill6 = new NekoSkill();
        nekoSkill6.NameSkill = "Fire Supreme";




        nekoListSkills.Add(nekoSkill1);
        nekoListSkills.Add(nekoSkill2);
        nekoListSkills.Add(nekoSkill3);
        nekoListSkills.Add(nekoSkill4);
        nekoListSkills.Add(nekoSkill5);
        nekoListSkills.Add(nekoSkill6);

        neko.traitsNeko.Add(listTraitNames[0], 1);
        neko.traitsNeko.Add(listTraitNames[1], 2);
        neko.traitsNeko.Add(listTraitNames[2], 1);
        neko.traitsNeko.Add(listTraitNames[3], 2);
        neko.traitsNeko.Add(listTraitNames[4], 4);
        neko.traitsNeko.Add(listTraitNames[5], 3);
        neko.traitsNeko.Add(listTraitNames[6], 4);
        neko.traitsNeko.Add(listTraitNames[7], 9);
        neko.traitsNeko.Add(listTraitNames[8], 8);
        neko.traitsNeko.Add(listTraitNames[9], 4);
        neko.traitsNeko.Add(listTraitNames[10], 4);
        neko.traitsNeko.Add(listTraitNames[11], 3);

        neko.NekoSkill = nekoListSkills;
        neko.Atk = 90;
        neko.Speed = 160;
        neko.HP = 160;
        neko.Magic = 140;
        neko.def = 150;
        neko.Resist = 130;



        Neko neko1 = new Neko();
        neko1.NekoName = "Neko #12300";
        neko1.NekoClass = NekoClass.Fire;
        neko1.UrlImage = "https://d1j8r0kxyu9tj8.cloudfront.net/neko/neko/origin/200x200/5002.png";
        neko1.Level = 25;

        List<NekoSkill> neko1ListSkills = new List<NekoSkill>();

        NekoSkill neko1Skill1 = new NekoSkill();
        neko1Skill1.NameSkill = "Fire Shocking";

        NekoSkill neko1Skill2 = new NekoSkill();
        neko1Skill2.NameSkill = "Fire Discard";

        NekoSkill neko1Skill3 = new NekoSkill();
        neko1Skill3.NameSkill = "Fire Virus";

        NekoSkill neko1Skill4 = new NekoSkill();
        neko1Skill4.NameSkill = "Fire Hell Boy";

        NekoSkill neko1Skill5 = new NekoSkill();
        neko1Skill5.NameSkill = "Fire Last Man Stand";


        neko1ListSkills.Add(neko1Skill1);
        neko1ListSkills.Add(neko1Skill2);
        neko1ListSkills.Add(neko1Skill3);
        neko1ListSkills.Add(neko1Skill4);
        neko1ListSkills.Add(neko1Skill5);

        neko1.traitsNeko.Add(listTraitNames[0], 2);
        neko1.traitsNeko.Add(listTraitNames[1], 1);
        neko1.traitsNeko.Add(listTraitNames[2], 1);
        neko1.traitsNeko.Add(listTraitNames[3], 2);
        neko1.traitsNeko.Add(listTraitNames[4], 3);
        neko1.traitsNeko.Add(listTraitNames[5], 2);
        neko1.traitsNeko.Add(listTraitNames[6], 3);
        neko1.traitsNeko.Add(listTraitNames[7], 7);
        neko1.traitsNeko.Add(listTraitNames[8], 7);
        neko1.traitsNeko.Add(listTraitNames[9], 3);
        neko1.traitsNeko.Add(listTraitNames[10], 3);
        neko1.traitsNeko.Add(listTraitNames[11], 2);

        neko1.NekoSkill = neko1ListSkills;
        neko1.Atk = 100;
        neko1.Speed = 200;
        neko1.HP = 170;
        neko1.Magic = 130;
        neko1.def = 160;
        neko1.Resist = 130;



        Neko neko2 = new Neko();
        neko2.NekoName = "Neko #12301";
        neko2.NekoClass = NekoClass.Fire;
        neko2.UrlImage = "https://d1j8r0kxyu9tj8.cloudfront.net/neko/neko/origin/200x200/5003.png";
        neko2.Level = 20;

        List<NekoSkill> neko2ListSkills = new List<NekoSkill>();

        NekoSkill neko2Skill1 = new NekoSkill();
        neko2Skill1.NameSkill = "Fire Shocking";

        NekoSkill neko2Skill2 = new NekoSkill();
        neko2Skill2.NameSkill = "Fire Discard";

        NekoSkill neko2Skill3 = new NekoSkill();
        neko2Skill3.NameSkill = "Fire Virus";

        NekoSkill neko2Skill4 = new NekoSkill();
        neko2Skill4.NameSkill = "Fire Hell Boy";

        NekoSkill neko2Skill5 = new NekoSkill();
        neko2Skill5.NameSkill = "Fire Last Man Stand";

        NekoSkill neko2Skill6 = new NekoSkill();
        neko2Skill6.NameSkill = "Fire Supreme";

        NekoSkill neko2Skill7 = new NekoSkill();
        neko2Skill7.NameSkill = "Fire Buring Sun";
        neko2Skill7.IsLockSkill = true;


        neko2ListSkills.Add(neko2Skill1);
        neko2ListSkills.Add(neko2Skill2);
        neko2ListSkills.Add(neko2Skill3);
        neko2ListSkills.Add(neko2Skill4);
        neko2ListSkills.Add(neko2Skill5);
        neko2ListSkills.Add(neko2Skill6);
        neko2ListSkills.Add(neko2Skill7);

        neko2.NekoSkill = neko2ListSkills;
        neko2.Atk = 170;
        neko2.Speed = 115;
        neko2.HP = 200;
        neko2.Magic = 130;
        neko2.def = 160;
        neko2.Resist = 130;


        neko2.traitsNeko.Add(listTraitNames[0], 3);
        neko2.traitsNeko.Add(listTraitNames[1], 1);
        neko2.traitsNeko.Add(listTraitNames[2], 1);
        neko2.traitsNeko.Add(listTraitNames[3], 2);
        neko2.traitsNeko.Add(listTraitNames[4], 4);
        neko2.traitsNeko.Add(listTraitNames[5], 2);
        neko2.traitsNeko.Add(listTraitNames[6], 4);
        neko2.traitsNeko.Add(listTraitNames[7], 2);
        neko2.traitsNeko.Add(listTraitNames[8], 5);
        neko2.traitsNeko.Add(listTraitNames[9], 2);
        neko2.traitsNeko.Add(listTraitNames[10], 2);
        neko2.traitsNeko.Add(listTraitNames[11], 1);

        // neko earth
        Neko neko3 = new Neko();
        neko3.NekoName = "Neko #12211";
        neko3.NekoClass = NekoClass.Earth;
        neko3.UrlImage = "https://d1j8r0kxyu9tj8.cloudfront.net/neko/neko/origin/200x200/1.png";
        neko3.Level = 28;

        List<NekoSkill> neko3ListSkills = new List<NekoSkill>();

        NekoSkill neko3Skill1 = new NekoSkill();
        neko3Skill1.NameSkill = "Earth Shocking";

        NekoSkill neko3Skill2 = new NekoSkill();
        neko3Skill2.NameSkill = "Earth Scratch";

        NekoSkill neko3Skill3 = new NekoSkill();
        neko3Skill3.NameSkill = "Earth Blast";

        NekoSkill neko3Skill4 = new NekoSkill();
        neko3Skill4.NameSkill = "Earth Element Burn";

        NekoSkill neko3Skill5 = new NekoSkill();
        neko3Skill5.NameSkill = "Earth Discard";

        NekoSkill neko3Skill6 = new NekoSkill();
        neko3Skill6.NameSkill = "Earth Virus";
        neko3Skill6.IsLockSkill = true;

        NekoSkill neko3Skill7 = new NekoSkill();
        neko3Skill7.NameSkill = "Earth Hell Boy";


        neko3ListSkills.Add(neko3Skill1);
        neko3ListSkills.Add(neko3Skill2);
        neko3ListSkills.Add(neko3Skill3);
        neko3ListSkills.Add(neko3Skill4);
        neko3ListSkills.Add(neko3Skill5);
        neko3ListSkills.Add(neko3Skill6);
        neko3ListSkills.Add(neko3Skill7);

        neko3.NekoSkill = neko3ListSkills;
        neko3.Atk = 170;
        neko3.Speed = 140;
        neko3.HP = 150;
        neko3.Magic = 160;
        neko3.def = 120;
        neko3.Resist = 130;


        neko3.traitsNeko.Add(listTraitNames[0], 4);
        neko3.traitsNeko.Add(listTraitNames[1], 4);
        neko3.traitsNeko.Add(listTraitNames[2], 1);
        neko3.traitsNeko.Add(listTraitNames[3], 1);
        neko3.traitsNeko.Add(listTraitNames[4], 1);
        neko3.traitsNeko.Add(listTraitNames[5], 1);
        neko3.traitsNeko.Add(listTraitNames[6], 2);
        neko3.traitsNeko.Add(listTraitNames[7], 1);
        neko3.traitsNeko.Add(listTraitNames[8], 3);
        neko3.traitsNeko.Add(listTraitNames[9], 4);
        neko3.traitsNeko.Add(listTraitNames[10], 1);
        neko3.traitsNeko.Add(listTraitNames[11], 1);

        Neko neko4 = new Neko();
        neko4.NekoName = "Neko #12212";
        neko4.NekoClass = NekoClass.Earth;
        neko4.UrlImage = "https://d1j8r0kxyu9tj8.cloudfront.net/neko/neko/origin/200x200/2.png";
        neko4.Level = 18;

        List<NekoSkill> neko4ListSkills = new List<NekoSkill>();

        NekoSkill neko4Skill1 = new NekoSkill();
        neko4Skill1.NameSkill = "Earth Shocking";

        NekoSkill neko4Skill2 = new NekoSkill();
        neko4Skill2.NameSkill = "Earth Scratch";

        NekoSkill neko4Skill3 = new NekoSkill();
        neko4Skill3.NameSkill = "Earth Blast";

        NekoSkill neko4Skill4 = new NekoSkill();
        neko4Skill4.NameSkill = "Earth Element Burn";

        NekoSkill neko4Skill5 = new NekoSkill();
        neko4Skill5.NameSkill = "Earth Discard";

        NekoSkill neko4Skill6 = new NekoSkill();
        neko4Skill6.NameSkill = "Earth Virus";
        neko4Skill6.IsLockSkill = true;

        NekoSkill neko4Skill7 = new NekoSkill();
        neko4Skill7.NameSkill = "Earth Hell Boy";


        NekoSkill neko4Skill8 = new NekoSkill();
        neko4Skill8.NameSkill = "Earth Last Man Stand";

        neko4ListSkills.Add(neko4Skill1);
        neko4ListSkills.Add(neko4Skill2);
        neko4ListSkills.Add(neko4Skill3);
        neko4ListSkills.Add(neko4Skill4);
        neko4ListSkills.Add(neko4Skill5);
        neko4ListSkills.Add(neko4Skill6);
        neko4ListSkills.Add(neko4Skill7);
        neko4ListSkills.Add(neko4Skill8);

        neko4.NekoSkill = neko4ListSkills;
        neko4.Atk = 140;
        neko4.Speed = 125;
        neko4.HP = 190;
        neko4.Magic = 130;
        neko4.def = 150;
        neko4.Resist = 190;


        neko4.traitsNeko.Add(listTraitNames[0], 5);
        neko4.traitsNeko.Add(listTraitNames[1], 4);
        neko4.traitsNeko.Add(listTraitNames[2], 1);
        neko4.traitsNeko.Add(listTraitNames[3], 1);
        neko4.traitsNeko.Add(listTraitNames[4], 1);
        neko4.traitsNeko.Add(listTraitNames[5], 1);
        neko4.traitsNeko.Add(listTraitNames[6], 2);
        neko4.traitsNeko.Add(listTraitNames[7], 1);
        neko4.traitsNeko.Add(listTraitNames[8], 3);
        neko4.traitsNeko.Add(listTraitNames[9], 7);
        neko4.traitsNeko.Add(listTraitNames[10], 1);
        neko4.traitsNeko.Add(listTraitNames[11], 1);

        Neko neko5 = new Neko();
        neko5.NekoName = "Neko #12212";
        neko5.NekoClass = NekoClass.Earth;
        neko5.UrlImage = "https://d1j8r0kxyu9tj8.cloudfront.net/neko/neko/origin/200x200/3.png";
        neko5.Level = 19;

        List<NekoSkill> neko5ListSkills = new List<NekoSkill>();

        NekoSkill neko5Skill1 = new NekoSkill();
        neko5Skill1.NameSkill = "Earth Shocking";

        NekoSkill neko5Skill2 = new NekoSkill();
        neko5Skill2.NameSkill = "Earth Scratch";

        NekoSkill neko5Skill3 = new NekoSkill();
        neko5Skill3.NameSkill = "Earth Blast";

        NekoSkill neko5Skill4 = new NekoSkill();
        neko5Skill4.NameSkill = "Earth Element Burn";

        NekoSkill neko5Skill5 = new NekoSkill();
        neko5Skill5.NameSkill = "Earth Discard";

        NekoSkill neko5Skill6 = new NekoSkill();
        neko5Skill6.NameSkill = "Earth Virus";
        neko5Skill6.IsLockSkill = true;

        NekoSkill neko5Skill7 = new NekoSkill();
        neko5Skill7.NameSkill = "Earth Hell Boy";


        NekoSkill neko5Skill8 = new NekoSkill();
        neko5Skill8.NameSkill = "Earth Last Man Stand";

        neko5ListSkills.Add(neko5Skill1);
        neko5ListSkills.Add(neko5Skill2);
        neko5ListSkills.Add(neko5Skill3);
        neko5ListSkills.Add(neko5Skill4);
        neko5ListSkills.Add(neko5Skill5);
        neko5ListSkills.Add(neko5Skill6);
        neko5ListSkills.Add(neko5Skill7);
        neko5ListSkills.Add(neko5Skill8);

        neko5.NekoSkill = neko5ListSkills;
        neko5.Atk = 140;
        neko5.Speed = 125;
        neko5.HP = 190;
        neko5.Magic = 140;
        neko5.def = 160;
        neko5.Resist = 180;


        neko5.traitsNeko.Add(listTraitNames[0], 3);
        neko5.traitsNeko.Add(listTraitNames[1], 2);
        neko5.traitsNeko.Add(listTraitNames[2], 1);
        neko5.traitsNeko.Add(listTraitNames[3], 1);
        neko5.traitsNeko.Add(listTraitNames[4], 1);
        neko5.traitsNeko.Add(listTraitNames[5], 1);
        neko5.traitsNeko.Add(listTraitNames[6], 1);
        neko5.traitsNeko.Add(listTraitNames[7], 1);
        neko5.traitsNeko.Add(listTraitNames[8], 2);
        neko5.traitsNeko.Add(listTraitNames[9], 5);
        neko5.traitsNeko.Add(listTraitNames[10], 1);
        neko5.traitsNeko.Add(listTraitNames[11], 1);

        listNeko.Add(neko);
        listNeko.Add(neko1);
        listNeko.Add(neko2);
        listNeko.Add(neko3);
        listNeko.Add(neko4);
        listNeko.Add(neko5);
        return listNeko;
    }


}
