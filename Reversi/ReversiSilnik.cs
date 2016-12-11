#define PRIORYTETY

using System;

using System.Collections.Generic;

namespace Reversi
{
	// Opis klasy ReversiSilnik
	public class ReversiSilnik
	{
		public int planszaSzer=8;
		public int planszaWys=8;
		protected byte[,] plansza;
		protected byte nrGraczaWykonujacegoNastepnyRuch=1;

        public ReversiSilnik()
            : this(8,8)
        {
        }

		public ReversiSilnik(int planszaSzer,int planszaWys)
		{
            this.planszaSzer=planszaSzer;
            this.planszaWys=planszaWys;
            plansza=new byte[planszaSzer,planszaWys];

			for (int i=0; i<planszaSzer; i++)
				for (int j=0; j<planszaWys; j++)
					plansza[i,j]=0;

            plansza[planszaSzer/2-1,planszaWys/2-1]=1;
            plansza[planszaSzer/2,planszaWys/2]=1;
            plansza[planszaSzer/2-1,planszaWys/2]=2;
            plansza[planszaSzer/2,planszaWys/2-1]=2;

			
		}

		public byte StanPola(int poziomo,int pionowo)
		{
			if (poziomo<0 || poziomo>=planszaSzer || pionowo<0 || pionowo>=planszaWys)
				throw new Exception("Nieprawid³owe wspó³rzêdne pola");
			return plansza[poziomo,pionowo];
		}

		public byte NumerGraczaWykonujacegoNastepnyRuch()
		{
			return nrGraczaWykonujacegoNastepnyRuch;
		}

		public static string SymbolPola(int poziomo,int pionowo)
		{
			if (poziomo>25 || pionowo>8) return "("+poziomo.ToString()+","+pionowo.ToString()+")";
			return ""+"ABCDEFGHIJKLMNOPQRSTUVWXYZ"[poziomo]+"123456789"[pionowo];
		}

		private bool UstawPionek(int poziomo,int pionowo,bool testowanie)
		{
			//czy prawidlowe wspolrzedne pola
			if (poziomo<0 || poziomo>=planszaSzer || pionowo<0 || pionowo>=planszaWys)
				throw new Exception("Nieprawid³owe wspó³rzêdne pola");

			//czy pole nie jest juz zajete
			if (plansza[poziomo,pionowo]!=0) return false;

			bool poprawnyRuch=false;

			//petla po 8 kierunkach
			for (int kierunekPoziomo=-1; kierunekPoziomo<=1; kierunekPoziomo++)
			for (int kierunekPionowo=-1; kierunekPionowo<=1; kierunekPionowo++)
				{
				//wymuszenie pominiecia przypadku gdy obie zmienne maja wartosc 0
				if (kierunekPoziomo==0 && kierunekPionowo==0) continue;
				//szukanie pionkow gracza w jednym z 8 kierunkow
				int szukajPoziomo=poziomo;
				int szukajPionowo=pionowo;
				bool znalezionyPionekPrzeciwnika=false;
				bool znalezionyPionekGraczaWykonujacegoRuch=false;
				bool znalezionePustePole=false;
				bool osiagnietaKrawedzPlanszy=false;
				do
					{
					szukajPoziomo+=kierunekPoziomo;
					szukajPionowo+=kierunekPionowo;
					osiagnietaKrawedzPlanszy=(szukajPoziomo<0 || szukajPionowo<0 || szukajPoziomo>=planszaSzer || szukajPionowo>=planszaWys);
					if (!osiagnietaKrawedzPlanszy)
						{
						znalezionyPionekGraczaWykonujacegoRuch=(plansza[szukajPoziomo,szukajPionowo]==nrGraczaWykonujacegoNastepnyRuch);
						if (!znalezionePustePole) znalezionePustePole=(plansza[szukajPoziomo,szukajPionowo]==0);
						if (!znalezionyPionekPrzeciwnika) znalezionyPionekPrzeciwnika=(plansza[szukajPoziomo,szukajPionowo]==((nrGraczaWykonujacegoNastepnyRuch==1)?2:1));
						}
					}
				while(!(osiagnietaKrawedzPlanszy || znalezionyPionekGraczaWykonujacegoRuch));

				//sprawdzenie poprawnosci ruchu
				bool znalezione=(znalezionyPionekPrzeciwnika && znalezionyPionekGraczaWykonujacegoRuch && !znalezionePustePole);

				//odwrocenie pionkow spelnionego warunku
				if (znalezione)
					{
					if (!testowanie)
						{
						int maks_indeks=Math.Max(Math.Abs(szukajPoziomo-poziomo),Math.Abs(szukajPionowo-pionowo));
						for(int indeks=0;indeks<maks_indeks;indeks++)
						plansza[poziomo+indeks*kierunekPoziomo,pionowo+indeks*kierunekPionowo]=nrGraczaWykonujacegoNastepnyRuch;
						}
					poprawnyRuch=true;
					}

				}

			//jezeli ruch zostal wykonany to kolejnym ruchem jest ruch gracza wykonywujacego natepny ruch
			if (poprawnyRuch && !testowanie) nrGraczaWykonujacegoNastepnyRuch=(byte)((nrGraczaWykonujacegoNastepnyRuch==1)?2:1);

			return poprawnyRuch;
		}

