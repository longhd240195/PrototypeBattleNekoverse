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
    public static List<Neko> GetNeko()
    {
        List<Neko> listNeko = new List<Neko>();


        //data neko
        Neko neko = new Neko();
        neko.NekoName = "Neko #12312";
        neko.NekoClass = NekoClass.Fire;
        neko.NameImage = "10005";

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
        neko1.NameImage = "15371";

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
        neko2.NameImage = "17215";

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
        neko3.NameImage = "10447";

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
        neko4.NameImage = "10447";

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

        listNeko.Add(neko4);
        listNeko.Add(neko);
        listNeko.Add(neko2);
        listNeko.Add(neko3);
        listNeko.Add(neko1);
        return listNeko;
    }
}
