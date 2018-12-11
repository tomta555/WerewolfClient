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
        private bool _isDead;
        private List<Player> players = null;

        public GameForm()
        {
            InitializeComponent();
            

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
            _myRole = null;
            _isDead = false;
            
            
            StartSetup();
        }


        public void EnableButton(Button btn, bool state)
        {
            btn.Visible = btn.Enabled = state;
        }
        public void StartSetup()
        {
            panel1.BackColor = Color.Transparent;
            panel1.ForeColor = System.Drawing.Color.White;
            BtnJoin.Image = Properties.Resources.Btn_join;
            BtnJoin.Width = Properties.Resources.Btn_join.Width;
            BtnJoin.Height = Properties.Resources.Btn_join.Height;
            BtnJoin.BackColor = Color.Transparent;
            BtnJoin.FlatStyle = FlatStyle.Flat;
            BtnJoin.FlatAppearance.BorderSize = 0;
            BtnJoin.FlatAppearance.MouseDownBackColor = Color.Transparent;
            BtnJoin.FlatAppearance.MouseOverBackColor = Color.Transparent;
            BtnJoin.ForeColor = System.Drawing.Color.White;
            BtnJoin.Text = "Join Game";

            foreach (int i in Enumerable.Range(0, 16))
            {
                ButtonXSetup((Button)Controls["panel1"].Controls["BtnPlayer" + i]);              
            }
            
            //ButtonXSetup(BtnPlayer0);
            //ButtonXSetup(BtnPlayer1);
            //ButtonXSetup(BtnPlayer2);
            //ButtonXSetup(BtnPlayer2);
            //ButtonXSetup(BtnPlayer3);
            //ButtonXSetup(BtnPlayer4);
            //ButtonXSetup(BtnPlayer5);
            //ButtonXSetup(BtnPlayer6);
            //ButtonXSetup(BtnPlayer7);
            //ButtonXSetup(BtnPlayer8);
            //ButtonXSetup(BtnPlayer9);
            //ButtonXSetup(BtnPlayer10);
            //ButtonXSetup(BtnPlayer11);
            //ButtonXSetup(BtnPlayer12);
            //ButtonXSetup(BtnPlayer13);
            //ButtonXSetup(BtnPlayer14);
            //ButtonXSetup(BtnPlayer15);

            //TbChatBox.BackColor = Color.Transparent;

            bool itWorked = SetStyle(TbChatBox, ControlStyles.SupportsTransparentBackColor, true);
            TbChatBox.BackColor = Color.Transparent;
        }

        public void ButtonXSetup(Button btn)
        {
            btn.Image = Properties.Resources.Char_nonChar;
            btn.Width = Properties.Resources.Char_nonChar.Width;
            btn.Height = Properties.Resources.Char_nonChar.Height;
            btn.BackColor = Color.Transparent;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn.ForeColor = System.Drawing.Color.White;
            btn.Text = "";
            btn.Visible = false;
        }
        private void OnTimerEvent(object sender, EventArgs e)
        {
            WerewolfCommand wcmd = new WerewolfCommand();
            wcmd.Action = CommandEnum.RequestUpdate;
            controller.ActionPerformed(wcmd);
        }
        private void UpdateAvatar(WerewolfModel wm)
        {
            int i = 0;
            foreach (Player player in wm.Players)
            {
                Controls["panel1"].Controls["BtnPlayer" + i].Text = player.Name;
                if (player.Name == wm.Player.Name || player.Status != Player.StatusEnum.Alive)
                {
                    // FIXME, need to optimize this
                    Image img = Properties.Resources.Char_nonChar;
                    string role;
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
                        continue;
                    }
                    switch (role)
                    {
                        case WerewolfModel.ROLE_SEER:
                            img = Properties.Resources.Icon_seer;
                            break;
                        case WerewolfModel.ROLE_AURA_SEER:
                            img = Properties.Resources.Icon_aura_seer;
                            break;
                        case WerewolfModel.ROLE_PRIEST:
                            img = Properties.Resources.Icon_priest;
                            break;
                        case WerewolfModel.ROLE_DOCTOR:
                            img = Properties.Resources.Icon_doctor;
                            break;
                        case WerewolfModel.ROLE_WEREWOLF:
                            img = Properties.Resources.Icon_werewolf;
                            break;
                        case WerewolfModel.ROLE_WEREWOLF_SEER:
                            img = Properties.Resources.Icon_wolf_seer;
                            break;
                        case WerewolfModel.ROLE_ALPHA_WEREWOLF:
                            img = Properties.Resources.Icon_alpha_werewolf;
                            break;
                        case WerewolfModel.ROLE_WEREWOLF_SHAMAN:
                            img = Properties.Resources.Icon_wolf_shaman;
                            break;
                        case WerewolfModel.ROLE_MEDIUM:
                            img = Properties.Resources.Icon_medium;
                            break;
                        case WerewolfModel.ROLE_BODYGUARD:
                            img = Properties.Resources.Icon_bodyguard;
                            break;
                        case WerewolfModel.ROLE_JAILER:
                            img = Properties.Resources.Icon_jailer;
                            break;
                        case WerewolfModel.ROLE_FOOL:
                            img = Properties.Resources.Icon_fool;
                            break;
                        case WerewolfModel.ROLE_HEAD_HUNTER:
                            img = Properties.Resources.Icon_head_hunter;
                            break;
                        case WerewolfModel.ROLE_SERIAL_KILLER:
                            img = Properties.Resources.Icon_serial_killer;
                            break;
                        case WerewolfModel.ROLE_GUNNER:
                            img = Properties.Resources.Icon_gunner;
                            break;
                    }
                    ((Button)Controls["panel1"].Controls["BtnPlayer" + i]).Image = img;
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
                    case EventEnum.JoinGame:
                        if (wm.EventPayloads["Success"] == WerewolfModel.TRUE)
                        {
                            BtnJoin.Visible = false;
                            //AddChatMessage("You're joing the game #" + wm.EventPayloads["Game.Id"] + ", please wait for game start.");
                            AddSystemMessage("You're joing the game #" + wm.EventPayloads["Game.Id"] + ", please wait for game start.");
                            _updateTimer.Interval = 1000;
                            _updateTimer.Tick += new EventHandler(OnTimerEvent);
                            _updateTimer.Enabled = true;
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
                        EnableButton(BtnVote, true);///////Need Edit///////
                        EnableButton(BtnJoin, false);/////////////
                        UpdateAvatar(wm);
                        break;
                    case EventEnum.SwitchToDayTime:
                        //AddChatMessage("Switch to day time of day #" + wm.EventPayloads["Game.Current.Day"] + ".");
                        AddSystemMessage("Switch to day time of day #" + wm.EventPayloads["Game.Current.Day"] + ".");
                        _currentPeriod = Game.PeriodEnum.Day;
                        LBPeriod.Text = "Day time of";
                        //this.BackgroundImage = Properties.Resources._2; /////// switch background
                        break;
                    case EventEnum.SwitchToNightTime:
                        //AddChatMessage("Switch to night time of day #" + wm.EventPayloads["Game.Current.Day"] + ".");
                        AddSystemMessage("Switch to night time of day #" + wm.EventPayloads["Game.Current.Day"] + ".");
                        _currentPeriod = Game.PeriodEnum.Night;
                        LBPeriod.Text = "Night time of";
                        //this.BackgroundImage = Properties.Resources.BG_Back; /////// switch background
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
                            this.ButtonBG.Top--;
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
                        foreach (int i in Enumerable.Range(0, 16))
            {
                this.Controls["panel1"].Controls["BtnPlayer" + i].Visible = true;
            }

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
    }




}
