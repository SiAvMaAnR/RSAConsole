using System;

public class RSA
{
	private long p;// p простое число
	private long q;// q простое число

	private long e;// e открытая экспонента
	private long d;// d секретная экспонента

	private long n;// n
	private long Fi;// Ф(n)

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


	//private static bool IsCoprime(long a, long b)//Проверка на взаимную простоту
	//{
	//	return a == b ? a == 1 : a > b? IsCoprime(a - b, b) : IsCoprime(b - a, a);
	//}

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
		Console.WriteLine($"Введем p = {p}");
		Console.WriteLine($"Введем q = {q}");
		Console.WriteLine($"Вычислим n из выражения по формуле n = p * q = {n}");
		Console.WriteLine($"Вычислим Ф(n) по формуле Ф(n) = (p-1)*(q-1). Ф(n) = {Fi}");
		Console.WriteLine($"Выбираем ключ e, соответствующий условию алгоритма. e = {e}");
		Console.WriteLine($"Сгенерируем ключ d, соответствующий e^-1 (mod Ф(n)). d = {d}");

		Console.WriteLine($"У абонента A:");
		Console.WriteLine($"У абонента A:");
		Console.WriteLine($"У абонента A:");
	}

	private void keyGeneration()
	{

	}
}
