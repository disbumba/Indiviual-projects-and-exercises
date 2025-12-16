using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Testare_Proiect2;


    
namespace Testare_Proiect2
{
    public partial class Form1 : Form
    {

        private CardDeck deck;
        private Player player;
        private Dealer dealer;

        private List<PictureBox> dealerPictureBoxes = new List<PictureBox>();
        private List<Image> dealerCachedImages = new List<Image>();

        private readonly string cardBackRelativePath = "imagini/Spate_carte_joc.jpg";

            public Form1()
            {
                InitializeComponent();
                deck = new CardDeck();
                player = new Player();
                dealer = new Dealer();
                buttonHit.Enabled = false;
                buttonStand.Enabled = false;
                buttonRestart.Enabled = false;            
        }
      
        private void ButtonDeal_Click(object sender, EventArgs e)
        {
            ResetRoundUIOnly();
            buttonRestart.Enabled = false;
          
                var card = deck.DrawCard();
                player.AddCard(card);
                 playerControl1.AddCard(card);

                 AddDealerCard(deck.DrawCard(), false);
                card = deck.DrawCard();
                player.AddCard(card);
                playerControl1.AddCard(card);    
            
                AddDealerCard(deck.DrawCard(), true);
                buttonDeal.Enabled = false;
                buttonHit.Enabled = true;
                buttonStand.Enabled = true;       
        }

        private void ButtonHit_Click(object sender, EventArgs e)
        {
           
                var card = deck.DrawCard(); 
                player.AddCard(card);
                playerControl1.AddCard(card);

                if (player.CalculateScore() > 21)
                {
                    buttonHit.Enabled = false;
                    buttonStand.Enabled = false;
                    RevealDealerHiddenCards();
                    MessageBox.Show("Ai trecut peste 21 (bust)!");
                    buttonRestart.Enabled = true;
                } 
              if(player.CalculateScore()==21)
            {
                buttonHit.Enabled = false;
            }
        }

        private void ButtonStand_Click(object sender, EventArgs e)
        {
          while (dealer.CalculateScore() < 17 && deck.GetTotalNumberOfCards() > 0)
            {
                AddDealerCard(deck.DrawCard(), false);
                Application.DoEvents();
            }
           EndRound();
        }

        private void ButtonRestart_Click(object sender, EventArgs e)
        {
            deck.Reset();
            ResetRoundUIOnly();
            buttonDeal.Enabled = true;
            buttonHit.Enabled = false;
            buttonStand.Enabled = false;
            buttonRestart.Enabled = false;

        }

        private void AddDealerCard(PlayingCard card, bool faceDown)
        {
            dealer.AddCard(card);

            PictureBox pb = new PictureBox()
            {
                Width = 80,
                Height = 120,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Margin = new Padding(3)
            };

          
            string path = null;
            if (faceDown == true)
            {
                string aux = cardBackRelativePath;
                path = aux;
            }
            else
            {
                string aux2 = card.ImagePath;
                path = aux2;
            }
      
            Image img = LoadImageInMemory(path);
            if (img != null)
            {
                pb.Image = img;
                dealerCachedImages.Add(img);
            }
            if (faceDown == true)
            {
                pb.Tag = "facedown";
            }
          
            dealerFlowPanel.Controls.Add(pb);
            dealerPictureBoxes.Add(pb);
            UpdateDealerScoreLabel();
        }

        private void RevealDealerHiddenCards()
        {
            for (int i = 0; i < dealerPictureBoxes.Count; i++)
            {
                var pb = dealerPictureBoxes[i];

                bool isFaceDown = false;
                if (pb != null)
                {
                    if (pb.Tag != null)
                    {
                        if (pb.Tag.ToString() == "facedown")
                        {
                            isFaceDown = true;
                        }
                    }
                }
                {
                    var card = dealer.Hand[i];
                    Image img = LoadImageInMemory(card.ImagePath);
                    if (img != null)
                    {
                        pb.Image = img;
                        dealerCachedImages.Add(img);
                    }
                    pb.Tag = null;

                }
            }
            UpdateDealerScoreLabel();

        }
        private void UpdateDealerScoreLabel()
        {
            int visibleScore = 0;
            for (int i = 0; i < dealer.Hand.Count; i++)
            {
               
                PictureBox pb = null;
                if (i < dealerPictureBoxes.Count)
                {
                    pb = dealerPictureBoxes[i];
                }
                bool isFaceDown = (pb != null && pb.Tag != null && pb.Tag.ToString() == "facedown");
                if (!isFaceDown)
                {
                    visibleScore = visibleScore + dealer.Hand[i].Value;
                  
                    if (dealer.Hand[i].CardType == PlayingCard.Type.Ace && visibleScore <= 11)
                        visibleScore = visibleScore + 10;
                }           
                 
            }
            lblDealerScore.Text = $"Dealer Scor: {visibleScore}";
           
        }

        private void ResetRoundUIOnly()
        {
            player.ClearHand();
            playerControl1.ClearHand();
            dealer.ClearHand();
            
            for (int i = 0; i < dealerPictureBoxes.Count; i++)
            {
                var pb = dealerPictureBoxes[i];
                if (pb != null)
                {
                    if (pb.Image != null)
                    {
                        pb.Image.Dispose();
                    }
                    pb.Dispose();
                }
            }
            dealerPictureBoxes.Clear();

            dealerFlowPanel.Controls.Clear();
            UpdateDealerScoreLabel();
        }

        private Image LoadImageInMemory(string relativePath)
        {
            try
            {
                string fullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);
                if (!File.Exists(fullPath))
                    return null;

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

        private void EndRound(string bustMessage = null)
        {
            RevealDealerHiddenCards();

            int playerScore = player.CalculateScore();
            int dealerScore = dealer.CalculateScore();
            string result;

            if (!string.IsNullOrEmpty(bustMessage))
            {
                result = bustMessage + " Dealer wins.";
            }
            else if (playerScore > 21) result = "Player bust! Dealer wins.";
            else if (dealerScore > 21) result = "Dealer bust! Player wins.";
            else if (playerScore > dealerScore) result = "Player wins!";
            else if (playerScore < dealerScore) result = "Dealer wins!";
            else result = "Push (egal).";

            MessageBox.Show($"Rezultat: {result}\nPlayer: {playerScore}\nDealer: {dealerScore}");

            buttonHit.Enabled = false;
            buttonStand.Enabled = false;
            buttonRestart.Enabled = true;
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                for (int i = 0; i < dealerCachedImages.Count; i++)
                {
                    var img = dealerCachedImages[i];
                    if (img != null)
                    {
                        try { img.Dispose(); }
                        catch { }
                    }
                }
                dealerCachedImages.Clear();
            }
            base.Dispose(disposing);
        }

       
    }
}