		public bool UstawPionek(int poziomo,int pionowo)
		{
			return UstawPionek(poziomo,pionowo,false);
		}


		public bool CzyMozliwyRuch()
		{
			int iloscPolPoprawnych=0;
			for(int poziomo=0;poziomo<planszaSzer;poziomo++)
				for(int pionowo=0;pionowo<planszaWys;pionowo++)
					if (plansza[poziomo,pionowo]==0)
						if (UstawPionek(poziomo,pionowo,true))
							iloscPolPoprawnych++;

			return iloscPolPoprawnych>0;
		}

		public void Pass()
		{
			nrGraczaWykonujacegoNastepnyRuch=(byte)((nrGraczaWykonujacegoNastepnyRuch==1)?2:1);
		}

		private bool czyPat()
		{
			bool mozliwyRuchGracza1=CzyMozliwyRuch();
			Pass(); //zmiana gracza
			bool mozliwyRuchGracza2=CzyMozliwyRuch();
			Pass(); //powrot do wlasciwego gracza
			return (!mozliwyRuchGracza1 && !mozliwyRuchGracza2);
		}

		private bool czyWszystkiePolaZajete(int[] zliczenia)
		{
			if (zliczenia==null) zliczenia=new int[3];
			for(int poziomo=0;poziomo<planszaSzer;poziomo++)
				for(int pionowo=0;pionowo<planszaWys;pionowo++)
					zliczenia[plansza[poziomo,pionowo]]++;

			return zliczenia[0]==0;
		}

		public int CzyKoniec(int[] zliczenia)
		{

			int kod=czyPat()?2:0;
			kod=(czyWszystkiePolaZajete(zliczenia))?1:kod;
			return kod;
		}

		public byte this[int poziomo,int pionowo]
		{
			get
			{
				return StanPola(poziomo,pionowo);
			}

			set
			{
				UstawPionek(poziomo,pionowo);
			}
		}
	}

	public class ReversiSilnikAI : ReversiSilnik
	{
		#if PRIORYTETY
		public long[,] planszaPriorytety;
		#endif

        public ReversiSilnikAI(int planszaSzer,int planszaWys)
                :base(planszaSzer,planszaWys)
        {
            #if PRIORYTETY
		    planszaPriorytety=new long[planszaSzer,planszaWys];
		    #endif
        }

		private int UstawPionek(int poziomo,int pionowo,bool testowanie)
		{
			//czy prawidlowe wspolrzedne
			if (poziomo<0 || poziomo>=planszaSzer || pionowo<0 || pionowo>=planszaWys)
				throw new Exception("Nieprawid³owe wspó³rzêdne pola");

			//czy pole nie jest juz zajete
			if (plansza[poziomo,pionowo]!=0) return 0;

			bool poprawnyRuch=false;
			int odwroconePionkiPrzeciwnika=0;

			//petla po 8 kierunkach
			for (int kierunekPoziomo=-1; kierunekPoziomo<=1; kierunekPoziomo++)
			for (int kierunekPionowo=-1; kierunekPionowo<=1; kierunekPionowo++)
			{
			if (kierunekPoziomo==0 && kierunekPionowo==0) kierunekPionowo++; //wymuszenie pominiecia przypadku gdy obie zmienne rowne 0
			//szukanie pionkow gracza w jednym z 8 kierunkow
			int szukajPoziomo=poziomo;
			int szukajPionowo=pionowo;
			bool znalezionyPionekPrzeciwnika=false;
			bool znalezionyPionekGraczaWykonujacegoRuch=false;
			bool znalezionePustePole=false;
			bool osiagnietaKrawedzPlanszy=false;
			do
				{
				szukajPoziomo+=kierunekPoziomo;
				szukajPionowo+=kierunekPionowo;
				osiagnietaKrawedzPlanszy=(szukajPoziomo<0 || szukajPionowo<0 || szukajPoziomo>=planszaSzer || szukajPionowo>=planszaWys);
				if (!osiagnietaKrawedzPlanszy)
					{
					znalezionyPionekGraczaWykonujacegoRuch=(plansza[szukajPoziomo,szukajPionowo]==nrGraczaWykonujacegoNastepnyRuch);
					if (!znalezionePustePole) znalezionePustePole=(plansza[szukajPoziomo,szukajPionowo]==0);
					if (!znalezionyPionekPrzeciwnika) znalezionyPionekPrzeciwnika=(plansza[szukajPoziomo,szukajPionowo]==((nrGraczaWykonujacegoNastepnyRuch==1)?2:1));
					}
				}
			while(!(osiagnietaKrawedzPlanszy || znalezionyPionekGraczaWykonujacegoRuch));

			//sprawdzenie warunku poprawnosci ruchu gracza
			bool znalezione=(znalezionyPionekPrzeciwnika && znalezionyPionekGraczaWykonujacegoRuch && !znalezionePustePole);

			//odwrocenie pionkow w przypadku spelnionego warunku
			if (znalezione)
				{
				int maks_indeks=Math.Max(Math.Abs(szukajPoziomo-poziomo),Math.Abs(szukajPionowo-pionowo));
				odwroconePionkiPrzeciwnika+=maks_indeks;
				if (!testowanie)
					for(int indeks=0;indeks<maks_indeks;indeks++)
						plansza[poziomo+indeks*kierunekPoziomo,pionowo+indeks*kierunekPionowo]=nrGraczaWykonujacegoNastepnyRuch;
				poprawnyRuch=true;
				}

			}

			//jezeli ruch zostal wykonany - zmiana gracza
			if (poprawnyRuch && !testowanie) nrGraczaWykonujacegoNastepnyRuch=(byte)((nrGraczaWykonujacegoNastepnyRuch==1)?2:1);

			//zwrocenie poprawnego ruchu
			return odwroconePionkiPrzeciwnika;
		}

