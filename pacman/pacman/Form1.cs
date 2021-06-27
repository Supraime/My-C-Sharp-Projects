using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using pacman;
using System.Media;
using System.Windows.Media;
using System.IO;

namespace pacman
{
    public partial class Form1 : BorderLessForm
    {
        
        bool startgame = false, tresec = true, col = false, pacmanturn, ghost1turn, Supermod, Supermod1, Supermod2, Supermod3, Supermod4, ghost2turn, ghost3turn, ghost4turn, ghost1caneat, ghost2caneat, ghost3caneat, ghost4caneat, g1rip, g2rip, g3rip, g4rip, v1, v2, v3, v4;
        int lifep = 3, startdirection = 1, pointscore = 0, systemscore = 0, left, top, direzione, next, temp = 1, leftghost1, leftghost2, dif = 0, leftghost3, leftghost4, topghost1, topghost2, topghost3, topghost4, ghost1speed = 2, ghost2speed = 2, ghost3speed = 2, ghost4speed = 2, random1, random2, random3, random4;
        AboutDev fr = new AboutDev();
       
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void OkeyBut_Click(object sender, EventArgs e)
        {
            if (HardStyle.SelectedIndex == 0)
            {
                dif = 0;
            }
            else if (HardStyle.SelectedIndex == 1)
            {
                dif = 1;
            }
            else if (HardStyle.SelectedIndex == 2)
            {
                dif = 2;
            }
            if (Convert.ToString(LangStyle.SelectedItem) == "Русский")
            {
                StGame.Text = "Играть";
                Setting.Text = "Настройки";
                ExitB.Text = "Выход";
                OkeyBut.Text = "Подтвердить";
                label253.Text = "Язык";
                label254.Text = "Сложность";
                label142.Text = "Жизни:";
                label2.Text = "Счет:";
                HardStyle.Items.Clear();
                HardStyle.Items.Add("Малышь");
                HardStyle.Items.Add("Мальчик");
                HardStyle.Items.Add("Мужик");
                HardStyle.SelectedIndex = dif;
                AbDev.Text = "О разработчике";
                fr.OkAb.Text = "Понятно";
            }
            else if(Convert.ToString(LangStyle.SelectedItem) == "English")
            {
                StGame.Text = "Start";
                Setting.Text = "Settings";
                ExitB.Text = "Exit";
                OkeyBut.Text = "Okey!";
                label253.Text = "Lang";
                label254.Text = "Complex:";
                label142.Text = "Life:";
                label2.Text = "Score:";
                HardStyle.Items.Clear();
                HardStyle.Items.Add("Kid");
                HardStyle.Items.Add("Boy");
                HardStyle.Items.Add("Man");
                HardStyle.SelectedIndex = dif;
                AbDev.Text = "About Developer";
                fr.OkAb.Text = "Xm, okey!";
            }
            
            if(musconoff) sp.Play();
            NextPanel.Visible = true;

        }

        private void MusicCikl_Tick(object sender, EventArgs e)
        {
            Uri te = new Uri(test);
            clicker.Volume = 150;
            clicker.Open(te);
            clicker.Play();
        }

        private void Setting_Click(object sender, EventArgs e)
        {
            NextPanel.Visible = false;
            if (musconoff) sp.Play();
        }
        bool harp = false;
        private void Hardplay_Tick(object sender, EventArgs e)
        {
            if(!harp)
            {
                ghost1speed = 3;
                ghost2speed = 3;
                ghost3speed = 3;
                ghost4speed = 3;
                Hardplay.Interval = 10000;
                harp = true;
            }
            else
            {
                ghost1speed = 2;
                ghost2speed = 2;
                ghost3speed = 2;
                ghost4speed = 2;
                if(dif==1)
                {
                    Hardplay.Interval = 60000;
                }
                else if(dif == 3)
                {
                    Hardplay.Interval = 30000;
                }
                harp = false;
            }
        }

        private void nextlvl_Tick(object sender, EventArgs e)
        {
            nextlvl.Enabled = false;
            SettingsPanel.Visible = true;
            MenuPanel.Visible = false;
            gonextvl.Enabled = true;
            startgame = true;
        }

        private void gonextvl_Tick(object sender, EventArgs e)
        {
            loadnextlvl();
            gonextvl.Enabled = false;
        }

        private void AbDev_Click(object sender, EventArgs e)
        {
            fr.Show();
        }
        bool musconoff = true;
        private void MusicOnOff_Click(object sender, EventArgs e)
        {
            if(musconoff)
            {
                MusicOnOff.BackgroundImage = Properties.Resources.musicOFF;
                musconoff = false;
                clicker.Stop();
                MusicCikl.Enabled = false;
            }
            else
            {
                sp.Play();
                Uri te = new Uri(test);
                clicker.Open(te);
                clicker.Play();
                MusicCikl.Enabled = true;
                MusicOnOff.BackgroundImage = Properties.Resources.musicON;
                musconoff = true;
            }
        }
        bool vis = false;
        private void CherryTimer_Tick(object sender, EventArgs e)
        {
            if(!vis)
            {
                    cherry.Visible = true;
                    vis = true;
            }
            else
            {
                cherry.Visible = false;
                vis = false;
            }
        }

        private void Pointer_Tick(object sender, EventArgs e)
        {
            point300.Visible = false;
            point200.Visible = false;
            Pointer.Enabled = false;
        }

        private void ExitB_Click(object sender, EventArgs e)
        {
            if(musconoff) sp.Play();
            Application.Exit();
        }

        int t = 0;
        private void timer9_Tick(object sender, EventArgs e)
        {
            if (t == 0)
            {
                StGame.ForeColor = System.Drawing.Color.Yellow;
                AbDev.ForeColor = System.Drawing.Color.Yellow;
                t = 1;
            }
            else if(t == 1)
            {
                StGame.ForeColor = System.Drawing.Color.White;
                AbDev.ForeColor = System.Drawing.Color.White;
                t = 2;
            }
            else
            {
                StGame.ForeColor = System.Drawing.Color.Red;
                AbDev.ForeColor = System.Drawing.Color.Red;
                t = 0;
            }
        }

        int tick4, tick5, tick6, prec1, prec2, prec3, prec4;
        bool dir1, dir2, dir3, dir4;
        Random rand = new Random();
        private void timer4_Tick(object sender, EventArgs e) // Стартует розовый
        {
            tick4++;
            if (ghost3.Top > 178 && tick4 > 100) { prec1 = 3; ghost3.Top--; }
            if (ghost3.Top == 178) timer4.Enabled = false;
        }

