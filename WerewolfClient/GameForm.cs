using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EventEnum = WerewolfClient.WerewolfModel.EventEnum;
using CommandEnum = WerewolfClient.WerewolfCommand.CommandEnum;
using WerewolfAPI.Model;
using Role = WerewolfAPI.Model.Role;
namespace WerewolfClient
{
    public partial class GameForm : Form , View
    {
        private Timer _updateTimer;
        private WerewolfController controller;
        private Game.PeriodEnum _currentPeriod;
        private int _currentDay;
        private int _currentTime;
        private bool _voteActivated;
        private bool _actionActivated;
        private string _myRole;
        private int card_count = 0;
        private static bool firstshot = false;
        private bool _isDead;
        private List<Player> players = null;
        private int BG_count = 0;
        private Image[] card_img = new Image[16];
        private string[] BG_Arr = { "#020304", "#020304", "#020304", "#020304", "#020304", "#020304", "#070b12", "#0d1420", "#131d2e", "#18263c", "#1e2f4a",
                                    "#233858", "#294066", "#2f4974", "#345282", "#3a5b90", "#40649e", "#456dac", "#4d76b7", "#5b81bd", "#698cc3",
                                    "#7796c8", "#85a1ce", "#93acd4", "#a1b7d9", "#afc2df", "#bdcce5", "#cbd7ea", "#d9e2f0", "#e7edf5", "#f5f7fb",
                                    "#f5f7fb", "#f5f7fb", "#f5f7fb", "#f5f7fb", "#f5f7fb" };
                                      
        public GameForm()
        {
             
            InitializeComponent();

            card_img[0] = Properties.Resources.card_01;
            card_img[1] = Properties.Resources.card_02;
            card_img[2] = Properties.Resources.card_03;
            card_img[3] = Properties.Resources.card_04;
            card_img[4] = Properties.Resources.card_05;
            card_img[5] = Properties.Resources.card_06;
            card_img[6] = Properties.Resources.card_07;
            card_img[7] = Properties.Resources.card_08;
            card_img[8] = Properties.Resources.card_09;
            card_img[9] = Properties.Resources.card_010;
            card_img[10] = Properties.Resources.card_011;
            card_img[11] = Properties.Resources.card_012;
            card_img[12] = Properties.Resources.card_013;
            card_img[13] = Properties.Resources.card_014;
            card_img[14] = Properties.Resources.card_015;
            card_img[15] = Properties.Resources.card_016;

            Card_box.Image = card_img[0];          
            Card_box.Width = card_img[0].Width;
            Card_box.Height = card_img[0].Height;
            Card_box.BackColor = Color.Transparent;
            foreach (int i in Enumerable.Range(0, 16))
            {                
                this.Controls["panel1"].Controls["BtnPlayer" + i].Click += new System.EventHandler(this.BtnPlayerX_Click);
                this.Controls["panel1"].Controls["BtnPlayer" + i].Tag = i;
            }
            
            _updateTimer = new Timer();
            _voteActivated = false;
            _actionActivated = false;
            EnableButton(BtnJoin, true);
            EnableButton(BtnAction, false);
            EnableButton(BtnVote, false);
            EnableButton(BtnLeave, false);
            EnableButton(BtnSignOut, false);
            BtnBack.Visible = false;
            
            _myRole = null;
            _isDead = false;
            StartSetup();
            this.DoubleBuffered = true;
            foreach (Control control in this.Controls)
            {
                control.EnableDoubleBuferring();
            }
        }


