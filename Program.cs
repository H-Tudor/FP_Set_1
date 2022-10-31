using System.ComponentModel;
using System.Security.Cryptography;

internal class Program {
	private static void Main(string[] args) {
		Console.WriteLine("Fundamentele Programarii - Setul 1 de probleme:\n" +
			"\t1. Ecuatia de gradul 1\n" +
			"\t2. Ecuatia de gradul 2\n" +
			"\t3. K divide N\n" +
			"\t4. An bisect\n" +
			"\t5. A K-a cifra de la sfarsitul unui numar\n" +
			"\t6. Numerele a, b, c pot fi laturile unui triunghi\n" +
			"\t7. Inversarea a 2 valori a si b\n" +
			"\t8. Inversarea a 2 valori a si b fara crearea unor noi variabile\n" +
			"\t9. Toti divizorii lui N\n" +
			"\t10. N prim\n" +
			"\t11. Cifrele lui N in ordine inversa\n" +
			"\t12. Cate numere divizibile cu N sunt in intervalul [A, B]\n" +
			"\t13. Toti anii bisecti din intervalul [A, B]\n" +
			"\t14. N palindrom\n" +
			"\t15. Afisati 3 numere in ordine crescatoare\n" +
			"\t16. Afisati 5 numere in ordine crescatoare fara tablouri\n" +
			"\t17. Cel mai mare divizor comun si cel mai mic multiplu comun a doua numere\n" +
			"\t18. Descompunerea in factori primi ai unui număr n\n" +
			"\t19. N format doar cu 2 cifre care se pot repeta\n" +
			"\t20. Fractia m/n in format zecimal, cu perioada intre paranteze\n" +
			"\t21. N intre 1 si 1024 prin intrebari" +
			"\t0. Exit program\n");

		bool ok = true;
		while(ok == true) {
			int[] src = IntInput("Introduceti numarul problemei: ");
			int opt = src == null ? 0 : src[0];
			switch(opt) {
				case 1:		Ec1();			break;
				case 2:		Ec2();			break;
				case 3:		NdivK();		break;
				case 4:		Bisect();		break;
				case 5:		KcifN();		break;
				case 6:		ABCTri();		break;
				case 7:		Swap1();		break;
				case 8:		Swap2();		break;
				case 9:		AllDivN();		break;
				case 10:	NPrime();		break;
				case 11:	ReverseN();		break;
				case 12:	IntvDivN();		break;
				case 13:	IntvBisect();	break;
				case 14:	NPalindrom();	break;
				case 15:	Asc3();			break;
				case 16:	Asc5();			break;
				case 17:	CMM_DM_C();		break;
				case 18:	FPrimes();		break;
				case 19:	Rep2Cif();		break;
				case 20:	Fraction();		break;
				case 21:	NGuess();		break;
				case 0:
					ok = false;
					Console.WriteLine("Iesire din program");
					break;
				default:	Console.WriteLine("Numarul Problemei este invalid");	break;
			}
		}
	}

	private static void NGuess() {
		bool found = false;
		int start = 0, end = 1024, mid = 512;
		while(!found) {
			string[] src = GenericInput($"Este numarul mai mare sau egal cu {mid}(y/n): ");

			if(src[0] == "y") {
				src = GenericInput($"Este numarul egal cu {mid}(y/n): ");
				if(src[0] == "y") found = true;
				else if(src[0] == "n") {
					start = mid; mid = (start + end) / 2;
				}
			}
			else if(src[0] == "n") {
				end = mid; mid = (start + end) / 2;
			}
		}
		Console.WriteLine($"Numarul este {mid}");
	}

	private static void Fraction(int n = 0, int m = 0, bool main = true) {
		if(main == true) {
			int[] src = IntInput("Dati n / m: ");
			if(src == null) throw new Exception("Null Input");
			n = src[0]; m = src[1];
		}

		int[] fpm = FPrimes(m, false);
		bool np = (IntInArray(2, fpm) && IntInArray(5, fpm));

		double div = (float)n / (float)m;
		if(np == false) { 
				
		} else if(np == true && fpm.Length == 2) {
			Console.WriteLine($"{n}/{m} = {div}");
		} else {

		}
	}

