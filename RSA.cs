using System;

public class RSA
{
	private long p;// p простое число
	private long q;// q простое число

	private long e;// e открытая экспонента

	private long d;// d секретная экспонента

	private long n;// n
	private long Fi;// Ф(n)

	//private string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
	private string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzАБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя0123456789.,?!*/+-=_()%;:#";//Набор сиволов

	private int[] numericConversion;
	private long[] encrypt;
	private string[] alphabetEncrypt;
	//long p = 36563, long q = 57731;
	//string text = PUBLIC;

	private static bool IsPrimeNumber(long n)//Проверка на простоту
	{
		bool result = true;

		if (n > 1)
		{
			for (var i = 2u; i < n; i++)
			{
				if (n % i == 0)
				{
					result = false;
					break;
				}
			}
		}
		else
		{
			result = false;
		}
		return result;
	}

	private static long GCD(long A,long B)//Поиск НОД | Алгоритм Евклида
	{
		while(B!=0) 
			(A, B) = (B, A % B);
		return A;
	}

	private static void extendedGCD(long a, long b, out long x, out long y, out long d)
	{
		long q, r, x1, x2, y1, y2;


		if (b == 0)
		{
			d = a;
			x = 1;
			y = 0;
			return;
		}
		x2 = 1; y2 = 0;
		x1 = 0; y1 = 1;

		while (b > 0)
		{
			q = a / b; r = a - q * b;
			x = x2 - q * x1; y = y2 - q * y1;
			a = b; b = r;
			x2 = x1; x1 = x; y2 = y1; y1 = y;
		}
		d = a; x = x2; y = y2;
	}//Расширенный алгоритм Евклида

	public RSA(long e, long p, long q)//Конструктор
	{
		try
		{
			this.p = (IsPrimeNumber(p)) ? p : throw new Exception("Error: p должно быть простым");
			this.q = (IsPrimeNumber(q)) ? q : throw new Exception("Error: q должно быть простым");

			this.n = p * q;// n модуль

			this.Fi = (p - 1) * (q - 1);// Фи(n)

			this.e = ((1 < e && e < Fi) && (GCD(e, Fi)==1)) ? e : throw new Exception("Error: Должно выполняться 2 условия:\n 1 - (1 < e < Ф(n))\n 2 - e и Ф(n) - взаимно простые числа!");

			extendedGCD(e, Fi, out long x, out long y, out long d);
			this.d = x + Fi;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	public void Cipher()
	{
		//(e,n) --> Открытый ключ
		//(d,n) --> Закрытый ключ
		Console.WriteLine($"Сообщение хочет получить абонент B от абонента A");
		Console.WriteLine($"Процесс инициирует абонент B!\n");

		Console.WriteLine($"У абонента B:");
		Console.WriteLine($"Введем p = {p};");
		Console.WriteLine($"Введем q = {q};");
		Console.WriteLine($"Вычислим n из выражения по формуле n = p * q = {n};");
		Console.WriteLine($"Вычислим Ф(n) по формуле Ф(n) = (p-1)*(q-1). Ф(n) = {Fi};");
		Console.WriteLine($"Выбираем ключ e, соответствующий условию алгоритма. e = {e};");
		Console.WriteLine($"Сгенерируем ключ d, соответствующий e^-1 (mod Ф(n)). d = {d};\n");

		Console.WriteLine($"У абонента A:");
		Console.WriteLine($"Формируем алфавит;");

		Console.Write($"Преобразовываем текст в числовой эквивалент: ");
		foreach (var item in numericConversion) Console.Write(item+" ");

		Console.Write($"\nВыполняем цифрование по формуле m^e(mod n): ");
		foreach (var item in encrypt) Console.Write(item + " ");

		Console.WriteLine($"\nПриведение к символьному виду: ");
	}

	public void getOpenKey(out long e,out long n)//Получить открытый ключ
	{
		e = this.e;
		n = this.n;
	}

	private long reSquaring(long m, long e, long n)//c=m^e(mod n)
	{
		long C = 0, E = e;

		int i;
		for (i=1; E!= 1; i++)
			E = E / 2;

		long b = m % n;
		for (int j = 1; j < i; j++)
		{
			b = (long)Math.Pow(b, 2) % n;
		}
		C = (m * b)%n;
		return C;
	}

	private string symbolicRepresentationToString(long C)//Приведение к символьному типу
	{
		C.ToString().Length;
		return "";
	}

	public string[] Encrypt(string m, long e, long n)//Зашифровать
	{
		numericConversion = new int[m.Length];
		for (int i = 0; i < m.Length; i++)
		{
			for (int j = 0; j < alphabet.Length; j++)
			{
				if (m[i]==alphabet[j])
				{
					numericConversion[i] = j; break;
				}
			}
		}

		encrypt = new long[numericConversion.Length];//Шифротекст
		for (int i = 0; i < numericConversion.Length; i++)
		{
			encrypt[i] = reSquaring(numericConversion[i], e, n);
		}


		alphabetEncrypt = new string[encrypt.Length];//Шифротекст в символьном представлении
		for (int i = 0; i < encrypt.Length; i++)
		{
			alphabetEncrypt[i] = symbolicRepresentationToString(encrypt[i]);
		}
		return alphabetEncrypt;
	}
}
