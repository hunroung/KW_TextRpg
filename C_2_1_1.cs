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
    public partial class C_2_1_1 : Form
    {
        public C_2_1_1()
        {
            InitializeComponent();
        }
        public int visit = 0;
        public character ch;
        //public slime slime = new slime();
        public C_2_1_1(ref character character)
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
        private void btn_save_Click(object sender, EventArgs e)
        {
            ch.save();
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            ch.close = 1;
            this.Close();
        }

        //폼 로딩시 세팅 단계
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

        private void btn_left_move_Click(object sender, EventArgs e)
        {
            /*
            this.Close();
            */
        }


        private void C_2_1_1_Load(object sender, EventArgs e)
        {
            if (ch.tur_visit == 0)
            {
                npc_name.Text = "???";
                textBox1.AppendText("저쪽에 쓰러져 있는 무언가가 보인다. 가까이 가볼까? \r\n");
                btn_attack.Visible = false;
                btn_defend.Visible = false;
                move_btn_enable();
                btn_yes.Visible = true;
                btn_no.Visible = true;
                picture_npc.Image = Image.FromFile(".\\img\\tur1.png");
            }
            else if (ch.tur_visit == 1)
            {
                npc_name.Text = "별주부";
                textBox1.AppendText("토끼의 간을 구하지 못하면 용왕님이... 용궁의 미래가... 아이고... \r\n\r\n");
                textBox1.AppendText("[ 현재 퀘스트를 수락한 상태입니다. ] \r\n");
                picture_npc.Image = Image.FromFile(".\\img\\tur2.png");
            }
            else if (ch.tur_visit == 2)
            {
                ch.tur_visit = 3;
                npc_name.Text = "별주부";
                textBox1.AppendText("그건... 토끼 간이 아닌가요? 설마 저를 위해서? \r\n");
                textBox1.AppendText("이 은혜를 어찌 값아야 할지... 제가 지금 가진건 이게 전부군요. \r\n\r\n");
                textBox1.AppendText("[exp 500 을 획득하였습니다.] \r\n[스킬회복물약 2개를 획득하였습니다.] ");
                for (int i = 0; i < 51; i++) ch.exp_gain(10);
                ch.item_gain(2, 2);
                picture_npc.Image = Image.FromFile(".\\img\\tur3.png");
                update();
            }
            else if (ch.tur_visit == 3)
            {
                npc_name.Text = "별주부";
                textBox1.AppendText("용궁의 은인을 이렇게 보내는 건 여간 안타까운 일이 아니군요. \r\n");
                textBox1.AppendText("후일 용궁에 방문하신다면 극진히 대접하지요. \r\n\r\n");
                textBox1.AppendText("[ 퀘스트를 완료하셨습니다. ] \r\n");
                picture_npc.Image = Image.FromFile(".\\img\\tur3.png");
            }

        }

        private void btn_no_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_yes_Click(object sender, EventArgs e)
        {
            btn_yes.Enabled = false;
            btn_no.Enabled = false;
            npc_name.Text = "별주부";
            picture_npc.Image = Image.FromFile(".\\img\\tur2.png");
            textBox1.AppendText("\r\n으윽... 머리가... \r\n");
            this.Refresh();
            Delay(2000);
            textBox1.AppendText("실례했군요. 저는 저 호수 바닥의 용궁에서 용왕님을 모시는 별주부라고 합지요. \r\n");
            this.Refresh();
            Delay(2000);
            textBox1.AppendText("용왕님이 죽을병에 걸리셔서 그 약의 재료인 토끼의 간을 구하러 뭍으로 올라왔지요. \r\n");
            this.Refresh();
            Delay(2000);
            textBox1.AppendText("아시겠지만 다른 친구들은 뭍으로 올라올 수가 없으니까요. \r\n");
            this.Refresh();
            Delay(2000);
            textBox1.AppendText("어의의 말로는 평범한 토끼가 아니라 개중에서도 범상치 않은 놈의 간이어야 한다더군요. \r\n");
            this.Refresh();
            Delay(2000);
            textBox1.AppendText("그런 놈을 만났지만 슬프게도 저는 그만 한방에 나가떨어지고 말았지요. \r\n");
            this.Refresh();
            Delay(2000);
            textBox1.AppendText("하이고 이걸 어쩌나... \r\n");
            this.Refresh();
            Delay(2000);
            textBox1.AppendText("[방울진 눈물을 닦아내는 별주부의 모습이 당신의 마음을 움직이는 것도 같기도 하고...] \r\n");
            this.Refresh();
            Delay(2000);
            textBox1.AppendText("[어쩌지? 도와줄까?] \r\n");
            this.Refresh();
            Delay(2000);
            btn_no.Enabled = true;
            btn_yes.Visible = false;
            btn_quest_yes.Visible = true;
        }

        private void btn_quest_yes_Click(object sender, EventArgs e)
        {
            ch.tur_visit = 1;
            MessageBox.Show("퀘스트를 수락하였습니다.\r\n그리고 C_2_2의 아래쪽에서 뭔가 큰 소리가 들립니다.");
            this.Close();
        }

        private void btn_down_move_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_up_move_Click(object sender, EventArgs e)
        {

        }
    }
}
