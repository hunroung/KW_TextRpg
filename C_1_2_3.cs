﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class C_1_2_3 : Form
    {
        public C_1_2_3()
        {
            InitializeComponent();
        }

        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@form 복사시에 아래 부분 복사 후 Form2 를 새로 만든 폼 이름으로 바꿀것.
        //해당 부분 copy 필요
        public int visit = 0;
        public character ch;
        
        public C_1_2_3(ref character character)
        {


            //string name = "슬라임";
            //slime.name = name;
            ch = character;

            InitializeComponent();


            setting(character);
            item_btn_enable();
            act_btn_enable();
            picture_main.Image = character.main;
            //picture_npc.Image = slime.img;
            //스킬 옮겨 담기
        }

        //폼 로딩시 세팅 단계
        private void btn_save_Click(object sender, EventArgs e)
        {
            ch.save();
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            ch.close = 1;
            this.Close();
        }
        public int fight = 0;
        public NPC monster = new NPC();
        public void setting(character character)
        {
            //따로 추가
            if (fight == 1)
            {
                npc_name.Text = monster.name;
                npc_health.Text = monster.real_health.ToString();
            }
            //따로 추가
            if (character.item_str > 0)
            {
                str.Text = character.str.ToString() + " +" + character.item_str.ToString();
            }
            else
            {
                str.Text = character.str.ToString();
            }
            if (character.item_intel > 0)
            {
                intel.Text = character.intel.ToString() + " +" + character.item_intel.ToString();
            }
            else
            {
                intel.Text = character.intel.ToString();
            }
            if (character.item_spd > 0)
            {
                spd.Text = character.spd.ToString() + " +" + character.item_spd.ToString();
            }
            else
            {
                spd.Text = character.spd.ToString();
            }
            if (character.item_def > 0)
            {
                def.Text = character.def.ToString() + " +" + character.item_def.ToString();
            }
            else
            {
                def.Text = character.def.ToString();
            }

            item_btn_able(ch);

            label2.Text = ch.skill_point.ToString();
            name.Text = character.name;
            exp.Text = character.exp_per.ToString() + '%';
            leb.Text = character.leb.ToString();
            point.Text = character.stat_point.ToString();
            real_health.Text = character.real_health.ToString() + " / " + character.max_health.ToString();

            if (character.stat_point < 1)
            {
                stat_btn_setting(false);
            }
            else
            {
                stat_btn_setting(true);
            }
            if (cmb_skill.Items.Count < ch.skill_count)
            {
                cmb_skill.Items.Clear();
                for (int i = 0; i < ch.skill_count; i++)
                {
                    cmb_skill.Items.Add(ch.skill[i]);
                }
            }

        }
        //공격, 방어, 스킬, 도망 버튼 비활성화
        public void act_btn_enable()
        {
            btn_attack.Enabled = false;
            btn_defend.Enabled = false;
            btn_skill.Enabled = false;
            btn_run.Enabled = false;
        }
        //공격, 방어, 스킬, 도망 버튼 활성화
        public void act_btn_able()
        {
            btn_attack.Enabled = true;
            btn_defend.Enabled = true;
            btn_skill.Enabled = true;
            btn_run.Enabled = true;
        }

        //stat 포인트에 따라 버튼 활성화 , 비활성화
        public void stat_btn_setting(bool bl)
        {
            if (bl)
            {
                btn_str.Enabled = true;
                btn_intel.Enabled = true;
                btn_spd.Enabled = true;
                btn_def.Enabled = true;
            }
            else
            {

                btn_str.Enabled = false;
                btn_intel.Enabled = false;
                btn_spd.Enabled = false;
                btn_def.Enabled = false;
            }
        }
        //아이템 버튼 비활성화 하기
        public void item_btn_enable()
        {
            item_1.Text = ch.item_have(0).ToString();
            item_2.Text = ch.item_have(1).ToString();
            item_3.Text = ch.item_have(2).ToString();
            item_4.Text = ch.item_have(3).ToString();
            item_5.Text = ch.item_have(4).ToString();
            item_6.Text = ch.item_have(5).ToString();
            item_7.Text = ch.item_have(6).ToString();
            item_8.Text = ch.item_have(7).ToString();

            btn_item_1.Enabled = false;
            btn_item_2.Enabled = false;
            btn_item_3.Enabled = false;
            btn_item_4.Enabled = false;
            btn_item_5.Enabled = false;
            btn_item_6.Enabled = false;
            btn_item_7.Enabled = false;
            btn_item_8.Enabled = false;
        }
        private static DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);

            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }

            return DateTime.Now;
        }
        //업데이트 용
        public void update()
        {
            Delay(100);
            setting(ch);
            Delay(100);
        }
        public void move_btn_enable()
        {
            btn_travel.Enabled = false;
            btn_down_move.Enabled = false;
            btn_left_move.Enabled = false;
            btn_right_move.Enabled = false;
            btn_up_move.Enabled = false;
        }



        public void move_btn_able()
        {
            btn_travel.Enabled = true;
            btn_down_move.Enabled = true;
            btn_left_move.Enabled = true;
            btn_right_move.Enabled = true;
            btn_up_move.Enabled = true;
        }
        //아이템 버튼 활성화 하기
        public void item_btn_able(character character)
        {
            for (int i = 0; i < character.max_item; i++)
            {

                switch (i)
                {
                    case 0:
                        item_1.Text = character.item_have(i).ToString();
                        if (character.item_have(i) > 0)
                            btn_item_1.Enabled = true;
                        else
                            btn_item_1.Enabled = false;
                        break;
                    case 1:
                        item_2.Text = character.item_have(i).ToString();
                        if (character.item_have(i) > 0)
                            btn_item_2.Enabled = true;
                        else
                            btn_item_2.Enabled = false;

                        break;
                    case 2:
                        item_3.Text = character.item_have(i).ToString();
                        if (character.item_have(i) > 0)
                            btn_item_3.Enabled = true;
                        else
                            btn_item_3.Enabled = false;

                        break;
                    case 3:
                        item_4.Text = character.item_have(i).ToString();
                        if (character.item_have(i) > 0)
                            btn_item_4.Enabled = true;
                        else
                            btn_item_4.Enabled = false;

                        break;
                    case 4:
                        item_5.Text = character.item_have(i).ToString();
                        if (character.item_have(i) > 0)
                            btn_item_5.Enabled = true;
                        else
                            btn_item_5.Enabled = false;

                        break;
                    case 5:
                        item_6.Text = character.item_have(i).ToString();
                        if (character.item_have(i) > 0)
                            btn_item_6.Enabled = true;
                        else
                            btn_item_6.Enabled = false;

                        break;
                    case 6:
                        item_7.Text = character.item_have(i).ToString();
                        if (character.item_have(i) > 0)
                            btn_item_7.Enabled = true;
                        else
                            btn_item_7.Enabled = false;
                        break;
                    case 7:
                        item_8.Text = character.item_have(i).ToString();
                        if (character.item_have(i) > 0)
                            btn_item_8.Enabled = true;
                        else
                            btn_item_8.Enabled = false;
                        break;
                    default:
                        break;

                }

            }
        }

        private void btn_right_move_Click(object sender, EventArgs e)
        {

            if (ch.wiz_visit == 0)
            {
                textBox1.AppendText("누군가 마법으로 결계를 설치해놨다. \r\n먼저, 결계를 풀지 않으면 다음 맵으로 이동할 수 없다.\r\n\r\n");
            }
            else
            {
             C_1_2_4 form = new C_1_2_4(ref ch);
            this.Hide();
            form.ShowDialog();

            if (ch.real_health <= 0)
            {
                this.Close();
            }
            this.Show();
            update();
            this.Refresh();
            }
        }

        private void btn_up_move_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void C_1_2_3_Load(object sender, EventArgs e)
        {
            if (ch.wiz_visit == 0)
            {
                picture_npc.Image = Image.FromFile(".\\img\\magic_lock.png");
            }
            else
            {
                picture_npc.Image = Image.FromFile(".\\img\\magic_unlock.png");
                textBox1.AppendText("결계가 풀린 상태가 되었다.\r\n다음 맵으로 이동할 수 있을 것 같다.\r\n");
            }
        }


        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
    }
}
