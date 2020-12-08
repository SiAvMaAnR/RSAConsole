using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSA_Console
{
	class Program
	{
		static void Main(string[] args)
		{
			RSA algorithmRSA = new RSA(17,36563,57731);
			//RSA algorithmRSA = new RSA(3, 3, 11);

			//RSA algorithmRSA = new RSA(17,7,11);//Генерируем ключи


			algorithmRSA.getOpenKey(out long e, out long n);//Возврат открытых ключей

			//algorithmRSA.Encrypt("PUBLIC", e, n);//Зашифровываем сообщение
			algorithmRSA.Encrypt("PUBLIC", e, n);//Зашифровываем сообщение



			algorithmRSA.Cipher();


		}
	}
}