        public void EnableButton(Button btn, bool state)
        {
            btn.Visible = btn.Enabled = state;
        }
        public void StartSetup()
        {
            panel1.BackColor = Color.Transparent;
            panel1.ForeColor = System.Drawing.Color.White;
            BtnJoin.Image = Properties.Resources.button_resize;
            BtnJoin.Width = Properties.Resources.button_resize.Width;
            BtnJoin.Height = Properties.Resources.button_resize.Height;
            BtnJoin.BackColor = Color.Transparent;
            BtnJoin.FlatStyle = FlatStyle.Flat;
            BtnJoin.FlatAppearance.BorderSize = 0;
            BtnJoin.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BtnJoin.FlatAppearance.MouseOverBackColor = Color.Transparent;
            BtnJoin.Text = "Join Game";
            BtnViewRole.Image = Properties.Resources.button_resize;
            BtnViewRole.Width = Properties.Resources.button_resize.Width;
            BtnViewRole.Height = Properties.Resources.button_resize.Height;
            BtnViewRole.BackColor = Color.Transparent;
            BtnViewRole.FlatStyle = FlatStyle.Flat;
            BtnViewRole.FlatAppearance.BorderSize = 0;
            BtnViewRole.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BtnViewRole.FlatAppearance.MouseOverBackColor = Color.Transparent;
            BtnViewRole.Text = "Roles";
            Sun_moon.Image = Properties.Resources.BG_the_moon_resize;
            Sun_moon.Width = Properties.Resources.BG_the_moon_resize.Width;
            Sun_moon.Height = Properties.Resources.BG_the_moon_resize.Height;
            Sun_moon.BackColor = Color.Transparent;
            Sun_moon.ForeColor = System.Drawing.Color.White;
            Sun_moon.Text = "";
            BtnRight.Image = Properties.Resources.Arrow_resize;
            BtnRight.Width  = Properties.Resources.Arrow_resize.Width;
            BtnRight.Height = Properties.Resources.Arrow_resize.Height;
            BtnRight.BackColor = Color.Transparent;
            BtnRight.FlatStyle = FlatStyle.Flat;
            BtnRight.FlatAppearance.BorderSize = 0;
            BtnRight.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BtnRight.FlatAppearance.MouseOverBackColor = Color.Transparent;
            BtnLeft.Image = Properties.Resources.Arrow_L_resize;
            BtnLeft.Width = Properties.Resources.Arrow_L_resize.Width;
            BtnLeft.Height = Properties.Resources.Arrow_L_resize.Height;
            BtnLeft.BackColor = Color.Transparent;
            BtnLeft.FlatStyle = FlatStyle.Flat;
            BtnLeft.FlatAppearance.BorderSize = 0;
            BtnLeft.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BtnLeft.FlatAppearance.MouseOverBackColor = Color.Transparent;
            BtnBack.Image = Properties.Resources.button_resize;
            BtnBack.Width = Properties.Resources.button_resize.Width;
            BtnBack.Height = Properties.Resources.button_resize.Height;
            BtnBack.BackColor = Color.Transparent;
            BtnBack.FlatStyle = FlatStyle.Flat;
            BtnBack.FlatAppearance.BorderSize = 0;
            BtnBack.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BtnBack.FlatAppearance.MouseOverBackColor = Color.Transparent;

            BtnVote.BackColor = Color.Transparent;
            BtnVote.FlatStyle = FlatStyle.Flat;
            BtnVote.FlatAppearance.BorderSize = 0;
            BtnVote.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BtnVote.FlatAppearance.MouseOverBackColor = Color.Transparent;
            BtnLeave.BackColor = Color.Transparent;
            BtnLeave.FlatStyle = FlatStyle.Flat;
            BtnLeave.FlatAppearance.BorderSize = 0;
            BtnLeave.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BtnLeave.FlatAppearance.MouseOverBackColor = Color.Transparent;
            BtnAction.BackColor = Color.Transparent;
            BtnAction.FlatStyle = FlatStyle.Flat;
            BtnAction.FlatAppearance.BorderSize = 0;
            BtnAction.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BtnAction.FlatAppearance.MouseOverBackColor = Color.Transparent;
            BtnSignOut.BackColor = Color.Transparent;
            BtnSignOut.FlatStyle = FlatStyle.Flat;
            BtnSignOut.FlatAppearance.BorderSize = 0;
            BtnSignOut.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BtnSignOut.FlatAppearance.MouseOverBackColor = Color.Transparent;
            foreach (int i in Enumerable.Range(0, 16))
            {
                ButtonXSetup((Button)Controls["panel1"].Controls["BtnPlayer" + i], i);
                ButtonVisible((Button)Controls["panel1"].Controls["BtnPlayer" + i], false);
            }

            this.SystemOutBox.Visible = false;
            this.TbChatBox.Visible = false;
            this.TbChatInput.Visible = false;
            this.LBDay.Visible = false;
            this.LBPeriod.Visible = false;
            this.LBTime.Visible = false;
            this.label1.Visible = false;
            this.label2.Visible = false;

            Card_box.Visible = false;
            BtnRight.Visible = false;
            BtnLeft.Visible = false;

            panel1.BackgroundImage = Properties.Resources.BG_new_village;
            panel1.BackColor = Color.Transparent;

        }

