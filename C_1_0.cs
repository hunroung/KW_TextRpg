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
    public partial class C_1_0 : Form
    {
        public C_1_0()
        {
            InitializeComponent();
        }

        private void C_1_0_Load(object sender, EventArgs e)
        {
            move_btn_enable();
            textBox1.AppendText("당신은 우거진 숲 속에서 깨어났다.\r\n");
            this.Refresh();
            Delay(2000);
            textBox1.AppendText("주위에는 나무들과 풀밭이 보이고 새들의 지저귐이 들려온다.\r\n");
            this.Refresh();
            Delay(2000);
            textBox1.AppendText("당신은 이곳이 어디인지, 어떻게 여기에 왔는지 기억하지 못한다.\r\n");
            this.Refresh();
            Delay(2000);
            textBox1.AppendText("어디로 가야할지 막막하지만 당신은 마음이 향하는 곳으로 걷는다.\r\n");
            this.Refresh();
            Delay(2000);
            textBox1.AppendText("이곳은 치유의 샘이다. \r\n전투의 피로를 이곳에서 회복하자.\r\n");
            move_btn_able();
            
        }
        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@form 복사시에 아래 부분 복사 후 Form2 를 새로 만든 폼 이름으로 바꿀것.
        //해당 부분 copy 필요
        public int visit = 0;
        public character ch;
        //public slime slime = new slime();
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
        private void btn_close_Click(object sender, EventArgs e)
        {
            ch.close = 1;
            this.Close();
        }
        public C_1_0(ref character character)
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
            for (int i = 0; i < character.skill_count; i++)
            {
                cmb_skill.Items.Add(character.skill[i]);
            }


        }

        //폼 로딩시 세팅 단계
        public void setting(character character)
        {
            //따로 추가

            //npc_name.Text = slime.name;
            //npc_health.Text = slime.real_health.ToString();
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
        private void btn_str_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            switch (button.Name.ToString())
            {
                case "btn_str":
                    ch.str += 1;
                    ch.stat_use();
                    break;
                case "btn_intel":
                    ch.intel += 1;
                    ch.stat_use();
                    break;
                case "btn_spd":
                    ch.spd += 1;
                    ch.stat_use();
                    break;
                case "btn_def":
                    ch.def += 1;
                    ch.stat_use();
                    break;
                default:
                    break;
            }
            update();
        }
        //아이템 사용
        private void btn_item_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            switch (button.Name.ToString())
            {
                case "btn_item_1":
                    ch.item_use(0);
                    break;
                case "btn_item_2":
                    ch.item_use(1);
                    break;
                case "btn_item_3":
                    ch.item_use(2);
                    break;
                case "btn_item_4":
                    ch.item_use(3);
                    break;
                case "btn_item_5":
                    ch.item_use(4);
                    break;
                case "btn_item_6":
                    ch.item_use(5);
                    break;
                case "btn_item_7":
                    ch.item_use(6);
                    break;
                case "btn_item_8":
                    ch.item_use(7);
                    break;
                default:
                    break;
            }
            update();
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
        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        private void btn_right_move_Click(object sender, EventArgs e)
        {
            C_1_1 form = new C_1_1(ref ch);
            this.Hide();
            form.ShowDialog();
            
            if (ch.real_health <= 0 || ch.close == 1)
            {
                this.Close();
            }
            this.Show();
            update();
            this.Refresh();
            
        }

        private void btn_left_move_Click(object sender, EventArgs e)
        {

        }

        private void btn_up_move_Click(object sender, EventArgs e)
        {

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            ch.save();
        }

        private void btn_travel_Click(object sender, EventArgs e)
        {
            ch.healed(ch.max_health);
            textBox1.AppendText("체력이 모두 회복되었다.\r\n");
            setting(ch);
        }

        private void C_1_0_Load_1(object sender, EventArgs e)
        {

        }
    }
}