	private static bool Rep2Cif(int n = 0, bool main = true) {
		if(main == true) {
			int[] src = IntInput("Dati n: ");
			if(src == null) throw new Exception("Null Input");
			n = src[0];
		}

		int k = 0;
		int[] cif = new int[10];
		while(n != 0) {
			k++;
			cif[n % 10]++;
			n /= 10;
		}

		int s = 0;
		for(int i = 0; i < 10; i++) {
			if(cif[i] > 0) s++;
		}

		bool ok = true;
		if(s > 2) ok = false;

		if(main == true) {
			if(ok) Console.WriteLine($"Numarul este valid, fiind compus din {k} cifre cu {s} valori");
			else Console.WriteLine($"Numarul este nu valid, fiind compus din {k} cifre cu {s} valori");
		}

		return ok;
	}

	private static int[] FPrimes(int n = 0, bool main = true) {
		if(main == true) {
			int[] src = IntInput("Dati n: ");
			if(src == null) throw new Exception("Null Input");
			n = src[0];
		}

		int fLast = 0;
		List<int> fs = new();
		for(int i = 2; i <= n; i++) {
			if(NPrime(i, false)) {
				while(n % i == 0) {
					if(i != fLast) { fLast = i;	fs.Add(i);	}
					n /= i;
				}
			}		
		}

		int[] toR = new int[fs.Count];
		int k = 0;
		foreach(int i in fs) {
			toR[k] = i;
			k++;
		}

		if(main == true) {
			Console.Write("Factorii primi sunt: ");
			foreach(int i in fs) {
				Console.Write($"{i} ");
			}
			Console.Write("\n");
		}
		return toR;
	}

	private static int[] CMM_DM_C(int a = 0, int b = 0, bool main = true) {
		if(main == true) {
			int[] src = IntInput("Dati a si b: ");
			if(src == null) throw new Exception("Null Input");
			a = src[0]; b = src[1];
		}

		int initA = a, initB = b, c;
		while(b != 0) {
			c = a % b;
			a = b;
			b = c;
		}

		int CMMDC = a;
		int CMMMC = (initA * initB) / CMMDC;
		if(main == true) Console.WriteLine($"CMMDC: {CMMDC}, CMMMC: {CMMMC}");

		int[] toR = { CMMDC, CMMMC };
		return toR;
	}

	private static void Asc5(int a = 0, int b = 0, int c = 0, int d = 0, int e = 0, bool main = true) {
		if(main == true) {
			int[] src = IntInput("Dati 5 numere: ");
			if(src == null) throw new Exception("Null Input");
			a = src[0]; b = src[1]; c = src[2]; d = src[3]; e = src[4];
		}

		bool ok;
		do {
			ok = true;
			if(a > b) { (a, b) = (b, a); ok = false; }
			if(b > c) { (b, c) = (c, b); ok = false; }
			if(c > d) { (c, d) = (d, c); ok = false; }
			if(d > e) { (d, e) = (e, d); ok = false; }

		} while(ok == false);

		if(main == true)	Console.WriteLine($"{a} {b} {c} {d} {e}");
	}

	private static void Asc3(int a = 0, int b = 0, int c = 0, bool main = true) {
		if(main == true) {
			int[] src = IntInput("Dati 3 numere: ");
			if(src == null) throw new Exception("Null Input");
			a = src[0]; b = src[1]; c = src[2];
		}

		int max = Math.Max(a, Math.Max(b, c));
		int min = Math.Min(a, Math.Min(b, c));
		Console.WriteLine($"{min}, {a + b + c - max - min}, {max}");
	}

	private static bool NPalindrom(int n = 0, bool main = true) {
		if(main == true) {
			int[] src = IntInput("Dati n: ");
			if(src == null) throw new Exception("Null Input");
			n = src[0];
		}

		bool ok = (Math.Abs(n) == ReverseN(n, false));
		if(main == true) {
			if(ok) Console.WriteLine($"{n} este palidrom");
			else Console.WriteLine($"{n} nu este palindrom");
		}

		return ok;
	}

	private static void IntvBisect(int an = 0, int a = 0, int b = 0, bool main = true) {
		if(main == true) {
			int[] src = IntInput("Dati anul si capetele a si b ale intervalului: ");
			if(src == null) throw new Exception("Null Input");
			an = src[0]; a = src[1]; b = src[2];
		}

		for(int i = a; i <= b; i++) {
			if(i % an == 0) {
				if(main == true) Console.Write($"{i}, ");
			}
		}
	}