        private void timer5_Tick(object sender, EventArgs e)// Стартует синий
        {
            tick5++;
            if (ghost2.Left > 153 && ghost2.Left < 176 && tick5 > 300) ghost2.Left++;
            if (ghost2.Top > 178 && ghost2.Left == 176) { ghost2.Top--; }
            if (ghost2.Top == 178) { timer6.Enabled = true; timer5.Enabled = false; }
        }
        private void timer6_Tick(object sender, EventArgs e) // Стартует оранжевый
        {
            tick6++;
            if (ghost4.Left > 176 && ghost4.Left < 200 && tick6 > 100) ghost4.Left--;
            if (ghost4.Top > 178 && ghost4.Left == 176) { ghost4.Top--; }
            if (ghost4.Top == 178) timer6.Enabled = false;
        }
        private void StGame_Click(object sender, EventArgs e)
        {
            startgame = true;
            life();
            points();
            SettingsPanel.Visible = false;
            reloadgame();
            this.KeyPreview = true;
            this.Focus();
            if (musconoff) sp.Play();
            clicker.Stop();
            MusicCikl.Enabled = false;
            if (musconoff)
            {
                Uri te = new Uri(gamemuz);
                clicker.Volume = 80;
                clicker.Open(te);
                clicker.Play();
            }
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
            timer7.Enabled = false;
            SettingsPanel.Visible = true;
            if(musconoff)
            {
                Uri te = new Uri(test);
                clicker.Open(te);
                clicker.Play();
                MusicCikl.Enabled = true;
            }
            pause.Enabled = true;
        }
        private void pause_Tick(object sender, EventArgs e)
        {
            reloadgame();
            pause.Enabled = false;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (ghost2.Top == 208) startdirection = 2;
            if (ghost2.Top == 220) startdirection = 1;
            if (startdirection == 1)
            {
                ghost2.Top--;
                ghost4.Top--;
            }
            if (startdirection == 2)
            {
                ghost2.Top++;
                ghost4.Top++;
            }
        }
        private void powermod_Tick(object sender, EventArgs e)
        {
            tresec = false;
            if (!g1rip)
            {
                v1 = false;
                ghost1caneat = true;
                Supermod1 = false;
                switch (dif)
                {
                    case 0:
                        ghost1speed = 2;
                        break;
                    case 1:
                        ghost1speed = 2;
                        break;
                    case 2:
                        ghost1speed = 2;
                        break;
                }
            }
            if (!g2rip)
            {
                v2 = false;
                ghost2caneat = true;
                Supermod2 = false;
                switch (dif)
                {
                    case 0:
                        ghost2speed = 2;
                        break;
                    case 1:
                        ghost2speed = 2;
                        break;
                    case 2:
                        ghost2speed = 2;
                        break;
                }
            }
            if (!g3rip)
            {
                v3 = false;
                ghost3caneat = true;
                Supermod3 = false;
                switch (dif)
                {
                    case 0:
                        ghost3speed = 2;
                        break;
                    case 1:
                        ghost3speed = 2;
                        break;
                    case 2:
                        ghost3speed = 2;
                        break;
                }
            }
            if (!g4rip)
            {
                v4 = false;
                ghost4caneat = true;
                Supermod4 = false;
                switch (dif)
                {
                    case 0:
                        ghost4speed = 2;
                        break;
                    case 1:
                        ghost4speed = 2;
                        Hardplay.Interval = 60000;
                        Hardplay.Enabled = true;
                        break;
                    case 2:
                        ghost4speed = 2;
                        Hardplay.Interval = 30000;
                        Hardplay.Enabled = true;
                        break;
                }
            }
            Supermod = false;
            powermod.Enabled = false;
            powermod1.Enabled = false;
            if (prec1 == 1 && !g1rip) { if (ghost1.Left % 2 == 0) leftghost1 = ghost1speed; ghost1.Image = Properties.Resources.rright; }
            if (prec1 == 2 && !g1rip) { if (ghost1.Left % 2 == 0) leftghost1 = -ghost1speed; ghost1.Image = Properties.Resources.rleft; }
            if (prec1 == 3 && !g1rip) { if (ghost1.Top % 2 == 0) topghost1 = -ghost1speed; ghost1.Image = Properties.Resources.rup; }
            if (prec1 == 4 && !g1rip) { if (ghost1.Top % 2 == 0) topghost1 = ghost1speed; ghost1.Image = Properties.Resources.rdown; }

            if (prec2 == 1 && !g2rip) { if (ghost2.Left % 2 == 0) leftghost2 = ghost2speed; ghost2.Image = Properties.Resources.bright; }
            if (prec2 == 2 && !g2rip) { if (ghost2.Left % 2 == 0) leftghost2 = -ghost2speed; ghost2.Image = Properties.Resources.bleft; }
            if (prec2 == 3 && !g2rip) { if (ghost2.Top % 2 == 0) topghost2 = -ghost2speed; ghost2.Image = Properties.Resources.bup; }
            if (prec2 == 4 && !g2rip) { if (ghost2.Top % 2 == 0) topghost2 = ghost2speed; ghost2.Image = Properties.Resources.bdown; }

            if (prec3 == 1 && !g3rip) { if (ghost3.Left % 2 == 0) leftghost3 = ghost3speed; ghost3.Image = Properties.Resources.pright; }
            if (prec3 == 2 && !g3rip) { if (ghost3.Left % 2 == 0) leftghost3 = -ghost3speed; ghost3.Image = Properties.Resources.pleft; }
            if (prec3 == 3 && !g3rip) { if (ghost3.Top % 2 == 0) topghost3 = -ghost3speed; ghost3.Image = Properties.Resources.pup; }
            if (prec3 == 4 && !g3rip) { if (ghost3.Top % 2 == 0) topghost3 = ghost3speed; ghost3.Image = Properties.Resources.pdown; }

            if (prec4 == 1 && !g4rip) { if (ghost4.Left % 2 == 0) leftghost4 = ghost4speed; ghost4.Image = Properties.Resources.oright; }
            if (prec4 == 2 && !g4rip) { if (ghost4.Left % 2 == 0) leftghost4 = -ghost4speed; ghost4.Image = Properties.Resources.oleft; }
            if (prec4 == 3 && !g4rip) { if (ghost4.Top % 2 == 0) topghost4 = -ghost4speed; ghost4.Image = Properties.Resources.oup; }
            if (prec4 == 4 && !g4rip) { if (ghost4.Top % 2 == 0) topghost4 = ghost4speed; ghost1.Image = Properties.Resources.odown; }
        }


        private void timer8_Tick(object sender, EventArgs e)
        {
            pacman.SetBounds(pacman.Left, pacman.Top, 0, 0);
            g1rip = false;
            g2rip = false;
            g3rip = false;
            g4rip = false;
            v1 = false;
            v2 = false;
            v3 = false;
            v4 = false;
            ghost1caneat = true;
            ghost2caneat = true;
            ghost3caneat = true;
            ghost4caneat = true;
            ghost1.Visible = false;
            ghost2.Visible = false;
            ghost3.Visible = false;
            ghost4.Visible = false;
            pacman.Visible = false;
            tick4 = 0;
            tick5 = 0;
            tick6 = 0;
            Supermod = false;
            Supermod1 = false;
            Supermod2 = false;
            Supermod3 = false;
            Supermod4 = false;
            switch (dif)
            {
                case 0:
                    ghost1speed = 2;
                    break;
                case 1:
                    ghost1speed = 2;
                    break;
                case 2:
                    ghost1speed = 2;
                    break;
            }
            switch (dif)
            {
                case 0:
                    ghost2speed = 2;
                    break;
                case 1:
                    ghost2speed = 2;
                    break;
                case 2:
                    ghost2speed = 2;
                    break;
            }
            switch (dif)
            {
                case 0:
                    ghost3speed = 2;
                    break;
                case 1:
                    ghost3speed = 2;
                    break;
                case 2:
                    ghost3speed = 2;
                    break;
            }
            switch (dif)
            {
                case 0:
                    ghost4speed = 2;
                    break;
                case 1:
                    ghost4speed = 2;
                    Hardplay.Interval = 60000;
                    Hardplay.Enabled = true;
                    break;
                case 2:
                    ghost4speed = 2;
                    Hardplay.Interval = 30000;
                    Hardplay.Enabled = true;
                    break;
            }
            lifep--;
            life();
            prec1 = 0;
            prec2 = 0;
            prec3 = 0;
            prec4 = 0;
            startdirection = 1;
            dir1 = false;
            dir2 = false;
            dir3 = false;
            dir4 = false;
            col = false;
            next = 0;
            temp = 1;
            direzione = 0;
            pacman.Left = 24;
            pacman.Top = 392;
            ghost1.Left = 176;
            ghost1.Top = 178;
            ghost2.Left = 154;
            ghost2.Top = 213;
            ghost3.Left = 176;
            ghost3.Top = 213;
            ghost4.Left = 199;
            ghost4.Top = 213;
            leftghost1 = 0;
            leftghost2 = 0;
            leftghost3 = 0;
            leftghost4 = 0;
            topghost1 = 0;
            topghost2 = 0;
            topghost3 = 0;
            topghost4 = 0;
            left = 0;
            top = 0;
            timer8.Enabled = false;
            pacman.Image = Properties.Resources._1dx;
            ghost1.Image = Properties.Resources.rup;
            ghost2.Image = Properties.Resources.bup;
            ghost3.Image = Properties.Resources.pup;
            ghost4.Image = Properties.Resources.oup;
            ghost1.Visible = true;
            ghost2.Visible = true;
            ghost3.Visible = true;
            ghost4.Visible = true;
            pacman.SetBounds(pacman.Left, pacman.Top, 22, 22);
            pacman.Visible = true;
            timer2.Enabled = true;
            timer3.Enabled = true;
            timer8.Interval = 1900;
        }