		#region AI
		//struktura do przechowywania informacji o mozliwym ruchu – polu planszy
		private struct MozliwyRuch
		{
			public int poziomo;
			public int pionowo;
			public int priorytet;

			public MozliwyRuch(int poziomo,int pionowo,int priorytet)
			{
				this.poziomo=poziomo;
				this.pionowo=pionowo;
				this.priorytet=priorytet;
			}
		}

		//klasa potrzebna do sortowania ruchow wzgledem priorytetow
		private class PorownywaczRuchow : IComparer<MozliwyRuch>
		{
            public int Compare(MozliwyRuch ruch1,MozliwyRuch ruch2)
			{
				//return ((MozliwyRuch)ruch2).priorytet-((MozliwyRuch)ruch1).priorytet;
                return ruch2.priorytet-ruch1.priorytet;
			}
		}


		//zasadnicza metoda AI
		public int[] ProponujNajlepszyRuch()
		{
			//deklaracja tablicy mozliwych ruchow
            List<MozliwyRuch> mozliweRuchy=new List<ReversiSilnikAI.MozliwyRuch>();

			int skokPriorytetu=planszaSzer*planszaWys;

			//poszukiwanie mozliwych ruchow
			for(int poziomo=0;poziomo<planszaSzer;poziomo++)
				for(int pionowo=0;pionowo<planszaWys;pionowo++)
					if (plansza[poziomo,pionowo]==0)
						{
						int priorytet=UstawPionek(poziomo,pionowo,true);
						if (priorytet>0)
							{
							MozliwyRuch mr=new MozliwyRuch(poziomo,pionowo,priorytet);

							//pole w rogu +
							if ((mr.poziomo==0 || mr.poziomo==planszaSzer-1) && (mr.pionowo==0 || mr.pionowo==planszaWys-1))
								mr.priorytet+=skokPriorytetu*skokPriorytetu;

							//pole sasiadujace z rogiem na przekatnych -
							if ((mr.poziomo==1 || mr.poziomo==planszaSzer-2) && (mr.pionowo==1 || mr.pionowo==planszaWys-2))
								mr.priorytet-=skokPriorytetu*skokPriorytetu;

							//pole sasiadujace z rogiem na w pionie -
							if ((mr.poziomo==0 || mr.poziomo==planszaSzer-1) && (mr.pionowo==1 || mr.pionowo==planszaWys-2))
								mr.priorytet-=skokPriorytetu*skokPriorytetu;

							//pole sasiadujace z rogiem na w poziomie -
							if ((mr.poziomo==1 || mr.poziomo==planszaSzer-2) && (mr.pionowo==0 || mr.pionowo==planszaWys-1))
								mr.priorytet-=skokPriorytetu*skokPriorytetu;

							//pole na brzegu +
							if (mr.poziomo==0 || mr.poziomo==planszaSzer-1 || mr.pionowo==0 || mr.pionowo==planszaWys-1)
								mr.priorytet+=skokPriorytetu;

							//pole sasiadujace z brzegiem -
							if (mr.poziomo==1 || mr.poziomo==planszaSzer-2 || mr.pionowo==1 || mr.pionowo==planszaWys-2)
								mr.priorytet-=skokPriorytetu;

							//dodanie do listy
							mozliweRuchy.Add(mr);
							}
						}

			#if PRIORYTETY
            for (int i=0;i<planszaSzer;i++)
                for (int j=0;j<planszaWys;j++)
                    planszaPriorytety[i,j]=0;

            foreach (MozliwyRuch mozliwyRuch in mozliweRuchy)
            {
                planszaPriorytety[mozliwyRuch.poziomo,mozliwyRuch.pionowo]=mozliwyRuch.priorytet;
            }
			#endif

			//wybor pola o najwiekszym priorytecie
			mozliweRuchy.Sort(new PorownywaczRuchow());
			MozliwyRuch najlepszyMozliwyRuch=(MozliwyRuch)mozliweRuchy[0];
			int[] najlepszyInt={najlepszyMozliwyRuch.poziomo,najlepszyMozliwyRuch.pionowo};
			return najlepszyInt;
		}
	#endregion
	}

}

