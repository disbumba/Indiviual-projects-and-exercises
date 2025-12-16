using System;
using System.Drawing;
using System.Windows.Forms;
namespace Testare_Proiect2
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    

        #region Windows Form Designer generated code

    
        private Testare_Proiect2.PlayerControl playerControl;
        private System.Windows.Forms.Button buttonDeal;
        private System.Windows.Forms.Button buttonHit;
        private System.Windows.Forms.Label lblDealerScore;
        private System.Windows.Forms.FlowLayoutPanel dealerFlowPanel;
        private System.Windows.Forms.Button buttonRestart;
        private System.Windows.Forms.Button buttonStand;


        private void InitializeComponent()
        {
            this.buttonRestart = new System.Windows.Forms.Button();
            this.buttonDeal = new System.Windows.Forms.Button();
            this.lblDealerScore = new System.Windows.Forms.Label();
            this.dealerFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonStand = new System.Windows.Forms.Button();
            this.buttonHit = new System.Windows.Forms.Button();
            this.playerControl1 = new Testare_Proiect2.PlayerControl();
            this.SuspendLayout();
            // 
            // buttonRestart
            // 
            this.buttonRestart.Location = new System.Drawing.Point(352, 365);
            this.buttonRestart.Name = "buttonRestart";
            this.buttonRestart.Size = new System.Drawing.Size(124, 75);
            this.buttonRestart.TabIndex = 0;
            this.buttonRestart.Text = "buttonRestart";
            this.buttonRestart.UseVisualStyleBackColor = true;
            this.buttonRestart.Click += new System.EventHandler(this.ButtonRestart_Click);
            // 
            // buttonDeal
            // 
            this.buttonDeal.Location = new System.Drawing.Point(494, 365);
            this.buttonDeal.Name = "buttonDeal";
            this.buttonDeal.Size = new System.Drawing.Size(133, 75);
            this.buttonDeal.TabIndex = 1;
            this.buttonDeal.Text = "buttonDeal";
            this.buttonDeal.UseVisualStyleBackColor = true;
            this.buttonDeal.Click += new System.EventHandler(this.ButtonDeal_Click);
            // 
            // lblDealerScore
            // 
            this.lblDealerScore.AutoSize = true;
            this.lblDealerScore.Location = new System.Drawing.Point(403, 19);
            this.lblDealerScore.Name = "lblDealerScore";
            this.lblDealerScore.Size = new System.Drawing.Size(116, 20);
            this.lblDealerScore.TabIndex = 2;
            this.lblDealerScore.Text = "Dealer score: 0";
            // 
            // dealerFlowPanel
            // 
            this.dealerFlowPanel.AutoScroll = true;
            this.dealerFlowPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dealerFlowPanel.Location = new System.Drawing.Point(407, 48);
            this.dealerFlowPanel.Name = "dealerFlowPanel";
            this.dealerFlowPanel.Size = new System.Drawing.Size(357, 259);
            this.dealerFlowPanel.TabIndex = 3;
            this.dealerFlowPanel.WrapContents = false;
            // 
            // buttonStand
            // 
            this.buttonStand.Location = new System.Drawing.Point(195, 365);
            this.buttonStand.Name = "buttonStand";
            this.buttonStand.Size = new System.Drawing.Size(131, 77);
            this.buttonStand.TabIndex = 5;
            this.buttonStand.Text = "buttonStand";
            this.buttonStand.UseVisualStyleBackColor = true;
            this.buttonStand.Click += new System.EventHandler(this.ButtonStand_Click);
            // 
            // buttonHit
            // 
            this.buttonHit.Location = new System.Drawing.Point(41, 365);
            this.buttonHit.Name = "buttonHit";
            this.buttonHit.Size = new System.Drawing.Size(148, 77);
            this.buttonHit.TabIndex = 6;
            this.buttonHit.Text = "buttonHit";
            this.buttonHit.UseVisualStyleBackColor = true;
            this.buttonHit.Click += new System.EventHandler(this.ButtonHit_Click);
            // 
            // playerControl1
            // 
            this.playerControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.playerControl1.Location = new System.Drawing.Point(12, 48);
            this.playerControl1.Name = "playerControl1";
            this.playerControl1.Size = new System.Drawing.Size(389, 259);
            this.playerControl1.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.playerControl1);
            this.Controls.Add(this.buttonHit);
            this.Controls.Add(this.buttonStand);
            this.Controls.Add(this.dealerFlowPanel);
            this.Controls.Add(this.lblDealerScore);
            this.Controls.Add(this.buttonDeal);
            this.Controls.Add(this.buttonRestart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private PlayerControl playerControl1;
    }
}