        private void ghosteater_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            ghosteater.Enabled = false;
        }
        string test = Path.Combine(Application.StartupPath, "mnmusic.wav");
        string gamemuz = Path.Combine(Application.StartupPath, "gamemuz.mp3");
        public List<object> pointobject = new List<object>();
        SoundPlayer sp = new SoundPlayer(Properties.Resources.click);
        //SoundPlayer pacch = new SoundPlayer(Properties.Resources.dp_superpac_wakka);
        SoundPlayer dead = new SoundPlayer(Properties.Resources.pacman_death);
        SoundPlayer eat = new SoundPlayer(Properties.Resources.pacman_eatfruit);
        SoundPlayer eatghostm = new SoundPlayer(Properties.Resources.pacman_eatghost);
        SoundPlayer winer = new SoundPlayer(Properties.Resources.pacman_intermission);
        MediaPlayer clicker = new MediaPlayer();
        public Form1()
        {
            InitializeComponent();
            HardStyle.SelectedIndex = 0;
            LangStyle.SelectedItem = "Русский";
            Uri te = new Uri(test);
            clicker.Volume = 150;
            clicker.Open(te);
            clicker.Play();
            pointobject.Add(label4);
            pointobject.Add(label5);
            pointobject.Add(label6);
            pointobject.Add(label7);
            pointobject.Add(label8);
            pointobject.Add(label9);
            pointobject.Add(label10);
            pointobject.Add(label11);
            pointobject.Add(label12);
            pointobject.Add(label13);
            pointobject.Add(label14);
            pointobject.Add(label15);
            pointobject.Add(label16);
            pointobject.Add(label17);
            pointobject.Add(label18);
            pointobject.Add(label19);
            pointobject.Add(label20);
            pointobject.Add(label21);
            pointobject.Add(label22);
            pointobject.Add(label23);
            pointobject.Add(label24);
            pointobject.Add(label25);
            pointobject.Add(label26);
            pointobject.Add(label27);
            pointobject.Add(label28);
            pointobject.Add(label29);
            pointobject.Add(label30);
            pointobject.Add(label31);
            pointobject.Add(label32);
            pointobject.Add(label33);
            pointobject.Add(label34);
            pointobject.Add(label35);
            pointobject.Add(label36);
            pointobject.Add(label37);
            pointobject.Add(label38);
            pointobject.Add(label39);
            pointobject.Add(label40);
            pointobject.Add(label41);
            pointobject.Add(label42);
            pointobject.Add(label43);
            pointobject.Add(label44);
            pointobject.Add(label45);
            pointobject.Add(label46);
            pointobject.Add(label47);
            pointobject.Add(label48);
            pointobject.Add(label49);
            pointobject.Add(label50);
            pointobject.Add(label51);
            pointobject.Add(label52);
            pointobject.Add(label53);
            pointobject.Add(label54);
            pointobject.Add(label55);
            pointobject.Add(label56);
            pointobject.Add(label57);
            pointobject.Add(label58);
            pointobject.Add(label59);
            pointobject.Add(label60);
            pointobject.Add(label61);
            pointobject.Add(label62);
            pointobject.Add(label63);
            pointobject.Add(label64);
            pointobject.Add(label65);
            pointobject.Add(label66);
            pointobject.Add(label67);
            pointobject.Add(label68);
            pointobject.Add(label69);
            pointobject.Add(label70);
            pointobject.Add(label71);
            pointobject.Add(label72);
            pointobject.Add(label73);
            pointobject.Add(label74);
            pointobject.Add(label75);
            pointobject.Add(label76);
            pointobject.Add(label77);
            pointobject.Add(label78);
            pointobject.Add(label79);
            pointobject.Add(label80);
            pointobject.Add(label81);
            pointobject.Add(label82);
            pointobject.Add(label83);
            pointobject.Add(label84);
            pointobject.Add(label85);
            pointobject.Add(label86);
            pointobject.Add(label87);
            pointobject.Add(label88);
            pointobject.Add(label89);
            pointobject.Add(label90);
            pointobject.Add(label91);
            pointobject.Add(label92);
            pointobject.Add(label93);
            pointobject.Add(label94);
            pointobject.Add(label95);
            pointobject.Add(label96);
            pointobject.Add(label97);
            pointobject.Add(label98);
            pointobject.Add(label99);
            pointobject.Add(label100);
            pointobject.Add(label101);
            pointobject.Add(label102);
            pointobject.Add(label103);
            pointobject.Add(label104);
            pointobject.Add(label105);
            pointobject.Add(label106);
            pointobject.Add(label107);
            pointobject.Add(label108);
            pointobject.Add(label109);
            pointobject.Add(label110);
            pointobject.Add(label111);
            pointobject.Add(label112);
            pointobject.Add(label113);
            pointobject.Add(label114);
            pointobject.Add(label115);
            pointobject.Add(label116);
            pointobject.Add(label117);
            pointobject.Add(label118);
            pointobject.Add(label119);
            pointobject.Add(label120);
            pointobject.Add(label121);
            pointobject.Add(label122);
            pointobject.Add(label123);
            pointobject.Add(label125);
            pointobject.Add(label126);
            pointobject.Add(label127);
            pointobject.Add(label128);
            pointobject.Add(label129);
            pointobject.Add(label130);
            pointobject.Add(label131);
            pointobject.Add(label132);
            pointobject.Add(label133);
            pointobject.Add(label134);
            pointobject.Add(label135);
            pointobject.Add(label136);
            pointobject.Add(label137);
            pointobject.Add(label138);
            pointobject.Add(label139);
            pointobject.Add(label140);
            pointobject.Add(label143);
            pointobject.Add(label144);
            pointobject.Add(label145);
            pointobject.Add(label146);
            pointobject.Add(label147);
            pointobject.Add(label148);
            pointobject.Add(label149);
            pointobject.Add(label150);
            pointobject.Add(label151);
            pointobject.Add(label152);
            pointobject.Add(label153);
            pointobject.Add(label154);
            pointobject.Add(label155);
            pointobject.Add(label156);
            pointobject.Add(label157);
            pointobject.Add(label158);
            pointobject.Add(label159);
            pointobject.Add(label160);
            pointobject.Add(label161);
            pointobject.Add(label162);
            pointobject.Add(label163);
            pointobject.Add(label164);
            pointobject.Add(label165);
            pointobject.Add(label166);
            pointobject.Add(label167);
            pointobject.Add(label168);
            pointobject.Add(label169);
            pointobject.Add(label170);
            pointobject.Add(label171);
            pointobject.Add(label172);
            pointobject.Add(label173);
            pointobject.Add(label174);
            pointobject.Add(label175);
            pointobject.Add(label176);
            pointobject.Add(label177);
            pointobject.Add(label178);
            pointobject.Add(label179);
            pointobject.Add(label180);
            pointobject.Add(label181);
            pointobject.Add(label182);
            pointobject.Add(label183);
            pointobject.Add(label184);
            pointobject.Add(label185);
            pointobject.Add(label186);
            pointobject.Add(label187);
            pointobject.Add(label188);
            pointobject.Add(label189);
            pointobject.Add(label190);
            pointobject.Add(label191);
            pointobject.Add(label192);
            pointobject.Add(label193);
            pointobject.Add(label194);
            pointobject.Add(label195);
            pointobject.Add(label196);
            pointobject.Add(label197);
            pointobject.Add(label198);
            pointobject.Add(label199);
            pointobject.Add(label200);
            pointobject.Add(label201);
            pointobject.Add(label202);
            pointobject.Add(label203);
            pointobject.Add(label204);
            pointobject.Add(label205);
            pointobject.Add(label206);
            pointobject.Add(label207);
            pointobject.Add(label208);
            pointobject.Add(label209);
            pointobject.Add(label210);
            pointobject.Add(label211);
            pointobject.Add(label212);
            pointobject.Add(label213);
            pointobject.Add(label214);
            pointobject.Add(label215);
            pointobject.Add(label216);
            pointobject.Add(label217);
            pointobject.Add(label218);
            pointobject.Add(label219);
            pointobject.Add(label220);
            pointobject.Add(label221);
            pointobject.Add(label222);
            pointobject.Add(label223);
            pointobject.Add(label224);
            pointobject.Add(label225);
            pointobject.Add(label226);
            pointobject.Add(label227);
            pointobject.Add(label228);
            pointobject.Add(label229);
            pointobject.Add(label230);
            pointobject.Add(label231);
            pointobject.Add(label232);
            pointobject.Add(label233);
            pointobject.Add(label234);
            pointobject.Add(label235);
            pointobject.Add(label236);
            pointobject.Add(label237);
            pointobject.Add(label238);
            pointobject.Add(label239);
            pointobject.Add(label240);
            pointobject.Add(label241);
            pointobject.Add(label242);
            pointobject.Add(label243);
            pointobject.Add(label244);
            pointobject.Add(label245);
            pointobject.Add(label246);
            pointobject.Add(label247);
            pointobject.Add(label248);
            pointobject.Add(label249);
            pointobject.Add(label250);
            pointobject.Add(label251);
            pointobject.Add(label252);
            pointobject.Add(label256);
            pointobject.Add(label257);
            pointobject.Add(label258);
            pointobject.Add(label259);
            pointobject.Add(label260);
            pointobject.Add(label261);
            pointobject.Add(label262);
            pointobject.Add(label263);
            pointobject.Add(label264);
            pointobject.Add(label265);
            pointobject.Add(label266);
            pointobject.Add(label267);
            pointobject.Add(label268);
            pointobject.Add(label269);
            pointobject.Add(label270);
            pointobject.Add(label271);
            pointobject.Add(label272);
            pointobject.Add(label273);
            pointobject.Add(label274);
            pointobject.Add(label275);
            pointobject.Add(label276);
            pointobject.Add(label277);
            pointobject.Add(label278);
            pointobject.Add(label279);
            pointobject.Add(label280);
            pointobject.Add(label281);
            pointobject.Add(label282);
            pointobject.Add(label283);
            pointobject.Add(label284);
            pointobject.Add(label285);
            pointobject.Add(label286);
            pointobject.Add(label287);
            pointobject.Add(label288);
            pointobject.Add(label289);
            pointobject.Add(label290);
            pointobject.Add(label291);
            pointobject.Add(label292);
            pointobject.Add(label293);
            pointobject.Add(label294);
            pointobject.Add(label295);
            pointobject.Add(label296);
            pointobject.Add(label297);
            pointobject.Add(label298);
            pointobject.Add(label299);
            pointobject.Add(label300);
            pointobject.Add(label301);
            pointobject.Add(label302);
            pointobject.Add(label303);
            pointobject.Add(label304);
            pointobject.Add(label305);
            pointobject.Add(label306);
            pointobject.Add(label307);
            pointobject.Add(label308);
            pointobject.Add(label309);
            pointobject.Add(label310);
            pointobject.Add(label311);
            pointobject.Add(label312);
            pointobject.Add(label313);
            pointobject.Add(label314);
            pointobject.Add(label315);
            pointobject.Add(label316);
            pointobject.Add(label317);
            pointobject.Add(label318);
            pointobject.Add(label319);
            pointobject.Add(label320);
            pointobject.Add(label321);
            pointobject.Add(label322);
            pointobject.Add(label323);
            pointobject.Add(label324);
            pointobject.Add(label325);
            pointobject.Add(label326);
            pointobject.Add(label327);
            pointobject.Add(label328);
            pointobject.Add(label329);
            pointobject.Add(label330);
            pointobject.Add(label331);
            pointobject.Add(label332);
            pointobject.Add(label333);
            pointobject.Add(label334);
            pointobject.Add(label335);
            pointobject.Add(label336);
            pointobject.Add(label337);
            pointobject.Add(label338);
            pointobject.Add(label339);
            pointobject.Add(label340);
            pointobject.Add(label341);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(musconoff) sp.Play();
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void StartGame_Click(object sender, EventArgs e)
        {
        }

        private void Form1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) next = 1;
            if (e.KeyCode == Keys.Right) next = 2;
            if (e.KeyCode == Keys.Up) next = 3;
            if (e.KeyCode == Keys.Down) next = 4;
            if (e.KeyCode == Keys.Escape) Close();
            temp = next;
        }
        private void life()
        {
            if (lifep == 3)
            {
                pictureBox4.Visible = true;
                pictureBox3.Visible = true;
                pictureBox7.Visible = true;
            }
            if (lifep == 2)
            {
                pictureBox4.Visible = true;
                pictureBox3.Visible = true;
                pictureBox7.Visible = false;
            }
            if (lifep == 1)
            {
                pictureBox4.Visible = false;
                pictureBox3.Visible = true;
                pictureBox7.Visible = false;
            }
        }

        private void points()
        {
            for (int i = 0; i < 332; i++)
            {
                if (((Label)pointobject[i]).Visible == true && pacman.Bounds.IntersectsWith(((Label)pointobject[i]).Bounds))
                {
                    pointscore += 10;
                    systemscore += 1;
                    ((Label)pointobject[i]).Visible = false;
                }
            }
            if (cherry.Visible == true && pacman.Bounds.IntersectsWith(cherry.Bounds))
            {
                if (musconoff) eat.Play();
                pointscore += 300;
                CherryTimer.Enabled = false;
                cherry.Visible = false;
                point300.Visible = true;
                Pointer.Enabled = true;
            }
            score.Text = pointscore.ToString();
            if (systemscore >= 332) { if(musconoff) winer.Play();  winsologame(); label141.Visible = true; }
        }

        private void winsologame()
        {
            //pointscore = 0;
            systemscore = 0;
           // lifep = 3;
            timer1.Enabled = false;
            timer2.Enabled = false;
            timer3.Enabled = false;
            timer4.Enabled = false;
            timer5.Enabled = false;
            timer6.Enabled = false;
            powermod1.Enabled = false;
            powermod.Enabled = false;
            nextlvl.Enabled = true;
            //leveltwo_load(2);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pacman.Enabled)
            {
                direction();
                freedirection();
            }
            if (ghost1.Enabled || ghost2.Enabled || ghost3.Enabled || ghost4.Enabled)
            {
                ghost();
            }
            if (col) control();
            eatghostmod();
            points();
            collision();
        }

       /* private void leveltwo_load(int level)
        {
            SettingsPanel.Visible = true;
            MenuPanel.Visible = false;
            switch (level)
            {
                case 2:
                    //level2load.Visible = true;
                    this.BackgroundImage = Properties.Resources.level2persoco;
                    for (int i = 0; i < 332; i++) ((Label)pointobject[i]).Visible = true;
                    ghost1.Image = Properties.Resources.rup;
                    ghost2.Image = Properties.Resources.bup;
                    ghost3.Image = Properties.Resources.pup;
                    ghost4.Image = Properties.Resources.oup;
                    ghost1.Left = 176;
                    ghost1.Top = 124;
                    ghost2.Left = 154;
                    ghost2.Top = 159;                                                                  ******************************************************************************
                    ghost3.Left = 176;                                                             **************************************************************************************
                    ghost3.Top = 159;                                                             ****************************  ЗАГОТОВКА ПОД НОВУЮ КАРТУ********************************************
                    ghost4.Left = 199;                                                              **************************************************************************************  
                    ghost4.Top = 159;                                                                   ********************************************************************************
                    label141.Location = new Point(123,203);
                    label124.Location = new Point(123, 203);
                    label3.Location = new Point(123, 203);
                    changepointpos(2);
                    break;
            }

        }

        private void changepointpos(int level)
        {
            switch (level)
            {
                case 2:
                    label279.Location = new Point(181, 56);
                    label285.Location = new Point(172, 56);
                    label286.Location = new Point(163, 56);
                    label279.Location = new Point(181, 56);
                    label279.Location = new Point(181, 56);

                    break;
            }

        }*/

        private void timer2_Tick(object sender, EventArgs e)
        {
            label3.Visible = false;
            col = true;
            timer1.Enabled = true;
            timer2.Enabled = false;
        }

        private void reloadgame()
        {
            label3.Visible = true;
            g1rip = false;
            g2rip = false;
            g3rip = false;
            g4rip = false;
            v1 = false;
            v2 = false;
            v3 = false;
            v4 = false;
            ghost1caneat = true;
            ghost2caneat = true;
            ghost3caneat = true;
            ghost4caneat = true;
            label124.Visible = false;
            label141.Visible = false;
            pacman.SetBounds(pacman.Left, pacman.Top, 22, 22);
            tick4 = 0;
            tick5 = 0;
            tick6 = 0;
            Supermod = false;
            Supermod1 = false;
            Supermod2 = false;
            Supermod3 = false;
            Supermod4 = false;
            switch (dif)
            {
                case 0:
                    ghost1speed = 2;
                    break;
                case 1:
                    ghost1speed = 2;
                    break;
                case 2:
                    ghost1speed = 2;
                    break;
            }
            switch (dif)
            {
                case 0:
                    ghost2speed = 2;
                    break;
                case 1:
                    ghost2speed = 2;
                    break;
                case 2:
                    ghost2speed = 2;
                    break;
            }
            switch (dif)
            {
                case 0:
                    ghost3speed = 2;
                    break;
                case 1:
                    ghost3speed = 2;
                    break;
                case 2:
                    ghost3speed = 2;
                    break;
            }
            switch (dif)
            {
                case 0:
                    ghost4speed = 2;
                    break;
                case 1:
                    ghost4speed = 2;
                    Hardplay.Interval = 60000;
                    Hardplay.Enabled = true;
                    break;
                case 2:
                    ghost4speed = 2;
                    Hardplay.Interval = 30000;
                    Hardplay.Enabled = true;
                    break;
            }
            life();
            prec1 = 0;
            prec2 = 0;
            prec3 = 0;
            prec4 = 0;
            startdirection = 2;
            dir1 = false;
            dir2 = false;
            dir3 = false;
            dir4 = false;
            col = false;
            next = 0;
            temp = 1;
            direzione = 0;
            pacman.Left = 24;
            pacman.Top = 392;
            ghost1.Left = 176;
            ghost1.Top = 178;
            ghost2.Left = 154;
            ghost2.Top = 213;
            ghost3.Left = 176;
            ghost3.Top = 213;
            ghost4.Left = 199;
            ghost4.Top = 213;
            leftghost1 = 0;
            leftghost2 = 0;
            leftghost3 = 0;
            leftghost4 = 0;
            topghost1 = 0;
            topghost2 = 0;
            topghost3 = 0;
            topghost4 = 0;
            left = 0;
            top = 0;
            timer1.Enabled = false;
            timer4.Enabled = false;
            timer5.Enabled = false;
            timer6.Enabled = false;
            timer7.Enabled = false;
            pause.Enabled = false;
            powermod.Enabled = false;
            powermod1.Enabled = false;
            pacman.Image = Properties.Resources._1dx;
            ghost1.Image = Properties.Resources.rup;
            ghost2.Image = Properties.Resources.bup;
            ghost3.Image = Properties.Resources.pup;
            ghost4.Image = Properties.Resources.oup;
            if (startgame)
            {
                timer2.Enabled = true;
                timer3.Enabled = true;
                CherryTimer.Enabled = true;
            }
            startgame = false;
            for (int i = 0; i < 332; i++) ((Label)pointobject[i]).Visible = true;
        }

        private void direction()
        {
            pacmanturn = true;
            a(pacman.Left, pacman.Top);
            pacman.Left += left;
            pacman.Top += top;
        }

        private void freedirection()
        {
            switch (direzione)
            {
                case 1:
                    if (next == 2)
                    {
                        left = 2;
                        pacman.Image = Properties.Resources.pacright;
                        direzione = next;
                        temp = next;
                    }
                    break;

                case 2:
                    if (next == 1)
                    {
                        left = -2;
                        pacman.Image = Properties.Resources.pacleft;
                        direzione = next;
                        temp = next;
                    }
                    break;

                case 3:
                    if (next == 4)
                    {
                        top = 2;
                        pacman.Image = Properties.Resources.pacdown;
                        direzione = next;
                        temp = next;
                    }
                    break;

                case 4:
                    if (next == 3)
                    {
                        top = -2;
                        pacman.Image = Properties.Resources.pacup;
                        direzione = next;
                        temp = next;
                    }
                    break;
            }
        }

        private void loadnextlvl()
        {
            label3.Visible = true;
            MenuPanel.Visible = true;
            SettingsPanel.Visible = false;
            g1rip = false;
            g2rip = false;
            g3rip = false;
            g4rip = false;
            v1 = false;
            v2 = false;
            v3 = false;
            v4 = false;
            ghost1caneat = true;
            ghost2caneat = true;
            ghost3caneat = true;
            ghost4caneat = true;
            label124.Visible = false;
            label141.Visible = false;
            pacman.SetBounds(pacman.Left, pacman.Top, 22, 22);
            tick4 = 0;
            tick5 = 0;
            tick6 = 0;
            Supermod = false;
            Supermod1 = false;
            Supermod2 = false;
            Supermod3 = false;
            Supermod4 = false;
            switch (dif)
            {
                case 0:
                    ghost1speed = 2;
                    break;
                case 1:
                    ghost1speed = 2;
                    break;
                case 2:
                    ghost1speed = 2;
                    break;
            }
            switch (dif)
            {
                case 0:
                    ghost2speed = 2;
                    break;
                case 1:
                    ghost2speed = 2;
                    break;
                case 2:
                    ghost2speed = 2;
                    break;
            }
            switch (dif)
            {
                case 0:
                    ghost3speed = 2;
                    break;
                case 1:
                    ghost3speed = 2;
                    break;
                case 2:
                    ghost3speed = 2;
                    break;
            }
            switch (dif)
            {
                case 0:
                    ghost4speed = 2;
                    break;
                case 1:
                    ghost4speed = 2;
                    Hardplay.Interval = 60000;
                    Hardplay.Enabled = true;
                    break;
                case 2:
                    ghost4speed = 2;
                    Hardplay.Interval = 30000;
                    Hardplay.Enabled = true;
                    break;
            }
            prec1 = 0;
            prec2 = 0;
            prec3 = 0;
            prec4 = 0;
            startdirection = 2;
            dir1 = false;
            dir2 = false;
            dir3 = false;
            dir4 = false;
            col = false;
            next = 0;
            temp = 1;
            direzione = 0;
            pacman.Left = 24;
            pacman.Top = 392;
            ghost1.Left = 176;
            ghost1.Top = 178;
            ghost2.Left = 154;
            ghost2.Top = 213;
            ghost3.Left = 176;
            ghost3.Top = 213;
            ghost4.Left = 199;
            ghost4.Top = 213;
            leftghost1 = 0;
            leftghost2 = 0;
            leftghost3 = 0;
            leftghost4 = 0;
            topghost1 = 0;
            topghost2 = 0;
            topghost3 = 0;
            topghost4 = 0;
            left = 0;
            top = 0;
            timer1.Enabled = false;
            timer4.Enabled = false;
            timer5.Enabled = false;
            timer6.Enabled = false;
            timer7.Enabled = false;
            pause.Enabled = false;
            powermod.Enabled = false;
            powermod1.Enabled = false;
            pacman.Image = Properties.Resources._1dx;
            ghost1.Image = Properties.Resources.rup;
            ghost2.Image = Properties.Resources.bup;
            ghost3.Image = Properties.Resources.pup;
            ghost4.Image = Properties.Resources.oup;
            if (startgame)
            {
                timer2.Enabled = true;
                timer3.Enabled = true;
                CherryTimer.Enabled = true;
            }
            startgame = false;
            for (int i = 0; i < 332; i++) ((Label)pointobject[i]).Visible = true;
        }
        private void ghost()
        {
            if (ghost1.Enabled == true)
            {
                ghost1.Left += leftghost1;
                ghost1.Top += topghost1;
                ghost1turn = true;
                a(ghost1.Left, ghost1.Top);
            }
            if (ghost2.Enabled == true)
            {
                ghost2.Left += leftghost2;
                ghost2.Top += topghost2;
                ghost2turn = true;
                a(ghost2.Left, ghost2.Top);
            }
            if (ghost3.Enabled == true)
            {
                ghost3.Left += leftghost3;
                ghost3.Top += topghost3;
                ghost3turn = true;
                a(ghost3.Left, ghost3.Top);
            }
            if (ghost4.Enabled == true)
            {
                ghost4.Left += leftghost4;
                ghost4.Top += topghost4;
                ghost4turn = true;
                a(ghost4.Left, ghost4.Top);
            }
        }

        private void control()
        {
            if (ghost2.Top == 213) { timer3.Enabled = false; timer4.Enabled = true; col = false; timer5.Enabled = true; }
        }

        private void eatghostmod()
        {
            if (pacman.Bounds.IntersectsWith(label173.Bounds) && label173.Visible == true)
            {
                if(musconoff) eat.Play();
                supermod2();
            }
            if (pacman.Bounds.IntersectsWith(label307.Bounds) && label307.Visible == true)
            {
                if (musconoff) eat.Play();
                supermod2();
            }
            if (pacman.Bounds.IntersectsWith(label220.Bounds) && label220.Visible == true)
            {
                if (musconoff) eat.Play();
                supermod2();
            }
            if (pacman.Bounds.IntersectsWith(label71.Bounds) && label71.Visible == true)
            {
                if (musconoff) eat.Play();
                supermod2();
            }
        }
        private void supermod2()
        {
            if (!g1rip)
            {
                v1 = false;
                ghost1speed = 1;
                Supermod1 = true;
                ghost1.Image = Properties.Resources.ghosteater;
                ghost1caneat = true;
            }
            if (!g2rip)
            {
                v2 = false;
                ghost2speed = 1;
                Supermod2 = true;
                ghost2.Image = Properties.Resources.ghosteater;
                ghost2caneat = true;
            }
            if (!g3rip)
            {
                v3 = false;
                ghost3speed = 1;
                Supermod3 = true;
                ghost3.Image = Properties.Resources.ghosteater;
                ghost3caneat = true;
            }
            if (!g4rip)
            {
                v4 = false;
                ghost4speed = 1;
                Supermod4 = true;
                ghost4.Image = Properties.Resources.ghosteater;
                ghost4caneat = true;
            }
            powermod.Enabled = false;
            powermod1.Enabled = false;
            Hardplay.Enabled = false;
            powermod1.Enabled = true;
            tresec = false;
            powermod.Enabled = true;
            Supermod = true;
        }
        private void collision()
        {
            if (pacman.Bounds.IntersectsWith(ghost1.Bounds) || pacman.Bounds.IntersectsWith(ghost2.Bounds) || pacman.Bounds.IntersectsWith(ghost3.Bounds) || pacman.Bounds.IntersectsWith(ghost4.Bounds))
            {
                if (pacman.Bounds.IntersectsWith(ghost1.Bounds) && !Supermod1) pacrip();
                if (pacman.Bounds.IntersectsWith(ghost2.Bounds) && !Supermod2) pacrip();
                if (pacman.Bounds.IntersectsWith(ghost3.Bounds) && !Supermod3) pacrip();
                if (pacman.Bounds.IntersectsWith(ghost4.Bounds) && !Supermod4) pacrip();
                if (Supermod)
                {
                    if (pacman.Bounds.IntersectsWith(ghost1.Bounds) && !Supermod1) pacrip();
                    if (pacman.Bounds.IntersectsWith(ghost2.Bounds) && !Supermod2) pacrip();
                    if (pacman.Bounds.IntersectsWith(ghost3.Bounds) && !Supermod3) pacrip();
                    if (pacman.Bounds.IntersectsWith(ghost4.Bounds) && !Supermod4) pacrip();
                }
                if (pacman.Bounds.IntersectsWith(ghost1.Bounds) && ghost1caneat && Supermod1)
                {
                    pointscore += 200;
                    g1rip = true;
                    v1 = true;
                    ghost1caneat = false;
                    timer1.Enabled = false;
                    if(musconoff) eatghostm.Play();
                    point200.Location = new Point(pacman.Left, pacman.Top);
                    point200.Visible = true;
                    Pointer.Enabled = false;
                    Pointer.Enabled = true;
                    ghosteater.Enabled = true;
                    ghost1speed = 4;
                }
                if (pacman.Bounds.IntersectsWith(ghost2.Bounds) && ghost2caneat && Supermod2)
                {
                    pointscore += 200;
                    g2rip = true;
                    v2 = true;
                    ghost2caneat = false;
                    timer1.Enabled = false;
                    if (musconoff) eatghostm.Play();
                    point200.Location = new Point(pacman.Left, pacman.Top);
                    point200.Visible = true;
                    Pointer.Enabled = false;
                    Pointer.Enabled = true;
                    ghosteater.Enabled = true;
                    ghost2speed = 4;
                }
                if (pacman.Bounds.IntersectsWith(ghost3.Bounds) && ghost3caneat && Supermod3)
                {
                    pointscore += 200;
                    g3rip = true;
                    v3 = true;
                    ghost3caneat = false;
                    timer1.Enabled = false;
                    if (musconoff) eatghostm.Play();
                    point200.Location = new Point(pacman.Left, pacman.Top);
                    point200.Visible = true;
                    Pointer.Enabled = false;
                    Pointer.Enabled = true;
                    ghosteater.Enabled = true;
                    ghost3speed = 4;
                }
                if (pacman.Bounds.IntersectsWith(ghost4.Bounds) && ghost4caneat && Supermod4)
                {
                    pointscore += 200;
                    g4rip = true;
                    v4 = true;
                    ghost4caneat = false;
                    timer1.Enabled = false;
                    if (musconoff) eatghostm.Play();
                    point200.Location = new Point(pacman.Left, pacman.Top);
                    point200.Visible = true;
                    Pointer.Enabled = false;
                    Pointer.Enabled = true;
                    ghosteater.Enabled = true;
                    Hardplay.Enabled = false;
                    ghost4speed = 4;
                }
            }
        }

        private void pacrip()
        {
            if (musconoff) dead.Play();
            pacman.Image = Properties.Resources.pacriper;
            if (lifep - 1 <= 0)
            {
                label124.Visible = true;
                CherryTimer.Enabled = false;
                point200.Visible = false;
                point300.Visible = false;
                pictureBox3.Visible = false;
                over();
            }
            else
            {
                top = 0;
                left = 0;
                topghost1 = 0;
                topghost2 = 0;
                topghost3 = 0;
                topghost4 = 0;
                leftghost1 = 0;
                leftghost2 = 0;
                leftghost3 = 0;
                leftghost4 = 0;
                timer1.Enabled = false;
                timer4.Enabled = false;
                timer5.Enabled = false;
                timer6.Enabled = false;
                pacmanturn = false;
                ghost1turn = false;
                ghost2turn = false;
                ghost3turn = false;
                ghost4turn = false;
                timer8.Enabled = true;
            }
        }

        private void over()
        {
            pointscore = 0;
            systemscore = 0;
            lifep = 3;
            timer1.Enabled = false;
            timer2.Enabled = false;
            timer3.Enabled = false;
            timer4.Enabled = false;
            timer5.Enabled = false;
            timer6.Enabled = false;
            powermod1.Enabled = false;
            powermod.Enabled = false;
            timer7.Enabled = true;
        }
        private void a(int left, int top)
        {
            if (pacmanturn)
            {
                switch (left)
                {
                    case 174:
                        if (top == 176) { leftright(1, 1, 0, 0); break; }
                        break;
                    case 24:
                        if (top == 392) { leftright(0, 1, 1, 0); break; }
                        if (top == 356) { leftright(0, 1, 0, 1); break; }
                        if (top == 320) { leftright(0, 1, 1, 0); break; }
                        if (top == 284) { leftright(0, 1, 0, 1); break; }
                        if (top == 140) { leftright(0, 1, 1, 0); break; }
                        if (top == 104) { leftright(0, 1, 1, 1); break; }
                        if (top == 56) { leftright(0, 1, 0, 1); break; }
                        break;
                    case 48:
                        if (top == 356) { leftright(1, 1, 1, 0); break; }
                        if (top == 320) { leftright(1, 0, 0, 1); break; }
                        break;
                    case 84:
                        if (top == 284) { leftright(1, 1, 1, 1); break; }
                        if (top == 356) { leftright(1, 0, 1, 0); break; }
                        if (top == 320) { leftright(0, 1, 1, 1); break; }
                        if (top == 212) { leftright(1, 1, 1, 1); break; }
                        if (top == 140) { leftright(1, 0, 1, 1); break; }
                        if (top == 56) { leftright(1, 1, 0, 1); break; }
                        if (top == 104) { leftright(1, 1, 1, 1); break; }
                        break;
                    case 120:
                        if (top == 320) { leftright(1, 1, 0, 1); break; }
                        if (top == 356) { leftright(0, 1, 1, 0); break; }
                        if (top == 284) { leftright(1, 1, 1, 0); break; }
                        if (top == 248) { leftright(0, 1, 1, 1); break; }
                        if (top == 104) { leftright(1, 1, 0, 1); break; }
                        if (top == 140) { leftright(0, 1, 1, 0); break; }
                        if (top == 176) { leftright(0, 1, 0, 1); break; }
                        if (top == 212) { leftright(1, 0, 1, 1); break; }
                        break;
                    case 156:
                        if (top == 356) { leftright(1, 0, 0, 1); break; }
                        if (top == 392) { leftright(1, 1, 1, 0); break; }
                        if (top == 284) { leftright(1, 0, 0, 1); break; }
                        if (top == 320) { leftright(1, 1, 1, 0); break; }
                        if (top == 104) { leftright(1, 1, 1, 0); break; }
                        if (top == 140) { leftright(1, 0, 0, 1); break; }
                        if (top == 176) { leftright(1, 1, 1, 0); break; }
                        if (top == 56) { leftright(1, 0, 0, 1); break; }
                        break;
                    case 192:
                        if (top == 320) { leftright(1, 1, 1, 0); break; }
                        if (top == 284) { leftright(0, 1, 0, 1); break; }
                        if (top == 392) { leftright(1, 1, 1, 0); break; }
                        if (top == 356) { leftright(0, 1, 0, 1); break; }
                        if (top == 56) { leftright(0, 1, 0, 1); break; }
                        if (top == 104) { leftright(1, 1, 1, 0); break; }
                        if (top == 140) { leftright(0, 1, 0, 1); break; }
                        if (top == 176) { leftright(1, 1, 1, 0); break; }
                        break;
                    case 228:
                        if (top == 284) { leftright(1, 1, 1, 0); break; }
                        if (top == 356) { leftright(1, 0, 1, 0); break; }
                        if (top == 320) { leftright(1, 1, 0, 1); break; }
                        if (top == 248) { leftright(1, 0, 1, 1); break; }
                        if (top == 212) { leftright(0, 1, 1, 1); break; }
                        if (top == 104) { leftright(1, 1, 0, 1); break; }
                        if (top == 140) { leftright(1, 0, 1, 0); break; }
                        if (top == 176) { leftright(1, 0, 0, 1); break; }
                        break;
                    case 264:
                        if (top == 284) { leftright(1, 1, 1, 1); break; }
                        if (top == 320) { leftright(1, 0, 1, 1); break; }
                        if (top == 356) { leftright(0, 1, 1, 0); break; }
                        if (top == 212) { leftright(1, 1, 1, 1); break; }
                        if (top == 140) { leftright(0, 1, 1, 1); break; }
                        if (top == 56) { leftright(1, 1, 0, 1); break; }
                        if (top == 104) { leftright(1, 1, 1, 1); break; }
                        break;
                    case 324:
                        if (top == 284) { leftright(1, 0, 0, 1); break; }
                        if (top == 320) { leftright(1, 0, 1, 0); break; }
                        if (top == 356) { leftright(1, 0, 0, 1); break; }
                        if (top == 392) { leftright(1, 0, 1, 0); break; }
                        if (top == 140) { leftright(1, 0, 1, 0); break; }
                        if (top == 104) { leftright(1, 0, 1, 1); break; }
                        if (top == 56) { leftright(1, 0, 0, 1); break; }
                        break;
                    case 300:
                        if (top == 320) { leftright(0, 1, 0, 1); break; }
                        if (top == 356) { leftright(1, 1, 1, 0); break; }
                        break;
                    case 374:
                        if (top == 212) { transport(0, 1); break; }
                        break;
                    case -26:
                        if (top == 212) { transport(1, 0); break; }
                        break;
                }
            }
            else
            {
                switch (left)
                {
                    case 176:
                        if (top == 178) { leftright(1, 1, 0, 0); break; }
                        break;
                    case 26:
                        if (top == 394) { leftright(0, 1, 1, 0); break; }
                        if (top == 358) { leftright(0, 1, 0, 1); break; }
                        if (top == 322) { leftright(0, 1, 1, 0); break; }
                        if (top == 286) { leftright(0, 1, 0, 1); break; }
                        if (top == 142) { leftright(0, 1, 1, 0); break; }
                        if (top == 106) { leftright(0, 1, 1, 1); break; }
                        if (top == 58) { leftright(0, 1, 0, 1); break; }
                        break;
                    case 50:
                        if (top == 358) { leftright(1, 1, 1, 0); break; }
                        if (top == 322) { leftright(1, 0, 0, 1); break; }
                        break;
                    case 86:
                        if (top == 286) { leftright(1, 1, 1, 1); break; }
                        if (top == 358) { leftright(1, 0, 1, 0); break; }
                        if (top == 322) { leftright(0, 1, 1, 1); break; }
                        if (top == 214) { leftright(1, 1, 1, 1); break; }
                        if (top == 142) { leftright(1, 0, 1, 1); break; }
                        if (top == 58) { leftright(1, 1, 0, 1); break; }
                        if (top == 106) { leftright(1, 1, 1, 1); break; }
                        break;
                    case 122:
                        if (top == 322) { leftright(1, 1, 0, 1); break; }
                        if (top == 358) { leftright(0, 1, 1, 0); break; }
                        if (top == 286) { leftright(1, 1, 1, 0); break; }
                        if (top == 250) { leftright(0, 1, 1, 1); break; }
                        if (top == 106) { leftright(1, 1, 0, 1); break; }
                        if (top == 142) { leftright(0, 1, 1, 0); break; }
                        if (top == 178) { leftright(0, 1, 0, 1); break; }
                        if (top == 214) { leftright(1, 0, 1, 1); break; }
                        break;
                    case 158:
                        if (top == 358) { leftright(1, 0, 0, 1); break; }
                        if (top == 394) { leftright(1, 1, 1, 0); break; }
                        if (top == 286) { leftright(1, 0, 0, 1); break; }
                        if (top == 322) { leftright(1, 1, 1, 0); break; }
                        if (top == 106) { leftright(1, 1, 1, 0); break; }
                        if (top == 142) { leftright(1, 0, 0, 1); break; }
                        if (top == 178) { leftright(1, 1, 1, 0); break; }
                        if (top == 58) { leftright(1, 0, 0, 1); break; }
                        break;
                    case 194:
                        if (top == 322) { leftright(1, 1, 1, 0); break; }
                        if (top == 286) { leftright(0, 1, 0, 1); break; }
                        if (top == 394) { leftright(1, 1, 1, 0); break; }
                        if (top == 358) { leftright(0, 1, 0, 1); break; }
                        if (top == 58) { leftright(0, 1, 0, 1); break; }
                        if (top == 106) { leftright(1, 1, 1, 0); break; }
                        if (top == 142) { leftright(0, 1, 0, 1); break; }
                        if (top == 178) { leftright(1, 1, 1, 0); break; }
                        break;
                    case 230:
                        if (top == 286) { leftright(1, 1, 1, 0); break; }
                        if (top == 358) { leftright(1, 0, 1, 0); break; }
                        if (top == 322) { leftright(1, 1, 0, 1); break; }
                        if (top == 250) { leftright(1, 0, 1, 1); break; }
                        if (top == 214) { leftright(0, 1, 1, 1); break; }
                        if (top == 106) { leftright(1, 1, 0, 1); break; }
                        if (top == 142) { leftright(1, 0, 1, 0); break; }
                        if (top == 178) { leftright(1, 0, 0, 1); break; }
                        break;
                    case 266:
                        if (top == 286) { leftright(1, 1, 1, 1); break; }
                        if (top == 322) { leftright(1, 0, 1, 1); break; }
                        if (top == 358) { leftright(0, 1, 1, 0); break; }
                        if (top == 214) { leftright(1, 1, 1, 1); break; }
                        if (top == 142) { leftright(0, 1, 1, 1); break; }
                        if (top == 58) { leftright(1, 1, 0, 1); break; }
                        if (top == 106) { leftright(1, 1, 1, 1); break; }
                        break;
                    case 326:
                        if (top == 286) { leftright(1, 0, 0, 1); break; }
                        if (top == 322) { leftright(1, 0, 1, 0); break; }
                        if (top == 358) { leftright(1, 0, 0, 1); break; }
                        if (top == 394) { leftright(1, 0, 1, 0); break; }
                        if (top == 142) { leftright(1, 0, 1, 0); break; }
                        if (top == 106) { leftright(1, 0, 1, 1); break; }
                        if (top == 58) { leftright(1, 0, 0, 1); break; }
                        break;
                    case 302:
                        if (top == 322) { leftright(0, 1, 0, 1); break; }
                        if (top == 358) { leftright(1, 1, 1, 0); break; }
                        break;
                    case 376:
                        if (top == 214) { transport(0, 1); break; }
                        break;
                    case -28:
                        if (top == 214) { transport(1, 0); break; }
                        break;
                }
            }
            pacmanturn = false;
            ghost1turn = false;
            ghost2turn = false;
            ghost3turn = false;
            ghost4turn = false;
        }

        private void transport(int i, int n)
        {
            if (pacmanturn)
            {
                if (i == 0) pacman.Left = -26;
                if (n == 0) pacman.Left = 374;
            }
            if (ghost1turn)
            {
                if (i == 0) ghost1.Left = -26;
                if (n == 0) ghost1.Left = 374;
            }
            if (ghost2turn)
            {
                if (i == 0) ghost2.Left = -26;
                if (n == 0) ghost2.Left = 374;
            }
            if (ghost3turn)
            {
                if (i == 0) ghost3.Left = -26;
                if (n == 0) ghost3.Left = 374;
            }
            if (ghost4turn)
            {
                if (i == 0) ghost4.Left = -26;
                if (n == 0) ghost4.Left = 374;
            }
        }

        private void leftright(int i, int y, int n, int m)
        {
            if (ghost1turn)
            {
                if (Supermod1 && !ghost1caneat)
                {
                    if (ghost1.Left < 180 && ghost1.Top == 178 || ghost1.Left > 170 && ghost1.Top == 178) { ghost1speed = 2; Supermod1 = false; v1 = false; ghost1caneat = true; g1rip = false; }
                    else
                    {
                        if (ghost1.Top < 178) { if (n == 1 && m == 1) n = 0; }
                        if (ghost1.Top > 178) { if (n == 1 && m == 1) m = 0; }
                        if (ghost1.Left < 176) { if (i == 1 && y == 1) i = 0; }
                        if (ghost1.Left > 176) { if (i == 1 && y == 1) y = 0; }
                    }
                }
                topghost1 = 0;
                leftghost1 = 0;
                while (!dir1)
                {
                    random1 = rand.Next(1, 5);
                    if (random1 == 1 && !dir1 && random1 != prec1) if (i == 1) { leftghost1 = -ghost1speed; dir1 = true; if (!Supermod1 && ghost1caneat) ghost1.Image = Properties.Resources.rleft; else if (!tresec || g1rip) { if (!tresec) ghost1.Image = Properties.Resources.ghosteater; if (g1rip) ghost1.Image = Properties.Resources.duleft; } else ghost1.Image = Properties.Resources.tempo; }
                    if (random1 == 2 && !dir1 && random1 != prec1) if (y == 1) { leftghost1 = ghost1speed; dir1 = true; if (!Supermod1 && ghost1caneat) ghost1.Image = Properties.Resources.rright; else if (!tresec || g1rip) { if (!tresec) ghost1.Image = Properties.Resources.ghosteater; if (g1rip) ghost1.Image = Properties.Resources.duright; } else ghost1.Image = Properties.Resources.tempo; }
                    if (random1 == 3 && !dir1 && random1 != prec1) if (m == 1) { topghost1 = ghost1speed; dir1 = true; if (!Supermod1 && ghost1caneat) ghost1.Image = Properties.Resources.rdown; else if (!tresec || g1rip) { if (!tresec) ghost1.Image = Properties.Resources.ghosteater; if (g1rip) ghost1.Image = Properties.Resources.dudown; } else ghost1.Image = Properties.Resources.tempo; }
                    if (random1 == 4 && !dir1 && random1 != prec1) if (n == 1) { topghost1 = -ghost1speed; dir1 = true; if (!Supermod1 && ghost1caneat) ghost1.Image = Properties.Resources.rup; else if (!tresec || g1rip) { if (!tresec) ghost1.Image = Properties.Resources.ghosteater; if (g1rip) ghost1.Image = Properties.Resources.duup; } else ghost1.Image = Properties.Resources.tempo; }
                }
                if (random1 == 1) prec1 = 2;
                if (random1 == 2) prec1 = 1;
                if (random1 == 3) prec1 = 4;
                if (random1 == 4) prec1 = 3;
                dir1 = false;
            }

            if (ghost2turn)
            {
                if (Supermod2 && !ghost2caneat)
                {
                    if (ghost2.Left < 180 && ghost2.Top == 178 || ghost2.Left > 170 && ghost2.Top == 178) { ghost2speed = 2; Supermod2 = false; v2 = false; ghost2caneat = true; g2rip = false; }
                    else
                    {
                        if (ghost2.Top < 178) { if (n == 1 && m == 1) n = 0; }
                        if (ghost2.Top > 178) { if (n == 1 && m == 1) m = 0; }
                        if (ghost2.Left < 176) { if (i == 1 && y == 1) i = 0; }
                        if (ghost2.Left > 176) { if (i == 1 && y == 1) y = 0; }
                    }
                }
                topghost2 = 0;
                leftghost2 = 0;
                while (!dir2)
                {
                    random2 = rand.Next(1, 5);
                    if (random2 == 1 && !dir2 && random2 != prec2) if (i == 1) { leftghost2 = -ghost2speed; dir2 = true; if (!Supermod2 && ghost2caneat) ghost2.Image = Properties.Resources.bleft; else if (!tresec || g2rip) { if (!tresec) ghost2.Image = Properties.Resources.ghosteater; if (g2rip) ghost2.Image = Properties.Resources.duleft; } else ghost2.Image = Properties.Resources.tempo; }
                    if (random2 == 2 && !dir2 && random2 != prec2) if (y == 1) { leftghost2 = ghost2speed; dir2 = true; if (!Supermod2 && ghost2caneat) ghost2.Image = Properties.Resources.bright; else if (!tresec || g2rip) { if (!tresec) ghost2.Image = Properties.Resources.ghosteater; if (g2rip) ghost2.Image = Properties.Resources.duright; } else ghost2.Image = Properties.Resources.tempo; }
                    if (random2 == 3 && !dir2 && random2 != prec2) if (m == 1) { topghost2 = ghost2speed; dir2 = true; if (!Supermod2 && ghost2caneat) ghost2.Image = Properties.Resources.bdown; else if (!tresec || g2rip) { if (!tresec) ghost2.Image = Properties.Resources.ghosteater; if (g2rip) ghost2.Image = Properties.Resources.dudown; } else ghost2.Image = Properties.Resources.tempo; }
                    if (random2 == 4 && !dir2 && random2 != prec2) if (n == 1) { topghost2 = -ghost2speed; dir2 = true; if (!Supermod2 && ghost2caneat) ghost2.Image = Properties.Resources.bup; else if (!tresec || g2rip) { if (!tresec) ghost2.Image = Properties.Resources.ghosteater; if (g2rip) ghost2.Image = Properties.Resources.duup; } else ghost2.Image = Properties.Resources.tempo; }
                }
                if (random2 == 1) prec2 = 2;
                if (random2 == 2) prec2 = 1;
                if (random2 == 3) prec2 = 4;
                if (random2 == 4) prec2 = 3;
                dir2 = false;
            }

            if (ghost3turn)
            {
                if (Supermod3 && !ghost3caneat)
                {
                    if (ghost3.Left < 180 && ghost3.Top == 178 || ghost3.Left > 170 && ghost3.Top == 178) { ghost3speed = 2; Supermod3 = false; v3 = false; ghost3caneat = true; g3rip = false; }
                    else
                    {
                        if (ghost3.Top > 178) { if (n == 1 && m == 1) m = 0; }
                        if (ghost3.Top < 178) { if (n == 1 && m == 1) n = 0; }
                        if (ghost3.Left < 176) { if (i == 1 && y == 1) i = 0; }
                        if (ghost3.Left > 176) { if (i == 1 && y == 1) y = 0; }
                    }
                }
                topghost3 = 0;
                leftghost3 = 0;
                while (!dir3)
                {
                    random3 = rand.Next(1, 5);
                    if (random3 == 1 && !dir3 && random3 != prec3) if (i == 1) { leftghost3 = -ghost3speed; dir3 = true; if (!Supermod3 && ghost3caneat) ghost3.Image = Properties.Resources.pleft; else if (!tresec || g3rip) { if (!tresec) ghost3.Image = Properties.Resources.ghosteater; if (g3rip) ghost3.Image = Properties.Resources.duleft; } else ghost3.Image = Properties.Resources.tempo; }
                    if (random3 == 2 && !dir3 && random3 != prec3) if (y == 1) { leftghost3 = ghost3speed; dir3 = true; if (!Supermod3 && ghost3caneat) ghost3.Image = Properties.Resources.pright; else if (!tresec || g3rip) { if (!tresec) ghost3.Image = Properties.Resources.ghosteater; if (g3rip) ghost3.Image = Properties.Resources.duright; } else ghost3.Image = Properties.Resources.tempo; }
                    if (random3 == 3 && !dir3 && random3 != prec3) if (m == 1) { topghost3 = ghost3speed; dir3 = true; if (!Supermod3 && ghost3caneat) ghost3.Image = Properties.Resources.pdown; else if (!tresec || g3rip) { if (!tresec) ghost3.Image = Properties.Resources.ghosteater; if (g3rip) ghost3.Image = Properties.Resources.dudown; } else ghost3.Image = Properties.Resources.tempo; }
                    if (random3 == 4 && !dir3 && random3 != prec3) if (n == 1) { topghost3 = -ghost3speed; dir3 = true; if (!Supermod3 && ghost3caneat) ghost3.Image = Properties.Resources.pup; else if (!tresec || g3rip) { if (!tresec) ghost3.Image = Properties.Resources.ghosteater; if (g3rip) ghost3.Image = Properties.Resources.duup; } else ghost3.Image = Properties.Resources.tempo; }
                }
                if (random3 == 1) prec3 = 2;
                if (random3 == 2) prec3 = 1;
                if (random3 == 3) prec3 = 4;
                if (random3 == 4) prec3 = 3;
                dir3 = false;
            }

            if (ghost4turn)
            {
                if (Supermod4 && !ghost4caneat)
                {
                    if (ghost4.Left < 180 && ghost4.Top == 178 || ghost4.Left > 170 && ghost4.Top == 178) { ghost4speed = 2; Supermod4 = false; v4 = false; ghost4caneat = true; g4rip = false; }
                    else
                    {
                        if (ghost4.Top > 178) { if (n == 1 && m == 1) m = 0; }
                        if (ghost4.Top < 178) { if (n == 1 && m == 1) n = 0; }
                        if (ghost4.Left < 176) { if (i == 1 && y == 1) i = 0; }
                        if (ghost4.Left > 176) { if (i == 1 && y == 1) y = 0; }
                    }
                }
                topghost4 = 0;
                leftghost4 = 0;
                while (!dir4)
                {
                    random4 = rand.Next(1, 5);
                    if (random4 == 1 && !dir4 && random4 != prec4) if (i == 1) { leftghost4 = -ghost4speed; dir4 = true; if (!Supermod4 && ghost4caneat) ghost4.Image = Properties.Resources.oleft; else if (!tresec || g4rip) { if (!tresec) ghost4.Image = Properties.Resources.ghosteater; if (g4rip) ghost4.Image = Properties.Resources.duleft; } else ghost4.Image = Properties.Resources.tempo; }
                    if (random4 == 2 && !dir4 && random4 != prec4) if (y == 1) { leftghost4 = ghost4speed; dir4 = true; if (!Supermod4 && ghost4caneat) ghost4.Image = Properties.Resources.oright; else if (!tresec || g4rip) { if (!tresec) ghost4.Image = Properties.Resources.ghosteater; if (g4rip) ghost4.Image = Properties.Resources.duright; } else ghost4.Image = Properties.Resources.tempo; }
                    if (random4 == 3 && !dir4 && random4 != prec4) if (m == 1) { topghost4 = ghost4speed; dir4 = true; if (!Supermod4 && ghost4caneat) ghost4.Image = Properties.Resources.odown; else if (!tresec || g4rip) { if (!tresec) ghost4.Image = Properties.Resources.ghosteater; if (g4rip) ghost4.Image = Properties.Resources.dudown; } else ghost4.Image = Properties.Resources.tempo; }
                    if (random4 == 4 && !dir4 && random4 != prec4) if (n == 1) { topghost4 = -ghost4speed; dir4 = true; if (!Supermod4 && ghost4caneat) ghost4.Image = Properties.Resources.oup; else if (!tresec || g4rip) { if (!tresec) ghost4.Image = Properties.Resources.ghosteater; if (g4rip) ghost4.Image = Properties.Resources.duup; } else ghost4.Image = Properties.Resources.tempo; }
                }
                if (random4 == 1) prec4 = 2;
                if (random4 == 2) prec4 = 1;
                if (random4 == 3) prec4 = 4;
                if (random4 == 4) prec4 = 3;
                dir4 = false;
            }

            if (pacmanturn)
            {
                top = 0;
                left = 0;
                if (temp == 1 && i == 1 || temp == 2 && y == 1 || temp == 3 && n == 1 || temp == 4 && m == 1)
                {
                    next = temp;
                }
                if (next == 1 && i == 1)
                {
                    left = -2;
                    pacman.Image = Properties.Resources.pacleft;
                    direzione = next;
                }
                if (next == 2 && y == 1)
                {
                    left = 2;
                    pacman.Image = Properties.Resources.pacright;
                    direzione = next;
                }
                if (next == 3 && n == 1)
                {
                    top = -2;
                    pacman.Image = Properties.Resources.pacup;
                    direzione = next;
                }
                if (next == 4 && m == 1)
                {
                    top = 2;
                    pacman.Image = Properties.Resources.pacdown;
                    direzione = next;
                }
                if (top == 0 && left == 0)
                {
                    temp = next;
                    next = direzione;
                    if (next == 1) pacman.Image = Properties.Resources._1sx;
                    if (next == 2) pacman.Image = Properties.Resources._1dx;
                    if (next == 3) pacman.Image = Properties.Resources._1up;
                    if (next == 4) pacman.Image = Properties.Resources._1down;
                }
            }
        }
    }
}
