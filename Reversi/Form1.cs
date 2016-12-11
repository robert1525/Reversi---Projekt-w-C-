#if DEBUG
#else
#warning Kompilacja wersji Release
#endif

#define PRIORYTETY

#if PRIORYTETY

#endif


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Reversi
{
    public partial class Form1 : Form
    {		
		private ReversiSilnikAI silnik=null;
        private Button[,] plansza=null;
		private Color[] kolory={Color.Ivory, Color.Green, Color.Sienna, Color.Black};
        private bool plaskiInterfejs=false;
        private bool pokazPriorytety=false;
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

        public Form1(string[] args)
		{           

			InitializeComponent();

            int planszaSzer=8;
            int planszaWys=8;

            //Parametry z linii polecen
			if (args!=null)
			{
				foreach (string argv in args)
				{
                    if (argv[0]=='/')
                    switch(argv[1])
                    {
                        case 'f': plaskiInterfejs=true; break;
                        case 'p': pokazPriorytety=true; break;
                        case 'w': planszaSzer=int.Parse(argv.Substring(2)); break;
                        case 'h': planszaWys=int.Parse(argv.Substring(2)); break;
                    }
				}
            }

            if ((planszaSzer<3) || (planszaWys<3))
            {
                MessageBox.Show("Podany rozmiar planszy "+planszaSzer+"x"+planszaWys+" jest zbyt ma³y do gry.\nPrzywracam rozmiar domyœlny 8x8");
                planszaSzer=8;
                planszaWys=8;
            }

            //inicjacja pol zaleznych od rozmiaru planszy
            silnik=new ReversiSilnikAI(planszaSzer,planszaWys);
            plansza=new Button[silnik.planszaSzer,silnik.planszaWys];            
            
            if (plaskiInterfejs)
            {
                button1.FlatStyle=FlatStyle.Flat;
                menuStrip1.Visible=false;
                menuStrip1=null;
            }
            else
            {
                mainMenu1=null;
            }

			//ustalanie rozmiaru przycisku
			const int rozmiarPlanszy=400;
			int przyciskSzer=rozmiarPlanszy/silnik.planszaSzer;
			int przyciskWys=rozmiarPlanszy/silnik.planszaWys;

			//dopasowywanie okna do calkowitej ilosci przyciskow
            int wysokoscMenu=(menuStrip1!=null)?menuStrip1.Height:0;
			int roznicaSzer=przyciskSzer*silnik.planszaSzer-this.ClientSize.Width;
			int roznicaWys=przyciskWys*silnik.planszaWys-this.ClientSize.Height;
			this.Width+=roznicaSzer+panel1.Width+1;
            this.Height+=roznicaWys+1+wysokoscMenu;

            linkLabel1.Top=panel1.ClientSize.Height-linkLabel1.Height-10;

			for (int i=0; i<silnik.planszaSzer; i++)
				for (int j=0; j<silnik.planszaWys; j++)
					{
					Button pole=new Button();
                    pole.SetBounds(i*przyciskSzer,1+j*przyciskWys+wysokoscMenu,przyciskSzer,przyciskWys);
					pole.Parent=this;
                    if (plaskiInterfejs) pole.FlatStyle=FlatStyle.Flat;
					pole.Click+=new System.EventHandler(this.kliknieciePolaPlanszy);
					plansza[i,j]=pole;
					}

			uzgodnijWygladPlanszy();

			this.Menu = this.mainMenu1;
		}

		#region Metody pomocnicze
		private void uzgodnijWygladPlanszy()
		{
			for (int i=0; i<silnik.planszaSzer; i++)
				for (int j=0; j<silnik.planszaWys; j++)
					{
					plansza[i,j].BackColor=kolory[silnik[i,j]];
					#if PRIORYTETY
                    if (pokazPriorytety) plansza[i,j].Text="";
					#endif
					}

			button1.BackColor=kolory[silnik.NumerGraczaWykonujacegoNastepnyRuch()];
		}

		private void ustawieniePlanszyOdNowa()
		{
			silnik=new ReversiSilnikAI(silnik.planszaSzer,silnik.planszaWys); //stary obiekt zostanie automatycznie usuniety
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

		private void kliknieciePolaPlanszy(object sender,EventArgs e)
		{
			//szukamy pola planszy odpowiadaj¹cego kliknietemu przyciskowi
			int kliknietePoziomo=-1,kliknietePionowo=-1;
			for(int poziomo=0;poziomo<silnik.planszaSzer;poziomo++)
				for(int pionowo=0;pionowo<silnik.planszaWys;pionowo++)
					if (sender==plansza[poziomo,pionowo])
						{
						kliknietePoziomo=poziomo;
						kliknietePionowo=pionowo;
						}

			//jezeli nie znaleziony - blad
			if (kliknietePoziomo==-1 || kliknietePionowo==-1)
				throw new Exception("Nie zidentyfikowane pole planszy");

			//wykonanie ruchu
			int zapamietanyNumerGracza=silnik.NumerGraczaWykonujacegoNastepnyRuch();
			if (silnik.UstawPionek(kliknietePoziomo,kliknietePionowo))
				{
				uzgodnijWygladPlanszy();
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
                    if (zliczenia[1]==zliczenia[2]) MessageBox.Show("Remis - obaj gracze zajêli tak¹ sam¹ iloœæ pól","Reversi");
                    else MessageBox.Show("Wygra³ gracz "+((zliczenia[1]>zliczenia[2])?"zielony":"br¹zowy"),"Reversi");
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
				//komputer zawsze br¹zowy
				if (!(graPrzeciwkoKomputerowi && silnik.NumerGraczaWykonujacegoNastepnyRuch()==2)) return;
				}

			//Ruch komputera (gracz nr 2)
			if (graPrzeciwkoKomputerowi && silnik.NumerGraczaWykonujacegoNastepnyRuch()==2)
				{
				opozniaczRuchuKomputera.Enabled=true; //tam jest wywolywany ruch komputera
				}

             if (plaskiInterfejs)
             {
                button1.Enabled=true;
                button1.Focus();
                button1.Enabled=false;
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
            "Ka¿dy z dwóch graczy ma do dyspozycji pionki: jeden koloru zielonego, drugi -- br¹zowego. Gracze uk³adaj¹ na przemian pionki w³asnego koloru na wolnych polach planszy do momentu, a¿ plansza zostanie ca³kowicie zape³niona lub ¿aden z graczy nie bêdzie móg³ wykonaæ dozwolonego ruchu.\n" +
            "Dozwolony ruch to taki, w którym pionek jest u³o¿ony na polu, które znajduje siê w linii (poziomej, pionowej lub ukoœnej) z innym pionkiem gracza wykonuj¹cego ruch, i na dok³adnie wszystkich polach pomiêdzy wybranym polem a tym pionkiem znajduj¹ siê pionki przeciwnika. " +
            "Wygrywa ten z graczy, którego wiêksza liczba pionków znajduje siê na planszy po zakoñczeniu gry, jeœli liczba pionków graczy jest jednakowa, nastêpuje remis.\n",
			"Zasady gry");
		}

		private void menuItem14_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show(
			"Komputer kieruje siê nastêpuj¹cymi priorytetami (od najwy¿szego):\n"+
            "1. Wstawianie pionka przy krawêdzi ca³ej planszy.\n" +
            "2. Wstawianie pionka w rogu.\n" +
            "3. Unikaæ wstawienia pionka poziomo lub pionowo w oddalonej o jedno pole od krawêdzi ca³ej planszy.\n" +
            "4. Unikaæ wstawienia pionka tu¿ przy rogu.\n" +
			"5. Wybieranie pola, w wyniku którego zostanie zajêta najwiêksza liczba pól.\n",
			"Reversi - Logika gry komputera");
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

            Color kolorGracza=(silnik.NumerGraczaWykonujacegoNastepnyRuch()==1)?kolory[1]:kolory[2];
            Color kolorTla=kolory[0];

			#if PRIORYTETY
            if (pokazPriorytety)
            {
                int redP=(kolorGracza.R+3*kolorTla.R)/4;
                int greenP=(kolorGracza.G+3*kolorTla.G)/4;
                int blueP=(kolorGracza.B+3*kolorTla.B)/4;
                Color kolorMozliwychRuchow=Color.FromArgb(redP,greenP,blueP);

                for (int i=0;i<silnik.planszaSzer;i++)
                    for (int j=0;j<silnik.planszaWys;j++)
                    {
                        long priorytet=silnik.planszaPriorytety[i,j];
                        if (priorytet!=0)
                        {
                            plansza[i,j].Text=priorytet.ToString();
                            plansza[i,j].BackColor=kolorMozliwychRuchow;
                        }
                    }
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

        private void Form1_FormClosed(object sender,FormClosedEventArgs e)
        {
            //dzieki temu nie ma efektu znikajacego menu
            this.Visible=false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void graToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}