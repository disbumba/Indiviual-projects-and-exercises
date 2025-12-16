using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Testare_Proiect2;

namespace Testare_Proiect2
{
    public class PlayerControl : UserControl
    {
        private FlowLayoutPanel flowPanel;
        private Label lblName;
        private Label lblScore;
        private Player player;

        public PlayerControl()
        {
            player = new Player();
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Width = 420;
            this.Height = 160;
            this.BorderStyle = BorderStyle.FixedSingle;

            lblName = new Label()
            {
                Text = "Player",
                AutoSize = true,
                Location = new Point(6, 6),
                Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold)
            };

            lblScore = new Label()
            {
                Text = "Scor: 0",
                AutoSize = true,
                Location = new Point(100, 6),
                Font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular)
            };

            flowPanel = new FlowLayoutPanel()
            {
                Location = new Point(6, 30),
                Size = new Size(400, 190),
                AutoScroll = true,
                WrapContents = false,
                FlowDirection = FlowDirection.LeftToRight
            };

            this.Controls.Add(lblName);
            this.Controls.Add(lblScore);
            this.Controls.Add(flowPanel);
        }

        public void AddCard(PlayingCard card)
        {
            if (card == null)
                return;
            player.AddCard(card);

            PictureBox pb = new PictureBox()
            {
                Width = 80,
                Height = 120,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Margin = new Padding(3)
            };

            
            Image img = LoadImageInMemory(card.ImagePath);
            if (img != null)
                pb.Image = img;
            else
                pb.Image = LoadImageInMemory("imagini/Spate_carte_joc.jpg");
            flowPanel.Controls.Add(pb);
            UpdateScoreLabel();
        }

        public void ClearHand()
        {
            player.ClearHand();
            flowPanel.Controls.Clear();
            UpdateScoreLabel();
        }

        private void UpdateScoreLabel()
        {
            lblScore.Text = $"Scor: {player.CalculateScore()}";
        }
        private Image LoadImageInMemory(string relativePath)
        {
            try
            {
                string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
                if (!File.Exists(fullPath)) return null;

                byte[] bytes = File.ReadAllBytes(fullPath);
                using (MemoryStream ms = new MemoryStream(bytes))
                {
                    Image img = Image.FromStream(ms);
                    return new Bitmap(img);
                }
            }
            catch
            {
                return null;
            }
        }
    }
}