namespace Reversi
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components=null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing&&(components!=null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.opozniaczRuchuKomputera = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.graToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nowaGraDlaJednegoGraczaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.¹zowyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rozpoczynaszTyzielonyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nowaGraDlaDwóchGraczyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.zamknijToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pomocToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.podpowiedŸRuchuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ruchWykonujeKomputerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zasadyGryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.strategiaKomputeraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.listBox2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.listBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(252, 24);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.panel1.Size = new System.Drawing.Size(106, 338);
            this.panel1.TabIndex = 0;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Location = new System.Drawing.Point(0, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(100, 23);
            this.linkLabel1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(66, 243);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 14);
            this.label6.TabIndex = 8;
            this.label6.Text = "2";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(66, 229);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 14);
            this.label5.TabIndex = 7;
            this.label5.Text = "2";
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Sienna;
            this.label4.Location = new System.Drawing.Point(7, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "Br¹zowy";
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(7, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "Zielony";
            // 
            // listBox2
            // 
            this.listBox2.BackColor = System.Drawing.SystemColors.Control;
            this.listBox2.ForeColor = System.Drawing.Color.Sienna;
            this.listBox2.Location = new System.Drawing.Point(53, 110);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(40, 82);
            this.listBox2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ostatnie ruchy:";
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.SystemColors.Control;
            this.listBox1.ForeColor = System.Drawing.Color.Green;
            this.listBox1.Location = new System.Drawing.Point(7, 110);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(40, 82);
            this.listBox1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(28, 28);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 40);
            this.button1.TabIndex = 1;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nastêpny ruch:";
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem6});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem5,
            this.menuItem2,
            this.menuItem3,
            this.menuItem4});
            this.menuItem1.Text = "Gra";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 0;
            this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem12,
            this.menuItem13});
            this.menuItem5.Text = "Nowa gra dla jednego gracza";
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 0;
            this.menuItem12.Shortcut = System.Windows.Forms.Shortcut.F2;
            this.menuItem12.Text = "Rozpoczyna komputer (br¹zowy)";
            this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 1;
            this.menuItem13.Shortcut = System.Windows.Forms.Shortcut.F3;
            this.menuItem13.Text = "Rozpoczynasz Ty (zielony)";
            this.menuItem13.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Shortcut = System.Windows.Forms.Shortcut.F4;
            this.menuItem2.Text = "Nowa gra dla dwóch graczy";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 2;
            this.menuItem3.Text = "-";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 3;
            this.menuItem4.Text = "Zamknij";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 1;
            this.menuItem6.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem10,
            this.menuItem11,
            this.menuItem7,
            this.menuItem14,
            this.menuItem8,
            this.menuItem9});
            this.menuItem6.Text = "Pomoc";
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 0;
            this.menuItem10.Shortcut = System.Windows.Forms.Shortcut.F5;
            this.menuItem10.Text = "PodpowiedŸ ruchu";
            this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 1;
            this.menuItem11.Shortcut = System.Windows.Forms.Shortcut.F6;
            this.menuItem11.Text = "Ruch wykonany przez komputer";
            this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 2;
            this.menuItem7.Shortcut = System.Windows.Forms.Shortcut.F1;
            this.menuItem7.Text = "Zasady gry";
            this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 3;
            this.menuItem14.Text = "Strategia komputera";
            this.menuItem14.Click += new System.EventHandler(this.menuItem14_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 4;
            this.menuItem8.Text = "-";
            // 
            // menuItem9
            // 
            this.menuItem9.Index = 5;
            this.menuItem9.Text = "";
            // 
            // opozniaczRuchuKomputera
            // 
            this.opozniaczRuchuKomputera.Interval = 300;
            this.opozniaczRuchuKomputera.Tick += new System.EventHandler(this.opozniaczRuchuKomputera_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.graToolStripMenuItem,
            this.pomocToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(358, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // graToolStripMenuItem
            // 
            this.graToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nowaGraDlaJednegoGraczaToolStripMenuItem,
            this.nowaGraDlaDwóchGraczyToolStripMenuItem,
            this.toolStripSeparator1,
            this.zamknijToolStripMenuItem});
            this.graToolStripMenuItem.Name = "graToolStripMenuItem";
            this.graToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.graToolStripMenuItem.Text = "Gra";
            this.graToolStripMenuItem.Click += new System.EventHandler(this.graToolStripMenuItem_Click);
            // 
            // nowaGraDlaJednegoGraczaToolStripMenuItem
            // 
            this.nowaGraDlaJednegoGraczaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.¹zowyToolStripMenuItem,
            this.rozpoczynaszTyzielonyToolStripMenuItem});
            this.nowaGraDlaJednegoGraczaToolStripMenuItem.Name = "nowaGraDlaJednegoGraczaToolStripMenuItem";
            this.nowaGraDlaJednegoGraczaToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.nowaGraDlaJednegoGraczaToolStripMenuItem.Text = "Nowa gra dla jednego gracza";
            // 
            // ¹zowyToolStripMenuItem
            // 
            this.¹zowyToolStripMenuItem.Name = "¹zowyToolStripMenuItem";
            this.¹zowyToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.¹zowyToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.¹zowyToolStripMenuItem.Text = "Rozpoczyna Komputer (br¹zowy)";
            this.¹zowyToolStripMenuItem.Click += new System.EventHandler(this.menuItem12_Click);
            // 
            // rozpoczynaszTyzielonyToolStripMenuItem
            // 
            this.rozpoczynaszTyzielonyToolStripMenuItem.Name = "rozpoczynaszTyzielonyToolStripMenuItem";
            this.rozpoczynaszTyzielonyToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.rozpoczynaszTyzielonyToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.rozpoczynaszTyzielonyToolStripMenuItem.Text = "Rozpoczynasz Ty (zielony)";
            this.rozpoczynaszTyzielonyToolStripMenuItem.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // nowaGraDlaDwóchGraczyToolStripMenuItem
            // 
            this.nowaGraDlaDwóchGraczyToolStripMenuItem.Name = "nowaGraDlaDwóchGraczyToolStripMenuItem";
            this.nowaGraDlaDwóchGraczyToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F4;
            this.nowaGraDlaDwóchGraczyToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.nowaGraDlaDwóchGraczyToolStripMenuItem.Text = "Nowa gra dla dwóch graczy";
            this.nowaGraDlaDwóchGraczyToolStripMenuItem.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(236, 6);
            // 
            // zamknijToolStripMenuItem
            // 
            this.zamknijToolStripMenuItem.Name = "zamknijToolStripMenuItem";
            this.zamknijToolStripMenuItem.Size = new System.Drawing.Size(239, 22);
            this.zamknijToolStripMenuItem.Text = "Zamknij";
            this.zamknijToolStripMenuItem.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // pomocToolStripMenuItem
            // 
            this.pomocToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.podpowiedŸRuchuToolStripMenuItem,
            this.ruchWykonujeKomputerToolStripMenuItem,
            this.zasadyGryToolStripMenuItem,
            this.strategiaKomputeraToolStripMenuItem,
            this.toolStripSeparator2});
            this.pomocToolStripMenuItem.Name = "pomocToolStripMenuItem";
            this.pomocToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.pomocToolStripMenuItem.Text = "Pomoc";
            // 
            // podpowiedŸRuchuToolStripMenuItem
            // 
            this.podpowiedŸRuchuToolStripMenuItem.Name = "podpowiedŸRuchuToolStripMenuItem";
            this.podpowiedŸRuchuToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.podpowiedŸRuchuToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.podpowiedŸRuchuToolStripMenuItem.Text = "PodpowiedŸ ruchu";
            this.podpowiedŸRuchuToolStripMenuItem.Click += new System.EventHandler(this.menuItem10_Click);
            // 
            // ruchWykonujeKomputerToolStripMenuItem
            // 
            this.ruchWykonujeKomputerToolStripMenuItem.Name = "ruchWykonujeKomputerToolStripMenuItem";
            this.ruchWykonujeKomputerToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6;
            this.ruchWykonujeKomputerToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.ruchWykonujeKomputerToolStripMenuItem.Text = "Ruch wykonuje komputer";
            this.ruchWykonujeKomputerToolStripMenuItem.Click += new System.EventHandler(this.menuItem11_Click);
            // 
            // zasadyGryToolStripMenuItem
            // 
            this.zasadyGryToolStripMenuItem.Name = "zasadyGryToolStripMenuItem";
            this.zasadyGryToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.zasadyGryToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.zasadyGryToolStripMenuItem.Text = "Zasady gry";
            this.zasadyGryToolStripMenuItem.Click += new System.EventHandler(this.menuItem7_Click);
            // 
            // strategiaKomputeraToolStripMenuItem
            // 
            this.strategiaKomputeraToolStripMenuItem.Name = "strategiaKomputeraToolStripMenuItem";
            this.strategiaKomputeraToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.strategiaKomputeraToolStripMenuItem.Text = "Logika gry komputera";
            this.strategiaKomputeraToolStripMenuItem.Click += new System.EventHandler(this.menuItem14_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(226, 6);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(358, 362);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Reversi - 1 gracz";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion    

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem graToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nowaGraDlaJednegoGraczaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ¹zowyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rozpoczynaszTyzielonyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nowaGraDlaDwóchGraczyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem zamknijToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pomocToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem podpowiedŸRuchuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ruchWykonujeKomputerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zasadyGryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem strategiaKomputeraToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

