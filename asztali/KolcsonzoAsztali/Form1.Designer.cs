namespace KolcsonzoAsztali
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listBoxNevek = new ListBox();
            listBoxKonyvek = new ListBox();
            buttonVisszahozva = new Button();
            buttonBezar = new Button();
            SuspendLayout();
            // 
            // listBoxNevek
            // 
            listBoxNevek.DisplayMember = "Nev";
            listBoxNevek.FormattingEnabled = true;
            listBoxNevek.ItemHeight = 15;
            listBoxNevek.Location = new Point(12, 12);
            listBoxNevek.Name = "listBoxNevek";
            listBoxNevek.Size = new Size(240, 424);
            listBoxNevek.TabIndex = 0;
            listBoxNevek.ValueMember = "Id";
            listBoxNevek.SelectedIndexChanged += listBoxNevek_SelectedIndexChanged;
            // 
            // listBoxKonyvek
            // 
            listBoxKonyvek.DisplayMember = "Info";
            listBoxKonyvek.FormattingEnabled = true;
            listBoxKonyvek.ItemHeight = 15;
            listBoxKonyvek.Location = new Point(258, 12);
            listBoxKonyvek.Name = "listBoxKonyvek";
            listBoxKonyvek.Size = new Size(530, 124);
            listBoxKonyvek.TabIndex = 1;
            listBoxKonyvek.ValueMember = "KolcsonzokId";
            listBoxKonyvek.SelectedIndexChanged += listBoxKonyvek_SelectedIndexChanged;
            // 
            // buttonVisszahozva
            // 
            buttonVisszahozva.Enabled = false;
            buttonVisszahozva.Location = new Point(284, 164);
            buttonVisszahozva.Name = "buttonVisszahozva";
            buttonVisszahozva.Size = new Size(106, 38);
            buttonVisszahozva.TabIndex = 2;
            buttonVisszahozva.Text = "Visszahozva";
            buttonVisszahozva.UseVisualStyleBackColor = true;
            buttonVisszahozva.Click += buttonVisszahozva_Click;
            // 
            // buttonBezar
            // 
            buttonBezar.Location = new Point(713, 415);
            buttonBezar.Name = "buttonBezar";
            buttonBezar.Size = new Size(75, 23);
            buttonBezar.TabIndex = 3;
            buttonBezar.Text = "Bezár";
            buttonBezar.UseVisualStyleBackColor = true;
            buttonBezar.Click += buttonBezar_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonBezar);
            Controls.Add(buttonVisszahozva);
            Controls.Add(listBoxKonyvek);
            Controls.Add(listBoxNevek);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Kölcsönző";
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxNevek;
        private ListBox listBoxKonyvek;
        private Button buttonVisszahozva;
        private Button buttonBezar;
    }
}