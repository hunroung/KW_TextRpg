﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public class character
    {
        public int[,] clear = new int[max_chapter,max_stage];//스테이지 클리어

        public static int max_chapter = 3;//최대 챕터
        public static int max_stage = 4;//최대 스테이지
        public static int max_item = 8; //아이템 종류
        public static int max_item_value = 10; //종류당 가질 수 있는 아이템의 최대 값
        public static int max_name = 15;//이름 최대 길이
        public static int max_skill = 10;//스킬 최대 개수

        public int chapter1_boss = 3;//챕터1 보스수
        public int chapter2_boss=2;//챕터2 보스수
        public int chapter3_boss=3;//챕터3 보스수

        public int max_skill_point = 3;//사용 가능한 스킬 횟수

        public Image main = Image.FromFile(".\\img\\main_character.png");
        public Image main_attack = Image.FromFile(".\\img\\main_character_attack.png");
        public Image main_attacked = Image.FromFile(".\\img\\main_character_attacked.png");
        public Image main_skill;
        public Image main_defend = Image.FromFile(".\\img\\main_character_defend.png");
        public Image main_dead = Image.FromFile(".\\img\\main_character_dead.png");

        //아이템 사용시 적용될 효과 수치를 따로 저장 후 되돌릴 때 사용
        public int item_str = 0;
        public int item_intel = 0;
        public int item_spd = 0;
        public int item_def = 0;

        public int close = 0;
        public string name;
        public int exp = 0;
        public int max_exp = 100;
        public int leb = 0;
        public double exp_per = 0;

        public int skill_point = 3;// 사용 가능한 스킬 횟수
        public int skill_count = 0; // 실제 스킬 갯수
        public int item_count = 0; // 실제 아이템 갯수

        public int max_health = 100;
        public int real_health = 100;
        public int stat_point = 0;
        public int str = 5;
        public int intel = 5;
        public int spd = 5;
        public int def = 5;

        public int wiz_visit = 0;
        public int tur_visit = 0;
        public int secret_shop01 = 0;

        public int chapter = 1;
        public int chapter_value = 1;

        //월광포화 아펠리우스 궁극기 반월검
        //심판

        public string[] skill = new string[max_skill];// 
        public int[] item = new int[max_item];

        public void exp_gain(int exp_)
        {
            this.exp += exp_;
            if (exp - max_exp > 0)
            {
                leb_gain(1);
                stat_point += 3;
                exp -= max_exp;
                max_exp = 2 * max_exp;
                max_skill_point++;
                skill_point = max_skill_point;
                max_health += 20 * leb;
                real_health = max_health;
            }
            exp_per = (double)exp / (double)max_exp * 100;
        }
        public void leb_gain(int leb_) { this.leb += leb_; }
        //0 힐포션 1 
        public void item_gain(int item, int val) { this.item[item] += val; }

        public void item_use(int item)
        {
            if (this.item[item] > 0)
            {
                switch (item)
                {
                    case 0:
                        //아이템 효과
                        this.healed(10);
                        break;
                    case 1:
                        //아이템 효과 - 대형회복물약(30회복, 스킬사용횟수 +1)
                        this.healed(30);
                        skill_point += 1;
                        break;
                    case 2:
                        //아이템 효과 - 스킬회복물약(스킬사용횟수 +3)
                        skill_point += 3;
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        //아이템 효과(코인 - 체력을 10 회복합니다. 또한, 비밀 상점의 재화로 사용 가능 합니다.)
                        this.healed(10);
                        break;
                    default:
                        break;

                }
            }
            this.item[item]--;
        }

        public int item_have(int item) { return this.item[item]; }
        public void stat_use()
        {
            if (stat_point > 0)
            {
                stat_point--;
            }
        }

        public int defense(int damage)
        {
            double total;
            total = (double)damage - (double)(def + item_def) * 2;
            if(damage>0)
            {
                real_health -= (int)total;
                if (real_health <= 0)
                {
                    real_health = 0;
                    return 0;
                }
                
            }
            return 1;
        }
        public int attack()
        {
            double damage = 10;
            damage = (double)(str + item_str) * 0.5 + damage;
            return (int)damage;
        }

        public void healed(int healed_)
        {
            real_health += healed_;
            if (real_health > max_health)
            {
                real_health = max_health;
            }
        }
        public int damaged(int damage)
        {
            real_health -= damage;
            if (real_health <= 0)
            {
                real_health = 0;
                return 0;
            }
            return 1;
        }

        public void skill_re()
        {
            skill_point = max_skill_point;
        }
        //스킬 0번 심판
        public void skill_gain(string skill_name)
        {
            skill[skill_count] = skill_name;
            skill_count++;
        }

        public int skill_use(string skill_name)
        {
            if (skill_point > 0)
            {
                
                if (skill_name == "심판")
                {
                    main_skill = Image.FromFile(".\\img\\main_character_skill_" + skill_name + ".png");
                    skill_point--;
                    return Judgement();
                }
                else if (skill_name == "메테오")
                {
                    main_skill = Image.FromFile(".\\img\\main_character_skill_" + skill_name + ".png");
                    skill_point--;
                    return Meteor();
                }
                else if (skill_name == "108번뇌")
                {
                    main_skill = Image.FromFile(".\\img\\main_character_skill_" + skill_name + ".png");
                    skill_point--;
                    return Weapon();
                }
            }
            return 0;
        }
        public int Weapon()
        {
            double damage = 50;
            damage = (double)(str + item_str) * 0.5 + damage;
            return (int)damage;
        }
        public int Meteor()
        {
            double damage = 30;
            damage = (double)(intel + item_intel) * 2.0 + damage;

            return (int)damage;
        }
        public int Judgement()
        {
            double damage = 20;

            damage = (double)(str+item_str) * 0.6 + (double)(spd+item_spd) * 0.1 + damage;

            return (int)damage;
        }

        public void item_clear()
        {
            item_str = 0;
            item_intel = 0;
            item_spd = 0;
            item_def = 0;
        }

        public void load(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string line;
                line = reader.ReadLine();
                chapter = int.Parse(line);
                line = reader.ReadLine();
                this.name = line;
                line = reader.ReadLine();
                str = int.Parse(line);
                line = reader.ReadLine();
                spd = int.Parse(line);
                line = reader.ReadLine();
                intel = int.Parse(line);
                line = reader.ReadLine();
                def = int.Parse(line);
                line = reader.ReadLine();
                exp = int.Parse(line);
                line = reader.ReadLine();
                max_exp = int.Parse(line);
                line= reader.ReadLine();
                exp_per = double.Parse(line);
                line = reader.ReadLine();
                max_health = int.Parse(line);
                line = reader.ReadLine();
                real_health = int.Parse(line);
                line = reader.ReadLine();
                stat_point = int.Parse(line);
                line = reader.ReadLine();
                max_skill_point = int.Parse(line);
                line = reader.ReadLine();
                skill_count = int.Parse(line);
                for (int i = 0; i < skill_count; i++)
                {
                    line = reader.ReadLine();
                    skill[i] = line;
                }
                for (int i = 0; i < max_item; i++)
                {
                    line = reader.ReadLine();
                    item[i] = int.Parse(line);
                }
                line = reader.ReadLine();
                leb = int.Parse(line);
            }
            skill_point = max_skill_point;
        }

        public void save()
        {
            using (StreamWriter writer = new StreamWriter(".\\saves\\"+name+".txt"))
            {
                writer.WriteLine(chapter);
                writer.WriteLine(name);
                writer.WriteLine(str);
                writer.WriteLine(spd);
                writer.WriteLine(intel);
                writer.WriteLine(def);
                writer.WriteLine(exp);
                writer.WriteLine(max_exp);
                writer.WriteLine(exp_per);
                writer.WriteLine(max_health);
                writer.WriteLine(real_health);
                writer.WriteLine(stat_point);
                writer.WriteLine(max_skill_point);
                writer.WriteLine(skill_count);
                for(int i=0;i<skill_count;i++)
                {
                    writer.WriteLine(skill[i]);
                }
                for (int i = 0; i < max_item; i++)
                {
                    writer.WriteLine(item[i]);
                }
                writer.WriteLine(leb);
            }
        }
        public int skill_have(string name)
        {
            int i = 0;
            for (i = 0; i < skill_count; i++)
            {
                if (name == skill[i])
                {
                    return i;
                }
            }
            return -1;
        }

        /*
        public void gold_gain(int val)
        {
            gold += val;
        }

        public int gold_use(int val)
        {
            if(gold-val>=0)
            {
                gold -= val;
                return 1;
            }
            return 0;
        }
        */
    }
}
