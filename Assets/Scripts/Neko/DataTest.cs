using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTest
{
    public static Neko GetNeko()
    {
        Neko neko = new Neko();
        neko.NekoClass = NekoClass.Fire;

        List<NekoSkill> nekoListSkills = new List<NekoSkill>();
        NekoSkill nekoSkill = new NekoSkill();
        Skill skill = new Skill();
        skill.NameSkill = "Shocking";
        skill.Desception = "Decrease all of your opponent's Nekos by 20%. \nThis skill can not be blocked by other Nekos";
        skill.Dame = 100;
        skill.SpriteName = "Skill_1";
        nekoSkill.skill = skill;

        NekoSkill nekoSkill1 = new NekoSkill();
        Skill skill1 = new Skill();
        skill1.NameSkill = "Element Burn";
        skill1.Desception = "Decrease all of your opponent's Nekos by 20%. \nThis skill can not be blocked by other Nekos";
        skill1.Dame = 100;
        skill1.SpriteName = "Skill_2";
        nekoSkill1.skill = skill1;

        NekoSkill nekoSkill2 = new NekoSkill();
        Skill skill2 = new Skill();
        skill2.NameSkill = "Discard";
        skill2.Desception = "Decrease all of your opponent's Nekos by 20%. \nThis skill can not be blocked by other Nekos";
        skill2.Dame = 100;
        skill2.SpriteName = "Skill_3";
        nekoSkill2.skill = skill2;

        NekoSkill nekoSkill3 = new NekoSkill();
        Skill skill3 = new Skill();
        skill3.NameSkill = "Fire virus";
        skill3.Desception = "Decrease all of your opponent's Nekos by 20%. \nThis skill can not be blocked by other Nekos";
        skill3.Dame = 100;
        skill3.SpriteName = "Skill_4";
        nekoSkill3.skill = skill3;

        NekoSkill nekoSkill4 = new NekoSkill();
        Skill skill4 = new Skill();
        skill4.NameSkill = "Hell boy";
        skill4.Desception = "Decrease all of your opponent's Nekos by 20%. \nThis skill can not be blocked by other Nekos";
        skill4.Dame = 100;
        skill4.SpriteName = "Skill_5";
        nekoSkill4.skill = skill4;

        NekoSkill nekoSkill5 = new NekoSkill();
        Skill skill5 = new Skill();
        skill5.NameSkill = "Last man stand";
        skill5.Desception = "Decrease all of your opponent's Nekos by 20%. \nThis skill can not be blocked by other Nekos";
        skill5.Dame = 100;
        skill5.SpriteName = "Skill_6";
        nekoSkill5.skill = skill5;

        NekoSkill nekoSkill6 = new NekoSkill();
        Skill skill6 = new Skill();
        skill6.NameSkill = "Fire Supreme";
        skill6.Desception = "Decrease all of your opponent's Nekos by 20%. \nThis skill can not be blocked by other Nekos";
        skill6.Dame = 100;
        skill6.SpriteName = "Skill_7";
        nekoSkill6.skill = skill6;

        NekoSkill nekoSkill7 = new NekoSkill();
        Skill skill7 = new Skill();
        skill7.NameSkill = "Buring Sun";
        skill7.Desception = "Decrease all of your opponent's Nekos by 20%. \nThis skill can not be blocked by other Nekos";
        skill7.Dame = 100;
        skill7.SpriteName = "Skill_8";
        nekoSkill7.skill = skill7;

        NekoSkill nekoSkill8 = new NekoSkill();
        Skill skill8 = new Skill();
        skill8.NameSkill = "Blast";
        skill8.Desception = "Decrease all of your opponent's Nekos by 20%. \nThis skill can not be blocked by other Nekos";
        skill8.Dame = 100;
        skill8.SpriteName = "Skill_9";
        nekoSkill8.skill = skill8;

        NekoSkill nekoSkill9 = new NekoSkill();
        Skill skill9 = new Skill();
        skill9.NameSkill = "Heal";
        skill9.Desception = "Decrease all of your opponent's Nekos by 20%. \nThis skill can not be blocked by other Nekos";
        skill9.Dame = 100;
        skill9.SpriteName = "Skill_10";
        nekoSkill9.skill = skill9;

        nekoListSkills.Add(nekoSkill);
        nekoListSkills.Add(nekoSkill1);
        nekoListSkills.Add(nekoSkill2);
        nekoListSkills.Add(nekoSkill3);
        nekoListSkills.Add(nekoSkill4);
        nekoListSkills.Add(nekoSkill5);
        nekoListSkills.Add(nekoSkill6);
        nekoListSkills.Add(nekoSkill7);
        nekoListSkills.Add(nekoSkill8);
        nekoListSkills.Add(nekoSkill9);

        neko.NekoSkill = nekoListSkills;
        neko.Atk = 123;
        neko.Speed = 123;
        neko.HP = 123;

        return neko;
    }
}
