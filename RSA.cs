using System;

public class RSA
{
	private uint p;// p простое число
	private uint q;// q простое число

	private uint e;// e открытая экспонента
	private uint d;// d секретная экспонента

	private uint n;// n
	private uint Fi;// Ф(n)

	//uint p = 36563, uint q = 57731

	private static bool IsPrimeNumber(uint n)
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
	}//Проверка на простоту

	public static bool IsCoprime(uint a, uint b)//Проверка на взаимную простоту
	{
		return a == b ? a == 1 : a > b? IsCoprime(a - b, b) : IsCoprime(b - a, a);
	}

	public RSA(uint e, uint p = 7, uint q = 11)//Конструктор
	{
		try
		{
			this.p = (IsPrimeNumber(p))? p: throw new Exception("Error: p должно быть простым");
			this.q = (IsPrimeNumber(q))? q: throw new Exception("Error: q должно быть простым");

			this.n = p * q;// n модуль

			this.Fi = (p - 1) * (q - 1);// Фи(n)

			this.e = ((1 < e && e < Fi) && (IsCoprime(e, Fi))) ? e : throw new Exception("Error: Должно выполняться 2 условия:\n 1 - (1 < e < Ф(n))\n 2 - e и Ф(n) - взаимно простые числа!");// e экспонента

		}
		catch(Exception ex)
		{
			Console.WriteLine(ex.Message);
		}
	}

	private void keyGeneration()
	{
		Console.WriteLine($"{n},{Fi},{e}");
	}

}