	private static int IntvDivN(int n = 0, int a = 0, int b = 0, bool main = true) {
		if(main == true) {
			int[] src = IntInput("Dati n si capetele a si b ale intervalului: ");
			if(src == null) throw new Exception("Null Input");
			n = src[0]; a = src[1]; b = src[2];
		}

		int c = 0;
		for(int i = a; i <= b; i++) {
			if(i % n == 0) c++;
		}

		if(main == true) {
			Console.WriteLine($"{n} divide {c} numere din intervalul {a}, {b}");
		}

		return c;
	}

	private static int ReverseN(int n = 0, bool main = true) {
		if(main == true) {
			int[] src = IntInput("Dati n: ");
			if(src == null) throw new Exception("Null Input");
			n = src[0];
		}

		n = Math.Abs(n);
		int rev = 0;
		while(n > 0) {
			rev = rev * 10 + n % 10;
			n /= 10;
		}

		if(main == true) {
			Console.WriteLine($"Cifrele in ordine inversa sunt: {rev}");
		}

		return rev;
	}

	private static bool NPrime(int n = 0, bool main = true) {
		if(main == true) {
			int[] src = IntInput("Dati n: ");
			if(src == null) throw new Exception("Null Input");
			n = src[0];
		}

		bool ok = true;
		if(n < 2) ok = false;
		else if(n > 2) {
			int stop = (int)Math.Sqrt(n);
			for(int i = 3; i <= stop; i += 2)
				if(n % i == 0) {ok = false; break; }
		}

		if(main == true) {
			if(ok == true) Console.WriteLine($"{n} e prim");
			else Console.WriteLine($"{n} nu e prim");
		}

		return ok;
	}

	private static void AllDivN(int n = 0, bool main = true) {
		if(main == true) {
			int[] src = IntInput("Dati n: ");
			if(src == null) throw new Exception("Null Input");
			n = src[0];
		}
		Console.Write($"1, ");
		int stop = n / 2;
		for(int i = 2; i <= stop; i += 1) {
			if(n % i == 0) Console.Write($"{i}, ");
		}
		Console.Write($"{n}\n");
	}

	private static void Swap2(int a = 0, int b = 0, bool main = true) {
		if(main == true) {
			int[] src = IntInput("Dati a si b: ");
			if(src == null) throw new Exception("Null Input");
			a = src[0]; b = src[1];
		}

		a += b;
		b = a - b;
		a -= b;

		if(main == true) {
			Console.WriteLine($"Numerele a si b: {a}, {b}");
		}
	}

	private static void Swap1(int a = 0, int b = 0, bool main = true) {
		if(main == true) {
			int[] src = IntInput("Dati a si b: ");
			if(src == null) throw new Exception("Null Input");
			a = src[0]; b = src[1];
		}

		(a, b) = (b, a);

		if(main == true) {
			Console.WriteLine($"Numerele a si b: {a}, {b}");
		}
	}

	private static bool ABCTri(int a = 0, int b = 0, int c = 0, bool main = true) {
		if(main == true) {
			int[] src = IntInput("Dati a, b si c: ");
			if(src == null) throw new Exception("Null Input");
			a = src[0]; b = src[1]; c = src[2];
		}

		bool ok = false;
		if(a > b && a > c && a < b + c) ok = true;
		else if(b > a && b > c && b < a + c) ok = true;
		else if(c > b && c > a && c < b + a) ok = true;

		if(main == true) {
			if(ok) Console.WriteLine($"{a}, {b}, {c} pot fi laturile unui triunghi");
			else Console.WriteLine($"{a}, {b}, {c} nu pot fi laturile unui triunghi");
		}

		return ok;
	}

	private static int KcifN(int n = 0, int k = 0, bool main = true) {
		if(main == true) {
			int[] src = IntInput("Dati n si k: ");
			if(src == null) throw new Exception("Null Input");
			n = src[0]; k = src[1];
		}

		int cif = -1, initK = k, initN = n;
		while(k > 0 && n != 0) {
			cif = n % 10;
			n /= 10; 
			k--;
		}

		if(n == 0 & k > 0) cif = -1;
		if(main == true) {
			if(n == 0 & k > 0) Console.WriteLine($"Numarul {initN} nu are {initK} cifre");
			else Console.WriteLine($"Cifra {initK} de la coada a numarului {initN} este {cif}");
		}

		return cif;
	}

