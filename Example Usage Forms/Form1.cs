using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using SteamIDs_Engine;
using System.Drawing.Text;

namespace Example_Usage_Forms {
    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();
            this.Paint += OnPaint;
        }

        private void Form1_Load(object sender, EventArgs e) {
            textBox1.Text = MainGlabals.g_sSteamID2;
            textBox2.Text = MainGlabals.g_sSteamID32;
            textBox3.Text = MainGlabals.g_sSteamID64;
        }

        public void OnPaint(object sender, PaintEventArgs e) {
            System.Drawing.Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();
            Font myFont = new System.Drawing.Font("Helvetica", 12, FontStyle.Regular);
            Brush myBrush = new SolidBrush(System.Drawing.Color.Red);
            Brush _greenBrush = new SolidBrush(System.Drawing.Color.Green);
            Brush _darkblueBrush = new SolidBrush(System.Drawing.Color.DarkBlue);
            graphicsObj.TextRenderingHint = TextRenderingHint.AntiAlias;
            graphicsObj.DrawString(MainGlabals.InfoText, myFont, myBrush, 24f, 174f);
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            textBox1.Text = MainGlabals.g_sSteamID2;
        }

        private void textBox2_TextChanged(object sender, EventArgs e) {
            textBox2.Text = MainGlabals.g_sSteamID32;
        }

        private void textBox3_TextChanged(object sender, EventArgs e) {
            textBox3.Text = MainGlabals.g_sSteamID64;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Clipboard.SetText(MainGlabals.g_sSteamID2);
            MainGlabals.InfoText = string.Format("{0} copied!", MainGlabals.g_sSteamID2);
            this.Invalidate();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Clipboard.SetText(MainGlabals.g_sSteamID32);
            MainGlabals.InfoText = string.Format("{0} copied!", MainGlabals.g_sSteamID32);
            this.Invalidate();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            Clipboard.SetText(MainGlabals.g_sSteamID64);
            MainGlabals.InfoText = string.Format("{0}\ncopied!", MainGlabals.g_sSteamID64);
            this.Invalidate();
        }

        private void textBox4_TextChanged(object sender, EventArgs e) {
            string inputtext = textBox4.Text;
            if (inputtext.Contains("[") || inputtext.Contains("]")) {
                inputtext = inputtext.Replace("]", "").Replace("[", ""); //Remove the [ ]
            }

            //Steam2 Conv AKA Universe ID OR Account ID OLD
            if (Regex.IsMatch(inputtext, SteamIDRegex.Steam2Regex)) {
                MainGlabals.g_sSteamID2 = inputtext;
            } else if (Regex.IsMatch(inputtext, SteamIDRegex.Steam64Regex)) { 
                MainGlabals.g_sSteamID2 = SteamIDConvert.Steam64ToSteam2(Convert.ToInt64(inputtext));
            } else if (Regex.IsMatch(inputtext, SteamIDRegex.Steam32Regex)) {
                MainGlabals.g_sSteamID2 = SteamIDConvert.Steam32ToSteam2(inputtext);
            } else {
                MainGlabals.g_sSteamID2 = string.Format("ERROR ?");
            }

            //Steam32 Conv AKA Account ID
            if (Regex.IsMatch(inputtext, SteamIDRegex.Steam2Regex)) {
                MainGlabals.g_sSteamID32 = string.Format("[{0}]", SteamIDConvert.Steam2ToSteam32(inputtext));
            } else if (Regex.IsMatch(inputtext, SteamIDRegex.Steam64Regex)) {
                MainGlabals.g_sSteamID32 = string.Format("[{0}]", SteamIDConvert.Steam64ToSteam32(Convert.ToInt64(inputtext)));
            } else if (Regex.IsMatch(inputtext, SteamIDRegex.Steam32Regex)) { 
                MainGlabals.g_sSteamID32 = string.Format("[{0}]", inputtext);
            } else {
                MainGlabals.g_sSteamID32 = string.Format("ERROR ?");
            }


            //SteamID64 Conv AKA Community ID
            if (Regex.IsMatch(inputtext, SteamIDRegex.Steam2Regex)) {
                MainGlabals.g_sSteamID64 = SteamIDConvert.Steam2ToSteam64(inputtext).ToString();
            } else if (Regex.IsMatch(inputtext, SteamIDRegex.Steam64Regex)) {
                MainGlabals.g_sSteamID64 = inputtext;
            } else if (Regex.IsMatch(inputtext, SteamIDRegex.Steam32Regex)) {
                MainGlabals.g_sSteamID64 = SteamIDConvert.Steam32ToSteam64(inputtext).ToString();
            } else {
                MainGlabals.g_sSteamID64 = string.Format("ERROR ?");
            }

            //Refresh forms to update all the boxes.
            textBox1.Text = MainGlabals.g_sSteamID2;
            textBox2.Text = MainGlabals.g_sSteamID32;
            textBox3.Text = MainGlabals.g_sSteamID64;
        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            //https://steamcommunity.com/id/NachoReplay/
            System.Diagnostics.Process.Start("https://steamcommunity.com/id/NachoReplay");
        }
    }
}