        public void ButtonXSetup(Button btn, int i)
        {
            if(i < 8)
            {
                btn.Image = Properties.Resources.char_someone_resize;
                btn.Width = Properties.Resources.char_someone_resize.Width;
                btn.Height = Properties.Resources.char_someone_resize.Height + 20;
            }
            else
            {
                btn.Image = Properties.Resources.char_someone_resize2;
                btn.Width = Properties.Resources.char_someone_resize2.Width;
                btn.Height = Properties.Resources.char_someone_resize2.Height + 20;
            }

            btn.BackColor = Color.Transparent;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn.ForeColor = System.Drawing.Color.Black;
            btn.Text = "";
        }

        public void ButtonVisible(Button btn, bool state)
        {
            btn.Visible = state;
        }

        private void OnTimerEvent(object sender, EventArgs e)
        {
            WerewolfCommand wcmd = new WerewolfCommand();
            wcmd.Action = CommandEnum.RequestUpdate;
            controller.ActionPerformed(wcmd);
        }
        private void UpdateAvatar(WerewolfModel wm)
        {
            bool isGunner = false;
            int i = 0;
            foreach (Player player in wm.Players)
            {
                string role = null;
                Controls["panel1"].Controls["BtnPlayer" + i].Text = player.Name;
                if (player.Name == wm.Player.Name || player.Status != Player.StatusEnum.Alive)
                {
                    // FIXME, need to optimize this
                    Image img = Properties.Resources.char_villager_resize;
                    
                    if (player.Name == wm.Player.Name)
                    {
                        role = _myRole;
                    }
                    else if (player.Role != null)
                    {
                        role = player.Role.Name;
                    }
                    else
                    {                        
                        goto endloop;
                    }
                    if (i >= 8)
                    {
                        switch (role)
                        {
                            case WerewolfModel.ROLE_SEER:
                                img = Properties.Resources.char_seer_resize2;
                                break;
                            case WerewolfModel.ROLE_AURA_SEER:
                                img = Properties.Resources.char_auraseer_resize2;
                                break;
                            case WerewolfModel.ROLE_PRIEST:
                                img = Properties.Resources.char_priest_resize2;
                                break;
                            case WerewolfModel.ROLE_DOCTOR:
                                img = Properties.Resources.char_doctor_resize2;
                                break;
                            case WerewolfModel.ROLE_WEREWOLF:
                                img = Properties.Resources.char_wolf_resize2;
                                break;
                            case WerewolfModel.ROLE_WEREWOLF_SEER:
                                img = Properties.Resources.char_wolfseer_resize2;
                                break;
                            case WerewolfModel.ROLE_ALPHA_WEREWOLF:
                                img = Properties.Resources.char_alphawolf_resize2;
                                break;
                            case WerewolfModel.ROLE_WEREWOLF_SHAMAN:
                                img = Properties.Resources.char_wolf_shaman_resize2;
                                break;
                            case WerewolfModel.ROLE_MEDIUM:
                                img = Properties.Resources.char_medium_resize2;
                                break;
                            case WerewolfModel.ROLE_BODYGUARD:
                                img = Properties.Resources.char_Bodyguard_resize2;
                                break;
                            case WerewolfModel.ROLE_JAILER:
                                img = Properties.Resources.char_jailer_resize2;
                                break;
                            case WerewolfModel.ROLE_FOOL:
                                img = Properties.Resources.char_fool_resize2;
                                break;
                            case WerewolfModel.ROLE_HEAD_HUNTER:
                                img = Properties.Resources.char_Head_Hunter_resize2;
                                break;
                            case WerewolfModel.ROLE_SERIAL_KILLER:
                                img = Properties.Resources.char_killer_resize2;
                                break;
                            case WerewolfModel.ROLE_GUNNER:
                                img = Properties.Resources.char_gunner_resize2;
                                break;
                        }
                    }
                    else
                    {
                        switch (role)
                        {
                            case WerewolfModel.ROLE_SEER:
                                img = Properties.Resources.char_seer_resize;
                                break;
                            case WerewolfModel.ROLE_AURA_SEER:
                                img = Properties.Resources.char_auraseer_resize;
                                break;
                            case WerewolfModel.ROLE_PRIEST:
                                img = Properties.Resources.char_priest_resize;
                                break;
                            case WerewolfModel.ROLE_DOCTOR:
                                img = Properties.Resources.char_doctor_resize;
                                break;
                            case WerewolfModel.ROLE_WEREWOLF:
                                img = Properties.Resources.char_wolf_resize;
                                break;
                            case WerewolfModel.ROLE_WEREWOLF_SEER:
                                img = Properties.Resources.char_wolfseer_resize;
                                break;
                            case WerewolfModel.ROLE_ALPHA_WEREWOLF:
                                img = Properties.Resources.char_alphawolf_resize;
                                break;
                            case WerewolfModel.ROLE_WEREWOLF_SHAMAN:
                                img = Properties.Resources.char_wolf_shaman_resize;
                                break;
                            case WerewolfModel.ROLE_MEDIUM:
                                img = Properties.Resources.char_medium_resize;
                                break;
                            case WerewolfModel.ROLE_BODYGUARD:
                                img = Properties.Resources.char_Bodyguard_resize;
                                break;
                            case WerewolfModel.ROLE_JAILER:
                                img = Properties.Resources.char_jailer_resize;
                                break;
                            case WerewolfModel.ROLE_FOOL:
                                img = Properties.Resources.char_fool_resize;
                                break;
                            case WerewolfModel.ROLE_HEAD_HUNTER:
                                img = Properties.Resources.char_Head_Hunter_resize;
                                break;
                            case WerewolfModel.ROLE_SERIAL_KILLER:
                                img = Properties.Resources.char_killer_resize;
                                break;
                            case WerewolfModel.ROLE_GUNNER:
                                isGunner = true;
                                img = Properties.Resources.char_gunner_resize;
                                break;
                        }
                    }
                    ((Button)Controls["panel1"].Controls["BtnPlayer" + i]).Image = img;
                }
                else if(player.Name != wm.Player.Name)
                {
                    Image img = Properties.Resources.char_villager_resize;
                    ((Button)Controls["panel1"].Controls["BtnPlayer" + i]).Image = img;
                }
                endloop:
                if(player.Status == Player.StatusEnum.Shotdead)
                {
                    Image img = Properties.Resources.RIPstone_resize;
                    ((Button)Controls["panel1"].Controls["BtnPlayer" + i]).Image = img;
                    ((Button)Controls["panel1"].Controls["BtnPlayer" + i]).Width = img.Width;
                    ((Button)Controls["panel1"].Controls["BtnPlayer" + i]).Height = img.Height;
                }
                else if (player.Status == Player.StatusEnum.Killdead)
                {
                    Image img = Properties.Resources.RIPstone_resize;
                    ((Button)Controls["panel1"].Controls["BtnPlayer" + i]).Image = img;
                    ((Button)Controls["panel1"].Controls["BtnPlayer" + i]).Width = img.Width;
                    ((Button)Controls["panel1"].Controls["BtnPlayer" + i]).Height = img.Height;
                }
                else if (player.Status == Player.StatusEnum.Holydead)
                {
                    Image img = Properties.Resources.RIPstone_resize;
                    ((Button)Controls["panel1"].Controls["BtnPlayer" + i]).Image = img;
                    ((Button)Controls["panel1"].Controls["BtnPlayer" + i]).Width = img.Width;
                    ((Button)Controls["panel1"].Controls["BtnPlayer" + i]).Height = img.Height;
                }
                else if (player.Status == Player.StatusEnum.Votedead)
                {
                    Image img = Properties.Resources.RIPstone_resize;
                    ((Button)Controls["panel1"].Controls["BtnPlayer" + i]).Image = img;
                    ((Button)Controls["panel1"].Controls["BtnPlayer" + i]).Width = img.Width;
                    ((Button)Controls["panel1"].Controls["BtnPlayer" + i]).Height = img.Height;
                }
                else if (player.Status == Player.StatusEnum.Jaildead)
                {
                    Image img = Properties.Resources.RIPstone_resize;
                    ((Button)Controls["panel1"].Controls["BtnPlayer" + i]).Image = img;
                    ((Button)Controls["panel1"].Controls["BtnPlayer" + i]).Width = img.Width;
                    ((Button)Controls["panel1"].Controls["BtnPlayer" + i]).Height = img.Height;
                }
                i++;
            }
            

        }