	private static bool Bisect(int an = 0, bool main = true) {
		if(main == true) {
			int[] src = IntInput("Dati anul: ");
			if(src == null) throw new Exception("Null Input");
			an = src[0];
		}

		bool div = NdivK(n: an, k: 4, main:false);
		if(main == true) {
			if(div) Console.WriteLine($"Anul {an} este bisect");
			else Console.WriteLine($"Anul {an} nu este bisect");
		}

		return div;
	}

	private static bool NdivK(int n = 0, int k = 0, bool main = true) {
		if(main == true) {
			int[] src = IntInput("Dati n si k: ");
			if(src == null) throw new Exception("Null Input");
			n = src[0]; k = src[1];
		}

		bool div = false;
		if(n % k == 0) div = true;
		if(main == true) {
			if(div) Console.WriteLine($"{k} divide pe {n}");
			else Console.WriteLine($"{k} nu divide pe {n}");
		}

		return div;
	}

	private static float[,] Ec2(int a = 0, int b = 0, int c = 0, bool main = true) {
		if(main == true) {
			int[] src = IntInput("Ecuatia de gradul II: ax^2 + bx + c = 0\nIntroduceti a, b si c: ");
			if(src == null) throw new Exception("Null Input");
			a = src[0]; b = src[1]; c = src[2];
		}

		float[,] x = new float[2, 2];
		int d = (b * b) - (4 * a * c);
		//Console.WriteLine($"DEBUG: delta = {d}");
		if(d >= 0) {
			x[0, 0] = (-b + (float)Math.Sqrt(d)) / 2 * a;
			x[1, 0] = (-b - (float)Math.Sqrt(d)) / 2 * a;
		} else {
			x[0, 0] = (-b) / 2 * a;
			x[1, 0] = (-b) / 2 * a;
			x[0, 1] = (float)Math.Sqrt(-d) / 2 * a;
			x[1, 1] = -(float)Math.Sqrt(-d) / 2 * a;
		}

		if(main == true) {
			if(d >= 0) {
				Console.WriteLine($"x1 = {x[0, 0]}, x2 = {x[1, 0]}");
			} else {
				Console.Write("x1 = ");
				if(x[0, 0] != 0) {
					Console.Write($"{x[0, 0]} ");
					if(x[0, 1] == 1) Console.Write("+i, ");
					else if(x[0, 1] == -1) Console.Write("-i, ");
					else {
						if(x[0, 1] > 0) Console.Write($"+{x[0, 1]}i, ");
						else Console.Write($"{x[0, 1]}i, ");
					}
				} else {
					if(x[0, 1] == 1) Console.Write("i, ");
					else if(x[0, 1] == -1) Console.Write("-i, ");
					else Console.Write($"{x[0, 1]}i, ");
				}

				Console.Write("x2 = ");
				if(x[1, 0] != 0) {
					Console.Write($"{x[1, 0]} ");
					if(x[1, 1] == 1) Console.Write("+i, ");
					else if(x[1, 1] == -1) Console.Write("-i, ");
					else {
						if(x[1, 1] > 0) Console.Write($"+{x[1, 1]}i, ");
						else Console.Write($"{x[1, 1]}i, ");
					}
				} else {
					if(x[1, 1] == 1) Console.Write("i, ");
					else if(x[1, 1] == -1) Console.Write("-i, ");
					else Console.Write($"{x[1, 1]}i, ");
				}
				Console.Write('\n');
			}
		}

		return x;
	}

	private static float Ec1(int a = 0, int b = 0, bool main = true) {
		if(main == true) {
			int[] src = IntInput("Ecuatia de gradul I: ax + b = 0\nIntroduceti a si b: ");
			if(src == null) throw new Exception("Null Input");
			a = src[0]; b = src[1];
		}

		float x = -b / a;
		if(main == true) {
			Console.WriteLine($"x = {x}");
		}

		return x;
	}

