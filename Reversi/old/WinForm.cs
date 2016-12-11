#if DEBUG
	#warning Kompilacja wersji Debug
#else
	#warning Kompilacja wersji Release
#endif

#if PRIORYTETY //zdefiniowane w opcjach projektu
	#warning Kompilacja wersji Priorytety
#endif


using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Reversi
{
	/// <summary>
	/// Summary description for WinForm.
	/// </summary>
	public class WinForm : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components;

		private Button[,] plansza=new Button[ReversiSilnikAI.planszaSzer,ReversiSilnikAI.planszaWys];
		private ReversiSilnikAI silnik=new ReversiSilnikAI();
		private Color[] kolory={Color.Ivory, Color.Green, Color.Sienna, Color.Black};
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox listBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem9;

		//komputer ma numer 2 i gra br¹zowymi
		private bool graPrzeciwkoKomputerowi=true;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.Timer opozniaczRuchuKomputera;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.MenuItem menuItem14;

		public WinForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//ustalanie rozmiaru przycisku
			const int rozmiarPlanszy=400;
			int przyciskSzer=rozmiarPlanszy/ReversiSilnikAI.planszaSzer;
			int przyciskWys=rozmiarPlanszy/ReversiSilnikAI.planszaWys;

			//dopasowywanie okna do calkowitej ilosci przyciskow
			int roznicaSzer=przyciskSzer*ReversiSilnikAI.planszaSzer-this.ClientSize.Width;
			int roznicaWys=przyciskWys*ReversiSilnikAI.planszaWys-this.ClientSize.Height;
			this.Width+=roznicaSzer+panel1.Width+1;
			this.Height+=roznicaWys+1;

            linkLabel1.Top=panel1.ClientSize.Height-linkLabel1.Height-10;

			for (int i=0; i<ReversiSilnikAI.planszaSzer; i++)
				for (int j=0; j<ReversiSilnikAI.planszaWys; j++)
					{
					Button pole=new Button();
					pole.SetBounds(i*przyciskSzer,1+j*przyciskWys,przyciskSzer,przyciskWys);
					pole.Parent=this;
					pole.Click+=new System.EventHandler(this.kliknieciePolaPlanszy);
					plansza[i,j]=pole;
					}

			uzgodnijWygladPlanszy();

			/*
			//test
			silnik.UstawPionek(2,4);
			uzgodnijWygladPlanszy();
			*/
			linkLabel1.Links.Add(0,linkLabel1.Text.Length,"http://www.phys.uni.torun.pl/~jacek");

			//przeniesione, zeby rozmiar formy byl dobrze ustalony
			this.Menu = this.mainMenu1;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose (bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
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
            this.components=new System.ComponentModel.Container();
            this.panel1=new System.Windows.Forms.Panel();
            this.linkLabel1=new System.Windows.Forms.LinkLabel();
            this.label6=new System.Windows.Forms.Label();
            this.label5=new System.Windows.Forms.Label();
            this.label4=new System.Windows.Forms.Label();
            this.label3=new System.Windows.Forms.Label();
            this.listBox2=new System.Windows.Forms.ListBox();
            this.label2=new System.Windows.Forms.Label();
            this.listBox1=new System.Windows.Forms.ListBox();
            this.button1=new System.Windows.Forms.Button();
            this.label1=new System.Windows.Forms.Label();
            this.mainMenu1=new System.Windows.Forms.MainMenu(this.components);
            this.menuItem1=new System.Windows.Forms.MenuItem();
            this.menuItem5=new System.Windows.Forms.MenuItem();
            this.menuItem12=new System.Windows.Forms.MenuItem();
            this.menuItem13=new System.Windows.Forms.MenuItem();
            this.menuItem2=new System.Windows.Forms.MenuItem();
            this.menuItem3=new System.Windows.Forms.MenuItem();
            this.menuItem4=new System.Windows.Forms.MenuItem();
            this.menuItem6=new System.Windows.Forms.MenuItem();
            this.menuItem10=new System.Windows.Forms.MenuItem();
            this.menuItem11=new System.Windows.Forms.MenuItem();
            this.menuItem7=new System.Windows.Forms.MenuItem();
            this.menuItem14=new System.Windows.Forms.MenuItem();
            this.menuItem8=new System.Windows.Forms.MenuItem();
            this.menuItem9=new System.Windows.Forms.MenuItem();
            this.opozniaczRuchuKomputera=new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle=System.Windows.Forms.BorderStyle.Fixed3D;
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
            this.panel1.Dock=System.Windows.Forms.DockStyle.Right;
            this.panel1.Location=new System.Drawing.Point(252,0);
            this.panel1.Name="panel1";
            this.panel1.RightToLeft=System.Windows.Forms.RightToLeft.No;
            this.panel1.Size=new System.Drawing.Size(106,362);
            this.panel1.TabIndex=0;
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor=System.Drawing.SystemColors.ControlText;
            this.linkLabel1.LinkColor=System.Drawing.SystemColors.ControlText;
            this.linkLabel1.Location=new System.Drawing.Point(7,243);
            this.linkLabel1.Name="linkLabel1";
            this.linkLabel1.Size=new System.Drawing.Size(93,14);
            this.linkLabel1.TabIndex=9;
            this.linkLabel1.TabStop=true;
            this.linkLabel1.Text="Jacek Matulewski";
            this.linkLabel1.VisitedLinkColor=System.Drawing.SystemColors.ControlText;
            this.linkLabel1.LinkClicked+=new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label6
            // 
            this.label6.Location=new System.Drawing.Point(67,222);
            this.label6.Name="label6";
            this.label6.Size=new System.Drawing.Size(26,14);
            this.label6.TabIndex=8;
            this.label6.Text="2";
            // 
            // label5
            // 
            this.label5.Location=new System.Drawing.Point(67,208);
            this.label5.Name="label5";
            this.label5.Size=new System.Drawing.Size(26,14);
            this.label5.TabIndex=7;
            this.label5.Text="2";
            // 
            // label4
            // 
            this.label4.ForeColor=System.Drawing.Color.Sienna;
            this.label4.Location=new System.Drawing.Point(7,222);
            this.label4.Name="label4";
            this.label4.Size=new System.Drawing.Size(46,14);
            this.label4.TabIndex=6;
            this.label4.Text="Br¹zowy";
            // 
            // label3
            // 
            this.label3.ForeColor=System.Drawing.Color.Green;
            this.label3.Location=new System.Drawing.Point(7,208);
            this.label3.Name="label3";
            this.label3.Size=new System.Drawing.Size(40,14);
            this.label3.TabIndex=5;
            this.label3.Text="Zielony";
            // 
            // listBox2
            // 
            this.listBox2.BackColor=System.Drawing.SystemColors.Control;
            this.listBox2.ForeColor=System.Drawing.Color.Sienna;
            this.listBox2.Location=new System.Drawing.Point(53,97);
            this.listBox2.Name="listBox2";
            this.listBox2.Size=new System.Drawing.Size(40,82);
            this.listBox2.TabIndex=4;
            // 
            // label2
            // 
            this.label2.Location=new System.Drawing.Point(7,76);
            this.label2.Name="label2";
            this.label2.Size=new System.Drawing.Size(80,14);
            this.label2.TabIndex=3;
            this.label2.Text="Ostatnie ruchy:";
            // 
            // listBox1
            // 
            this.listBox1.BackColor=System.Drawing.SystemColors.Control;
            this.listBox1.ForeColor=System.Drawing.Color.Green;
            this.listBox1.Location=new System.Drawing.Point(7,97);
            this.listBox1.Name="listBox1";
            this.listBox1.Size=new System.Drawing.Size(40,82);
            this.listBox1.TabIndex=2;
            // 
            // button1
            // 
            this.button1.Enabled=false;
            this.button1.Location=new System.Drawing.Point(33,28);
            this.button1.Name="button1";
            this.button1.Size=new System.Drawing.Size(34,34);
            this.button1.TabIndex=1;
            this.button1.Click+=new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Location=new System.Drawing.Point(7,7);
            this.label1.Name="label1";
            this.label1.Size=new System.Drawing.Size(80,14);
            this.label1.TabIndex=0;
            this.label1.Text="Nastêpny ruch:";
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem6});
            // 
            // menuItem1
            // 
            this.menuItem1.Index=0;
            this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem5,
            this.menuItem2,
            this.menuItem3,
            this.menuItem4});
            this.menuItem1.Text="Gra";
            // 
            // menuItem5
            // 
            this.menuItem5.Index=0;
            this.menuItem5.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem12,
            this.menuItem13});
            this.menuItem5.Text="Nowa gra dla jednego gracza";
            // 
            // menuItem12
            // 
            this.menuItem12.Index=0;
            this.menuItem12.Shortcut=System.Windows.Forms.Shortcut.F2;
            this.menuItem12.Text="Rozpoczyna komputer (br¹zowy)";
            this.menuItem12.Click+=new System.EventHandler(this.menuItem12_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.Index=1;
            this.menuItem13.Shortcut=System.Windows.Forms.Shortcut.F3;
            this.menuItem13.Text="Rozpoczynasz Ty (zielony)";
            this.menuItem13.Click+=new System.EventHandler(this.menuItem5_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index=1;
            this.menuItem2.Shortcut=System.Windows.Forms.Shortcut.F4;
            this.menuItem2.Text="Nowa gra dla dwóch graczy";
            this.menuItem2.Click+=new System.EventHandler(this.menuItem2_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index=2;
            this.menuItem3.Text="-";
            // 
            // menuItem4
            // 
            this.menuItem4.Index=3;
            this.menuItem4.Text="Zamknij";
            this.menuItem4.Click+=new System.EventHandler(this.menuItem4_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index=1;
            this.menuItem6.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem10,
            this.menuItem11,
            this.menuItem7,
            this.menuItem14,
            this.menuItem8,
            this.menuItem9});
            this.menuItem6.Text="Pomoc";
            // 
            // menuItem10
            // 
            this.menuItem10.Index=0;
            this.menuItem10.Shortcut=System.Windows.Forms.Shortcut.F5;
            this.menuItem10.Text="PodpowiedŸ ruchu";
            this.menuItem10.Click+=new System.EventHandler(this.menuItem10_Click);
            // 
            // menuItem11
            // 
            this.menuItem11.Index=1;
            this.menuItem11.Shortcut=System.Windows.Forms.Shortcut.F6;
            this.menuItem11.Text="Ruch wykonany przez komputer";
            this.menuItem11.Click+=new System.EventHandler(this.menuItem11_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index=2;
            this.menuItem7.Text="Zasady gry";
            this.menuItem7.Click+=new System.EventHandler(this.menuItem7_Click);
            // 
            // menuItem14
            // 
            this.menuItem14.Index=3;
            this.menuItem14.Text="Strategia komputera";
            this.menuItem14.Click+=new System.EventHandler(this.menuItem14_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index=4;
            this.menuItem8.Text="-";
            // 
            // menuItem9
            // 
            this.menuItem9.Index=5;
            this.menuItem9.Text="O programie ...";
            this.menuItem9.Click+=new System.EventHandler(this.menuItem9_Click);
            // 
            // opozniaczRuchuKomputera
            // 
            this.opozniaczRuchuKomputera.Interval=300;
            this.opozniaczRuchuKomputera.Tick+=new System.EventHandler(this.opozniaczRuchuKomputera_Tick);
            // 
            // WinForm
            // 
            this.AutoScaleBaseSize=new System.Drawing.Size(5,13);
            this.ClientSize=new System.Drawing.Size(358,362);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle=System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox=false;
            this.Name="WinForm";
            this.Text="Reversi - 1 gracz";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.Run(new WinForm());
		}

		#region Metody pomocnicze
		private void uzgodnijWygladPlanszy()
		{
			for (int i=0; i<ReversiSilnikAI.planszaSzer; i++)
				for (int j=0; j<ReversiSilnikAI.planszaWys; j++)
					{
					//plansza[i,j].Text=silnik.StanPola(i,j).ToString();
					//plansza[i,j].BackColor=kolory[silnik.StanPola(i,j)];
					plansza[i,j].BackColor=kolory[silnik[i,j]];
					#if PRIORYTETY
					plansza[i,j].Text="";
					#endif
					}

			//this.Text="Nastêpny ruch gracz nr "+silnik.NumerGraczaWykonujacegoNastepnyRuch();
			button1.BackColor=kolory[silnik.NumerGraczaWykonujacegoNastepnyRuch()];
		}

		private void ustawieniePlanszyOdNowa()
		{
			silnik=new ReversiSilnikAI(); //stary obiekt zostanie automatycznie usuniety
			listBox1.Items.Clear();
			listBox2.Items.Clear();
			label5.Text="2";
			label6.Text="2";
			uzgodnijWygladPlanszy();
		}

		private void ruchKomputera()
		{
			int[] wspolrzedne=silnik.ProponujNajlepszyRuch();
			kliknieciePolaPlanszy(plansza[wspolrzedne[0],wspolrzedne[1]],null);
		}

		//************************************//
		// G£ÓWNA METODA "RZ¥DZ¥CA" PROGRAMEM //
		//************************************//
		private void kliknieciePolaPlanszy(object sender,EventArgs e)
		{
			//szukamy pola planszy odpowiadaj¹cego kliknietemu przyciskowi
			int kliknietePoziomo=-1,kliknietePionowo=-1;
			for(int poziomo=0;poziomo<ReversiSilnikAI.planszaSzer;poziomo++)
				for(int pionowo=0;pionowo<ReversiSilnikAI.planszaWys;pionowo++)
					if (sender==plansza[poziomo,pionowo])
						{
						kliknietePoziomo=poziomo;
						kliknietePionowo=pionowo;
						}

			//jezeli nie znaleziony - zglaszanie bledu
			if (kliknietePoziomo==-1 || kliknietePionowo==-1)
				throw new Exception("Nie zidentyfikowane pole planszy");

			//wykonanie ruchu
			int zapamietanyNumerGracza=silnik.NumerGraczaWykonujacegoNastepnyRuch();
			if (silnik.UstawPionek(kliknietePoziomo,kliknietePionowo))
				{
				uzgodnijWygladPlanszy();
				//listBox1.Items.Add(""+zapamietanyNumerGracza+": "+kliknietePoziomo+", "+kliknietePionowo);
				switch(zapamietanyNumerGracza)
					{
					case 1: listBox1.Items.Add(ReversiSilnikAI.SymbolPola(kliknietePoziomo,kliknietePionowo)); break;
					case 2: listBox2.Items.Add(ReversiSilnikAI.SymbolPola(kliknietePoziomo,kliknietePionowo)); break;
					}
				listBox1.SelectedIndex=listBox1.Items.Count-1;
				listBox2.SelectedIndex=listBox2.Items.Count-1;
				}

			//sprawdzenie czy gra zakonczona
			int[] zliczenia=new int[3];
			int koniec_kod=silnik.CzyKoniec(zliczenia);
			label5.Text=zliczenia[1].ToString();
			label6.Text=zliczenia[2].ToString();
			if (koniec_kod==2) MessageBox.Show("Obaj gracze nie mog¹ wykonaæ ruchu");
			if (koniec_kod>0)
				{
				//informacja o wygranym
				MessageBox.Show("Wygra³ gracz "+((zliczenia[1]>zliczenia[2])?"zielony":"br¹zowy"),"Reversi");
				if (MessageBox.Show(this,"Czy rozpocz¹æ grê od nowa?","Reversi",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
					{
					//rozpoczecie gry od nowa
					ustawieniePlanszyOdNowa();
					}
					else
					{
					this.Close();
					}
				return;
				}


			//sprawdzenie czy kolejny gracz ma mozliwosc ruchu
			if (!silnik.CzyMozliwyRuch())
				{
				MessageBox.Show("Gracz "+((silnik.NumerGraczaWykonujacegoNastepnyRuch()==1)?"zielony":"br¹zowy")+" zmuszony jest do oddania ruchu");
				silnik.Pass();
				uzgodnijWygladPlanszy();
				//jezeli komputer, to nie powinno byc return
				//(komputer zawsze br¹zowy)
				if (!(graPrzeciwkoKomputerowi && silnik.NumerGraczaWykonujacegoNastepnyRuch()==2)) return;
				}

			//Ruch komputera (gracz nr 2)
			if (graPrzeciwkoKomputerowi && silnik.NumerGraczaWykonujacegoNastepnyRuch()==2)
				{
				opozniaczRuchuKomputera.Enabled=true; //tam jest wywolywany ruch komputera z jednosekundowym opoznieniem
				//ruchKomputera();
				}
		}
		#endregion

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start(e.Link.LinkData as string);
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			ruchKomputera();
		}

		private void menuItem7_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show(
			"W grze Reversi gracze zajmuj¹ na przemian pola planszy przejmuj¹c przy tym wszystkie pola przeciwnika znajduj¹ce siê miêdzy nowo zajêtym polem, a innymi polami gracza wykonuj¹cego ruch. Celem gry jest zdobycie wiêkszej iloœci pól ni¿ przeciwnik.\n"+
			"Gracz mo¿e zaj¹æ jedynie takie pole, które pozwoli mu przej¹æ przynajmniej jedno pole przeciwnika. Je¿eli takiego pola nie ma, musi oddaæ ruch.\n"+
			"Gra koñczy siê w momencie zajêcia wszystkich pól lub gdy ¿aden z graczy nie mo¿e wykonaæ ruchu.\n",
			"Reversi - Zasady gry");
		}

		private void menuItem14_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show(
			"Komputer kieruje siê nastêpuj¹cymi priorytetami (od najwy¿szego):\n"+
			"1. Ustawiæ pionek w rogu.\n"+
			"2. Unikaæ ustawienia pionka tu¿ przy rogu.\n"+
			"3. Ustawiæ pionek przy krawêdzi planszy.\n"+
			"4. Unikaæ ustawienia pionka w wierszu lub kolumnie oddalonej o jedno pole od krawêdzi planszy.\n"+
			"5. Wybieraæ pole, w wyniku którego zdobyta zostanie najwiêksza liczba pól przeciwnika.\n",
			"Reversi - Strategia komputera");
		}

		private void menuItem9_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("Reversi (wersja "+Application.ProductVersion+")\n(c) Jacek Matulewski 2004\n\nTesty: Kazimierz Matulewski\n\nNajnowsz¹ wersjê mo¿na pobraæ ze strony\nhttp://www.phys.uni.torun.pl/~jacek/download/     ","Reversi - Informacje o programie");
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			graPrzeciwkoKomputerowi=false;
			ustawieniePlanszyOdNowa();
			this.Text="Reversi - 2 graczy";
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			graPrzeciwkoKomputerowi=true;
			ustawieniePlanszyOdNowa();
			this.Text="Reversi - 1 gracz";
		}

		private void menuItem10_Click(object sender, System.EventArgs e)
		{
			int[] wspolrzedne=silnik.ProponujNajlepszyRuch();

			Color kolorGracza=(silnik.NumerGraczaWykonujacegoNastepnyRuch()==1)?Color.Green:Color.Sienna;
			Color kolorTla=Color.Ivory;

			#if PRIORYTETY
			int redP=(kolorGracza.R+3*kolorTla.R)/4;
			int greenP=(kolorGracza.G+3*kolorTla.G)/4;
			int blueP=(kolorGracza.B+3*kolorTla.B)/4;
			Color kolorMozliwychRuchow=Color.FromArgb(redP,greenP,blueP);

			for (int i=0; i<ReversiSilnikAI.planszaSzer; i++)
				for (int j=0; j<ReversiSilnikAI.planszaWys; j++)
					{
					long priorytet=silnik.planszaPriorytety[i,j];
					plansza[i,j].Text=priorytet.ToString();
					if (priorytet!=0) plansza[i,j].BackColor=kolorMozliwychRuchow;
					}
			#endif

			//kolorPodpowiedzi.
			int red=(kolorGracza.R+kolorTla.R)/2;
			int green=(kolorGracza.G+kolorTla.G)/2;
			int blue=(kolorGracza.B+kolorTla.B)/2;
			Color kolorPodpowiedzi=Color.FromArgb(red,green,blue);

			plansza[wspolrzedne[0],wspolrzedne[1]].BackColor=kolorPodpowiedzi;
		}

		private void opozniaczRuchuKomputera_Tick(object sender, System.EventArgs e)
		{
			opozniaczRuchuKomputera.Enabled=false;
			if (silnik.CzyKoniec(null)==0) ruchKomputera();
		}

		private void menuItem11_Click(object sender, System.EventArgs e)
		{
			if (opozniaczRuchuKomputera.Enabled) return;
			if (silnik.CzyKoniec(null)==0) ruchKomputera();
		}

		private void menuItem12_Click(object sender, System.EventArgs e)
		{
			graPrzeciwkoKomputerowi=true;
			ustawieniePlanszyOdNowa();
			this.Text="Reversi - 1 gracz";

			//Ruch wykonuje komputer
			silnik.Pass();
			this.ruchKomputera(); //oddaje pierwszy ruch komputerowi
		}


	}
}