        public void Notify(Model m)
        {
            if (m is WerewolfModel)
            {
                WerewolfModel wm = (WerewolfModel)m;
                switch (wm.Event)
                {
                    case EventEnum.SignOut:
                        foreach (int i in Enumerable.Range(0, 16))
                        {

                            this.Controls["panel1"].Controls["BtnPlayer" + i].Click += new System.EventHandler(this.BtnPlayerX_Click);
                            this.Controls["panel1"].Controls["BtnPlayer" + i].Tag = i;
                        }

                        this.SystemOutBox.Visible = false;
                        this.TbChatBox.Visible = false;
                        this.TbChatInput.Visible = false;
                        this.LBDay.Visible = false;
                        this.LBPeriod.Visible = false;
                        this.LBTime.Visible = false;
                        this.label1.Visible = false;
                        this.label2.Visible = false;

                        _updateTimer = new Timer();
                        _voteActivated = false;
                        _actionActivated = false;
                        _myRole = null;
                        _isDead = false;

                        StartSetup();

                        EnableButton(BtnJoin, true);
                        EnableButton(BtnViewRole, true);
                        EnableButton(BtnAction, false);
                        EnableButton(BtnVote, false);
                        EnableButton(BtnLeave, false);
                        EnableButton(BtnSignOut, false);

                        SystemOutBox.Text = "";
                        
                        this.Visible = false;


                        break;
                    case EventEnum.LeaveGame:
                        foreach (int i in Enumerable.Range(0, 16))
                        {

                            this.Controls["panel1"].Controls["BtnPlayer" + i].Click += new System.EventHandler(this.BtnPlayerX_Click);
                            this.Controls["panel1"].Controls["BtnPlayer" + i].Tag = i;
                        }

                        this.SystemOutBox.Visible = false;
                        this.TbChatBox.Visible = false;
                        this.TbChatInput.Visible = false;
                        this.LBDay.Visible = false;
                        this.LBPeriod.Visible = false;
                        this.LBTime.Visible = false;
                        this.label1.Visible = false;
                        this.label2.Visible = false;

                        _updateTimer = new Timer();
                        _voteActivated = false;
                        _actionActivated = false;
                        _myRole = null;
                        _isDead = false;
                        StartSetup();
                        EnableButton(BtnJoin, true);
                        EnableButton(BtnViewRole, true);
                        EnableButton(BtnAction, false);
                        EnableButton(BtnVote, false);
                        EnableButton(BtnLeave, false);
                        EnableButton(BtnSignOut, false);
                        SystemOutBox.Text = "";
                        break;

                    case EventEnum.JoinGame:
                        if (wm.EventPayloads["Success"] == WerewolfModel.TRUE)
                        {
                            BtnJoin.Visible = false;
                            //AddChatMessage("You're joining the game #" + wm.EventPayloads["Game.Id"] + ", please wait for game start.");
                            AddSystemMessage("You're joining the game #" + wm.EventPayloads["Game.Id"] + ", please wait for game start.");
                            _updateTimer.Interval = 1000;
                            _updateTimer.Tick += new EventHandler(OnTimerEvent);
                            _updateTimer.Enabled = true;

                            foreach (int i in Enumerable.Range(0, 16))
                            {
                                ButtonVisible((Button)Controls["panel1"].Controls["BtnPlayer" + i], true);
                            }

                            this.SystemOutBox.Visible = true;
                            this.TbChatBox.Visible = true;
                            this.TbChatInput.Visible = true;
                            this.LBDay.Visible = true;
                            this.LBPeriod.Visible = true;
                            this.LBTime.Visible = true;
                            this.label1.Visible = true;
                            this.label2.Visible = true;
                            EnableButton(BtnLeave, true);
                            EnableButton(BtnSignOut, true);
                            EnableButton(BtnViewRole, false);

                        }
                        else
                        {
                            MessageBox.Show("You can't join the game, please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        break;
                    case EventEnum.GameStopped:
                        //AddChatMessage("Game is finished, outcome is " + wm.EventPayloads["Game.Outcome"]);
                        AddSystemMessage("Game is finished, outcome is " + wm.EventPayloads["Game.Outcome"]);
                        _updateTimer.Enabled = false;
                        break;
                    case EventEnum.GameStarted:
                        players = wm.Players;
                        _myRole = wm.EventPayloads["Player.Role.Name"];
                        //AddChatMessage("Your role is " + _myRole + ".");
                        AddSystemMessage("Your role is " + _myRole + ".");
                        _currentPeriod = Game.PeriodEnum.Night;
                        EnableButton(BtnAction, true);
                        switch (_myRole)
                        {
                            case WerewolfModel.ROLE_PRIEST:
                                BtnAction.Text = WerewolfModel.ACTION_HOLYWATER;
                                break;
                            case WerewolfModel.ROLE_GUNNER:
                                BtnAction.Text = WerewolfModel.ACTION_SHOOT;
                                break;
                            case WerewolfModel.ROLE_JAILER:
                                BtnAction.Text = WerewolfModel.ACTION_JAIL;
                                break;
                            case WerewolfModel.ROLE_WEREWOLF_SHAMAN:
                                BtnAction.Text = WerewolfModel.ACTION_ENCHANT;
                                break;
                            case WerewolfModel.ROLE_BODYGUARD:
                                BtnAction.Text = WerewolfModel.ACTION_GUARD;
                                break;
                            case WerewolfModel.ROLE_DOCTOR:
                                BtnAction.Text = WerewolfModel.ACTION_HEAL;
                                break;
                            case WerewolfModel.ROLE_SERIAL_KILLER:
                                BtnAction.Text = WerewolfModel.ACTION_KILL;
                                break;
                            case WerewolfModel.ROLE_SEER:
                            case WerewolfModel.ROLE_WEREWOLF_SEER:
                                BtnAction.Text = WerewolfModel.ACTION_REVEAL;
                                break;
                            case WerewolfModel.ROLE_AURA_SEER:
                                BtnAction.Text = WerewolfModel.ACTION_AURA;
                                break;
                            case WerewolfModel.ROLE_MEDIUM:
                                BtnAction.Text = WerewolfModel.ACTION_REVIVE;
                                break;
                            default:
                                EnableButton(BtnAction, false);
                                break;
                        }
                        EnableButton(BtnVote, true);
                        EnableButton(BtnJoin, false);
                        EnableButton(BtnViewRole, false);
                        UpdateAvatar(wm);
                        break;
                    case EventEnum.SwitchToDayTime:
                        //AddChatMessage("Switch to day time of day #" + wm.EventPayloads["Game.Current.Day"] + ".");
                        AddSystemMessage("Switch to day time of day #" + wm.EventPayloads["Game.Current.Day"] + ".");
                        _currentPeriod = Game.PeriodEnum.Day;
                        LBPeriod.Text = "Day time";
                        break;
                    case EventEnum.SwitchToNightTime:
                        //AddChatMessage("Switch to night time of day #" + wm.EventPayloads["Game.Current.Day"] + ".");
                        AddSystemMessage("Switch to night time of day #" + wm.EventPayloads["Game.Current.Day"] + ".");
                        _currentPeriod = Game.PeriodEnum.Night;
                        LBPeriod.Text = "Night time";
                        break;
                    case EventEnum.UpdateDay:
                        // TODO  catch parse exception here
                        string tempDay = wm.EventPayloads["Game.Current.Day"];
                        _currentDay = int.Parse(tempDay);
                        LBDay.Text = tempDay;
                        break;
                    case EventEnum.UpdateTime:
                        string tempTime = wm.EventPayloads["Game.Current.Time"];
                        _currentTime = int.Parse(tempTime);
                        LBTime.Text = tempTime;
                        if(_currentPeriod == Game.PeriodEnum.Night)
                        {
                            this.Sun_moon.Left -= 4;
                            this.BackColor = ColorTranslator.FromHtml(BG_Arr[BG_count]);
                            if (BG_count < 35) BG_count++;
                        }
                        else
                        {
                            this.BackColor = ColorTranslator.FromHtml(BG_Arr[BG_count]);
                            BG_count--;
                            this.Sun_moon.Left += 4;
                            if (BG_count == -1) BG_count++;
                        }
                        UpdateAvatar(wm);
                        break;
                    case EventEnum.Vote:
                        if (wm.EventPayloads["Success"] == WerewolfModel.TRUE)
                        {
                            //AddChatMessage("Your vote is registered.");
                            AddSystemMessage("Your vote is registered.");
                        }
                        else
                        {
                            //AddChatMessage("You can't vote now.");
                            AddSystemMessage("You can't vote now.");
                        }
                        break;
                    case EventEnum.Action:
                        if (wm.EventPayloads["Success"] == WerewolfModel.TRUE)
                        {
                            
                            //AddChatMessage("Your action is registered.");
                            AddSystemMessage("Your action is registered.");
                            if (_myRole == WerewolfModel.ROLE_GUNNER)
                            {
                                WerewolfCommand wcmd = new WerewolfCommand();
                                wcmd.Action = CommandEnum.Chat;
                                wcmd.Payloads = new Dictionary<string, string>() { { "Message", "I am a Gunner" } };
                                controller.ActionPerformed(wcmd);
                                firstshot = true;
                            }
                        }
                        else
                        {
                            //AddChatMessage("You can't perform action now.");
                            AddSystemMessage("You can't perform action now.");
                        }
                        break;
                    case EventEnum.YouShotDead:
                        //AddChatMessage("You're shot dead by gunner.");
                        AddSystemMessage("You're shot dead by gunner.");
                        _isDead = true;
                        break;
                    case EventEnum.OtherShotDead:
                        //AddChatMessage(wm.EventPayloads["Game.Target.Name"] + " was shot dead by gunner.");
                        AddSystemMessage(wm.EventPayloads["Game.Target.Name"] + " was shot dead by gunner.");
                        break;
                    case EventEnum.Alive:
                        //AddChatMessage(wm.EventPayloads["Game.Target.Name"] + " has been revived by medium.");
                        AddSystemMessage(wm.EventPayloads["Game.Target.Name"] + " has been revived by medium.");
                        if (wm.EventPayloads["Game.Target.Id"] == null)
                        {
                            _isDead = false;
                        }
                        break;
                    case EventEnum.ChatMessage:
                        if (wm.EventPayloads["Success"] == WerewolfModel.TRUE)
                        {
                            AddChatMessage(wm.EventPayloads["Game.Chatter"] + ":" + wm.EventPayloads["Game.ChatMessage"]);
                        }
                        break;
                    case EventEnum.Chat:
                        if (wm.EventPayloads["Success"] == WerewolfModel.FALSE)
                        {
                            switch (wm.EventPayloads["Error"])
                            {
                                case "403":
                                    AddSystemMessage("You're not alive, can't talk now.");
                                    break;
                                case "404":
                                    AddSystemMessage("You're not existed, can't talk now.");
                                    break;
                                case "405":
                                    AddSystemMessage("You're not in a game, can't talk now.");
                                    break;
                                case "406":
                                    AddSystemMessage("You're not allow to talk now, go to sleep.");
                                    break;
                            }
                        }
                        break;
                }
                // need to reset event
                wm.Event = EventEnum.NOP;
            }
        }


        public void setController(Controller c)
        {
            controller = (WerewolfController)c;
        }
        private void BtnPlayerX_Click(object sender, EventArgs e)
        {
            Button btnPlayer = (Button)sender;
            int index = (int)btnPlayer.Tag;
            if (players == null)
            {
                // Nothing to do here;
                return;
            }
            if (_actionActivated)
            {
                _actionActivated = false;
                BtnAction.BackColor = Button.DefaultBackColor;
                //AddChatMessage("You perform [" + BtnAction.Text + "] on " + players[index].Name);
                AddSystemMessage("You perform [" + BtnAction.Text + "] on " + players[index].Name);
                WerewolfCommand wcmd = new WerewolfCommand();
                wcmd.Action = CommandEnum.Action;
                wcmd.Payloads = new Dictionary<string, string>() { { "Target", players[index].Id.ToString() } };
                controller.ActionPerformed(wcmd);
            }
            if (_voteActivated)
            {
                _voteActivated = false;
                BtnVote.BackColor = Button.DefaultBackColor;
                //AddChatMessage("You vote on " + players[index].Name);
                AddSystemMessage("You vote on " + players[index].Name);
                WerewolfCommand wcmd = new WerewolfCommand();
                wcmd.Action = CommandEnum.Vote;
                wcmd.Payloads = new Dictionary<string, string>() { { "Target", players[index].Id.ToString() } };
                controller.ActionPerformed(wcmd);
            }
        }
        private void BtnJoin_Click(object sender, EventArgs e)
        {
            WerewolfCommand wcmd = new WerewolfCommand();
            wcmd.Action = CommandEnum.JoinGame;
            controller.ActionPerformed(wcmd);

        }
        private void BtnViewRole_Click(object sender, EventArgs e)
        {
            Card_box.Visible = true;
            BtnLeft.Visible = true;
            BtnRight.Visible = true;
            BtnJoin.Visible = false;
            BtnBack.Visible = true;

        }

        private void BtnSignOut_Click(object sender, EventArgs e)
        {
            WerewolfCommand wcmd = new WerewolfCommand();
            wcmd.Action = CommandEnum.SignOut;
            controller.ActionPerformed(wcmd);

        }
        private void BtnLeave_Click(object sender, EventArgs e)
        {   
            WerewolfCommand wcmd = new WerewolfCommand();
            wcmd.Action = CommandEnum.LeaveGame;
            controller.ActionPerformed(wcmd);
        }



        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        public void AddChatMessage(string str)
        {
            TbChatBox.AppendText(str + Environment.NewLine);
        }
        public void AddSystemMessage(string str)
        {
            SystemOutBox.AppendText(str + Environment.NewLine);
        }
        private void TbChatInput_Enter(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return && TbChatInput.Text != "")
            {
                WerewolfCommand wcmd = new WerewolfCommand();
                wcmd.Action = CommandEnum.Chat;
                wcmd.Payloads = new Dictionary<string, string>() { { "Message", TbChatInput.Text } };
                TbChatInput.Text = "";
                controller.ActionPerformed(wcmd);
            }
        }

        private void BtnVote_Click(object sender, EventArgs e)////////////Need Edit////////////
        {
            if (_voteActivated)
            {
                BtnVote.BackColor = Button.DefaultBackColor;
            }
            else
            {
                BtnVote.BackColor = Color.Red;
            }
            _voteActivated = !_voteActivated;
            if (_actionActivated)
            {
                BtnAction.BackColor = Button.DefaultBackColor;
                _actionActivated = false;
            }
        }

        private void BtnAction_Click(object sender, EventArgs e)
        {
            if (_isDead)
            {
                AddChatMessage("You're dead!!");
                return;
            }
            if (_actionActivated)
            {
                BtnAction.BackColor = Button.DefaultBackColor;
            }
            else
            {
                BtnAction.BackColor = Color.Red;
            }
            _actionActivated = !_actionActivated;
            if (_voteActivated)
            {
                BtnVote.BackColor = Button.DefaultBackColor;
                _voteActivated = false;
            }
        }

        public static bool SetStyle(Control c, ControlStyles Style, bool value)
        {
            bool retval = false;
            Type typeTB = typeof(Control);
            System.Reflection.MethodInfo misSetStyle = typeTB.GetMethod("SetStyle", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            if (misSetStyle != null && c != null) { misSetStyle.Invoke(c, new object[] { Style, value }); retval = true; }
            return retval;
        }

        private void GameForm_Load(object sender, EventArgs e)
        {

        }

        private void BtnRight_Click(object sender, EventArgs e)
        {
            card_count++;
            if (card_count == 16) card_count = 0;
            Card_box.Image = card_img[card_count];
            
        }

        private void BtnLeft_Click(object sender, EventArgs e)
        {
            card_count--;
            if (card_count == -1) card_count = 15;
            Card_box.Image = card_img[card_count];
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Card_box.Visible = false;
            BtnLeft.Visible = false;
            BtnRight.Visible = false;
            BtnJoin.Visible = true;
            BtnBack.Visible = false;
        }
    }
    public static class Extensions
    {
        public static void EnableDoubleBuferring(this Control control)
        {
            var property = typeof(Control).GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            property.SetValue(control, true, null);
        }
    }




}