	/// <summary>
	/// Generic function for reading one or more integers from the Console
	/// </summary>
	/// <param name="txt">The text to present to the user, usually specifing the number of integers to type in</param>
	/// <returns>Array of \<unknown\> integers</returns>
	private static int[] IntInput(string txt) {
		try {
			Console.Write(txt);
			char[] sep = { ' ', '.', ',', ';', '/' };
			string[] src = Console.ReadLine().Split(sep, StringSplitOptions.RemoveEmptyEntries);
			if(src.Length == 0) {
				return null;
				//throw new Exception("Empty Input");
			} 
			int[] output = new int[src.Length];
			int i = 0;
			foreach(string s in src) {
				//Console.WriteLine($"DEBUG: input {i} = {s}");
				checked {output[i] = int.Parse(s);}
				i++;
			}
			return output;
		} catch(OverflowException) {
			Console.WriteLine($"ERROR: input was too high / big or too low");
			return null;
		} catch(IndexOutOfRangeException) {
			Console.WriteLine($"ERROR: input 'opt' was empty");
			return null;
		} catch(Exception e) {
			Console.WriteLine($"ERROR: {e}");
			return null;
		}
	}

	private static string[] GenericInput(string txt) {
		Console.Write(txt);
		char[] sep = { ' ', '.', ',', ';', '/' };
		string[] src = Console.ReadLine().Split(sep, StringSplitOptions.RemoveEmptyEntries);
		if(src.Length == 0) throw new Exception("Empty Input");
		return src;
	}

	private static bool IntInArray(int n, int[] array) {
		foreach(int i in array) {
			if(i == n) return true;
		}
		return false;
	}
}
/*
1.  Rezolvați ecuația de gradul 1 cu o necunoscuta: ax + b = 0, unde a si b sunt date de intrare. 
2.  Rezolvați ecuația de gradul 2 cu o necunoscuta: ax^2 + bx + c = 0, unde a, b si c sunt date de intrare. Tratați toate cazurile posibile. 
3.  Determinați daca n se divide cu k, unde n si k sunt date de intrare. 
4.  Determinați daca un an y este an bisect. 
5.  Extrageți si afișați a k-a cifra de la sfârșitul unui număr. Cifrele se numără de la dreapta la stânga. 
6.  Determinați daca trei numere pozitive a, b si c pot fi lungimile laturilor unui triunghi. 
7.  (Swap) Se dau doua variabile numerice a si b ale cărora valori sunt date de intrare. Se cere sa se inverseze valorile lor. 
8.  (Swap restricționat) Se dau doua variabile numerice a si b ale cărora valori sunt date de intrare. Se cere sa se inverseze valorile lor fără a folosi alte variabile suplimentare.  
9.  Afișați toți divizorii numărului n. 
10.  Test de primalitate: determinați daca un număr n este prim.
11.  Afișați in ordine inversa cifrele unui număr n. 
12.  Determinați cate numere întregi divizibile cu n se afla in intervalul \[a, b\]. 
13.  Determinați cați ani bisecți sunt intre anii y1 si y2.
14.  Determinați daca un număr n este palindrom. (un număr este palindrom daca citit invers obținem un număr egal cu el, de ex. 121 sau 12321. 
15.  Se dau 3 numere. Sa se afișeze in ordine crescătoarea. 
16.  Se dau 5 numere. Sa se afișeze in ordine crescătoare. (nu folosiți tablouri)
17.  Determinați cel mai mare divizor comun si cel mai mic multiplu comun a doua numere. Folosiți algoritmul lui Euclid. 
18.  Afișați descompunerea in factori primi ai unui număr n.  De ex. pentru n = 1176 afișați 2^3 x 3^1 x 7^2. 
19.  Determinați daca un număr e format doar cu 2 cifre care se pot repeta. De ex. 23222 sau 9009000 sunt astfel de numere, pe când 593 si 4022 nu sunt. 
20.  Afisati fractia m/n in format zecimal, cu perioada intre paranteze (daca e cazul). Exemplu: 13/30 = 0.4(3). (https://github.com/HoreaOros/ROSE2020/blob/master/2611/Program.cs)  
	- O fractie este neperiodica daca numitorul este de forma 2^m*5^n unde m si n sunt mai mari sau egale decat 0  
	- O fractie este periodica simpla daca numitorul nu se divide cu 2 si nici cu 5.   
	- O fractie este periodica mixta daca se divide cu 2 si/sau 5 SI se mai divide si cu alte numere prime diferite de 2 si 5. 
21.  Ghiciti un numar intre 1 si 1024 prin intrebari de forma "numarul este mai mare sau egal decat x?".

*/